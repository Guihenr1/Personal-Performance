using System;
using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class Biometria : Entity
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

        public Aluno Aluno { get; set; }

        public Biometria(int peso, double altura, int bracoDireito, int bracoEsquerdo, int torax, int cintura, int quadril, int coxaDireita, int coxaEsquerda, int gemeoDireito, int gemeoEsquerdo, int anteBracoDireito, int anteBracoEsquerdo)
        {
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
    }
}