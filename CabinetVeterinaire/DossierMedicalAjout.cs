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
using Path = System.IO.Path;

namespace CabinetVeterinaire
{
    public partial class DossierMedicalAjout : Form
    {
        public int id;
        public string nomAnimal, diagnostic, vaccin, ordonance, analyseMedical, radiologie;
        public Image image;

        private void DossierMedicalAjout_Load(object sender, EventArgs e)
        {
            Facturedb.DisplayComboBoxAnimal("SELECT NOM FROM ANIMAL", comboBox1);

        }

         private readonly DossierMedicalListe _parent;

        private void chooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Choisir une Image(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imageText.Text = dlg.FileName;
                pictureBox1.Image = new Bitmap(dlg.FileName);
                pictureBox1.ImageLocation = dlg.FileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Choisir une Image(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imageText.Text = dlg.FileName;
                pictureBox1.Image = new Bitmap(dlg.FileName);
                pictureBox1.ImageLocation = dlg.FileName;
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        public DossierMedicalAjout(DossierMedicalListe parent)
        {
              _parent = parent;
            InitializeComponent();
        }


        public void UpdateInfo()
        {
            // textForm.Text = "Modifier un client ";
            Ajouterbtn.Text = "Modifier";
            comboBox1.Text = nomAnimal;
           // diagnostic.Text = nomAnimal;
            vaccinbox.Text = vaccin;
            diagnosticbox.Text = ordonance;
            analysebox.Text = analyseMedical;
            radiologiebox.Text = radiologie;


        }
        public void Clear()
        {
            comboBox1.Text /*= AnimalCombo.Text*/ = vaccinbox.Text = diagnosticbox.Text = analysebox.Text = radiologiebox.Text = String.Empty;
        }

        private void Ajouterbtn_Click(object sender, EventArgs e)
        {
            if (Ajouterbtn.Text == "Ajouter")
            {
                File.Copy(imageText.Text, Application.StartupPath + @"/image/" + Path.GetFileName(pictureBox1.ImageLocation));



                DossierMedical c = new DossierMedical(comboBox1.Text.Trim(), diagnosticbox.Text, vaccinbox.Text.Trim(), diagnosticbox.Text.Trim(), analysebox.Text.Trim(), radiologiebox.Text.Trim(), Path.GetFileName(pictureBox1.ImageLocation));
                DossierMedicaldb.AddDossierMedical(c);
               Clear();

            }
            if (Ajouterbtn.Text == "Modifier")
            {
                File.Copy(imageText.Text, Application.StartupPath + @"/image/" + Path.GetFileName(pictureBox1.ImageLocation));


                DossierMedical c = new DossierMedical(comboBox1.Text.Trim(), diagnosticbox.Text, vaccinbox.Text.Trim(), diagnosticbox.Text.Trim(), analysebox.Text.Trim(), radiologiebox.Text.Trim(), Path.GetFileName(pictureBox1.ImageLocation));

                DossierMedicaldb.UpdateDossierMedical(c, id);
                Clear();

            }
            _parent.Display();
        }


        

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
           /*  OpenFileDialog openFileDialog1 = new OpenFileDialog();
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

               
            }*/
        }
    }
}
