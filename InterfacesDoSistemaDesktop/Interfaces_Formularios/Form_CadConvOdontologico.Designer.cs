﻿namespace InterfacesDoSistemaDesktop.Interfaces_Formularios
{
    partial class Form_CadConvOdontologico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CadConvOdontologico));
            this.gpbConvenioOdontologico = new System.Windows.Forms.GroupBox();
            this.rdbPercentual = new System.Windows.Forms.RadioButton();
            this.rdbValorFixado = new System.Windows.Forms.RadioButton();
            this.lblModoDesconto = new System.Windows.Forms.Label();
            this.btnCadastrarConvOdonto = new System.Windows.Forms.Button();
            this.txtPorcentagemConvOdonto = new System.Windows.Forms.TextBox();
            this.txtValorConvOdonto = new System.Windows.Forms.TextBox();
            this.mskCnpjConvOdonto = new System.Windows.Forms.MaskedTextBox();
            this.txtNomeConvOdonto = new System.Windows.Forms.TextBox();
            this.lblPercentual = new System.Windows.Forms.Label();
            this.lblvalorFixado = new System.Windows.Forms.Label();
            this.lblCnpjConvOdonto = new System.Windows.Forms.Label();
            this.lblNomeConvOdonto = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.gpbConvenioOdontologico.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbConvenioOdontologico
            // 
            this.gpbConvenioOdontologico.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gpbConvenioOdontologico.Controls.Add(this.btnSair);
            this.gpbConvenioOdontologico.Controls.Add(this.rdbPercentual);
            this.gpbConvenioOdontologico.Controls.Add(this.rdbValorFixado);
            this.gpbConvenioOdontologico.Controls.Add(this.lblModoDesconto);
            this.gpbConvenioOdontologico.Controls.Add(this.btnCadastrarConvOdonto);
            this.gpbConvenioOdontologico.Controls.Add(this.txtPorcentagemConvOdonto);
            this.gpbConvenioOdontologico.Controls.Add(this.txtValorConvOdonto);
            this.gpbConvenioOdontologico.Controls.Add(this.mskCnpjConvOdonto);
            this.gpbConvenioOdontologico.Controls.Add(this.txtNomeConvOdonto);
            this.gpbConvenioOdontologico.Controls.Add(this.lblPercentual);
            this.gpbConvenioOdontologico.Controls.Add(this.lblvalorFixado);
            this.gpbConvenioOdontologico.Controls.Add(this.lblCnpjConvOdonto);
            this.gpbConvenioOdontologico.Controls.Add(this.lblNomeConvOdonto);
            this.gpbConvenioOdontologico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gpbConvenioOdontologico.Location = new System.Drawing.Point(12, 12);
            this.gpbConvenioOdontologico.Name = "gpbConvenioOdontologico";
            this.gpbConvenioOdontologico.Size = new System.Drawing.Size(328, 371);
            this.gpbConvenioOdontologico.TabIndex = 0;
            this.gpbConvenioOdontologico.TabStop = false;
            this.gpbConvenioOdontologico.Text = "Cadastro de convênio odontológico";
            // 
            // rdbPercentual
            // 
            this.rdbPercentual.AutoSize = true;
            this.rdbPercentual.Location = new System.Drawing.Point(88, 168);
            this.rdbPercentual.Name = "rdbPercentual";
            this.rdbPercentual.Size = new System.Drawing.Size(104, 21);
            this.rdbPercentual.TabIndex = 11;
            this.rdbPercentual.Text = "Percentual";
            this.rdbPercentual.UseVisualStyleBackColor = true;
            this.rdbPercentual.CheckedChanged += new System.EventHandler(this.rdbPercentual_CheckedChanged);
            // 
            // rdbValorFixado
            // 
            this.rdbValorFixado.AutoSize = true;
            this.rdbValorFixado.Checked = true;
            this.rdbValorFixado.Location = new System.Drawing.Point(9, 168);
            this.rdbValorFixado.Name = "rdbValorFixado";
            this.rdbValorFixado.Size = new System.Drawing.Size(73, 21);
            this.rdbValorFixado.TabIndex = 10;
            this.rdbValorFixado.TabStop = true;
            this.rdbValorFixado.Text = "Fixado";
            this.rdbValorFixado.UseVisualStyleBackColor = true;
            this.rdbValorFixado.CheckedChanged += new System.EventHandler(this.rdbValorFixado_CheckedChanged);
            // 
            // lblModoDesconto
            // 
            this.lblModoDesconto.AutoSize = true;
            this.lblModoDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblModoDesconto.Location = new System.Drawing.Point(6, 150);
            this.lblModoDesconto.Name = "lblModoDesconto";
            this.lblModoDesconto.Size = new System.Drawing.Size(227, 15);
            this.lblModoDesconto.TabIndex = 9;
            this.lblModoDesconto.Text = "Selecione a forma de desconto aplicada";
            // 
            // btnCadastrarConvOdonto
            // 
            this.btnCadastrarConvOdonto.BackColor = System.Drawing.Color.LightBlue;
            this.btnCadastrarConvOdonto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadastrarConvOdonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnCadastrarConvOdonto.Location = new System.Drawing.Point(6, 327);
            this.btnCadastrarConvOdonto.Name = "btnCadastrarConvOdonto";
            this.btnCadastrarConvOdonto.Size = new System.Drawing.Size(220, 30);
            this.btnCadastrarConvOdonto.TabIndex = 8;
            this.btnCadastrarConvOdonto.Text = "Cadastrar Convênio Odontológico";
            this.btnCadastrarConvOdonto.UseVisualStyleBackColor = false;
            this.btnCadastrarConvOdonto.Click += new System.EventHandler(this.btnCadastrarConvOdonto_Click);
            // 
            // txtPorcentagemConvOdonto
            // 
            this.txtPorcentagemConvOdonto.Enabled = false;
            this.txtPorcentagemConvOdonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtPorcentagemConvOdonto.Location = new System.Drawing.Point(9, 277);
            this.txtPorcentagemConvOdonto.MaxLength = 2;
            this.txtPorcentagemConvOdonto.Name = "txtPorcentagemConvOdonto";
            this.txtPorcentagemConvOdonto.Size = new System.Drawing.Size(100, 20);
            this.txtPorcentagemConvOdonto.TabIndex = 7;
            // 
            // txtValorConvOdonto
            // 
            this.txtValorConvOdonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtValorConvOdonto.Location = new System.Drawing.Point(9, 219);
            this.txtValorConvOdonto.Name = "txtValorConvOdonto";
            this.txtValorConvOdonto.Size = new System.Drawing.Size(150, 20);
            this.txtValorConvOdonto.TabIndex = 6;
            this.txtValorConvOdonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorConvOdonto_KeyPress);
            // 
            // mskCnpjConvOdonto
            // 
            this.mskCnpjConvOdonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.mskCnpjConvOdonto.Location = new System.Drawing.Point(9, 111);
            this.mskCnpjConvOdonto.Mask = "00,000,000/0000-00";
            this.mskCnpjConvOdonto.Name = "mskCnpjConvOdonto";
            this.mskCnpjConvOdonto.Size = new System.Drawing.Size(150, 20);
            this.mskCnpjConvOdonto.TabIndex = 5;
            // 
            // txtNomeConvOdonto
            // 
            this.txtNomeConvOdonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtNomeConvOdonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtNomeConvOdonto.Location = new System.Drawing.Point(9, 53);
            this.txtNomeConvOdonto.MaxLength = 60;
            this.txtNomeConvOdonto.Name = "txtNomeConvOdonto";
            this.txtNomeConvOdonto.Size = new System.Drawing.Size(200, 20);
            this.txtNomeConvOdonto.TabIndex = 4;
            // 
            // lblPercentual
            // 
            this.lblPercentual.AutoSize = true;
            this.lblPercentual.Enabled = false;
            this.lblPercentual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblPercentual.Location = new System.Drawing.Point(6, 259);
            this.lblPercentual.Name = "lblPercentual";
            this.lblPercentual.Size = new System.Drawing.Size(94, 15);
            this.lblPercentual.TabIndex = 3;
            this.lblPercentual.Text = "Desconto em %";
            // 
            // lblvalorFixado
            // 
            this.lblvalorFixado.AutoSize = true;
            this.lblvalorFixado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblvalorFixado.Location = new System.Drawing.Point(6, 201);
            this.lblvalorFixado.Name = "lblvalorFixado";
            this.lblvalorFixado.Size = new System.Drawing.Size(71, 15);
            this.lblvalorFixado.TabIndex = 2;
            this.lblvalorFixado.Text = "Valor fixado";
            // 
            // lblCnpjConvOdonto
            // 
            this.lblCnpjConvOdonto.AutoSize = true;
            this.lblCnpjConvOdonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblCnpjConvOdonto.Location = new System.Drawing.Point(6, 93);
            this.lblCnpjConvOdonto.Name = "lblCnpjConvOdonto";
            this.lblCnpjConvOdonto.Size = new System.Drawing.Size(38, 15);
            this.lblCnpjConvOdonto.TabIndex = 1;
            this.lblCnpjConvOdonto.Text = "CNPJ";
            // 
            // lblNomeConvOdonto
            // 
            this.lblNomeConvOdonto.AutoSize = true;
            this.lblNomeConvOdonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblNomeConvOdonto.Location = new System.Drawing.Point(6, 35);
            this.lblNomeConvOdonto.Name = "lblNomeConvOdonto";
            this.lblNomeConvOdonto.Size = new System.Drawing.Size(184, 15);
            this.lblNomeConvOdonto.TabIndex = 0;
            this.lblNomeConvOdonto.Text = "Nome do convênio odontológico";
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.LightBlue;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnSair.Location = new System.Drawing.Point(247, 327);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 30);
            this.btnSair.TabIndex = 13;
            this.btnSair.Text = "Fechar";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // Form_CadConvOdontologico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(352, 395);
            this.Controls.Add(this.gpbConvenioOdontologico);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_CadConvOdontologico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Convênio Odontologico";
            this.gpbConvenioOdontologico.ResumeLayout(false);
            this.gpbConvenioOdontologico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbConvenioOdontologico;
        private System.Windows.Forms.Label lblPercentual;
        private System.Windows.Forms.Label lblvalorFixado;
        private System.Windows.Forms.Label lblCnpjConvOdonto;
        private System.Windows.Forms.Label lblNomeConvOdonto;
        private System.Windows.Forms.TextBox txtNomeConvOdonto;
        private System.Windows.Forms.MaskedTextBox mskCnpjConvOdonto;
        private System.Windows.Forms.TextBox txtValorConvOdonto;
        private System.Windows.Forms.TextBox txtPorcentagemConvOdonto;
        private System.Windows.Forms.Button btnCadastrarConvOdonto;
        private System.Windows.Forms.RadioButton rdbPercentual;
        private System.Windows.Forms.RadioButton rdbValorFixado;
        private System.Windows.Forms.Label lblModoDesconto;
        private System.Windows.Forms.Button btnSair;
    }
}