using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WS
{
    public partial class FrmCadastrarRemedio : Form
    {
        //Aqui é criado uma Lista privada, para ser usada durante todo o Forms
        private ObservableCollection<Remedios> receitas;
        public FrmCadastrarRemedio()
        {
            InitializeComponent();
        }
        //Aqui é onde o Forms é carregado e preenchendo o ComboBox e escondendo algumas colunas do DGV
        private void FrmCadastrarRemedio_Load(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente();
            var pacientes = paciente.listarPacientes();

            receitas = new ObservableCollection<Remedios>();

            dgvRemedio.DataSource = receitas.ToList();
            dgvRemedio.Columns["Id"].Visible = false;
            dgvRemedio.Columns["Quarto"].Visible = false;
            dgvRemedio.Columns["Id_Paciente"].Visible = false;
            dgvRemedio.Columns["HoraCalculo"].Visible = false;
            dgvRemedio.Columns["Nome_Paciente"].HeaderText = "Nome Paciente";

            // Aqui é preenchido o ComboBox
            foreach (var item in pacientes)
            {
                cbxPaciente.Items.Add(item.Nome);
                cbxPaciente.DisplayMember = item.Nome;
                cbxPaciente.ValueMember = item.Id.ToString();
            }
        }
        //Aqui é o Botão de Cadastro, onde faz a verificação se está vazio ou não, Caso dê algum erro irá cair no Catch
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNomeRemedio.Text) == true || string.IsNullOrEmpty(cbxPaciente.Text) == true)
                {
                    MessageBox.Show("Preencha os Campos", "Campos Vazios!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Nessa Parte, faço com que o objeto seja preenchido e adicionado na lista citada anteriormente
                    var Remedio = new Remedios
                    {
                        Nome_Paciente = cbxPaciente.Text,    
                        Remedio = txtNomeRemedio.Text,
                        Hora = dtpHora.Value.ToString("HH:mm"),
                        Id_Paciente = Convert.ToInt32(cbxPaciente.ValueMember)
                    };
                    receitas.Add(Remedio);
                    //Aqui o DGV é preenchido
                    dgvRemedio.DataSource = receitas.ToList();

                    MessageBox.Show("Adicionado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomeRemedio.Text = "";
                    dtpHora.Text = "00:00";
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Botão para finalizar tudo, novamente, caso dê algum erro irá cair no Catch
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Aqui é inserido no BD e limpa a Lista
                Remedios remedios = new Remedios();
                foreach (var item in receitas)
                {
                    remedios.Inserir(item.Remedio, item.Hora, item.Id_Paciente);
                }
                MessageBox.Show("Finalizado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                receitas.Clear();
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Botão de Voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
