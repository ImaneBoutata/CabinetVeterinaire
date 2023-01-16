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
            ClientCombo.Text = cinClient;
            AnimalCombo.Text = nomAnimal;
            referenceBox.Text = reference;
            montantBox.Text = montant.ToString();
            modeBox.Text = modePaiement;


        }
        public void Clear()
        {
            ClientCombo.Text = AnimalCombo.Text = referenceBox.Text = montantBox.Text = modeBox.Text = String.Empty;
        }

        private void ClientCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FactureAjout_Load(object sender, EventArgs e)
        {
            Facturedb.DisplayComboBoxClient("SELECT CIN FROM CLIENT", ClientCombo);
            Facturedb.DisplayComboBoxAnimal("SELECT NOM FROM ANIMAL", AnimalCombo);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Ajouterbtn.Text == "Ajouter")
            {
                Facture f = new Facture(ClientCombo.Text.Trim(), AnimalCombo.Text.Trim(), referenceBox.Text.Trim(), Convert.ToDouble(montantBox.Text.Trim()), modeBox.Text.Trim());
                //textForm.Text = "Ajouter un client ";
                Ajouterbtn.Text = "Ajouter";

                cinClient = ClientCombo.Text;
                nomAnimal = AnimalCombo.Text;
                reference = referenceBox.Text;
                montant = Convert.ToDouble(montantBox.Text);
                modePaiement = modeBox.Text;




                Facturedb.AddFacture(f);
                  Clear();

            }
            if (Ajouterbtn.Text == "Modifier")
            {

                Facture f = new Facture(ClientCombo.Text.Trim(), AnimalCombo.Text.Trim(), referenceBox.Text.Trim(), Convert.ToDouble(montantBox.Text.Trim()), modeBox.Text.Trim());

                Facturedb.UpdateFacture(f, id);
                  Clear();

            }
             _parent.Display();
        }
    }
}
