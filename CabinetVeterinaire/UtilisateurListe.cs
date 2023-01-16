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
    public partial class UtilisateurListe : Form
    {
        public UtilisateurAjout utilisateurAjout;
        public UtilisateurListe()
        {
            InitializeComponent();
            utilisateurAjout = new UtilisateurAjout(this);
            Display();
        }

        public void Display()
        {
            Utilisateurdb.DisplayAndSearch("SELECT  * FROM UTILISATEUR", usergrid);
        }
        private void rdvgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                //Edit
                utilisateurAjout.Clear();
                utilisateurAjout.id = Convert.ToInt16(usergrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                utilisateurAjout.nom = usergrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                utilisateurAjout.prenom = usergrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                utilisateurAjout.login = usergrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                utilisateurAjout.password = usergrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                utilisateurAjout.role = usergrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                utilisateurAjout.email = usergrid.Rows[e.RowIndex].Cells[8].Value.ToString();
                utilisateurAjout.telephone = usergrid.Rows[e.RowIndex].Cells[9].Value.ToString();
                utilisateurAjout.UpdateInfo();
                utilisateurAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer cet utilisateur ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Utilisateurdb.DeleteUtilisateur(Convert.ToInt32(usergrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UtilisateurAjout u = new UtilisateurAjout(this);
            u.Show();
            this.Hide();
        }
    }
}
