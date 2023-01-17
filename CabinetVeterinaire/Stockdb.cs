using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CabinetVeterinaire
{
    internal class Stockdb
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


        public static void AddStock(Stock c)
        {

            string sql = "INSERT INTO STOCK VALUES (NULL, @reference, @categorie, @qte, @prix)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@reference", MySqlDbType.VarChar).Value = c.Reference;
            cmd.Parameters.Add("@categorie", MySqlDbType.VarChar).Value = c.Categorie;
            cmd.Parameters.Add("@qte", MySqlDbType.VarChar).Value = c.Qte;
            cmd.Parameters.Add("@prix", MySqlDbType.VarChar).Value = c.PrixUnitaire;
          



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoutation avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("stock non ajouté. " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }



        public static void UpdateStock(Stock c, int id)
        {
            string sql = "Update STOCK SET reference=@reference,categorie=@categorie,qte=@qte, prix=@prix where id=@stockId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@stockId", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@reference", MySqlDbType.VarChar).Value = c.Reference;
            cmd.Parameters.Add("@categorie", MySqlDbType.VarChar).Value = c.Categorie;
            cmd.Parameters.Add("@qte", MySqlDbType.VarChar).Value = c.Qte;
            cmd.Parameters.Add("@prix", MySqlDbType.VarChar).Value = c.PrixUnitaire;
           



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modification avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Stock non modifié" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();


        }


        public static void DeleteStock(int id)
        {
            string sql = "DELETE from  STOCK where id=@stockId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@StockID", MySqlDbType.VarChar).Value = id;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("STOCK supprimer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("STOCK non supprimé " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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


    }
}
