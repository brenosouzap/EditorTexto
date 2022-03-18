
namespace EditorTexto
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarSalvamentoAutomaticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.desfazerCtrlZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refazerCtrlUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarCtrlCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horaDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localizarCtrlFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quebraDeLinhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alinhamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.direitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esquerdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarCriptografadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarDescriptografandoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarChaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdAbrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.sfdSalvarComo = new System.Windows.Forms.SaveFileDialog();
            this.txtTela = new System.Windows.Forms.RichTextBox();
            this.fdFont = new System.Windows.Forms.FontDialog();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.lbAutoSave = new System.Windows.Forms.Label();
            arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.salvarToolStripMenuItem,
            this.salvarComoToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.habilitarSalvamentoAutomaticoToolStripMenuItem,
            this.sairToolStripMenuItem});
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 19);
            arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.novoToolStripMenuItem.Text = "Novo                              Ctrl+N";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.abrirToolStripMenuItem.Text = "Abrir                               Ctrl+O";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.salvarToolStripMenuItem.Text = "Salvar                             Ctrl+S";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // salvarComoToolStripMenuItem
            // 
            this.salvarComoToolStripMenuItem.Name = "salvarComoToolStripMenuItem";
            this.salvarComoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.salvarComoToolStripMenuItem.Text = "Salvar Como...              Ctrl+Shift+S";
            this.salvarComoToolStripMenuItem.Click += new System.EventHandler(this.salvarComoToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir                        Ctrl+P";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // habilitarSalvamentoAutomaticoToolStripMenuItem
            // 
            this.habilitarSalvamentoAutomaticoToolStripMenuItem.Name = "habilitarSalvamentoAutomaticoToolStripMenuItem";
            this.habilitarSalvamentoAutomaticoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.habilitarSalvamentoAutomaticoToolStripMenuItem.Text = "AutoSalvamento";
            this.habilitarSalvamentoAutomaticoToolStripMenuItem.Click += new System.EventHandler(this.habilitarSalvamentoAutomaticoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.sairToolStripMenuItem.Text = "Sair                                 Ctrl+E";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            arquivoToolStripMenuItem,
            this.editarToolStripMenuItem1,
            this.editarToolStripMenuItem,
            this.ferramentaToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(612, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desfazerCtrlZToolStripMenuItem,
            this.refazerCtrlUToolStripMenuItem,
            this.copiarCtrlCToolStripMenuItem,
            this.colarToolStripMenuItem,
            this.horaDataToolStripMenuItem,
            this.localizarCtrlFToolStripMenuItem,
            this.quebraDeLinhaToolStripMenuItem});
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(49, 19);
            this.editarToolStripMenuItem1.Text = "Editar";
            // 
            // desfazerCtrlZToolStripMenuItem
            // 
            this.desfazerCtrlZToolStripMenuItem.Name = "desfazerCtrlZToolStripMenuItem";
            this.desfazerCtrlZToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.desfazerCtrlZToolStripMenuItem.Text = "Desfazer                         Ctrl+Z";
            this.desfazerCtrlZToolStripMenuItem.Click += new System.EventHandler(this.desfazerCtrlZToolStripMenuItem_Click);
            // 
            // refazerCtrlUToolStripMenuItem
            // 
            this.refazerCtrlUToolStripMenuItem.Name = "refazerCtrlUToolStripMenuItem";
            this.refazerCtrlUToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.refazerCtrlUToolStripMenuItem.Text = "Refazer                           Ctrl+Y";
            this.refazerCtrlUToolStripMenuItem.Click += new System.EventHandler(this.refazerCtrlUToolStripMenuItem_Click);
            // 
            // copiarCtrlCToolStripMenuItem
            // 
            this.copiarCtrlCToolStripMenuItem.Name = "copiarCtrlCToolStripMenuItem";
            this.copiarCtrlCToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.copiarCtrlCToolStripMenuItem.Text = "Copiar                            Ctrl+C";
            this.copiarCtrlCToolStripMenuItem.Click += new System.EventHandler(this.copiarCtrlCToolStripMenuItem_Click);
            // 
            // colarToolStripMenuItem
            // 
            this.colarToolStripMenuItem.Name = "colarToolStripMenuItem";
            this.colarToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.colarToolStripMenuItem.Text = "Colar                               Ctrl+V";
            this.colarToolStripMenuItem.Click += new System.EventHandler(this.colarToolStripMenuItem_Click);
            // 
            // horaDataToolStripMenuItem
            // 
            this.horaDataToolStripMenuItem.Name = "horaDataToolStripMenuItem";
            this.horaDataToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.horaDataToolStripMenuItem.Text = "Hora/Data                      Ctrl+D";
            this.horaDataToolStripMenuItem.Click += new System.EventHandler(this.horaDataToolStripMenuItem_Click);
            // 
            // localizarCtrlFToolStripMenuItem
            // 
            this.localizarCtrlFToolStripMenuItem.Name = "localizarCtrlFToolStripMenuItem";
            this.localizarCtrlFToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.localizarCtrlFToolStripMenuItem.Text = "Localizar                         Ctrl+F";
            this.localizarCtrlFToolStripMenuItem.Click += new System.EventHandler(this.localizarCtrlFToolStripMenuItem_Click);
            // 
            // quebraDeLinhaToolStripMenuItem
            // 
            this.quebraDeLinhaToolStripMenuItem.Name = "quebraDeLinhaToolStripMenuItem";
            this.quebraDeLinhaToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.quebraDeLinhaToolStripMenuItem.Text = "Quebra de linha            Ctrl+W";
            this.quebraDeLinhaToolStripMenuItem.Click += new System.EventHandler(this.quebraDeLinhaToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.coresToolStripMenuItem,
            this.alinhamentoToolStripMenuItem,
            this.temaToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(67, 19);
            this.editarToolStripMenuItem.Text = "Formatar";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.fontToolStripMenuItem.Text = "Fonte                      Ctrl+L";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // coresToolStripMenuItem
            // 
            this.coresToolStripMenuItem.Name = "coresToolStripMenuItem";
            this.coresToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.coresToolStripMenuItem.Text = "Cores                      Ctrl+B";
            this.coresToolStripMenuItem.Click += new System.EventHandler(this.coresToolStripMenuItem_Click);
            // 
            // alinhamentoToolStripMenuItem
            // 
            this.alinhamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.direitaToolStripMenuItem,
            this.esquerdaToolStripMenuItem,
            this.centroToolStripMenuItem});
            this.alinhamentoToolStripMenuItem.Name = "alinhamentoToolStripMenuItem";
            this.alinhamentoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.alinhamentoToolStripMenuItem.Text = "Alinhamento";
            // 
            // direitaToolStripMenuItem
            // 
            this.direitaToolStripMenuItem.Name = "direitaToolStripMenuItem";
            this.direitaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.direitaToolStripMenuItem.Text = "Direita";
            this.direitaToolStripMenuItem.Click += new System.EventHandler(this.direitaToolStripMenuItem_Click);
            // 
            // esquerdaToolStripMenuItem
            // 
            this.esquerdaToolStripMenuItem.Name = "esquerdaToolStripMenuItem";
            this.esquerdaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.esquerdaToolStripMenuItem.Text = "Esquerda";
            this.esquerdaToolStripMenuItem.Click += new System.EventHandler(this.esquerdaToolStripMenuItem_Click);
            // 
            // centroToolStripMenuItem
            // 
            this.centroToolStripMenuItem.Name = "centroToolStripMenuItem";
            this.centroToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.centroToolStripMenuItem.Text = "Centro";
            this.centroToolStripMenuItem.Click += new System.EventHandler(this.centroToolStripMenuItem_Click);
            // 
            // temaToolStripMenuItem
            // 
            this.temaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.normalToolStripMenuItem});
            this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
            this.temaToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.temaToolStripMenuItem.Text = "Tema";
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.greenToolStripMenuItem.Text = "Verde";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.normalToolStripMenuItem.Text = "Padrão";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // ferramentaToolStripMenuItem
            // 
            this.ferramentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarCriptografadoToolStripMenuItem,
            this.importarDescriptografandoToolStripMenuItem,
            this.criarChaveToolStripMenuItem});
            this.ferramentaToolStripMenuItem.Name = "ferramentaToolStripMenuItem";
            this.ferramentaToolStripMenuItem.Size = new System.Drawing.Size(79, 19);
            this.ferramentaToolStripMenuItem.Text = "Ferramenta";
            // 
            // exportarCriptografadoToolStripMenuItem
            // 
            this.exportarCriptografadoToolStripMenuItem.Name = "exportarCriptografadoToolStripMenuItem";
            this.exportarCriptografadoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.exportarCriptografadoToolStripMenuItem.Text = "Exportar Criptografado";
            this.exportarCriptografadoToolStripMenuItem.Click += new System.EventHandler(this.exportarCriptografadoToolStripMenuItem_Click);
            // 
            // importarDescriptografandoToolStripMenuItem
            // 
            this.importarDescriptografandoToolStripMenuItem.Name = "importarDescriptografandoToolStripMenuItem";
            this.importarDescriptografandoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.importarDescriptografandoToolStripMenuItem.Text = "Importar Descriptografando";
            // 
            // criarChaveToolStripMenuItem
            // 
            this.criarChaveToolStripMenuItem.Name = "criarChaveToolStripMenuItem";
            this.criarChaveToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.criarChaveToolStripMenuItem.Text = "Criar chave";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 19);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sobreToolStripMenuItem.Text = "Sobre                   F1";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // ofdAbrirArquivo
            // 
            this.ofdAbrirArquivo.FileName = "arquivo.txt";
            // 
            // txtTela
            // 
            this.txtTela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTela.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTela.Location = new System.Drawing.Point(0, 25);
            this.txtTela.Margin = new System.Windows.Forms.Padding(4);
            this.txtTela.Name = "txtTela";
            this.txtTela.Size = new System.Drawing.Size(612, 435);
            this.txtTela.TabIndex = 2;
            this.txtTela.Text = "";
            this.txtTela.WordWrap = false;
            this.txtTela.TextChanged += new System.EventHandler(this.txtTela_TextChanged);
            // 
            // txtProcurar
            // 
            this.txtProcurar.BackColor = System.Drawing.SystemColors.Window;
            this.txtProcurar.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtProcurar.Enabled = false;
            this.txtProcurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcurar.ForeColor = System.Drawing.Color.Silver;
            this.txtProcurar.Location = new System.Drawing.Point(327, 25);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(285, 24);
            this.txtProcurar.TabIndex = 3;
            this.txtProcurar.Text = "Digite sua pesquisa";
            this.txtProcurar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProcurar.Visible = false;
            this.txtProcurar.WordWrap = false;
            this.txtProcurar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcurar_KeyDown);
            this.txtProcurar.Leave += new System.EventHandler(this.txtProcurar_Leave);
            // 
            // lbAutoSave
            // 
            this.lbAutoSave.AutoSize = true;
            this.lbAutoSave.Enabled = false;
            this.lbAutoSave.Location = new System.Drawing.Point(5, 30);
            this.lbAutoSave.Name = "lbAutoSave";
            this.lbAutoSave.Size = new System.Drawing.Size(128, 18);
            this.lbAutoSave.TabIndex = 4;
            this.lbAutoSave.Text = "AutoSalvamento...";
            this.lbAutoSave.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 460);
            this.Controls.Add(this.lbAutoSave);
            this.Controls.Add(this.txtProcurar);
            this.Controls.Add(this.txtTela);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdAbrirArquivo;
        private System.Windows.Forms.SaveFileDialog sfdSalvarComo;
        public System.Windows.Forms.RichTextBox txtTela;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.FontDialog fdFont;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alinhamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem direitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esquerdaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem horaDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quebraDeLinhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarCriptografadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarDescriptografandoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarChaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desfazerCtrlZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refazerCtrlUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarCtrlCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localizarCtrlFToolStripMenuItem;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.ToolStripMenuItem habilitarSalvamentoAutomaticoToolStripMenuItem;
        private System.Windows.Forms.Label lbAutoSave;
    }
}

