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
    public partial class FrmDias : Form
    {
        public FrmDias()
        {
            InitializeComponent();
        }
        //O Form é carregado usando um método da classe Remédios, e ordenando pela hora mais atual o DGV, Caso dê erro irá pro Catch
        private void FrmDias_Load(object sender, EventArgs e)
        {
            try
            {
                Remedios remedios = new Remedios();

                remedios.HoraCalculo = Convert.ToDateTime(remedios.Hora).TimeOfDay;
                TimeSpan horaAtual = DateTime.Now.TimeOfDay;

                dgvDias.DataSource = remedios.listarRemedios().OrderBy(r => Math.Abs((r.HoraCalculo - horaAtual).TotalMinutes)).ToList();
                dgvDias.Columns["Id"].Visible = false;
                dgvDias.Columns["Id_Paciente"].Visible = false;
                dgvDias.Columns["HoraCalculo"].Visible = false;
                dgvDias.Columns["Nome_Paciente"].HeaderText = "Nome Paciente";
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
