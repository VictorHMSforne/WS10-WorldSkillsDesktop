using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS
{
    //Criação das Propriedades da classe e criando a conexão do Banco
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quarto { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\User\OneDrive\Área de Trabalho\te\WS\DbConsultorio.mdf"";Integrated Security=True");

        // Método de Listagem dos pacientes
        public List<Paciente> listarPacientes()
        {
            List<Paciente> li = new List<Paciente>();
            string sql = "SELECT * FROM Pacientes";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                Paciente paciente = new Paciente();
                paciente.Id = (int)dr["Id"];
                paciente.Nome = dr["Nome"].ToString();
                paciente.Quarto = (int)dr["Quarto"];
                li.Add(paciente);
            }
            conn.Close();
            return li;  
        }
        //Método de Inserção no BD, usando o Try e Catch

        public void Inserir(string nome, int quarto)
        {
            try
            {
                string sql = "INSERT INTO Pacientes(Nome,Quarto) VALUES('" + nome + "','" + quarto + "')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            
        }

    }
}
