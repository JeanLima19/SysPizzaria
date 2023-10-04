using SysPizzaria.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPizzaria.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string CodERP { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, string description, string codERP, decimal price)
        {
            Validation(name, description,codERP, price);
        }

        public Product(int id, string name, string description, string codERP, decimal price)
        {
            DomainValidationException.When(id < 0, "O Id do produto não pode ser menor que Zero!");
            Id = id;
            Validation(name, description, codERP, price);
        }

        private void Validation(string name, string description, string codERP, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(description), "A descrição do Produto deve ser informada!");
            DomainValidationException.When(string.IsNullOrEmpty(codERP), "O código ERP deve ser informado!");
            DomainValidationException.When(price < 0, "O preço deve ser informado!");

            Name = name;
            Description = description;
            CodERP = codERP;
            Price = price;
        }
    }
}
