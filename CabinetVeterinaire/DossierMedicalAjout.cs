using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetVeterinaire
{
    public partial class DossierMedicalAjout : Form
    {
        public int id;
        public string nomAnimal, diagnostic, vaccin, ordonance, analyseMedical, radiologie;
        public Image image;

        private void DossierMedicalAjout_Load(object sender, EventArgs e)
        {
            Facturedb.DisplayComboBoxAnimal("SELECT NOM FROM ANIMAL", AnimalCombo);

        }

         private readonly DossierMedicalListe _parent;
        public DossierMedicalAjout(DossierMedicalListe parent)
        {
              _parent = parent;
            InitializeComponent();
        }


        public void UpdateInfo()
        {
            // textForm.Text = "Modifier un client ";
            Ajouterbtn.Text = "Modifier";
            AnimalCombo.Text = nomAnimal;
           // diagnostic.Text = nomAnimal;
            vaccinbox.Text = vaccin;
            ordonancebox.Text = ordonance;
            analysebox.Text = analyseMedical;
            radiologiebox.Text = radiologie;


        }
        public void Clear()
        {
            AnimalCombo.Text /*= AnimalCombo.Text*/ = vaccinbox.Text = ordonancebox.Text = analysebox.Text = radiologiebox.Text = String.Empty;
        }

        private void Ajouterbtn_Click(object sender, EventArgs e)
        {
            if (Ajouterbtn.Text == "Ajouter")
            {

                DossierMedical c = new DossierMedical(AnimalCombo.Text.Trim(), diagnostic, vaccinbox.Text.Trim(), ordonancebox.Text.Trim(), analysebox.Text.Trim(), radiologiebox.Text.Trim());
                DossierMedicaldb.AddDossierMedical(c);
               // Clear();

            }
            if (Ajouterbtn.Text == "Modifier")
            {

               DossierMedical c = new DossierMedical(AnimalCombo.Text.Trim(), diagnostic, vaccinbox.Text.Trim(), ordonancebox.Text.Trim(), analysebox.Text.Trim(), radiologiebox.Text.Trim());

                DossierMedicaldb.UpdateDossierMedical(c, id);
               // Clear();

            }
           // _parent.Display();
        }


        

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
             OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                string filePath = openFileDialog1.FileName;

                // Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    // Read the file and do something with the contents
                    string fileContent = reader.ReadToEnd();
                    // ...
                    //MessageBox.Show(fileContent);
                    diagnostic = filePath;
                    string imagePath = diagnostic;
                     image = Image.FromFile(imagePath);
                } 

               
            }
        }
    }
}
