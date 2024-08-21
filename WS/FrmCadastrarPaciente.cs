using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WS
{
    public partial class FrmCadastrarPaciente : Form
    {
        public FrmCadastrarPaciente()
        {
            InitializeComponent();
        }
        //Inicializa o Form, onde o DGV vai receber o método de Listagem e depois eu escondo a coluna Id, do DGV
        private void FrmCadastrarPaciente_Load(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente();
            dgvPaciente.DataSource = paciente.listarPacientes();
            dgvPaciente.Columns["Id"].Visible = false;
        }

        //Aqui é feito o cadastro, onde faz uma verificação se os campos estão vazios ou não, Depois é adicionado ao banco de Dados.
        //Caso em algum momento dê um erro, ele irá cair no Catch
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text) == true || string.IsNullOrEmpty(txtQuarto.Text) == true)
                {
                    MessageBox.Show("Preencha os Campos", "Campos Vazios!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Paciente paciente = new Paciente();
                    paciente.Inserir(txtNome.Text, Convert.ToInt32(txtQuarto.Text));
                    dgvPaciente.DataSource = paciente.listarPacientes();
                    dgvPaciente.Columns["Id"].Visible = false;
                    MessageBox.Show("Paciente Inserido com Sucesso!", "Inserção Concluída!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message,"Erro!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //A função deste botão é voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
