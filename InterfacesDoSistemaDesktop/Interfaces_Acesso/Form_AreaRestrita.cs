﻿using InterfacesDoSistemaDesktop.Interfaces_Acesso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using InterfacesDoSistemaDesktop.Interfaces_Formularios;
using InterfacesDoSistemaDesktop.Interfaces_Views_Delete;
using InterfacesDoSistemaDesktop.Interfaces_Ferias;
using InterfacesDoSistemaDesktop.Intercafes_Folha;

namespace InterfacesDoSistemaDesktop
{
    public partial class Form_AreaRestrita : Form
    {
        public Form_AreaRestrita(string nomeFuncionario)
        {
            InitializeComponent();
            lblUsuario.Text = nomeFuncionario;
        }

        private void btnCadastros_Click(object sender, EventArgs e)
        {
            btnBotaoUm.Visible = true;
            btnBotaoUm.Text = "Cadastrar Nova Empresa";
            btnBotaoDois.Visible = true;
            btnBotaoDois.Text = "Cadastrar Novo Convênio Médico";
            btnBotaoTres.Visible = true;
            btnBotaoTres.Text = "Cadastrar Novo Convênio Odontológico";
            btnBotaoQuatro.Visible = true;
            btnBotaoQuatro.Text = "Cadastrar Novo Funcionário";
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            btnBotaoUm.Visible = true;
            btnBotaoUm.Text = "Consultar Minhas Empresas";
            btnBotaoDois.Visible = true;
            btnBotaoDois.Text = "Consultar Meus Convênios Médicos";
            btnBotaoTres.Visible = true;
            btnBotaoTres.Text = "Consultar Meus Convênios Odontológicos";
            btnBotaoQuatro.Visible = true;
            btnBotaoQuatro.Text = "Consultar Meus Funcionários";
        }

        private void btnFerias_Click(object sender, EventArgs e)
        {
            btnBotaoUm.Visible = true;
            btnBotaoUm.Text = "Consultar Férias Agendadas";
            btnBotaoDois.Visible = true;
            btnBotaoDois.Text = "Agendar / Alterar Férias";
            btnBotaoTres.Visible = false;
            btnBotaoQuatro.Visible = false;
        }

        private void btnFolhaDePagamento_Click(object sender, EventArgs e)
        {
            btnBotaoUm.Visible = true;
            btnBotaoUm.Text = "Consultar Folhas Geradas";
            btnBotaoDois.Visible = true;
            btnBotaoDois.Text = "Gerar Folha de Pagamento";
            btnBotaoTres.Visible = false;
            btnBotaoQuatro.Visible = false;
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            Form_Ajuda _form_Ajuda = new Form_Ajuda();
            _form_Ajuda.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult sair = MessageBox.Show("Deseja realmente fechar o sistema?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sair == DialogResult.Yes)
            {
                Close();
            }
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult sair = MessageBox.Show("Deseja realmente fechar o sistema?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sair == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnBotaoUm_Click(object sender, EventArgs e)
        {
            switch (btnBotaoUm.Text) 
            {
                case "Cadastrar Nova Empresa":
                    Form_CadEmpresas _CadEmpresas = new Form_CadEmpresas();
                    _CadEmpresas.ShowDialog();
                    break;

                case "Consultar Minhas Empresas":
                    Form_ViewDeleteEmpresas _viewDeleteEmpresas = new Form_ViewDeleteEmpresas();
                    _viewDeleteEmpresas.ShowDialog();
                    break;

                case "Consultar Férias Agendadas":
                    Form_VisualizarFerias _VisualizarFerias = new Form_VisualizarFerias();
                    _VisualizarFerias.ShowDialog();
                    break;

                case "Consultar Folhas Geradas":
                    Form_VisualizarFolhasPagamento _VisualizarFolhasPagamento = new Form_VisualizarFolhasPagamento();
                    _VisualizarFolhasPagamento.ShowDialog();
                    break;

                default: break;
            }
        }

        private void btnBotaoDois_Click(object sender, EventArgs e)
        {
            switch (btnBotaoDois.Text)
            {
                case "Cadastrar Novo Convênio Médico":
                    Form_CadConvMedico _cadConvMedico = new Form_CadConvMedico();
                    _cadConvMedico.ShowDialog();
                    break;

                case "Consultar Meus Convênios Médicos":
                    Form_ViewDeleteConvenioMedico _viewDeleteConvenioMedico = new Form_ViewDeleteConvenioMedico();
                    _viewDeleteConvenioMedico.ShowDialog();
                    break;

                case "Agendar / Alterar Férias":
                    Form_ConsultarTabelaFerias _consultarTabelaFerias = new Form_ConsultarTabelaFerias();
                    _consultarTabelaFerias.ShowDialog();
                    break;

                case "Gerar Folha de Pagamento":
                    Form_SelFuncionarioGerarFolha _SelFuncionarioGerarFolha = new Form_SelFuncionarioGerarFolha();
                    _SelFuncionarioGerarFolha.ShowDialog();
                    break;

                default: break;
            }
        }

        private void btnBotaoTres_Click(object sender, EventArgs e)
        {
            switch (btnBotaoTres.Text)
            {
                case "Cadastrar Novo Convênio Odontológico":
                    Form_CadConvOdontologico _CadConvOdontologico = new Form_CadConvOdontologico();
                    _CadConvOdontologico.ShowDialog();
                    break;

                case "Consultar Meus Convênios Odontológicos":
                    Form_ViewDeleteConvenioOdontologico _viewDeleteConvenioOdontologico = new Form_ViewDeleteConvenioOdontologico();
                    _viewDeleteConvenioOdontologico.ShowDialog();
                    break;

                default: break;
            }
        }

        private void btnBotaoQuatro_Click(object sender, EventArgs e)
        {
            switch (btnBotaoQuatro.Text)
            {
                case "Cadastrar Novo Funcionário":
                    Form_CadFuncionarios _cadFuncionarios = new Form_CadFuncionarios();
                    _cadFuncionarios.ShowDialog();
                    break;

                case "Consultar Meus Funcionários":
                    Form_ViewDeleteFuncionarios _viewDeleteFuncionarios = new Form_ViewDeleteFuncionarios();
                    _viewDeleteFuncionarios.ShowDialog();
                    break;

                default: break;
            }
        }

        private void cadastrarNovaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CadEmpresas _CadEmpresas = new Form_CadEmpresas();
            _CadEmpresas.ShowDialog();
        }

        private void cadastrarNovoConvênioMédicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CadConvMedico _cadConvMedico = new Form_CadConvMedico();
            _cadConvMedico.ShowDialog();
        }

        private void cadastrarNovoConvênioOdontológicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CadConvOdontologico _CadConvOdontologico = new Form_CadConvOdontologico();
            _CadConvOdontologico.ShowDialog();
        }

        private void cadastrarNovoFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CadFuncionarios _cadFuncionarios = new Form_CadFuncionarios();
            _cadFuncionarios.ShowDialog();
        }

        private void consultarMinhasEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ViewDeleteEmpresas _viewDeleteEmpresas = new Form_ViewDeleteEmpresas();
            _viewDeleteEmpresas.ShowDialog();
        }

        private void consultarMeusConvêniosMédicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ViewDeleteConvenioMedico _viewDeleteConvenioMedico = new Form_ViewDeleteConvenioMedico();
            _viewDeleteConvenioMedico.ShowDialog();
        }

        private void consultarMeusConvêniosOdontológicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ViewDeleteConvenioOdontologico _viewDeleteConvenioOdontologico = new Form_ViewDeleteConvenioOdontologico();
            _viewDeleteConvenioOdontologico.ShowDialog();
        }

        private void consultarMeusFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ViewDeleteFuncionarios _viewDeleteFuncionarios = new Form_ViewDeleteFuncionarios();
            _viewDeleteFuncionarios.ShowDialog();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Ajuda _form_Ajuda = new Form_Ajuda();
            _form_Ajuda.ShowDialog();
        }

       
    }
}
