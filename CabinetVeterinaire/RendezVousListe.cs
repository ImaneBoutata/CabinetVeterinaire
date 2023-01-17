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
    public partial class RendezVousListe : Form
    {
        public RendezVousAjout rendezVousAjout;
        public RendezVousListe()
        {
            InitializeComponent();
            rendezVousAjout = new RendezVousAjout(this);
            Display();
        }

        public void Display()
        {
            Facturedb.DisplayAndSearch("SELECT  * FROM RENDEZVOUS", dataGridView1);
        }
        private void facturegrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.ColumnIndex == 0)
            {
                //Edit
                rendezVousAjout.Clear();
                rendezVousAjout.id = Convert.ToInt16(rdvgrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                rendezVousAjout.cinClient = rdvgrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                rendezVousAjout.nomAnimal = rdvgrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                rendezVousAjout.daterdv = rdvgrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                rendezVousAjout.heure = rdvgrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                rendezVousAjout.local = rdvgrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                rendezVousAjout.UpdateInfo();
                rendezVousAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer ce rdv ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    RendezVousdb.DeleteRdv(Convert.ToInt32(rdvgrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }*/
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RendezVousAjout r = new RendezVousAjout(this);
            r.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            ClientListe c = new ClientListe();
            c.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AnimalListe c = new AnimalListe();
            c.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FactureListe c = new FactureListe();
            c.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DossierMedicalListe c = new DossierMedicalListe();
            c.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UtilisateurListe c = new UtilisateurListe();
            c.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                rendezVousAjout.Clear();
                rendezVousAjout.id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                rendezVousAjout.cinClient = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                rendezVousAjout.nomAnimal = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                rendezVousAjout.daterdv = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                rendezVousAjout.heure = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                rendezVousAjout.local = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                rendezVousAjout.UpdateInfo();
                rendezVousAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer ce rdv ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    RendezVousdb.DeleteRdv(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }

        }
    }
}
