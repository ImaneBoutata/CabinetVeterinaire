using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CabinetVeterinaire
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public byte[] key = Encoding.UTF8.GetBytes("kdjfzel5zkd6eonf");
        public byte[] iv = Encoding.UTF8.GetBytes("ptrg9rej3ef5rjg6");
        private void sign_Click(object sender, EventArgs e)
        {
            //string decryptedPassword = AesCryp.Decrypt(passwordbox.Text, key, iv);

            if (Utilisateurdb.seConnecter(loginbox.Text, passwordbox.Text) == true)
            {
                Dashboard d = new Dashboard();

                d.Show();
                this.Hide();

            }
        }
    }
}
