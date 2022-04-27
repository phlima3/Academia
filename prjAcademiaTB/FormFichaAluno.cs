using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjAcademiaTB
{
    public partial class FormFichaAluno : Form
    {

        internal Aluno Registro { get; set; }

        public FormFichaAluno()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Registro = new Aluno(8, "ALUNO TESTE", 45, 70, 1.56);
            this.Dispose();
        }
    }
}
