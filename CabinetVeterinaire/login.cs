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
            if (Utilisateurdb.seConnecter(textBox1.Text, textBox2.Text) == true)
            {
                Dashbord d = new Dashbord();

                d.Show();
                this.Hide();

            }
        }
    }
}
