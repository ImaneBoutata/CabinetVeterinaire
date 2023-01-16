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
    public partial class listClient : Form
    {
        public listClient()
        {
            InitializeComponent();
            Display();
        }

        public void Display()
        {
            Clientdb.DisplayAndSearch("SELECT  ID,Nom,Prenom,Cin,email,adresse,telephone FROM CLIENT", clientgridview);
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.ColumnIndex == 0)
            {
                //Edit
                clientInterface.Clear();
                clientInterface.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                clientInterface.nom = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                clientInterface.prenom = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                clientInterface.CIN = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                clientInterface.UpdateInfo();
                clientInterface.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)

            //Delete
            {
                if (MessageBox.Show("Vous voulez vraiment supprimer ce client ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Clientdb.DeleteClient(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }


                return;
            }*/
        }
    }
}
