using System;

namespace DevIO.Business.Core.Models
{
    public abstract class Entity //abstratra pois ele será uma classe mãe ele só fornecerá
    {
        protected Entity() //Protect pois apenas a classe acessará o método
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; } //Utilizando um Guid para gerar ID's aleatórias sempre
    }
}
