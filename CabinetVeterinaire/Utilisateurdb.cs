using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CabinetVeterinaire
{
    internal class Utilisateurdb
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


        public static void AddUtilisateur(Utilisateur c)
        {

            string sql = "INSERT INTO UTILISATEUR VALUES (NULL, @nom, @prenom, @login, @password, @role, @email, @telephone)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = c.Nom;
            cmd.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = c.Prenom;
            cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = c.Login;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = c.Password;
            cmd.Parameters.Add("@role", MySqlDbType.VarChar).Value = c.Role;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = c.Email;
            cmd.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = c.Telephone;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoutation avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("User non ajouté. " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }



        public static void UpdateUtilisateur(Utilisateur c, int id)
        {
            string sql = "Update UTILISATEUR SET nom=@nom,prenom=@prenom,login=@login, password=@password, role=@role, email=@email, telephone=@telephone where id=@utilisateurId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Utilisateurid", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = c.Nom;
            cmd.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = c.Prenom;
            cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = c.Login;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = c.Password;
            cmd.Parameters.Add("@role", MySqlDbType.VarChar).Value = c.Role;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = c.Email;
            cmd.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = c.Telephone;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modification avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("user non modifié" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();


        }


        public static void DeleteUtilisateur(int id)
        {
            string sql = "DELETE from  UTILISATEUR where id=@utilisateurId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@UtilisateurID", MySqlDbType.VarChar).Value = id;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("user supprimer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("user non supprimé " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();



        }


        public static Boolean seConnecter(String login, String password)
        {
            int i = 0;

            if (login != "" && password != "")
            {
                try
                {
                    i = 0;
                    string sql = "select login, password from utilisateur WHERE login = @login AND password = @password";
                    MySqlConnection con = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    i = Convert.ToInt32(tbl.Rows.Count.ToString());
                    if (i == 0)

                    {
                        MessageBox.Show("Nom d'utilisateur ou mot de passe est incorrect.\n", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }

                    else
                    {
                        con.Close();
                        return true;
                        //  main_form();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe est incorrect.\n" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {

                MessageBox.Show("Les champs vide!!.\n", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;


            }
            return true;

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
