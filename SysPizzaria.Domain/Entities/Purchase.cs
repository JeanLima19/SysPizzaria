using SysPizzaria.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPizzaria.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }

        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(id < 0, "O Id deve ser informado!");
            Id = id;
            Validation(productId, personId, date);
        }

        private void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(personId < 0, "O Id da Pessoa deve ser informado!");
            DomainValidationException.When(productId < 0, "O Id do Produto deve ser informado!");
            DomainValidationException.When(!date.HasValue, "A Data da compra deve ser informada!");

            PersonId = personId;
            ProductId = productId;
            Date = date.Value;

        }
    }
}
