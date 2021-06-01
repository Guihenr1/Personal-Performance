using System;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.Biometria
{
    public class BiometriaCommand : Command {
        public Guid Id { get; protected set; }
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
        public int AntebracoDireito { get; set; }
        public int AntebracoEsquerdo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}