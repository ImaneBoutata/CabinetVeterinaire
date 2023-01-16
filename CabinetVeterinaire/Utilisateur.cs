using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    internal class Utilisateur
    {
        String nom;
        String prenom;
        String login;
        String password;
        String role;
        String email;
        String telephone;

        public Utilisateur(string nom, string prenom, string login, string password, string role, string email, string telephone)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.login = login;
            this.password = password;
            this.role = role;
            this.email = email;
            this.telephone = telephone;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public string Email { get => email; set => email = value; }
        public string Telephone { get => telephone; set => telephone = value; }
    }
}
