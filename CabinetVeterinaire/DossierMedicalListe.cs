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
    public partial class DossierMedicalListe : Form
    {
        public DossierMedicalAjout DossierMedicalAjout;
        public DossierMedicalListe()
        {
            InitializeComponent();
            DossierMedicalAjout = new DossierMedicalAjout(this);
            Display();
        }

        public void Display()
        {
            DossierMedicaldb.DisplayAndSearch("SELECT  ID,NOMANIMAL,diagnostic,vaccin,ordonance,analyseMedical,radiologie FROM DOSSIERMEDICAL", dossiergrid);
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                DossierMedicalAjout.Clear();
                DossierMedicalAjout.id = Convert.ToInt16(dossiergrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                DossierMedicalAjout.nomAnimal = dossiergrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                DossierMedicalAjout.diagnostic = dossiergrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                DossierMedicalAjout.vaccin = dossiergrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                DossierMedicalAjout.ordonance = dossiergrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                DossierMedicalAjout.analyseMedical = dossiergrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                DossierMedicalAjout.radiologie = dossiergrid.Rows[e.RowIndex].Cells[8].Value.ToString();
                DossierMedicalAjout.UpdateInfo();
                DossierMedicalAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer ce dossier ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DossierMedicaldb.DeleteDossierMedical(Convert.ToInt32(dossiergrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DossierMedicalAjout d = new DossierMedicalAjout(this);
            d.Show();
        }
    }
}
