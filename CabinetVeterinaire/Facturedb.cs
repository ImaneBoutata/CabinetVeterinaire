using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CabinetVeterinaire
{
    internal class Facturedb
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


        public static void AddFacture(Facture c)
        {
            string sql = "INSERT INTO FACTURE VALUES (NULL, @cinClient, @nomAnimal, @reference, @montant, @modePaiement)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@cinClient", MySqlDbType.VarChar).Value = c.CinClient;
            cmd.Parameters.Add("@nomAnimal", MySqlDbType.VarChar).Value = c.NomAnimal;
            cmd.Parameters.Add("@reference", MySqlDbType.VarChar).Value = c.Reference;
            cmd.Parameters.Add("@montant", MySqlDbType.VarChar).Value = c.Montant;
            cmd.Parameters.Add("@modePaiement", MySqlDbType.VarChar).Value = c.ModePaiement;
     



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoutation avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("FACTURE non ajouté. " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }



        public static void UpdateFacture(Facture c, int id)
        {
            string sql = "Update FACTURE SET cinClient=@cinClient,nomAnimal=@nomAnimal,reference=@reference,montant=@montant, modePaiement=@modePaiement where id=@factureId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Factureid", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@cinClient", MySqlDbType.VarChar).Value = c.CinClient;
            cmd.Parameters.Add("@nomAnimal", MySqlDbType.VarChar).Value = c.NomAnimal;
            cmd.Parameters.Add("@reference", MySqlDbType.VarChar).Value = c.Reference;
            cmd.Parameters.Add("@montant", MySqlDbType.VarChar).Value = c.Montant;
            cmd.Parameters.Add("@modePaiement", MySqlDbType.VarChar).Value = c.ModePaiement;
         



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modification avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("FACTURE non modifié" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();


        }


        public static void DeleteFacture(int id)
        {
            string sql = "DELETE from  FACTURE where id=@factureId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@factureID", MySqlDbType.VarChar).Value = id;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("FACTURE supprimer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("FACTURE non supprimé " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
