﻿using BaseDeDados;
using FolhaDePagamento;
using PlanoOdontologico;
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

namespace InterfacesDoSistemaDesktop
{
    public partial class Form_ConvenioOdontologico : Form
    {
        Folha _folha = new Folha();
        Crud_FolhaDePagamento _crud_FolhaDePagamento = new Crud_FolhaDePagamento();

        List<string> dadosRecebidos = new List<string>();
        List<string> dadosParaEnviar = new List<string>();
        List<string> dadosConvOdonto = new List<string>();

        Thread _t1, _t2;

        public Form_ConvenioOdontologico(List<string> dadosEnviados)
        {
            InitializeComponent();
            dadosRecebidos = dadosEnviados;
            dadosParaEnviar.Add(dadosRecebidos[0]); // Id
            dadosParaEnviar.Add(dadosRecebidos[1]); // Salario
            dadosParaEnviar.Add(dadosRecebidos[2]); // Adicional
            dadosParaEnviar.Add(dadosRecebidos[3]); // Horas Adc. Not
            dadosParaEnviar.Add(dadosRecebidos[4]); // Adc. Not
            dadosParaEnviar.Add(dadosRecebidos[5]); // Periculosidade/Insalubridade
            dadosParaEnviar.Add(dadosRecebidos[6]); // Horas extras
            dadosParaEnviar.Add(dadosRecebidos[7]); // Vale transporte
            dadosParaEnviar.Add(dadosRecebidos[8]); // Vale alimentação/refeição
            dadosParaEnviar.Add(dadosRecebidos[9]); // id Convenio medico
            dadosParaEnviar.Add(dadosRecebidos[10]); // nome convenio medico
            dadosParaEnviar.Add(dadosRecebidos[11]); // valor convenio medico
            txtSalarioBase.Text = dadosRecebidos[1];
            string idConv = _crud_FolhaDePagamento.ColetarIdConvOdonto(dadosRecebidos[0]);
            dadosParaEnviar.Add(idConv + " Id convenio Odonto"); // Id Convenio odonto
            dadosConvOdonto = _crud_FolhaDePagamento.ColetarConvOdonto(idConv);
            txtConvenio.Text = dadosConvOdonto[0].ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtRetorno.Clear();
            txtRetorno.Focus();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (dadosConvOdonto[2] == "Valor")
            {
                txtRetorno.Text = dadosConvOdonto[1].ToString();
            }
            else
            {
                double retorno = _folha.CalcularConvenioOdontologico(Convert.ToDouble(txtSalarioBase.Text), Convert.ToDouble(dadosConvOdonto[1]));
                txtRetorno.Text = retorno.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult cancelar = MessageBox.Show("Deseja cancelar o processo de gerar para folha de pagamento?",
                                                   "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cancelar == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRetorno.Text))
            {
                dadosParaEnviar.Add(txtConvenio.Text.ToString() + " Nome Convênio odontológico");
                dadosParaEnviar.Add(txtRetorno.Text.ToString() + " Valor Convênio odontológico");
            }
            else
            {
                dadosParaEnviar.Add("0 Não Possui Convênio odontológico");
                dadosParaEnviar.Add("0 Não possui desconto de Convênio odontológico");
            }
            this.Close();
            _t1 = new Thread(Dependentes);
            _t1.SetApartmentState(ApartmentState.STA);
            _t1.Start();
        }

        private void Dependentes()
        {
            Application.Run(new Form_Dependentes(dadosParaEnviar));
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            _t2 = new Thread(ValeAlimentacao);
            _t2.SetApartmentState(ApartmentState.STA);
            _t2.Start();
        }

        private void ValeAlimentacao()
        {
            Application.Run(new Form_ConvenioMedico(dadosRecebidos));
        }
    }
}
