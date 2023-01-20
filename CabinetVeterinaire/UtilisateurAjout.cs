using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetVeterinaire
{

    public partial class UtilisateurAjout : Form
    {
        private readonly UtilisateurListe _parent;
        public string nom, prenom, login, password, email, telephone, role, encryptedPassword, decryptedPassword;
        public byte[] key = Encoding.UTF8.GetBytes("kdjfzel5zkd6eonf");
        public byte[] iv = Encoding.UTF8.GetBytes("ptrg9rej3ef5rjg6");
        /*  // Encrypt the password
          string password = "mypassword";
          string encryptedPassword = Encrypt(password, key, iv);
          Console.WriteLine("Encrypted password: " + encryptedPassword);

          // Decrypt the password
          string decryptedPassword = Decrypt(encryptedPassword, key, iv);
          Console.WriteLine("Decrypted password: " + decryptedPassword);*/

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public int id;
        public UtilisateurAjout(UtilisateurListe parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        public void UpdateInfo()
        {
            // textForm.Text = "Modifier un client ";
            Ajouterbtn.Text = "Modifier";
            nombox.Text = nom;
            prenombox.Text = prenom;
            loginbox.Text = login;
            passwordbox.Text = password;
            emailbox.Text = email;
            telephonebox.Text = telephone;
            rolebox.Text = role;


        }
        public void Clear()
        {
            nombox.Text = prenombox.Text = loginbox.Text = passwordbox.Text = rolebox.Text = emailbox.Text = telephonebox.Text= String.Empty;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Ajouterbtn.Text == "Ajouter")
            {
                encryptedPassword = AesCryp.Encrypt(passwordbox.Text, key, iv);
                Utilisateur c = new Utilisateur(nombox.Text.Trim(), prenombox.Text.Trim(), loginbox.Text.Trim(), encryptedPassword, rolebox.Text.Trim(), emailbox.Text.Trim(), telephonebox.Text.Trim());
                Utilisateurdb.AddUtilisateur(c);
                Clear();

            }
            if (Ajouterbtn.Text == "Modifier")
            {
                encryptedPassword = AesCryp.Encrypt(passwordbox.Text, key, iv);
                Utilisateur c = new Utilisateur(nombox.Text.Trim(), prenombox.Text.Trim(), loginbox.Text.Trim(), encryptedPassword, rolebox.Text.Trim(), emailbox.Text.Trim(), telephonebox.Text.Trim());

                Utilisateurdb.UpdateUtilisateur(c, id);
                Clear();

            }
            _parent.Display();
        }
    }
}
