using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CabinetVeterinaire
{
    internal class RendezVousdb
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


        public static void AddRdv(RendezVous c)
        {

            string sql = "INSERT INTO RendezVous VALUES (NULL, @cinClient, @nomAnimal, @dateRdv, @heure, @local)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@cinClient", MySqlDbType.VarChar).Value = c.CinClient;
            cmd.Parameters.Add("@nomAnimal", MySqlDbType.VarChar).Value = c.NomAnimal;
            cmd.Parameters.Add("@dateRdv", MySqlDbType.VarChar).Value = c.DateRdv;
            cmd.Parameters.Add("@heure", MySqlDbType.VarChar).Value = c.Heure;
            cmd.Parameters.Add("@local", MySqlDbType.VarChar).Value = c.Local;
          



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoutation avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("rdv non ajouté. " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }



        public static void UpdateRdv(RendezVous c, int id)
        {
            string sql = "Update RendezVous SET cinClient=@cinClient,nomAnimal=@nomAnimal,dateRdv=@dateRdv,heure=@heure, local=@local where id=@RendezVousId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Clientid", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@cinClient", MySqlDbType.VarChar).Value = c.CinClient;
            cmd.Parameters.Add("@nomAnimal", MySqlDbType.VarChar).Value = c.NomAnimal;
            cmd.Parameters.Add("@dateRdv", MySqlDbType.VarChar).Value = c.DateRdv;
            cmd.Parameters.Add("@heure", MySqlDbType.VarChar).Value = c.Heure;
            cmd.Parameters.Add("@local", MySqlDbType.VarChar).Value = c.Local;
     



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modification avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("rdv non modifié" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();


        }


        public static void DeleteRdv(int id)
        {
            string sql = "DELETE from  RendezVous where id=@rendezVousId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@RendezVousID", MySqlDbType.VarChar).Value = id;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("rdv supprimer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("rdv non supprimé " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();



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


        public static void DisplayComboBoxClient(string query, ComboBox c)
        {

            MySqlConnection con = GetConnection();

            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader mydr = cmd.ExecuteReader();

            while (mydr.Read())
            {
                //string subj = mydr.GetString("CIN");
                //c.Items.Add(subj);
                c.Items.Add(mydr.GetString("cin"));
            }

        }

        public static void DisplayComboBoxAnimal(string query, ComboBox c)
        {

            MySqlConnection con = GetConnection();

            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader mydr = cmd.ExecuteReader();

            while (mydr.Read())
            {
                //string subj = mydr.GetString("CIN");
                //c.Items.Add(subj);
                c.Items.Add(mydr.GetString("nom"));
            }

        }

    }
}
