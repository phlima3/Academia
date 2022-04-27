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

    }
}
