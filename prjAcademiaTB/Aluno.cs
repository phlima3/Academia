using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAcademiaTB
{
    class Aluno
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public Aluno(long Id, string Nome,
            int Idade, double Peso, double Altura)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Idade = Idade;
            this.Peso = Peso;
            this.Altura = Altura;
        }

        public double IMC
        {
            get
            {
                return Math.Round(
                    Peso / Math.Pow(Altura, 2), 2);
            }
        }

        public string Classificar
        {
            get
            {
                double indice = IMC;
                if (indice <= 18.5) return "Baixo Peso";
                else if (indice >= 18.5 && indice <= 24.9)
                    return "Peso Normal";
                else if (indice >= 25 && indice <= 29.9)
                    return "SobrePeso";
                else if (indice >= 30 && indice <= 34.9)
                    return "Obesidade I";
                else if (indice >= 35 && indice <= 39.9)
                    return "Obesidade II";
                else if (indice >= 40 && indice <= 49.9)
                    return "Obesidade III";
                else return "Obesidade IV";
            }
        }
    }
}
