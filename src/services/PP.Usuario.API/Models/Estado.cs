﻿using System;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Models
{
    public class Estado : Entity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}