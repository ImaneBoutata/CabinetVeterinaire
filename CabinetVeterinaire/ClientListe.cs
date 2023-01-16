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
    public partial class ClientListe : Form
    {
        public ClientAjout clientAjout;
        public ClientListe()
        {
            InitializeComponent();
             clientAjout = new ClientAjout(this);
            Display();
        }


        public void Display()
        {
            Clientdb.DisplayAndSearch("SELECT  ID,NOM,PRENOM,CIN,EMAIL,ADRESSE,TELEPHONE FROM CLIENT", clientgrid);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClientAjout c = new ClientAjout(this);
            c.Show();
            this.Hide();
        }

        
        private void clientgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                clientAjout.Clear();
                clientAjout.id = Convert.ToInt16(clientgrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                clientAjout.nom = clientgrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                clientAjout.prenom = clientgrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                clientAjout.CIN = clientgrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                clientAjout.email = clientgrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                clientAjout.adresse = clientgrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                clientAjout.telephone = clientgrid.Rows[e.RowIndex].Cells[8].Value.ToString();
                clientAjout.UpdateInfo();
                clientAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer ce client ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Clientdb.DeleteClient(Convert.ToInt32(clientgrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
