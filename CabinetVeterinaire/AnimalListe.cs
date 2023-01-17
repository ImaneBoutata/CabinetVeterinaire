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
    public partial class AnimalListe : Form
    {
        public AnimalAjout animalAjout;
        public AnimalListe()
        {
            animalAjout = new AnimalAjout(this);
            InitializeComponent();
            Display();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AnimalAjout c = new AnimalAjout(this);
            c.Show();
            this.Hide();
        }
        public void Display()
        {
            Animaldb.DisplayAndSearch("SELECT  * FROM ANIMAL", datagrid1);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {/*

            if (e.ColumnIndex == 0)
            {
                //Edit
                animalAjout.Clear();
                animalAjout.id = Convert.ToInt16(animalgrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                animalAjout.cinClient = animalgrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                animalAjout.nom = animalgrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                animalAjout.categorie = animalgrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                animalAjout.age = Convert.ToInt16(animalgrid.Rows[e.RowIndex].Cells[6].Value.ToString());
                animalAjout.poids = Convert.ToDouble(animalgrid.Rows[e.RowIndex].Cells[7].Value.ToString());
                animalAjout.sexe = animalgrid.Rows[e.RowIndex].Cells[8].Value.ToString();
                animalAjout.race = animalgrid.Rows[e.RowIndex].Cells[9].Value.ToString();
                animalAjout.UpdateInfo();
                animalAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer cet animal ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Animaldb.DeleteAnimal(Convert.ToInt32(animalgrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                animalAjout.Clear();
                animalAjout.id = Convert.ToInt16(datagrid1.Rows[e.RowIndex].Cells[2].Value.ToString());
                animalAjout.cinClient = datagrid1.Rows[e.RowIndex].Cells[3].Value.ToString();
                animalAjout.nom = datagrid1.Rows[e.RowIndex].Cells[4].Value.ToString();
                animalAjout.categorie = datagrid1.Rows[e.RowIndex].Cells[5].Value.ToString();
                animalAjout.age = Convert.ToInt16(datagrid1.Rows[e.RowIndex].Cells[6].Value.ToString());
                animalAjout.poids = Convert.ToDouble(datagrid1.Rows[e.RowIndex].Cells[7].Value.ToString());
                animalAjout.sexe = datagrid1.Rows[e.RowIndex].Cells[8].Value.ToString();
                animalAjout.race = datagrid1.Rows[e.RowIndex].Cells[9].Value.ToString();
                animalAjout.UpdateInfo();
                animalAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer cet animal ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Animaldb.DeleteAnimal(Convert.ToInt32(datagrid1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            ClientListe c = new ClientListe();
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            RendezVousListe c = new RendezVousListe();
            c.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UtilisateurListe c = new UtilisateurListe();
            c.Show();
            this.Hide();
        }
    }
}
