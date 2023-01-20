using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace CabinetVeterinaire
{
    internal class Clientdb
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=cabinetVeterinaire";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("MySql connection !" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return conn;

        }


        public static void AddClient(Client c)
        {

            string sql = "INSERT INTO CLIENT VALUES (NULL, @nom, @prenom, @cin, @email, @adresse, @telephone)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = c.Nom;
            cmd.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = c.Prenom;
            cmd.Parameters.Add("@cin", MySqlDbType.VarChar).Value = c.Cin;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = c.Email;
            cmd.Parameters.Add("@adresse", MySqlDbType.VarChar).Value = c.Adresse;
            cmd.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = c.Telephone;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoutation avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Client non ajouté. " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }



        public static void UpdateClient(Client c, int id)
        {
            string sql = "Update CLIENT SET nom=@nom,prenom=@prenom,cin=@cin, email=@email, adresse=@adresse, telephone=@telephone where id=@clientId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Clientid", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = c.Nom;
            cmd.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = c.Prenom;
            cmd.Parameters.Add("@cin", MySqlDbType.VarChar).Value = c.Cin;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = c.Email;
            cmd.Parameters.Add("@adresse", MySqlDbType.VarChar).Value = c.Adresse;
            cmd.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = c.Telephone;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modification avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Client non modifié" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();


        }


        public static void DeleteClient(int id)
        {
            string sql = "DELETE from  CLIENT where id=@clientId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@ClientID", MySqlDbType.VarChar).Value = id;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client supprimer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Client non supprimé " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }

        public static void conditionEmail(string query)
        {
            

            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader mydr = cmd.ExecuteReader();

            while (mydr.Read())
            {
                notifs();

            }
           
        }

       /* public static string findByCin(String cin)
        {

        }*/

        public static void notifs()
        {
            MailMessage mail = new MailMessage("homesmart437@gmail.com", "imanebt6@gmail.com", "suuject", "Bonjour Mr/Mme, la date de votre rendez-vous approche");
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            // client.Port = 465;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("homesmart437@gmail.com", "hmsrctkhxrweeejs");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Send(mail);
            //MessageBox.Show("Success");
        }
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }


    }
}
