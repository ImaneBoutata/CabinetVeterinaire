using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CabinetVeterinaire
{
    public partial class FactureAjout : Form
    {
        public int id;
        public string cinClient, nomAnimal, reference, modePaiement;
        public double montant;
 

        private readonly FactureListe _parent;
        public FactureAjout(FactureListe parent)
        {
                _parent = parent;
            InitializeComponent();
        }

        public void UpdateInfo()
        {
            // textForm.Text = "Modifier un client ";
            Ajouterbtn.Text = "Modifier";
            comboBox1.Text = cinClient;
            comboBox2.Text = nomAnimal;
            referenceBox.Text = reference;
            montantBox.Text = montant.ToString();
            modeBox.Text = modePaiement;


        }
        public void Clear()
        {
            comboBox1.Text = comboBox2.Text = referenceBox.Text = montantBox.Text = modeBox.Text = String.Empty;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClientCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FactureAjout_Load(object sender, EventArgs e)
        {
            Facturedb.DisplayComboBoxClient("SELECT CIN FROM CLIENT", comboBox1);
            Facturedb.DisplayComboBoxAnimal("SELECT NOM FROM ANIMAL", comboBox2);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Ajouterbtn.Text == "Ajouter")
            {
                Facture f = new Facture(comboBox1.Text.Trim(), comboBox2.Text.Trim(), referenceBox.Text.Trim(), Convert.ToDouble(montantBox.Text.Trim()), modeBox.Text.Trim());
                Facturedb.AddFacture(f);
                  Clear();

            }
            if (Ajouterbtn.Text == "Modifier")
            {

                Facture f = new Facture(comboBox1.Text.Trim(), comboBox2.Text.Trim(), referenceBox.Text.Trim(), Convert.ToDouble(montantBox.Text.Trim()), modeBox.Text.Trim());

                Facturedb.UpdateFacture(f, id);
                  Clear();

            }
             _parent.Display();
        }
    }
}
