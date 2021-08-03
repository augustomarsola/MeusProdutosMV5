using FluentValidation;
using DevIO.Business.Core.Models;

namespace DevIO.Business.Core.Services
{
    public abstract class BaseService //Abstrato pois só será referênciado, não poderá ser incluido novas funções
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV: AbstractValidator<TE> where TE: Entity
        {
            var validator = validacao.Validate(entidade);

            return validator.IsValid;
        }
    }
}
