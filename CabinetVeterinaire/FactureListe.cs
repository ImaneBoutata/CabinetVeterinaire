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
    public partial class FactureListe : Form
    {
        public FactureAjout factureAjout;
        public FactureListe()
        {
            InitializeComponent();
            factureAjout = new FactureAjout(this);
            Display();
        }

        public void Display()
        {
            Facturedb.DisplayAndSearch("SELECT  ID,CINCLIENT,NOMANIMAL,REFERENCE,MONTANT,MODEPAIEMENT FROM FACTURE", facturegrid);
        }
        private void clientgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
              //  factureAjout.Clear();
                factureAjout.id = Convert.ToInt16(facturegrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                factureAjout.cinClient = facturegrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                factureAjout.nomAnimal = facturegrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                factureAjout.reference = facturegrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                factureAjout.montant = Convert.ToDouble(facturegrid.Rows[e.RowIndex].Cells[6].Value.ToString());
                factureAjout.modePaiement = facturegrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                //factureAjout.UpdateInfo();
                factureAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer cette facture ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Facturedb.DeleteFacture(Convert.ToInt32(facturegrid.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FactureAjout a = new FactureAjout(this);
            a.Show();

        }
    }
}
