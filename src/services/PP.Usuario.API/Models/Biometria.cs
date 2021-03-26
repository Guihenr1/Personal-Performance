using System;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Models
{
    public class Biometria : Entity, IAggregateRoot
    {
        public int Peso { get; set; }
        public double Altura { get; set; }
        public int BracoDireito { get; set; }
        public int BracoEsquerdo { get; set; }
        public int Torax { get; set; }
        public int Cintura { get; set; }
        public int Quadril { get; set; }
        public int CoxaDireita { get; set; }
        public int CoxaEsquerda { get; set; }
        public int GemeoDireito { get; set; }
        public int GemeoEsquerdo { get; set; }
        public int AnteBracoDireito { get; set; }
        public int AnteBracoEsquerdo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataDesativacao { get; set; }
        public bool Desativado { get; set; }

        protected Biometria() { }

        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public Biometria(Guid id, int peso, double altura, int bracoDireito, int bracoEsquerdo, int torax, int cintura, int quadril, int coxaDireita, int coxaEsquerda, int gemeoDireito, int gemeoEsquerdo, int anteBracoDireito, int anteBracoEsquerdo)
        {
            Id = id;
            Peso = peso;
            Altura = altura;
            BracoDireito = bracoDireito;
            BracoEsquerdo = bracoEsquerdo;
            Torax = torax;
            Cintura = cintura;
            Quadril = quadril;
            CoxaDireita = coxaDireita;
            CoxaEsquerda = coxaEsquerda;
            GemeoDireito = gemeoDireito;
            GemeoEsquerdo = gemeoEsquerdo;
            AnteBracoDireito = anteBracoDireito;
            AnteBracoEsquerdo = anteBracoEsquerdo;
            DataCadastro = DateTime.Now;
            Desativado = false;
        }

        public void AtribuirAluno(Aluno aluno) {
            Aluno = aluno;
        }

        public void DesativarBiometria() {
            Desativado = true;
            DataDesativacao = DateTime.Now;
        }
    }
}