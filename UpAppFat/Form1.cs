using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpAppFat.ClassDao;
using UpAppFat.ClassModels;

namespace UpAppFat
{
    public partial class Form1 : Form
    {
        private List<string> log = new List<string>();
        string txtlog; bool on = false;

        public Form1()
        {
            InitializeComponent();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            Upbd();
        }


        // teste atualização bancos
        private void Upbd(){

            List<ModelAluno> alunos = new List<ModelAluno>();
            ClassAlunoDao dao = new ClassAlunoDao();

                alunos = dao.GetIds(); // ok

                int i = 0;
                for (i = 0; i < alunos.Count; i++)
                {
                    ModelAluno aluno = new ModelAluno();
                    aluno = dao.ConsultaAluno(alunos[i].Cpf);

                    aluno.Nome = alunos[i].Nome;
                    aluno.Ra = alunos[i].Ra;
                    aluno.Curso = alunos[i].Curso;
                    aluno.Tel = alunos[i].Tel;
                    aluno.Cel = alunos[i].Cel;
                    aluno.Author_id = alunos[i].Author_id;
                    aluno.Cpf = alunos[i].Cpf;
                    aluno.Created_date = alunos[i].Created_date;
                    aluno.Published_date = alunos[i].Published_date;
                     MessageBox.Show("get" + i);

                if (aluno.Id > 0)
                    {
                    MessageBox.Show("consulta" + i);
                    dao.UpdateAlunos(aluno); // update dados existentes
                    MessageBox.Show("update" + i);
                    log.Add(aluno.Nome + " = atualizado");
                        Thread.Sleep(500);
                }
                    else
                    {
                        dao.InserirAluno(aluno); // cadastro novos dados
                        log.Add(aluno.Nome + " = Cadastrado");
                    }

                    txtlog += "\n" + log[i];
                }
                on = true;
            
            //button1.Enabled = on;
            lblNome.Text = txtlog;

        }
    }
}
