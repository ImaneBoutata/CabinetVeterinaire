using Bunifu.Charts.WinForms;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CabinetVeterinaire
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            formsPlot1.BackColor = Color.DarkGreen;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClientListe c = new ClientListe();
            c.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AnimalListe a = new AnimalListe();
            a.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FactureListe f  = new FactureListe();
            f.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DossierMedicalListe a = new DossierMedicalListe();
            a.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            RendezVousListe r = new RendezVousListe();
            r.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UtilisateurListe u = new UtilisateurListe();
            u.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            StockListecs c = new StockListecs();
            c.Show();
            this.Hide();
        }
        
        private void formsPlot1_Load(object sender, EventArgs e)
        {
            formsPlot1.BackColor = Color.DarkGreen;
            int a = RendezVousdb.howMany("select * from animal where categorie='chat'");
            int b = RendezVousdb.howMany("select * from animal where categorie='chien'");
            int c = RendezVousdb.howMany("select * from animal where categorie='oiseau'");
            int d = RendezVousdb.howMany("select * from animal where categorie='hamster'");
            //double[] values = { 789, 143, 283 };
            double[] values = { a, b, c,d };
            string[] labels = { "Chat", "Chien", "Oiseau", "Hamster" };
            formsPlot1.BackColor = Color.DarkGreen;
            Color[] labelcolors = { Color.White, Color.White, Color.White, Color.White };
            Color[] slicecolors = { System.Drawing.Color.FromArgb(129, 221, 182), System.Drawing.Color.FromArgb(6, 57, 112), System.Drawing.Color.FromArgb(118, 181, 197), System.Drawing.Color.FromArgb(226, 135, 67) };
            var pie = formsPlot1.Plot.AddPie(values);
            pie.SliceLabels = labels;
            pie.ShowLabels = true;
            pie.SliceFillColors = slicecolors;
            pie.SliceLabelColors = labelcolors;
            
            formsPlot1.Refresh();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            int a = RendezVousdb.howMany("select * from client");
            clientLabel.Text = a.ToString();

            int b = RendezVousdb.howMany("select * from animal");
            animalLabel.Text = b.ToString();
            
            int c = RendezVousdb.howMany("select * from rendezvous");
            rdvLabel.Text = c.ToString();

            chart();
        }
        
        public void chart()
        {

            MySqlConnection conn = new MySqlConnection("Datasource=localhost;database=cabinetVeterinaire;port=3306;username=root;password=");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM facture", conn);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            conn.Close();

            double[] dataX = new double[count];
            double[] dataY = new double[count];
            var plt = new ScottPlot.Plot(610, 404);
            String[] labels = new String[count];
            String[] ord = new String[count];


            MySqlConnection conn2 = new MySqlConnection("Datasource=localhost;database=cabinetVeterinaire;port=3306;username=root;password=");
            conn2.Open();
            MySqlCommand comm2 = new MySqlCommand("SELECT count(*) FROM facture group by cinClient", conn2);
            MySqlDataReader rdr;

            rdr = comm2.ExecuteReader();
            int i = 0;
            while (rdr.Read())
            {
                ord[i] = rdr.GetString(0);
                i++;
            }

            conn2.Close();



            MySqlConnection conn3 = new MySqlConnection("Datasource=localhost;database=cabinetVeterinaire;port=3306;username=root;password=");
            conn3.Open();
            MySqlCommand comm3 = new MySqlCommand("SELECT cinClient FROM facture group by cinClient", conn3);
            MySqlDataReader rdr3;

            rdr3 = comm3.ExecuteReader();
            int j = 0;
            while (rdr3.Read())
            {
                labels[j] = rdr3.GetString(0);
                j++;
            }

            conn3.Close();

            for (i = 0; i < count; i++)
            {
                dataY[i] = i;
            }

            for (i = 0; i < count; i++)
            {
                dataX[i] = Convert.ToInt32(ord[i]);
            }

            formsPlot2.Plot.AddBar(dataX, dataY, color: System.Drawing.Color.Lavender);
            formsPlot2.Plot.XTicks(dataY, labels);
            formsPlot2.Plot.SetAxisLimits(yMin: 0);
            formsPlot2.Refresh();
        }
        private void formsPlot2_Load(object sender, EventArgs e)
        {
           


        }
    }



}