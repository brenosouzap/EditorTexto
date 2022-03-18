/* TEdit - Editor texto e criptografia de texto

Licenca MIT - https://pt.wikipedia.org/wiki/Licen%C3%A7a_MIT

Copyright ©2022 Breno Prado and Edmar Prado

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

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
using System.Security.Cryptography;

namespace EditorTexto
{
    public partial class Form1 : Form
    {
        public string caminhoArquivo, retorno = "Cancel";
        bool autoSalvamento { get; set; } = false;

        public Form1()
        {
            InitializeComponent();
        }

        #region FormSobre
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre s1 = new Sobre();
            s1.Show();
        }
        #endregion FormSobre

        #region MenuArquivo
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var slr1 = new Salvar();

            if (caminhoArquivo == null)
            {
                sfdSalvarComo.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                var opcao = sfdSalvarComo.ShowDialog();

                if (opcao == DialogResult.OK)
                {
                    caminhoArquivo = sfdSalvarComo.FileName;

                    slr1.Salvamento(caminhoArquivo, txtTela.Text, false);

                    // Define OK para ser usado no botao SAIR e em seguida Cancelar
                    retorno = "Ok";
                }
            }
            else
            {
                slr1.Salvamento(caminhoArquivo, txtTela.Text, false);
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
            // Voltando as caracteristicas normais dos componentes abaixo
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

        private void habilitarSalvamentoAutomaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar salvar = new Salvar();
            salvar.AutoSalvamentoArquivo(autoSalvamento);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Esse metodo não está sendo EXECUTADO IMEDIATAMENTE - CORRIGIR
            if (caminhoArquivo == null && txtTela.Text == string.Empty)
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

        #region Imprimir
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
        #endregion Imprimir

        #endregion MenuArquivo

        #region TeclasAtalhos
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

                case Keys.Control | Keys.D:
                    horaDataToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.Z:
                    desfazerCtrlZToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.C:
                    copiarCtrlCToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.Y:
                    refazerCtrlUToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.V:
                    Clipboard.GetText();
                    break;

                case Keys.Control | Keys.F:
                    localizarCtrlFToolStripMenuItem_Click(sender, e);
                    break;
            }
        }
        #endregion TeclasAtalhos

        #region MenuFormatar
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

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fdFont.ShowDialog() == DialogResult.OK)
            {
                txtTela.Font = fdFont.Font;
            }
        }
        #endregion MenuFormatar

        #region Temas
        private void corTema(Color backcolor, Color forecolor)
        {
            if (backcolor == DefaultBackColor && forecolor == DefaultForeColor)
            {
                txtTela.BackColor = Color.White;
                txtTela.ForeColor = DefaultForeColor;
                menuStrip1.BackColor = DefaultBackColor;
                menuStrip1.ForeColor = DefaultForeColor;
            }
            else
            {
                txtTela.BackColor = backcolor;
                txtTela.ForeColor = forecolor;
                menuStrip1.BackColor = backcolor;
                menuStrip1.ForeColor = forecolor;
            }
        }

        private void coresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cdColor.ShowDialog() == DialogResult.OK)
                txtTela.ForeColor = cdColor.Color;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(Color.Black, Color.DarkGray);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(Color.DarkGreen, Color.Black);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(DefaultBackColor, DefaultForeColor);
        }

        #endregion Temas

        #region Eventos
        private void Form1_Load(object sender, EventArgs e)
        {
            txtProcurar.Enabled = false;
        }

        private void txtProcurar_Leave(object sender, EventArgs e)
        {
            string textoPesquisado = txtProcurar.Text;
            txtProcurar.Text = "Digite sua pesquisa";
            txtProcurar.Visible = false;
            localizarTexto(txtTela.BackColor, textoPesquisado);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs evento)
        {
            sairToolStripMenuItem_Click(sender, evento);

            // Habilita o cancelar ao clicar no botao X da janela e clicar em CANCELAR do MessageBox
            if (evento.Cancel != true)
            {
                evento.Cancel = true;
            }
        }

        #endregion Eventos

        #region MenuEditar
        private void horaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            // Coloca a data/hora no ponto correto do cursor na tela
            txtTela.Text = txtTela.Text.Insert(txtTela.SelectionStart, dateTime.ToString());
        }

        private void quebraDeLinhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = (txtTela.WordWrap == true) ? txtTela.WordWrap = false : txtTela.WordWrap = true;
        }

        private void desfazerCtrlZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.Undo();
        }

        private void refazerCtrlUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.Redo();
        }

        private void copiarCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.Copy();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.Paste();
        }

        private void localizarTexto(Color corMarcacaoTexto, string texto)
        {
            string textoProcurado = texto;

            if (!string.IsNullOrWhiteSpace(textoProcurado))
            {
                int i = 0;

                while (i < txtTela.Text.LastIndexOf(textoProcurado))
                {
                    txtTela.Find(textoProcurado, i, txtTela.Text.Length, RichTextBoxFinds.None);
                    txtTela.SelectionBackColor = corMarcacaoTexto;
                    i = txtTela.Text.IndexOf(textoProcurado, i) + 1;
                }
            }
        }

        private void txtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                localizarTexto(Color.Red, txtProcurar.Text);
            }
        }

        private void localizarCtrlFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!txtTela.Text.Equals(""))
            {
                txtProcurar.Enabled = true;
                txtProcurar.Visible = true;
                txtProcurar.Focus();
            }
        }

        #endregion MenuEditar

        #region MenuFerramentas
        private void exportarCriptografadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cripto = new Criptografia();
            string textoCripto = cripto.criptografar(txtTela.Text);
            cripto.salvarArquivoCripto(textoCripto);
        }



        #endregion MenuFerramentas

    }
}

