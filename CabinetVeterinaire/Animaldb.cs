using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CabinetVeterinaire
{
    internal class Animaldb
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


        public static void AddAnimal(Animal c)
        {
            string sql = "INSERT INTO ANIMAL VALUES (NULL, @cinClient, @nom, @categorie, @age, @poids, @sexe, @race)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@cinClient", MySqlDbType.VarChar).Value = c.CinClient;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = c.Nom;
            cmd.Parameters.Add("@categorie", MySqlDbType.VarChar).Value = c.Categorie;
            cmd.Parameters.Add("@age", MySqlDbType.VarChar).Value = c.Age;
            cmd.Parameters.Add("@poids", MySqlDbType.VarChar).Value = c.Poids;
            cmd.Parameters.Add("@sexe", MySqlDbType.VarChar).Value = c.Sexe;
            cmd.Parameters.Add("@race", MySqlDbType.VarChar).Value = c.Race;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoutation avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Animal non ajouté. " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }



        public static void UpdateAnimal(Animal c, int id)
        {
            string sql = "Update ANIMAL SET cinClient=@cinClient, nom=@nom,categorie=@categorie,age=@age, poids=@poids, sexe=@sexe, race=@race where id=@animalId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Animalid", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@cinClient", MySqlDbType.VarChar).Value = c.CinClient;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = c.Nom;
            cmd.Parameters.Add("@categorie", MySqlDbType.VarChar).Value = c.Categorie;
            cmd.Parameters.Add("@age", MySqlDbType.VarChar).Value = c.Age;
            cmd.Parameters.Add("@poids", MySqlDbType.VarChar).Value = c.Poids;
            cmd.Parameters.Add("@sexe", MySqlDbType.VarChar).Value = c.Sexe;
            cmd.Parameters.Add("@race", MySqlDbType.VarChar).Value = c.Race;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modification avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Animal non modifié" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();


        }


        public static void DeleteAnimal(int id)
        {
            string sql = "DELETE from  ANIMAL where id=@animalId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@AnimalID", MySqlDbType.VarChar).Value = id;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Animal supprimer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Animal non supprimé " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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


    }
}
