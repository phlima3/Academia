using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;
using System.Windows.Forms;

namespace prjAcademiaTB
{
    class AlunoDB
    {
        public void Inserir(Aluno reg)
        {
            ServidorSQL academia = new ServidorSQL();
            using (var banco = new SQLiteCommand(academia.Open()))
            {
                string sql = string.Format(
                    "INSERT INTO ALUNO(ID,NOME,IDADE,PESO,ALTURA)" +
                   "VALUES ({0},'{1}',{2},{3},{4}",
                   reg.Id, reg.Nome, reg.Idade, reg.Peso,
                   reg.Altura.ToString().Replace(',', '.') + ")");
                banco.CommandText = sql;
                banco.ExecuteNonQuery();
            }
        }
        public void Editar(Aluno reg)
        {
            ServidorSQL academia = new ServidorSQL();
            using (var banco = new SQLiteCommand(academia.Open()))
            {
                string sql = String.Format("UPDATE ALUNO SET NOME = '{0}'" +
                    ", IDADE = {1}, PESO = {2}, ALTURA = {3} " +
                    "WHERE ID = {4}", reg.Nome, reg.Idade, reg.Peso,
                    reg.Altura.ToString().Replace(',', '.'), reg.Id);
                banco.CommandText = sql;
                banco.ExecuteNonQuery();
            }
        }



        public void Excluir(Aluno reg)
        {
            ServidorSQL academia = new ServidorSQL();
            using (var banco = new SQLiteCommand(academia.Open()))
            {
                string sql = String.Format(
                    "DELETE FROM ALUNO WHERE ID = {0}",
                    reg.Id
                    ); ;
                banco.CommandText = sql;
                banco.ExecuteNonQuery();
            }
        }
        public void Select(BindingList<Aluno> Alunos)
        {
            ServidorSQL academia = new ServidorSQL();
            using (var banco = new SQLiteCommand(academia.Open()))
            {
                banco.CommandText = "SELECT * FROM ALUNO ORDER BY ID";
                SQLiteDataReader dr = banco.ExecuteReader();
                while (dr.Read())
                {
                    Aluno item = new Aluno(
                        dr.GetInt16(0),
                        dr.GetString(1),
                        dr.GetInt16(2),
                        dr.GetDouble(3),
                        dr.GetDouble(4)
                        );
                    Alunos.Add(item);
                }
            }
        }
        public long ProximoCodigo()
        {
            ServidorSQL academia = new ServidorSQL();
            using (var banco = new SQLiteCommand(academia.Open()))
            {
                banco.CommandText = "SELECT MAX(ID) AS COD FROM ALUNO";
                SQLiteDataReader dr = banco.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        return dr.GetInt16(0) + 1;
                    }
                    catch (Exception)
                    {

                        return 1;
                    }

                }
                return 1;
            }
        }
        public void pesquisar(DataGridView dgvLista, string p, string nome)
        {
            ServidorSQL academia = new ServidorSQL();
            string sql = "";

            using (var banco = new SQLiteCommand(academia.Open()))
            {
                if (p.Equals("F"))
                    sql = "SELECT * FROM ALUNO WHERE " +
                        " NOME LIKE '%" + nome + "'";

                else if (p.Equals("M"))
                    sql = "SELECT * FROM ALUNO WHERE " +
                        " NOME LIKE '%" + nome + "%'";
                else
                    sql = "SELECT * FROM ALUNO WHERE " +
                        " NOME LIKE '" + nome + "%'";
                banco.CommandText = sql;
                SQLiteDataReader dr = banco.ExecuteReader();
                BindingList<Aluno> Lista = new BindingList<Aluno>();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Aluno reg = new Aluno(
                        dr.GetInt16(0),
                        dr.GetString(1),
                        dr.GetInt16(2),
                        dr.GetDouble(3),
                        dr.GetDouble(4)
                        );
                        Lista.Add(reg);
                    }
                    dgvLista.DataSource = Lista;
                }
            }
        }
        public Aluno SelecionarRegistro(object p)
        {
            ServidorSQL academia = new ServidorSQL();
            using (var banco = new SQLiteCommand(academia.Open()))
            {
                banco.CommandText = "SELECT * FROM ALUNO WHERE ID ="
                    + p.ToString();
                SQLiteDataReader dr = banco.ExecuteReader();
                while (dr.Read())
                {
                    Aluno reg = new Aluno(
                         dr.GetInt16(0),
                        dr.GetString(1),
                        dr.GetInt16(2),
                        dr.GetDouble(3),
                        dr.GetDouble(4)
                        );
                    return reg;
                    
                }
            }
            return null;
        }
    }
}