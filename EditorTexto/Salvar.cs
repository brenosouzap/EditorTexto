using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EditorTexto
{
    class Salvar : Form1
    {
        public void salvar(string caminho, string texto, bool leituraArquivo)
        {
            try
            {
                using (var sw1 = new StreamWriter(caminho, leituraArquivo))
                {
                    sw1.WriteLine(texto);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Sem permissao para gravar o arquivo.");
            }
            catch (IOException)
            {
                MessageBox.Show("Erro ao ler ou gravar no arquivo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message: " + ex.Message);
            }
        }
    }
}
