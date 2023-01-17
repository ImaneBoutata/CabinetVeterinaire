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
    public partial class AnimalAjout : Form
    {
        public int id;
        public string cinClient, nom, categorie, sexe, race;
        public int age;
        public double poids;

        private readonly AnimalListe _parent;
        public AnimalAjout(AnimalListe parent)
        {
            _parent = parent;
            InitializeComponent();
           
        }

        private void animalnomBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateInfo()
        {
            // textForm.Text = "Modifier un client ";
            ajouterbtn.Text = "Modifier";
           // ClientCombo.Text = cinClient;
            comboBox1.Text = cinClient;
            animalnomBox.Text = nom;
            categorieBox.Text = categorie;
            ageBox.Text = age.ToString();
            poidsBox.Text = poids.ToString();
            sexeBox.Text = sexe;
            raceBox.Text = race;


        }
        public void Clear()
        {
            comboBox1.Text = animalnomBox.Text = categorieBox.Text = ageBox.Text = poidsBox.Text = sexeBox.Text = raceBox.Text = String.Empty;
        }

        private void AnimalAjout_Load(object sender, EventArgs e)
        {
            Animaldb.DisplayComboBoxClient("SELECT CIN FROM CLIENT", comboBox1);
        }

        
        private void ajouterbtn_Click(object sender, EventArgs e)
        {
            if (ajouterbtn.Text == "Ajouter")
            {

                Animal a = new Animal(comboBox1.Text, animalnomBox.Text.Trim(), categorieBox.Text.Trim(), Convert.ToInt16(ageBox.Text.Trim()), Convert.ToDouble(poidsBox.Text.Trim()), sexeBox.Text.Trim(), raceBox.Text.Trim());
                //textForm.Text = "Ajouter un client ";
                ajouterbtn.Text = "Ajouter";
               
                /*cinClient = ClientCombo.Text;
                nomAnimal = animalnomBox.Text;
                categorie = categorieBox.Text;

                age = Convert.ToInt16(ageBox.Text);
                poids = Convert.ToDouble(poidsBox.Text);
                sexe = sexeBox.Text;
                race = raceBox.Text;*/
                Animaldb.AddAnimal(a);
                 Clear();

            }
            if (ajouterbtn.Text == "Modifier")
            {

                Animal a = new Animal(comboBox1.Text, animalnomBox.Text.Trim(), categorieBox.Text.Trim(), Convert.ToInt16(ageBox.Text.Trim()), Convert.ToDouble(poidsBox.Text.Trim()), sexeBox.Text.Trim(), raceBox.Text.Trim());

                Animaldb.UpdateAnimal(a, id);
                Clear();

            }
             _parent.Display();
        }
    }
}
