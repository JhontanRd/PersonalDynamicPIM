namespace InterfacesDoSistemaDesktop.Interfaces_Ferias
{
    partial class Form_VisualizarFerias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_VisualizarFerias));
            this.gpbFeriasMarcadas = new System.Windows.Forms.GroupBox();
            this.dgvFeriasAgendadas = new System.Windows.Forms.DataGridView();
            this.cmbListarFuncionarios = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbFeriasMarcadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeriasAgendadas)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFeriasMarcadas
            // 
            this.gpbFeriasMarcadas.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gpbFeriasMarcadas.Controls.Add(this.btnFechar);
            this.gpbFeriasMarcadas.Controls.Add(this.cmbListarFuncionarios);
            this.gpbFeriasMarcadas.Controls.Add(this.lblEmpresa);
            this.gpbFeriasMarcadas.Controls.Add(this.btnListar);
            this.gpbFeriasMarcadas.Controls.Add(this.dgvFeriasAgendadas);
            this.gpbFeriasMarcadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gpbFeriasMarcadas.Location = new System.Drawing.Point(12, 12);
            this.gpbFeriasMarcadas.Name = "gpbFeriasMarcadas";
            this.gpbFeriasMarcadas.Size = new System.Drawing.Size(1060, 537);
            this.gpbFeriasMarcadas.TabIndex = 0;
            this.gpbFeriasMarcadas.TabStop = false;
            this.gpbFeriasMarcadas.Text = "Consultar férias marcadas";
            // 
            // dgvFeriasAgendadas
            // 
            this.dgvFeriasAgendadas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvFeriasAgendadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeriasAgendadas.Location = new System.Drawing.Point(9, 62);
            this.dgvFeriasAgendadas.Name = "dgvFeriasAgendadas";
            this.dgvFeriasAgendadas.ReadOnly = true;
            this.dgvFeriasAgendadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeriasAgendadas.Size = new System.Drawing.Size(892, 469);
            this.dgvFeriasAgendadas.TabIndex = 0;
            // 
            // cmbListarFuncionarios
            // 
            this.cmbListarFuncionarios.BackColor = System.Drawing.Color.LightBlue;
            this.cmbListarFuncionarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListarFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbListarFuncionarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbListarFuncionarios.FormattingEnabled = true;
            this.cmbListarFuncionarios.Location = new System.Drawing.Point(422, 30);
            this.cmbListarFuncionarios.Name = "cmbListarFuncionarios";
            this.cmbListarFuncionarios.Size = new System.Drawing.Size(300, 23);
            this.cmbListarFuncionarios.TabIndex = 10;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblEmpresa.Location = new System.Drawing.Point(6, 33);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(410, 15);
            this.lblEmpresa.TabIndex = 9;
            this.lblEmpresa.Text = "Selecione uma empresa para listar os funcionários com férias agendadas";
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.LightBlue;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnListar.Location = new System.Drawing.Point(747, 26);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(107, 30);
            this.btnListar.TabIndex = 8;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.LightBlue;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnFechar.Location = new System.Drawing.Point(929, 264);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(107, 30);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // Form_VisualizarFerias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.gpbFeriasMarcadas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_VisualizarFerias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar Ferias Agendadadas";
            this.Load += new System.EventHandler(this.Form_VisualizarFerias_Load);
            this.gpbFeriasMarcadas.ResumeLayout(false);
            this.gpbFeriasMarcadas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeriasAgendadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFeriasMarcadas;
        private System.Windows.Forms.DataGridView dgvFeriasAgendadas;
        private System.Windows.Forms.ComboBox cmbListarFuncionarios;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnFechar;
    }
}