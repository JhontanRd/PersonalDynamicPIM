namespace InterfacesDoSistemaDesktop.Intercafes_Folha
{
    partial class Form_VisualizarFolhasPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_VisualizarFolhasPagamento));
            this.gpbVisualizarFolhasPagamento = new System.Windows.Forms.GroupBox();
            this.cmbListarFuncionarios = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.dgvFolhasPagamentoGeradas = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbVisualizarFolhasPagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolhasPagamentoGeradas)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbVisualizarFolhasPagamento
            // 
            this.gpbVisualizarFolhasPagamento.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gpbVisualizarFolhasPagamento.Controls.Add(this.btnFechar);
            this.gpbVisualizarFolhasPagamento.Controls.Add(this.dgvFolhasPagamentoGeradas);
            this.gpbVisualizarFolhasPagamento.Controls.Add(this.cmbListarFuncionarios);
            this.gpbVisualizarFolhasPagamento.Controls.Add(this.lblEmpresa);
            this.gpbVisualizarFolhasPagamento.Controls.Add(this.btnListar);
            this.gpbVisualizarFolhasPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gpbVisualizarFolhasPagamento.Location = new System.Drawing.Point(12, 12);
            this.gpbVisualizarFolhasPagamento.Name = "gpbVisualizarFolhasPagamento";
            this.gpbVisualizarFolhasPagamento.Size = new System.Drawing.Size(1160, 587);
            this.gpbVisualizarFolhasPagamento.TabIndex = 0;
            this.gpbVisualizarFolhasPagamento.TabStop = false;
            this.gpbVisualizarFolhasPagamento.Text = "Consultar folhas de pagamento geradas";
            // 
            // cmbListarFuncionarios
            // 
            this.cmbListarFuncionarios.BackColor = System.Drawing.Color.LightBlue;
            this.cmbListarFuncionarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListarFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbListarFuncionarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbListarFuncionarios.FormattingEnabled = true;
            this.cmbListarFuncionarios.Location = new System.Drawing.Point(363, 22);
            this.cmbListarFuncionarios.Name = "cmbListarFuncionarios";
            this.cmbListarFuncionarios.Size = new System.Drawing.Size(300, 23);
            this.cmbListarFuncionarios.TabIndex = 13;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblEmpresa.Location = new System.Drawing.Point(13, 25);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(344, 15);
            this.lblEmpresa.TabIndex = 12;
            this.lblEmpresa.Text = "Selecione uma empresa para listar as folhas dos funcionários";
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.LightBlue;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnListar.Location = new System.Drawing.Point(688, 18);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(107, 30);
            this.btnListar.TabIndex = 11;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dgvFolhasPagamentoGeradas
            // 
            this.dgvFolhasPagamentoGeradas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvFolhasPagamentoGeradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFolhasPagamentoGeradas.Location = new System.Drawing.Point(6, 54);
            this.dgvFolhasPagamentoGeradas.Name = "dgvFolhasPagamentoGeradas";
            this.dgvFolhasPagamentoGeradas.ReadOnly = true;
            this.dgvFolhasPagamentoGeradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFolhasPagamentoGeradas.Size = new System.Drawing.Size(1003, 527);
            this.dgvFolhasPagamentoGeradas.TabIndex = 14;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.LightBlue;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnFechar.Location = new System.Drawing.Point(1032, 289);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(107, 30);
            this.btnFechar.TabIndex = 15;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // Form_VisualizarFolhasPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.gpbVisualizarFolhasPagamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_VisualizarFolhasPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar Folhas de Pagamento";
            this.Load += new System.EventHandler(this.Form_VisualizarFolhasPagamento_Load);
            this.gpbVisualizarFolhasPagamento.ResumeLayout(false);
            this.gpbVisualizarFolhasPagamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolhasPagamentoGeradas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbVisualizarFolhasPagamento;
        private System.Windows.Forms.DataGridView dgvFolhasPagamentoGeradas;
        private System.Windows.Forms.ComboBox cmbListarFuncionarios;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnFechar;
    }
}