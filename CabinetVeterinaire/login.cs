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

        private void sign_Click(object sender, EventArgs e)
        {
            if (Utilisateurdb.seConnecter(loginbox.Text, passwordbox.Text) == true)
            {
                Dashboard d = new Dashboard();

                d.Show();
                this.Hide();

            }
        }
    }
}
