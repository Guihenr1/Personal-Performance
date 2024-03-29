﻿using System;
using PP.Usuario.API.Application.Commands.Validations.Professor;

namespace PP.Usuario.API.Application.Commands.Professor
{
    public class AtualizarProfessorCommand : ProfessorCommand {
        public AtualizarProfessorCommand(Guid id, string nome, int cref)
        {
            Id = id;
            Nome = nome;
            CREF = cref;
        }

        public AtualizarProfessorCommand()
        {
            
        }

        public override bool EhValido() {
            ValidationResult = new AtualizarProfessorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}