using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CabinetVeterinaire
{
    public partial class RendezVousAjout : Form
    {
        private readonly RendezVousListe _parent;

        public int id;
        public string cinClient, nomAnimal, daterdv, heure, local;
        public RendezVousAjout(RendezVousListe parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RendezVousAjout_Load(object sender, EventArgs e)
        {
            RendezVousdb.DisplayComboBoxClient("SELECT CIN FROM CLIENT", ClientCombo);
            RendezVousdb.DisplayComboBoxAnimal("SELECT NOM FROM ANIMAL", AnimalCombo);
        }

        public void UpdateInfo()
        {
            // textForm.Text = "Modifier un client ";
            Ajouterbtn.Text = "Modifier";
            ClientCombo.Text = cinClient;
            AnimalCombo.Text = nomAnimal;
            heureBox.Text = heure;
            localbox.Text = local;
            daterdvpicker.Text = daterdv;


        }
        public void Clear()
        {
            ClientCombo.Text = AnimalCombo.Text = heureBox.Text = localbox.Text = daterdvpicker.Text = String.Empty;
        }

        private void Ajouterbtn_Click(object sender, EventArgs e)
        {
            if (Ajouterbtn.Text == "Ajouter")
            {

                RendezVous c = new RendezVous(ClientCombo.Text.Trim(), AnimalCombo.Text.Trim(), daterdvpicker.Text.Trim(), heureBox.Text.Trim(), localbox.Text.Trim());
                RendezVousdb.AddRdv(c);
                Clear();

            }
            if (Ajouterbtn.Text == "Modifier")
            {

                RendezVous c = new RendezVous(ClientCombo.Text.Trim(), AnimalCombo.Text.Trim(), daterdvpicker.Text.Trim(), heureBox.Text.Trim(), localbox.Text.Trim());

                RendezVousdb.UpdateRdv(c, id);
                Clear();

            }
            _parent.Display();
        }
    }
}
