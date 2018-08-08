using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpAppFat.ClassModels
{
    class ModelAluno
    {
        private int id;
        private string nome;
        private string ra;
        private string curso;
        private string tel;
        private string cel;
        private string email;
        private string author_id;
        private string cpf;
        private string created_date;
        private string published_date;

        public ModelAluno()
        {
            this.Id = 0;
            this.Nome = "";
            this.Ra = "";
            this.Curso = "";
            this.Tel = "";
            this.Cel = "";
            this.Email = "";
            this.Author_id = "";
            this.Cpf = "";
            this.Created_date = "";
            this.Published_date = "";
        }

        public ModelAluno(int id, string nome, string ra, string curso, string tel, string cel, string email, string author_id, string cpf, string created_date, string published_date)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ra = ra;
            this.Curso = curso;
            this.Tel = tel;
            this.Cel = cel;
            this.Email = email;
            this.Author_id = author_id;
            this.Cpf = cpf;
            this.Created_date = created_date;
            this.Published_date = published_date;

        }


        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Ra { get => ra; set => ra = value; }
        public string Curso { get => curso; set => curso = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Cel { get => cel; set => cel = value; }
        public string Email { get => email; set => email = value; }
        public string Author_id { get => author_id; set => author_id = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Created_date { get => created_date; set => created_date = value; }
        public string Published_date { get => published_date; set => published_date = value; }
    }


}
