﻿using System;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Models
{
    public class Ficha : Entity, IAggregateRoot
    {
        public string Objetivo { get; set; }
        public DateTime DataCadastro { get; set; }

        protected Ficha() { }

        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public Guid AnamneseRespostaId { get; set; }
        public AnamneseResposta AnamneseResposta { get; set; }

        public Ficha(Guid id, string objetivo)
        {
            Id = id;
            Objetivo = objetivo;
        }

        public void AtribuirAluno(Aluno aluno) {
            Aluno = aluno;
        }

        public void AtribuirAnamneseResposta(AnamneseResposta anamneseResposta) {
            AnamneseResposta = anamneseResposta;
        }
    }
}