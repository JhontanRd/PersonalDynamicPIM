using BaseDeDados;
using FuncionariosEmpresas;
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

namespace InterfacesDoSistemaDesktop.Intercafes_Folha
{
    public partial class Form_SelFuncionarioGerarFolha : Form
    {
        Crud_FolhaDePagamento _crud_FolhaDePagamento = new Crud_FolhaDePagamento();
        Funcionarios _funcionarios = new Funcionarios();

        Thread _t1;

        public string IdEmpresa { get; set; }
        public string IdFuncionario { get; set; }
        private string IdFolha { get; set; }
        private string NomeFuncionario { get; set; }
        private string NomeFuncionarioFolha { get; set; }
        public Form_SelFuncionarioGerarFolha()
        {
            InitializeComponent();
        }

        private void Form_SelFuncionarioGerarFolha_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> popularListaEmpresas = _crud_FolhaDePagamento.PopularCaixaListarEmpresas();
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
            string[] id = refEmpresa.Split(' ');
            IdEmpresa = id[0];

            // tabela da esquerda
            dgvFolhaNaoGerada.DataSource = null; 

            dgvFolhaNaoGerada.Columns.Clear();
            DataTable funcionarioParaGerarFolha = _crud_FolhaDePagamento.ListarFuncionariosParaGerarFolha(IdEmpresa);
            dgvFolhaNaoGerada.DataSource = funcionarioParaGerarFolha;

            dgvFolhaNaoGerada.Columns[0].Width = 70;
            dgvFolhaNaoGerada.Columns[1].Width = 100;
            dgvFolhaNaoGerada.Columns[2].Width = 150;
            dgvFolhaNaoGerada.Columns[3].Width = 60;
            dgvFolhaNaoGerada.Columns[4].Width = 100;
            dgvFolhaNaoGerada.Columns[5].Width = 80;

            // tabela da direita

            dgvFolhaGerada.DataSource = null;

            dgvFolhaGerada.Columns.Clear();
            DataTable folhasGeradas = _crud_FolhaDePagamento.AcompanhamentoFolhaPagamentoTempoReal(IdEmpresa);
            dgvFolhaGerada.DataSource = folhasGeradas;

            dgvFolhaGerada.Columns[0].Width = 100;
            dgvFolhaGerada.Columns[1].Width = 120;
            dgvFolhaGerada.Columns[2].Width = 120;
            dgvFolhaGerada.Columns[3].Width = 120;
            dgvFolhaGerada.Columns[4].Width = 120;
            dgvFolhaGerada.Columns[5].Width = 120;
            dgvFolhaGerada.Columns[5].Width = 100;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult fechar = MessageBox.Show("Deseja fechar?", "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (fechar == DialogResult.Yes)
            {
                Close();
            }
        }

        private void AtualizarTabela()
        {
            dgvFolhaGerada.DataSource = null;

            dgvFolhaGerada.Columns.Clear();
            DataTable folhasGeradas = _crud_FolhaDePagamento.AcompanhamentoFolhaPagamentoTempoReal(IdEmpresa);
            dgvFolhaGerada.DataSource = folhasGeradas;

            dgvFolhaGerada.Columns[0].Width = 100;
            dgvFolhaGerada.Columns[1].Width = 120;
            dgvFolhaGerada.Columns[2].Width = 120;
            dgvFolhaGerada.Columns[3].Width = 120;
            dgvFolhaGerada.Columns[4].Width = 120;
            dgvFolhaGerada.Columns[5].Width = 120;
            dgvFolhaGerada.Columns[5].Width = 100;
        }

        private void dgvFolhaNaoGerada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView tabelaEmpresas = (DataGridView)sender;
                DataGridViewRow linhaSelecionada = tabelaEmpresas.Rows[e.RowIndex];

                string idFuncionario = linhaSelecionada.Cells["Código"].Value.ToString();
                string nomeFuncionario = linhaSelecionada.Cells["Nome"].Value.ToString();
                IdFuncionario = idFuncionario;
                NomeFuncionario = nomeFuncionario;
            }
        }

        private void btnGerarFolha_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdFuncionario))
            {
                DialogResult agendar = MessageBox.Show($"Deseja prosseguir com a operação e gerar a folha de pagamento do funcionário {NomeFuncionario}, código {IdFuncionario}? ", "ATENÇÂO!", 
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                Form_AdiantamentoQuinzenal _AdiantamentoQuinzenal = new Form_AdiantamentoQuinzenal(IdFuncionario);
                _AdiantamentoQuinzenal.ShowDialog();
                
            }
        }
        private void dgvFolhaGerada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView tabelaFolhas = (DataGridView)sender;
                DataGridViewRow linhaSelecionada = tabelaFolhas.Rows[e.RowIndex];

                string idFolha = linhaSelecionada.Cells["Código folha"].Value.ToString();
                string funcionarioFolha = linhaSelecionada.Cells["Funcionário"].Value.ToString();
                IdFolha = idFolha;
                NomeFuncionarioFolha = funcionarioFolha;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdFolha))
            {
                DialogResult deletar = MessageBox.Show($"Deseja realmente excluir o registro da folha de pagamento do funcionário {NomeFuncionarioFolha}, código da folha {IdFolha}?\n\nApós um registro ser excluido os dados serão perdidos permanentemente, " +
                                                   "não podendo ser restaurados e uma nova folha tera de ser gerada.",
                                                   "ATENÇÂO!",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);
                if (deletar == DialogResult.Yes)
                {
                    bool retornoExclusao = _crud_FolhaDePagamento.ExcluirFolha(IdFolha);
                    if (retornoExclusao)
                    {
                        MessageBox.Show("O Registro foi excluido.", "Operação concluida.");
                        AtualizarTabela();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível excluir o registro.", "Falha na operação ");
                    }
                }
            }
            IdFolha = "";
        }

        private void btnAtualizarTabelaFolhasGeradas_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdFolha))
            {
                AtualizarTabela();
            }
            
        }
    }
}
