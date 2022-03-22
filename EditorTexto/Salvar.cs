using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace EditorTexto
{
    class Salvar : Form1
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

        public Task AutoSalvamentoArquivoAsync(bool flag, CancellationToken cancellationToken = default)
        {
            Task task = null;

            if (flag == true)
            {
                task = Task.Run(async () =>
                {
                    while (flag == true)
                    {
                        MessageBox.Show("Rodando...");
                        await Task.Delay(6000);
                    }
                });
            }

            if (flag == false)
            {
              
                // Arrumar o cancelamento da tarefa, porque esta fechando o editor
                if (cancellationToken.IsCancellationRequested == false)
                    try
                    {
                        throw new TaskCanceledException(task);
                    }
                    catch (TaskCanceledException)
                    {
                        MessageBox.Show("Tarefa cancelada.");
                    }

                return task;
            }

            return task;
        }
    }
}

