using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EditorTexto
{
    class Salvar
    {
        public void Salvamento(string caminho, string texto, bool leituraArquivo)
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

        async Task TempoAutoSalvamentoArquivo(bool flag)
        {
            if (flag == false) return;

            await Task.Delay(10);
        }

        public async void AutoSalvamentoArquivo(bool habilitaDesabilita)
        {
            if (habilitaDesabilita)
            {
                //while (habilitaDesabilita)
                //{
                await TempoAutoSalvamentoArquivo(habilitaDesabilita);
                MessageBox.Show("Passou um minuto.");
                //}
            }
        }
    }
}

