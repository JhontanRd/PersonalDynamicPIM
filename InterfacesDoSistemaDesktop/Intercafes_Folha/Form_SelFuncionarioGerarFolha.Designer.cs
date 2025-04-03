namespace InterfacesDoSistemaDesktop.Intercafes_Folha
{
    partial class Form_SelFuncionarioGerarFolha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SelFuncionarioGerarFolha));
            this.gpbSelFuncionarioGerarFolha = new System.Windows.Forms.GroupBox();
            this.lblFolhasGeradas = new System.Windows.Forms.Label();
            this.lblGerarFolhas = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGerarFolha = new System.Windows.Forms.Button();
            this.dgvFolhaGerada = new System.Windows.Forms.DataGridView();
            this.dgvFolhaNaoGerada = new System.Windows.Forms.DataGridView();
            this.cmbListarFuncionarios = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnAtualizarTabelaFolhasGeradas = new System.Windows.Forms.Button();
            this.gpbSelFuncionarioGerarFolha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolhaGerada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolhaNaoGerada)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbSelFuncionarioGerarFolha
            // 
            this.gpbSelFuncionarioGerarFolha.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.btnAtualizarTabelaFolhasGeradas);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.lblFolhasGeradas);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.lblGerarFolhas);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.btnExcluir);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.btnFechar);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.btnGerarFolha);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.dgvFolhaGerada);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.dgvFolhaNaoGerada);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.cmbListarFuncionarios);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.lblEmpresa);
            this.gpbSelFuncionarioGerarFolha.Controls.Add(this.btnListar);
            this.gpbSelFuncionarioGerarFolha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gpbSelFuncionarioGerarFolha.Location = new System.Drawing.Point(12, 12);
            this.gpbSelFuncionarioGerarFolha.Name = "gpbSelFuncionarioGerarFolha";
            this.gpbSelFuncionarioGerarFolha.Size = new System.Drawing.Size(1160, 587);
            this.gpbSelFuncionarioGerarFolha.TabIndex = 0;
            this.gpbSelFuncionarioGerarFolha.TabStop = false;
            this.gpbSelFuncionarioGerarFolha.Text = "Funcionários para gerar folhas de págamento";
            // 
            // lblFolhasGeradas
            // 
            this.lblFolhasGeradas.AutoSize = true;
            this.lblFolhasGeradas.BackColor = System.Drawing.Color.SlateBlue;
            this.lblFolhasGeradas.Location = new System.Drawing.Point(773, 66);
            this.lblFolhasGeradas.Name = "lblFolhasGeradas";
            this.lblFolhasGeradas.Padding = new System.Windows.Forms.Padding(2);
            this.lblFolhasGeradas.Size = new System.Drawing.Size(261, 21);
            this.lblFolhasGeradas.TabIndex = 17;
            this.lblFolhasGeradas.Text = "Funcionários Com Folhas Geradas";
            // 
            // lblGerarFolhas
            // 
            this.lblGerarFolhas.AutoSize = true;
            this.lblGerarFolhas.BackColor = System.Drawing.Color.SlateBlue;
            this.lblGerarFolhas.Location = new System.Drawing.Point(139, 66);
            this.lblGerarFolhas.Name = "lblGerarFolhas";
            this.lblGerarFolhas.Padding = new System.Windows.Forms.Padding(2);
            this.lblGerarFolhas.Size = new System.Drawing.Size(236, 21);
            this.lblGerarFolhas.TabIndex = 16;
            this.lblGerarFolhas.Text = "Funcionários Para Gerar Folha";
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.LightBlue;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnExcluir.Location = new System.Drawing.Point(512, 276);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(116, 30);
            this.btnExcluir.TabIndex = 15;
            this.btnExcluir.Text = "Excluir Folha";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.LightBlue;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnFechar.Location = new System.Drawing.Point(512, 322);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(116, 30);
            this.btnFechar.TabIndex = 14;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnGerarFolha
            // 
            this.btnGerarFolha.BackColor = System.Drawing.Color.LightBlue;
            this.btnGerarFolha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGerarFolha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnGerarFolha.Location = new System.Drawing.Point(512, 230);
            this.btnGerarFolha.Name = "btnGerarFolha";
            this.btnGerarFolha.Size = new System.Drawing.Size(116, 30);
            this.btnGerarFolha.TabIndex = 13;
            this.btnGerarFolha.Text = "Gerar Folha";
            this.btnGerarFolha.UseVisualStyleBackColor = false;
            this.btnGerarFolha.Click += new System.EventHandler(this.btnGerarFolha_Click);
            // 
            // dgvFolhaGerada
            // 
            this.dgvFolhaGerada.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvFolhaGerada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFolhaGerada.Location = new System.Drawing.Point(634, 90);
            this.dgvFolhaGerada.Name = "dgvFolhaGerada";
            this.dgvFolhaGerada.ReadOnly = true;
            this.dgvFolhaGerada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFolhaGerada.Size = new System.Drawing.Size(520, 491);
            this.dgvFolhaGerada.TabIndex = 12;
            this.dgvFolhaGerada.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFolhaGerada_CellClick);
            // 
            // dgvFolhaNaoGerada
            // 
            this.dgvFolhaNaoGerada.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvFolhaNaoGerada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFolhaNaoGerada.Location = new System.Drawing.Point(9, 90);
            this.dgvFolhaNaoGerada.Name = "dgvFolhaNaoGerada";
            this.dgvFolhaNaoGerada.ReadOnly = true;
            this.dgvFolhaNaoGerada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFolhaNaoGerada.Size = new System.Drawing.Size(497, 491);
            this.dgvFolhaNaoGerada.TabIndex = 11;
            this.dgvFolhaNaoGerada.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFolhaNaoGerada_CellClick);
            // 
            // cmbListarFuncionarios
            // 
            this.cmbListarFuncionarios.BackColor = System.Drawing.Color.LightBlue;
            this.cmbListarFuncionarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListarFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbListarFuncionarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbListarFuncionarios.FormattingEnabled = true;
            this.cmbListarFuncionarios.Location = new System.Drawing.Point(326, 27);
            this.cmbListarFuncionarios.Name = "cmbListarFuncionarios";
            this.cmbListarFuncionarios.Size = new System.Drawing.Size(300, 23);
            this.cmbListarFuncionarios.TabIndex = 10;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblEmpresa.Location = new System.Drawing.Point(6, 32);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(314, 15);
            this.lblEmpresa.TabIndex = 9;
            this.lblEmpresa.Text = "Selecione uma empresa para listar os seus funcionários";
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.LightBlue;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnListar.Location = new System.Drawing.Point(651, 23);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(107, 30);
            this.btnListar.TabIndex = 8;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnAtualizarTabelaFolhasGeradas
            // 
            this.btnAtualizarTabelaFolhasGeradas.BackColor = System.Drawing.Color.LightBlue;
            this.btnAtualizarTabelaFolhasGeradas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtualizarTabelaFolhasGeradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnAtualizarTabelaFolhasGeradas.Location = new System.Drawing.Point(512, 368);
            this.btnAtualizarTabelaFolhasGeradas.Name = "btnAtualizarTabelaFolhasGeradas";
            this.btnAtualizarTabelaFolhasGeradas.Size = new System.Drawing.Size(116, 30);
            this.btnAtualizarTabelaFolhasGeradas.TabIndex = 18;
            this.btnAtualizarTabelaFolhasGeradas.Text = "Aualizar";
            this.btnAtualizarTabelaFolhasGeradas.UseVisualStyleBackColor = false;
            this.btnAtualizarTabelaFolhasGeradas.Click += new System.EventHandler(this.btnAtualizarTabelaFolhasGeradas_Click);
            // 
            // Form_SelFuncionarioGerarFolha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.gpbSelFuncionarioGerarFolha);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_SelFuncionarioGerarFolha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleção de Funcionario Para Gerar Folha de Pagamento";
            this.Load += new System.EventHandler(this.Form_SelFuncionarioGerarFolha_Load);
            this.gpbSelFuncionarioGerarFolha.ResumeLayout(false);
            this.gpbSelFuncionarioGerarFolha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolhaGerada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolhaNaoGerada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSelFuncionarioGerarFolha;
        private System.Windows.Forms.ComboBox cmbListarFuncionarios;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView dgvFolhaGerada;
        private System.Windows.Forms.DataGridView dgvFolhaNaoGerada;
        private System.Windows.Forms.Button btnGerarFolha;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblFolhasGeradas;
        private System.Windows.Forms.Label lblGerarFolhas;
        private System.Windows.Forms.Button btnAtualizarTabelaFolhasGeradas;
    }
}