using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CabinetVeterinaire
{
    internal class DossierMedicaldb
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


        public static void AddDossierMedical(DossierMedical c)
        {
            
            string sql = "INSERT INTO DossierMedical VALUES (NULL, @nomAnimal, @diagnostic, @vaccin, @ordonance, @analyseMedical, @radiologie, @image)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@nomAnimal", MySqlDbType.VarChar).Value = c.NomAnimal;
            cmd.Parameters.Add("@diagnostic", MySqlDbType.VarChar).Value = c.Diagnostic;
            cmd.Parameters.Add("@vaccin", MySqlDbType.VarChar).Value = c.Vaccin;
            cmd.Parameters.Add("@ordonance", MySqlDbType.VarChar).Value = c.Ordonance;
            cmd.Parameters.Add("@analyseMedical", MySqlDbType.VarChar).Value = c.AnalyseMedical;
            cmd.Parameters.Add("@radiologie", MySqlDbType.VarChar).Value = c.Radiologie;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = c.Image;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoutation avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Dossier non ajouté. " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }



        public static void UpdateDossierMedical(DossierMedical c, int id)
        {
            string sql = "Update DossierMedical SET nomAnimal=@nomAnimal,diagnostic=@diagnostic,vaccin=@vaccin, ordonance=@ordonance, AnalyseMedical=@AnalyseMedical, radiologie=@radiologie, image=@image where id=@dossierMedicalId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DossierMedicalid", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@nomAnimal", MySqlDbType.VarChar).Value = c.NomAnimal;
            cmd.Parameters.Add("@diagnostic", MySqlDbType.VarChar).Value = c.Diagnostic;
            cmd.Parameters.Add("@vaccin", MySqlDbType.VarChar).Value = c.Vaccin;
            cmd.Parameters.Add("@ordonance", MySqlDbType.VarChar).Value = c.Ordonance;
            cmd.Parameters.Add("@analyseMedical", MySqlDbType.VarChar).Value = c.AnalyseMedical;
            cmd.Parameters.Add("@radiologie", MySqlDbType.VarChar).Value = c.Radiologie;
            cmd.Parameters.Add("@image", MySqlDbType.VarChar).Value = c.Image;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modification avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("dossier non modifié" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();


        }


        public static void DeleteDossierMedical(int id)
        {
            string sql = "DELETE from  dossierMedical where id=@dossierMedicalId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@DossierMedicalID", MySqlDbType.VarChar).Value = id;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("DossierMedical supprimer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DossierMedical non supprimé " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            tbl.Columns.Add("PICTURE", Type.GetType("System.Byte[]"));
            foreach (DataRow row in tbl.Rows)
            {
                row["PICTURE"] = File.ReadAllBytes(Application.StartupPath + @"/image/" + Path.GetFileName(row["image"].ToString()));
            }
            dgv.DataSource = tbl;
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
