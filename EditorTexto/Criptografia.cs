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
    class Criptografia : HashAlgorithm
    {
        HashAlgorithm algoritmo { get; set; }

        public Criptografia(HashAlgorithm algoritmo)
        {
            this.algoritmo = algoritmo;
        }

        public string criptografa(string textoTela)
        {
            var valorCodificado = Encoding.UTF8.GetBytes(textoTela);
            var senhaCifrada = algoritmo.ComputeHash(valorCodificado);
            var sb = new StringBuilder();

            foreach (var caractere in senhaCifrada)
            {
                sb.Append(caractere.ToString("X2"));
            }

            return sb.ToString();
        }

        private void descriptografa(string senhaDigitada, string senhaCadastrada)
        {
            
        }

        //private bool verificaHash(string senhaDigitada, string senhaCadastrada)
        //{
        //    var senhaCifrada = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

        //    if (string.IsNullOrEmpty(senhaCadastrada))
        //        throw new NullReferenceException("Cadastre uma senha.");

        //    var sb = new StringBuilder();

        //    foreach (var caractere in senhaCifrada)
        //    {
        //        sb.Append(caractere.ToString("X2"));
        //    }
        //    return sb.ToString() == senhaCadastrada;
        //}

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            throw new NotImplementedException();
        }

        protected override byte[] HashFinal()
        {
            throw new NotImplementedException();
        }
    }
}
