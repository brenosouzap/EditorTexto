using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace EditorTexto
{
    class Criptografia : Form1
    {
        private byte[] textoCifrado;
        private byte[] sal = new byte[] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x5, 0x4, 0x3, 0x2, 0x1, 0x0 };
        private string senha = "";

        public string criptografar(string textoTela)
        {
            string senha = "TEditSoftware";
            string mensagem = textoTela;
            string resultado = "";

            if (textoTela == string.Empty)
            {
                MessageBox.Show("Nao existe nada na tela para ser encriptado.", "Encriptação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }

            Rfc2898DeriveBytes chave = new Rfc2898DeriveBytes(senha, sal);

            var algoritmo = new RijndaelManaged();

            algoritmo.Key = chave.GetBytes(16);
            algoritmo.IV = chave.GetBytes(16);

            byte[] fonteBytes = new UnicodeEncoding().GetBytes(mensagem);

            using (var StreamFonte = new MemoryStream(fonteBytes))
            {
                using (MemoryStream StreamDestino = new MemoryStream())
                {
                    using (CryptoStream crypto = new CryptoStream(StreamFonte, algoritmo.CreateEncryptor(), CryptoStreamMode.Read))
                    {
                        moveBytes(crypto, StreamDestino);

                        textoCifrado = StreamDestino.ToArray();
                    }
                }
            }

            return resultado += Convert.ToBase64String(textoCifrado) + Environment.NewLine;
        }

        public bool salvarArquivoCripto(string textoEncriptado)
        {
            if (textoEncriptado == string.Empty)
                return false;

            string arquivoCripto;

            SaveFileDialog sfdSalvarComo = new SaveFileDialog();

            sfdSalvarComo.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            var opcao = sfdSalvarComo.ShowDialog();

            if (opcao == DialogResult.OK)
            {
                arquivoCripto = sfdSalvarComo.FileName;

                using (var arq = new StreamWriter(arquivoCripto, false))
                {
                    arq.WriteLine(textoEncriptado);
                }

                if (File.Exists(arquivoCripto))
                    MessageBox.Show("Arquivo criptografado gerado com sucesso.", "Criptografia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Erro ao gerar arquivo.", "Criptografia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        public void moveBytes(Stream fonte, Stream destino)
        {
            byte[] bytes = new byte[2049];
            var contador = fonte.Read(bytes, 0, bytes.Length - 1);
            while (contador != 0)
            {
                destino.Write(bytes, 0, contador);
                contador = fonte.Read(bytes, 0, bytes.Length - 1);
            }
        }

        private string leituraArquivoDescripto(string textoTela)
        {
            using (var arquivo = new StreamReader(@"C:\Users\edmar\Desktop\arquivo.txt", false))
            {
                string linha;

                while ((linha = arquivo.ReadLine()) != null)
                {
                    if (linha == null)
                        break;

                    textoTela += linha + "\n";
                }
            }

            return textoTela;
        }

        public string descriptografar(string textoTela)
        {
            //string textoDescripto = textoParaDescriptografa(textoTela);
            //byte[] textoCifrado = Encoding.ASCII.GetBytes(textoDescripto);
            byte[] textoCifrado = File.ReadAllBytes(@"C:\Users\edmar\Desktop\arquivo.txt");
            string mensagemDescriptografada;

            //if ((textoCifrado == null))
            //{
            //    MessageBox.Show("Os dados não estão criptografados!");
            //    return;
            //}

            Rfc2898DeriveBytes chave = new Rfc2898DeriveBytes(senha, sal);
            var algoritmo = new RijndaelManaged();
            algoritmo.Key = chave.GetBytes(16);
            algoritmo.IV = chave.GetBytes(16);
            string path = @"C:\Users\edmar\Desktop\arquivo.txt";

            using (var StreamFonte = new MemoryStream(textoCifrado))
            {
                using (MemoryStream StreamDestino = new MemoryStream())
                {
                    using (CryptoStream crypto = new CryptoStream(StreamFonte, algoritmo.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        moveBytes(crypto, StreamDestino);
                        byte[] bytesDescriptografados = StreamDestino.ToArray();
                        mensagemDescriptografada = new UnicodeEncoding().GetString(bytesDescriptografados);
                        File.WriteAllBytes(path, textoCifrado);
                        txtTela.Text = mensagemDescriptografada;
                    }
                }
            }
            return mensagemDescriptografada;
        }
    }
}
