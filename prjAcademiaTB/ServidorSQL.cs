using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
namespace prjAcademiaTB
{
    class ServidorSQL
    {
        public SQLiteConnection Conexao { get; set; }
        public SQLiteConnection Open()
        {
            string banco = Environment.CurrentDirectory +
                "\\academia.sqlite";
            string sql = String.Format(
                "Data Source = {0}; version=3;", banco);
            Conexao = new SQLiteConnection(sql);
            Conexao.Open();
            return Conexao;
        }
        public bool CriarBanco()
        {
            try
            {
                string banco = Environment.CurrentDirectory +
               "\\academia.sqlite";
                if (!File.Exists(banco))
                {
                    SQLiteConnection.CreateFile(banco);
                    criarTabelas();
                    return true;
                }
                else return false;
            }
            catch (Exception Erro)
            {
                System.Windows.Forms.
                    MessageBox.Show("Erro: " +
                    Erro.Message);
                return false;
            }
        }
        private void criarTabelas()
        {
            try
            {
                string sql = "CREATE TABLE IF NOT EXISTS ALUNO (" + 
                    "ID INT PRIMARY KEY, NOME VARCHAR(45), IDADE INT,"+
                    "PESO DOUBLE, ALTURA DOUBLE)";
                using (var banco = new SQLiteCommand(Open()))
                {
                    banco.CommandText = sql;
                    banco.ExecuteNonQuery();
                }
            }
            catch (Exception Erro)
            {

                System.Windows.Forms.
                   MessageBox.Show("Erro: " +
                   Erro.Message);
               
            }
        }
    }
}