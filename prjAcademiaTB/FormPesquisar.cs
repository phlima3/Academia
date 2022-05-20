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
    public partial class FormPesquisar : Form
    {
        public FormPesquisar()
        {
            InitializeComponent();
        }

        internal Aluno Registro { get; set; }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rbInicio.Checked) Pesquisar("I");
            else if (rbMeio.Checked) Pesquisar("M");
            else Pesquisar("F");
        }

        private void Pesquisar(string p)
        {
            AlunoDB tabela = new AlunoDB();
            tabela.pesquisar(dgvLista, p,txtNome.Text);
            dgvLista.AutoResizeColumns();
        }

        private void dgvLista_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            AlunoDB tabela = new AlunoDB();
            Registro = tabela.SelecionarRegistro(
                dgvLista.CurrentRow.Cells["ID"].Value
                );
        }   
    }
}
