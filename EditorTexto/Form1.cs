using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace EditorTexto
{
    public partial class Form1 : Form
    {
        string caminhoArquivo, retorno = "Cancel";

        public Form1()
        {
            InitializeComponent();
        }

        private void corTema (Color background, Color foreground)
        {
            if (background == DefaultBackColor && foreground == DefaultForeColor)
            {
                txtTela.BackColor = Color.White;
                txtTela.ForeColor = DefaultForeColor;
                menuStrip1.BackColor = DefaultBackColor;
                menuStrip1.ForeColor = DefaultForeColor;
            } else
            {
                txtTela.BackColor = background;
                txtTela.ForeColor = foreground;
                menuStrip1.BackColor = background;
                menuStrip1.ForeColor = foreground;
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre s1 = new Sobre();
            s1.Show();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var slr1 = new Salvar();

            if (caminhoArquivo == null)
            {
                sfdSalvarComo.Filter ="Text files (*.txt)|*.txt|All files (*.*)|*.*";

                var opcao = sfdSalvarComo.ShowDialog();

                if (opcao == DialogResult.OK)
                {
                    caminhoArquivo = sfdSalvarComo.FileName;

                    slr1.salvar(caminhoArquivo, txtTela.Text, false);

                    // Define OK para ser usado no botao SAIR e em seguida Cancelar
                    retorno = "Ok";
                }
            }
            else
            {
                slr1.salvar(caminhoArquivo, txtTela.Text, false);
            }

            _ = (caminhoArquivo != null) ? this.Text = "TEdit - " + caminhoArquivo : "TEdit";
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caminhoArquivo = null;
            salvarToolStripMenuItem_Click(sender, e);
        }

        public void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdAbrirArquivo.ShowDialog() == DialogResult.OK)
            {
                caminhoArquivo = ofdAbrirArquivo.FileName;

                if (File.Exists(caminhoArquivo))
                {
                    txtTela.Text = string.Empty;

                    using (var objectFile = new StreamReader(caminhoArquivo))
                    {
                        string linha;

                        this.Text = "TEdit - " + caminhoArquivo;

                        while ((linha = objectFile.ReadLine()) != null)
                        {
                            if (linha == null)
                                break;

                            txtTela.Text += linha + "\n";
                        }
                    }
                }
            }
        }

        private void defineCaracteristicasPadrao_ButtonNovo()
        {
            // Voltando aos padrões normais dos componentes abaixo
            this.Text = "TEdit - Sem Titulo";
            caminhoArquivo = null;
            txtTela.Text = string.Empty;

            // Ex: Font("Arial", 12, FontStyle.Bold)
            txtTela.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Regular);
            txtTela.ForeColor = DefaultForeColor;
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtTela.Text != string.Empty || caminhoArquivo != null)
            {
                DialogResult opcao = MessageBox.Show("Deseja salvar as mudanças?", "Novo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (opcao)
                {
                    case DialogResult.No:
                        defineCaracteristicasPadrao_ButtonNovo();
                        break;

                    case DialogResult.Yes:
                        salvarToolStripMenuItem_Click(sender, e);
                        defineCaracteristicasPadrao_ButtonNovo();
                        break;

                    case DialogResult.Cancel:
                        FormClosingEventArgs cancelar = new FormClosingEventArgs(CloseReason.UserClosing, true);
                        cancelar.Cancel = true;
                        break;
                }
            }
            else
            {
                defineCaracteristicasPadrao_ButtonNovo();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs evento)
        {
            sairToolStripMenuItem_Click(sender, evento);

            // Habilita o cancelar ao clicar no botao X da janela e clicar em CANCELAR do MessageBox
            if (evento.Cancel != true)
            {
                evento.Cancel = true;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Esse metodo não está sendo EXECUTADO IMEDIATAMENTE - CORRIGIR
            if (caminhoArquivo == null & txtTela.Text == string.Empty)
            {
                Application.ExitThread();
            }

            DialogResult opcao = MessageBox.Show("Você deseja gravar o arquivo antes de sair?",
                "Sair", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (opcao)
            {
                case DialogResult.Yes:
                    salvarToolStripMenuItem_Click(sender, e);

                    if (retorno == "Ok")
                        Application.ExitThread();

                    break;

                case DialogResult.No:
                    Application.ExitThread();
                    break;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fdFont.ShowDialog() == DialogResult.OK)
            {
                txtTela.Font = fdFont.Font;
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument imprimirDados = new PrintDocument();
            
            PrintDialog confImpressora = new PrintDialog()
            {
                // Configuracoes padrao para impressao
                AllowSelection = true, //false
                AllowSomePages = true, //false
                AllowCurrentPage = true, //false
                AllowPrintToFile = true, //true
                PrintToFile = true, //false
                ShowNetwork = false, //true
                ShowHelp = true, //false
                UseEXDialog = false, //true
                Document = imprimirDados
            };

            imprimirDados.DocumentName = (caminhoArquivo == null) ? "TEdit" : "TEdit - " + caminhoArquivo;

            if (confImpressora.ShowDialog() == DialogResult.OK)
            {
                imprimirDados.Print();
            }
        }

        private void coresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cdColor.ShowDialog() == DialogResult.OK)
                txtTela.ForeColor = cdColor.Color;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.N:
                    novoToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.O:
                    abrirToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.Shift | Keys.S:
                    salvarComoToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.P:
                    imprimirToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.E:
                    sairToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.L:
                    fontToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.B:
                    coresToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.F1:
                    sobreToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.S:
                    salvarToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.W:
                    quebraDeLinhaToolStripMenuItem_Click(sender, e);
                    break;
            }
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(Color.Black, Color.DarkGray);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(Color.DarkGreen, Color.Black);
        }

        private void horaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            
            // Arrumar esse codigo para escrever a data no local do cursor do teclado
            // E nao no final da tela
            txtTela.Text += dateTime.ToString();
        }

        private void quebraDeLinhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = (txtTela.WordWrap == true) ? txtTela.WordWrap = false : txtTela.WordWrap = true;
        }

        private void txtTela_TextChanged(object sender, EventArgs e)
        {
            // Como seria fazer essas combinacoes usando ENUM com [Flags]
            if (caminhoArquivo == null && txtTela.Text.Equals(string.Empty))
                this.Text = "TEdit";
            else if (caminhoArquivo == null && txtTela.Text != string.Empty)
                this.Text = "*TEdit";
            else if (caminhoArquivo != null && txtTela.Text != string.Empty)
                this.Text = "*TEdit - " + caminhoArquivo;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(DefaultBackColor, DefaultForeColor);
        }
    }
}
