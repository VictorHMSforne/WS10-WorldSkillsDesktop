using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS
{
    //Criação das Propriedades da classe e criando a conexão do Banco
    public class Remedios
    {
        public int Id { get; set; }
        public string Nome_Paciente { get; set; }
        public int Quarto { get; set; }
        public string Remedio { get; set; }
        public string Hora { get; set; }
        public int Id_Paciente { get; set; }
        public TimeSpan HoraCalculo { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Desktop\ws\WS\WS\DbConsultorio.mdf;Integrated Security=True");

        // Método de Listagem dos Remédios
        public List<Remedios> listarRemedios()
        {
            List<Remedios> li = new List<Remedios>();
            string sql = "SELECT r.Id, p.Nome, p.Quarto, r.Remedio, r.Hora " +
                "FROM Remedios r " +
                "INNER JOIN Pacientes p ON r.Id_Paciente = p.ID";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Remedios remedios = new Remedios();
                remedios.Id = (int)dr["Id"];
                remedios.Nome_Paciente = dr["Nome"].ToString();
                remedios.Quarto = (int)dr["Quarto"];
                remedios.Remedio = dr["Remedio"].ToString();
                remedios.Hora = dr["Hora"].ToString();
                
                li.Add(remedios);
            }
            conn.Close();
            return li;
        }
        //Método de Inserção no BD, usando o Try e Catch
        public void Inserir(string remedio, string hora, int id_paciente)
        {
            try
            {
                string sql = "INSERT INTO Remedios(Remedio,Hora,Id_Paciente) VALUES('" + remedio + "','" + hora + "','" + id_paciente + "')";
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
