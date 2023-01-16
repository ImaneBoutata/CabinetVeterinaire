using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetVeterinaire
{
    public partial class ClientAjout : Form
    {
        private readonly ClientListe _parent;

       public int id;
        public string nom, prenom, CIN, email, adresse, telephone;
       
        public ClientAjout(ClientListe parent)
        {
            _parent = parent;
            InitializeComponent();
            
        }
        public void UpdateInfo()
        {
           // textForm.Text = "Modifier un client ";
            ajouterbtn.Text = "Modifier";
            nomBox.Text = nom;
            prenomBox.Text = prenom;
            cinBox.Text = CIN;
            emailBox.Text = email;
            adresseBox.Text= adresse;
            telephoneBox.Text= telephone;


        }
        public void Clear()
        {
            nomBox.Text = prenomBox.Text = cinBox.Text = emailBox.Text = adresseBox.Text = telephoneBox.Text = String.Empty;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ajouterbtn.Text == "Ajouter")
            {

                Client c = new Client(nomBox.Text.Trim(), prenomBox.Text.Trim(), cinBox.Text.Trim(), emailBox.Text.Trim(),adresseBox.Text.Trim(),telephoneBox.Text.Trim());
                Clientdb.AddClient(c);
                Clear();

            }
            if (ajouterbtn.Text == "Modifier")
            {

                Client c = new Client(nomBox.Text.Trim(), prenomBox.Text.Trim(), cinBox.Text.Trim(), emailBox.Text.Trim(), adresseBox.Text.Trim(), telephoneBox.Text.Trim());

                Clientdb.UpdateClient(c, id);
                Clear();

            }
            _parent.Display();
        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
