using FluentValidation;
using DevIO.Business.Core.Models;
using DevIO.Business.Core.Notificacoes;
using FluentValidation.Results;

namespace DevIO.Business.Core.Services
{
    public abstract class BaseService //Abstrato pois só será referênciado, não poderá ser incluido novas funções
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV: AbstractValidator<TE> where TE: Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
