﻿namespace InterfacesDoSistemaDesktop
{
    partial class Form_ConvenioOdontologico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ConvenioOdontologico));
            this.gpbConvenioOdontologico = new System.Windows.Forms.GroupBox();
            this.txtConvenio = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.txtRetorno = new System.Windows.Forms.TextBox();
            this.lblRetorno = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtSalarioBase = new System.Windows.Forms.TextBox();
            this.lblConvenioOdontologico = new System.Windows.Forms.Label();
            this.lblSalarioBase = new System.Windows.Forms.Label();
            this.gpbConvenioOdontologico.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbConvenioOdontologico
            // 
            this.gpbConvenioOdontologico.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gpbConvenioOdontologico.Controls.Add(this.txtConvenio);
            this.gpbConvenioOdontologico.Controls.Add(this.btnCancelar);
            this.gpbConvenioOdontologico.Controls.Add(this.btnAvancar);
            this.gpbConvenioOdontologico.Controls.Add(this.btnVoltar);
            this.gpbConvenioOdontologico.Controls.Add(this.txtRetorno);
            this.gpbConvenioOdontologico.Controls.Add(this.lblRetorno);
            this.gpbConvenioOdontologico.Controls.Add(this.btnLimpar);
            this.gpbConvenioOdontologico.Controls.Add(this.btnCalcular);
            this.gpbConvenioOdontologico.Controls.Add(this.txtSalarioBase);
            this.gpbConvenioOdontologico.Controls.Add(this.lblConvenioOdontologico);
            this.gpbConvenioOdontologico.Controls.Add(this.lblSalarioBase);
            this.gpbConvenioOdontologico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gpbConvenioOdontologico.Location = new System.Drawing.Point(12, 12);
            this.gpbConvenioOdontologico.Name = "gpbConvenioOdontologico";
            this.gpbConvenioOdontologico.Size = new System.Drawing.Size(839, 349);
            this.gpbConvenioOdontologico.TabIndex = 1;
            this.gpbConvenioOdontologico.TabStop = false;
            this.gpbConvenioOdontologico.Text = "Convênio odontológico";
            // 
            // txtConvenio
            // 
            this.txtConvenio.Enabled = false;
            this.txtConvenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvenio.Location = new System.Drawing.Point(144, 66);
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.ReadOnly = true;
            this.txtConvenio.Size = new System.Drawing.Size(150, 21);
            this.txtConvenio.TabIndex = 35;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnCancelar.Location = new System.Drawing.Point(667, 313);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.BackColor = System.Drawing.Color.LightBlue;
            this.btnAvancar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAvancar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnAvancar.Location = new System.Drawing.Point(758, 313);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(75, 30);
            this.btnAvancar.TabIndex = 33;
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.UseVisualStyleBackColor = false;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.LightBlue;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnVoltar.Location = new System.Drawing.Point(574, 313);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 30);
            this.btnVoltar.TabIndex = 32;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // txtRetorno
            // 
            this.txtRetorno.Enabled = false;
            this.txtRetorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetorno.Location = new System.Drawing.Point(190, 143);
            this.txtRetorno.Name = "txtRetorno";
            this.txtRetorno.ReadOnly = true;
            this.txtRetorno.Size = new System.Drawing.Size(112, 21);
            this.txtRetorno.TabIndex = 7;
            // 
            // lblRetorno
            // 
            this.lblRetorno.AutoSize = true;
            this.lblRetorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblRetorno.Location = new System.Drawing.Point(6, 144);
            this.lblRetorno.Name = "lblRetorno";
            this.lblRetorno.Size = new System.Drawing.Size(178, 15);
            this.lblRetorno.TabIndex = 6;
            this.lblRetorno.Text = "Valor do convenio odontológico";
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.LightBlue;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnLimpar.Location = new System.Drawing.Point(9, 99);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 30);
            this.btnLimpar.TabIndex = 5;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.LightBlue;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnCalcular.Location = new System.Drawing.Point(90, 99);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 30);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtSalarioBase
            // 
            this.txtSalarioBase.BackColor = System.Drawing.Color.LightBlue;
            this.txtSalarioBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalarioBase.Enabled = false;
            this.txtSalarioBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSalarioBase.Location = new System.Drawing.Point(88, 33);
            this.txtSalarioBase.Name = "txtSalarioBase";
            this.txtSalarioBase.ReadOnly = true;
            this.txtSalarioBase.Size = new System.Drawing.Size(100, 21);
            this.txtSalarioBase.TabIndex = 2;
            // 
            // lblConvenioOdontologico
            // 
            this.lblConvenioOdontologico.AutoSize = true;
            this.lblConvenioOdontologico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblConvenioOdontologico.Location = new System.Drawing.Point(6, 66);
            this.lblConvenioOdontologico.Name = "lblConvenioOdontologico";
            this.lblConvenioOdontologico.Size = new System.Drawing.Size(132, 15);
            this.lblConvenioOdontologico.TabIndex = 1;
            this.lblConvenioOdontologico.Text = "Convenio odontológico";
            // 
            // lblSalarioBase
            // 
            this.lblSalarioBase.AutoSize = true;
            this.lblSalarioBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblSalarioBase.Location = new System.Drawing.Point(6, 34);
            this.lblSalarioBase.Name = "lblSalarioBase";
            this.lblSalarioBase.Size = new System.Drawing.Size(76, 15);
            this.lblSalarioBase.TabIndex = 0;
            this.lblSalarioBase.Text = "Salário base";
            // 
            // Form_ConvenioOdontologico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(863, 373);
            this.Controls.Add(this.gpbConvenioOdontologico);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_ConvenioOdontologico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convenio Odontológico";
            this.gpbConvenioOdontologico.ResumeLayout(false);
            this.gpbConvenioOdontologico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbConvenioOdontologico;
        private System.Windows.Forms.TextBox txtSalarioBase;
        private System.Windows.Forms.Label lblConvenioOdontologico;
        private System.Windows.Forms.Label lblSalarioBase;
        private System.Windows.Forms.TextBox txtRetorno;
        private System.Windows.Forms.Label lblRetorno;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox txtConvenio;
    }
}