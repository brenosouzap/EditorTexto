using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;


namespace EditorTexto
{
    class Criptografia
    {
        string nomeArquivo { get; set; }

        public Criptografia(string nomeArquivo)
        {
            this.nomeArquivo = nomeArquivo;
        }

        private void criarChave()
        {
            
        }

        private void criptografia()
        {
            //return textoCrip;
        }

        private void descriptografia()
        {
            //return textoDescrip;
        }

        private void exportar(string nomeArquivo)
        {
            string textoCrip;

            using (var escreverDados = new StreamWriter(nomeArquivo, false))
            {
                escreverDados.WriteLine(nomeArquivo);
            }

            //return textoCrip;
        }

        private void importar(string nomeArquivo)
        {
            string textoDescrip;

            using (var escreverDados = new StreamReader(nomeArquivo, false))
            {
                
            }

            //return textoDescrip;
        }
    }
}
