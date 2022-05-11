using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAcademiaTB
{
     class Academia
    {

        public BindingList<Aluno> Alunos;

        public Academia(BindingList<Aluno> Alunos)
        {
            this.Alunos = Alunos;
        }
        public void Matricular (Aluno novo)
        {
            if (novo != null){
                Alunos.Add(novo);
            }
        }

        internal void Editar(Aluno aluno)
        {
            Aluno p = Alunos.FirstOrDefault(i=>i.Id == aluno.Id);
            if (p != null)
            {
                p.Nome = aluno.Nome;
                p.Idade = aluno.Idade;
                p.Peso = aluno.Peso;
                p.Altura = aluno.Altura;

            }
            
            
        }

        internal void Excluir(Aluno atual)
        {
            Aluno p = Alunos.FirstOrDefault(i => i.Id == atual.Id);
            Alunos.Remove(p);
        }
    }
}
