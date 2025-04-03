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

namespace InterfacesDoSistemaDesktop.Intercafes_Folha
{
    public partial class Form_VisualizarFolhasPagamento : Form
    {
        Crud_AgendamentoFerias _crud_AgendamentoFerias = new Crud_AgendamentoFerias();
        Crud_FolhaDePagamento _folha = new Crud_FolhaDePagamento();

        private string IdEmpresa { get; set; }
        public Form_VisualizarFolhasPagamento()
        {
            InitializeComponent();
        }

        private void Form_VisualizarFolhasPagamento_Load(object sender, EventArgs e)
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

            dgvFolhasPagamentoGeradas.DataSource = null;

            dgvFolhasPagamentoGeradas.Columns.Clear();

            DataTable tabelaFolhasGeradas = _folha.ConsultarFolhasGeradas(IdEmpresa);
            dgvFolhasPagamentoGeradas.DataSource = tabelaFolhasGeradas;

            dgvFolhasPagamentoGeradas.Columns[0].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[1].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[2].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[3].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[4].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[5].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[6].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[7].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[8].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[9].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[10].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[11].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[12].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[13].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[14].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[15].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[16].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[17].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[18].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[19].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[20].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[21].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[22].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[23].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[24].Width = 120;
            dgvFolhasPagamentoGeradas.Columns[25].Width = 120;
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
