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
            Animaldb.DisplayAndSearch("SELECT  ID,CINCLIENT,NOM,CATEGORIE,AGE,POIDS,SEXE,RACE FROM ANIMAL", animalgrid);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            }
        }
    }
}
