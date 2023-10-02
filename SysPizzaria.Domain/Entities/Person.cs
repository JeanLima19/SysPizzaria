﻿using SysPizzaria.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPizzaria.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "O Id deve ser maior que zero!");
            Id = id;
            Validation(name, document, phone);
        }

        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(document), "O Documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "O número deve ser informado!");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}