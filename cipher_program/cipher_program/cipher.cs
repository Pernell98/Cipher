using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cipher_program //Message-Digest Algorithm 5 (MD5)
{
    public partial class frmEncryptandDecrypt : Form
    {
        public frmEncryptandDecrypt()
        {
            InitializeComponent();
        }

        string hash = "f0xle@rn";
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(txtValue.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) //CipherMode.ECB considered a weakness
                {
                    ICryptoTransform transform = tripDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    txtEncrypt.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            byte[] data = Convert.FromBase64String(txtEncrypt.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) //CipherMode.ECB considered a weakness
                {
                    ICryptoTransform transform = tripDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    txtDecrypt.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtValue.Clear();
            txtEncrypt.Clear();
            txtDecrypt.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmEncryptandDecrypt_Load(object sender, EventArgs e)
        {

        }
    }
}
