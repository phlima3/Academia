using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;

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
                    );
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

                }
            }
        }
    }
}