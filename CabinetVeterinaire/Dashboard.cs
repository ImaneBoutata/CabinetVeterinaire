namespace CabinetVeterinaire
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
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
    }



}