using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;

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
            Facturedb.DisplayAndSearch("SELECT  ID,CINCLIENT,NOMANIMAL,REFERENCE,MONTANT,MODEPAIEMENT FROM FACTURE", dataGridView1);
        }
        private void clientgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {/*
            if (e.ColumnIndex == 0)
            {
                //Edit
                factureAjout.Clear();
                factureAjout.id = Convert.ToInt16(facturegrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                factureAjout.cinClient = facturegrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                factureAjout.nomAnimal = facturegrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                factureAjout.reference = facturegrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                factureAjout.montant = Convert.ToDouble(facturegrid.Rows[e.RowIndex].Cells[6].Value.ToString());
                factureAjout.modePaiement = facturegrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                factureAjout.UpdateInfo();
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
            }*/
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FactureAjout a = new FactureAjout(this);
            a.Show();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                factureAjout.Clear();
                factureAjout.id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                factureAjout.cinClient = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                factureAjout.nomAnimal = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                factureAjout.reference = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                factureAjout.montant = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                factureAjout.modePaiement = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                factureAjout.UpdateInfo();
                factureAjout.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer cette facture ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Facturedb.DeleteFacture(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    Display();
                }


                return;
            }

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            StockListecs c = new StockListecs();
            c.Show();
            this.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Result.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            // pTable.HorizontalAlignment = Element.a;

                            foreach (DataGridViewColumn col in dataGridView1.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new iTextSharp.text.Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {


                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }


                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {
                                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                foreach (DataGridViewRow viewRow in dataGridView1.Rows)

                                {
                                    string path = viewRow.Cells[6].Value.ToString();
                                    document.Open();

                                    document.Add(pTable);


                                }







                                document.Close();
                                fileStream.Close();

                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
