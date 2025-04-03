using BaseDeDados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfacesDoSistemaDesktop.Interfaces_Ferias
{
    public partial class Form_VisualizarFerias : Form
    {
        Crud_AgendamentoFerias _crud_AgendamentoFerias = new Crud_AgendamentoFerias();

        private string IdEmpresa { get; set; }

        public Form_VisualizarFerias()
        {
            InitializeComponent();
        }

        private void Form_VisualizarFerias_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> popularListaEmpresas = _crud_AgendamentoFerias.PopularCaixaListarEmpresas();
            cmbListarFuncionarios.Items.Clear();
            foreach (var empresas in popularListaEmpresas)
            {
                cmbListarFuncionarios.Items.Add(empresas);
            }
            cmbListarFuncionarios.ValueMember = "Key";
            cmbListarFuncionarios.DisplayMember = "Value";
            cmbListarFuncionarios.SelectedIndex = 0;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            
            string refEmpresa = cmbListarFuncionarios.SelectedItem.ToString();
            refEmpresa = refEmpresa.Replace("[", "").Replace("]", "").Replace(",", " ");
            string[] idEmpresa = refEmpresa.Split(' ');
            IdEmpresa = idEmpresa[0];

            dgvFeriasAgendadas.DataSource = null; 

            dgvFeriasAgendadas.Columns.Clear();
            
            DataTable tabelaFeriasAgendadas = _crud_AgendamentoFerias.ListarFeriasAgendadas(IdEmpresa);
            dgvFeriasAgendadas.DataSource = tabelaFeriasAgendadas;

            dgvFeriasAgendadas.Columns[0].Width = 100;
            dgvFeriasAgendadas.Columns[1].Width = 100; 
            dgvFeriasAgendadas.Columns[2].Width = 70; 
            dgvFeriasAgendadas.Columns[3].Width = 120; 
            dgvFeriasAgendadas.Columns[4].Width = 50; 
            dgvFeriasAgendadas.Columns[5].Width = 120; 
            dgvFeriasAgendadas.Columns[6].Width = 50; 
            dgvFeriasAgendadas.Columns[7].Width = 120;
            dgvFeriasAgendadas.Columns[8].Width = 50;
            dgvFeriasAgendadas.Columns[9].Width = 100;
            dgvFeriasAgendadas.Columns[10].Width = 100;
            dgvFeriasAgendadas.Columns[11].Width = 70;
            dgvFeriasAgendadas.Columns[12].Width = 120;
            dgvFeriasAgendadas.Columns[13].Width = 120;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult fechar = MessageBox.Show("Deseja fechar a interface?",
                                                   "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (fechar == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
