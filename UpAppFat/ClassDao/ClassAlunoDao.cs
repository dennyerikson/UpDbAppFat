using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpAppFat.ClassModels;
using System.Data.SQLite;
using UpAppFat.ClassConexao;

namespace UpAppFat.ClassDao
{
    class ClassAlunoDao
    {
        string strCon = @"Data Source=C:\django\django-appfat\django-AppFat\appfat\dbup.sqlite3; Version = 3;";
        // consulta de dados da tabela alunos
        public ModelAluno ConsultaAluno(string cpf)
        {
            ModelAluno aluno = new ModelAluno();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(strCon))
                using (SQLiteCommand com = new SQLiteCommand("SELECT * FROM blog_aluno WHERE cpf='"+cpf+"'", con))
                {
                    //com.Parameters.AddWithValue("@cpf", cpf);
                    con.Open();
                    SQLiteDataReader consulta = com.ExecuteReader();

                    if (consulta.HasRows)
                    {
                        consulta.Read();

                        aluno.Id = Convert.ToInt16(consulta["id"]);
                        aluno.Nome = consulta["nome"].ToString();
                        aluno.Ra = consulta["ra"].ToString();
                        aluno.Curso = consulta["curso"].ToString();
                        aluno.Tel = consulta["tel"].ToString();
                        aluno.Cel = consulta["cel"].ToString();
                        aluno.Email = consulta["email"].ToString();
                        aluno.Author_id = consulta["author_id"].ToString();
                        aluno.Cpf = consulta["cpf"].ToString();
                        aluno.Created_date = consulta["created_date"].ToString();
                        aluno.Published_date = consulta["published_date"].ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERRO CONSULTA " + ex);
            }

            return aluno;
        }

       
        // criar lista com ids e dados para atualizar 07/08/2018 banco novo
        public List<ModelAluno> GetIds()
        {
            List<ModelAluno> ids = new List<ModelAluno>();

            SQLiteCommand com = new SQLiteCommand();
            com.Connection = ClassCon.ConOpen();
            com.CommandText = "SELECT * FROM blog_aluno";
            SQLiteDataReader consulta = com.ExecuteReader();

            try
            {
                while (consulta.Read())
                {
                    //ids.Add(Convert.ToInt16(consulta["id"]), consulta["nome"].ToString());
                    ids.Add(new ModelAluno(Convert.ToInt16(consulta["id"]),
                    consulta["nome"].ToString(),
                    consulta["ra"].ToString(),
                    consulta["curso"].ToString(),
                   consulta["tel"].ToString(),
                    consulta["cel"].ToString(),
                    consulta["email"].ToString(),
                    consulta["author_id"].ToString(),
                   consulta["cpf"].ToString(),
                    consulta["created_date"].ToString(),
                   consulta["published_date"].ToString()
                   ));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERRO LISTA" + ex);
                com.Connection.Clone();
                consulta.Close();
            }

            return ids;
        }

        // iserir novos dados no banco Update
        public void InserirAluno(ModelAluno aluno)
        {
            SQLiteCommand com = new SQLiteCommand();
            com.Connection = ClassConUp.ConUp();
            com.CommandText = "INSERT INTO blog_aluno (nome, ra, curso, tel, cel, email, author_id, cpf, created_date, published_date) " +
                "VALUES (@nome, @ra, @curso, @tel, @cel, @email, @author_id, @cpf, @created_date, @published_date)";

            com.Parameters.AddWithValue("@nome", aluno.Nome);
            com.Parameters.AddWithValue("@ra", aluno.Ra);
            com.Parameters.AddWithValue("@curso", aluno.Curso);
            com.Parameters.AddWithValue("@tel", aluno.Tel);
            com.Parameters.AddWithValue("@cel", aluno.Cel);
            com.Parameters.AddWithValue("@email", aluno.Email);
            com.Parameters.AddWithValue("@author_id", aluno.Author_id);
            com.Parameters.AddWithValue("@cpf", aluno.Cpf);
            com.Parameters.AddWithValue("@created_date", aluno.Created_date);
            com.Parameters.AddWithValue("@published_date", aluno.Published_date);

            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error inserir: " + ex);
            }
            finally
            {
                com.Connection.Clone();
            }

        }

        // update dados no banco Update no banco Update
        public void UpdateAlunos(ModelAluno aluno)
        {
            //SQLiteCommand com = new SQLiteCommand();
            //com.Connection = ClassConUp.ConUp();
            //com.CommandText = "UPDATE blog_aluno SET nome='" + aluno.Nome + " ', ra='" + aluno.Ra + " ', curso='" + aluno.Curso + " ', tel='" + aluno.Tel +
            //    "', cel='" + aluno.Cel + " ', email='" + aluno.Email + " ', author_id='" + aluno.Author_id + " ', cpf='" + aluno.Cpf + " ', created_date='" + aluno.Created_date + " ', published_date='" + aluno.Published_date + " ' WHERE cpf= '"+aluno.Cpf+"'";
          

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(strCon))
                using (SQLiteCommand com = new SQLiteCommand("UPDATE blog_aluno SET nome='" + aluno.Nome + " ', ra='" + aluno.Ra + " ', curso='" +          aluno.Curso + " ', tel='" + aluno.Tel + "', cel='" + aluno.Cel + " ', email='" + aluno.Email + " ', author_id='" + aluno.Author_id + " ', cpf='" + aluno.Cpf + " ', created_date='" + aluno.Created_date + " ', published_date='" + aluno.Published_date + " ' WHERE cpf= '" + aluno.Cpf + "'", con))
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
               
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERRO UP" +ex);

            }
           
        }
    }
}
