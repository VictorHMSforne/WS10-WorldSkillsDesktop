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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrarPaciente_Click(object sender, EventArgs e)
        {
            FrmCadastrarPaciente paciente = new FrmCadastrarPaciente();
            paciente.ShowDialog();
        }

        private void btnRemedio_Click(object sender, EventArgs e)
        {
            FrmCadastrarRemedio remedio = new FrmCadastrarRemedio();
            remedio.ShowDialog();
        }

        private void btnDias_Click(object sender, EventArgs e)
        {
            FrmDias dias = new FrmDias();
            dias.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        
    }
}
