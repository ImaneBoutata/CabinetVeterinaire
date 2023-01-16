using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    internal class Veterinaire
    {
        String nom;
        String prenom;
        String email;
        String cin;
        String adresse;
        String telephone;

        public Veterinaire(string nom, string prenom, string email, String cin, string adresse, String telephone)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.cin = cin;
            this.adresse = adresse;
            this.telephone = telephone;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Cin { get => cin; set => cin = value; }
        public string Telephone { get => telephone; set => telephone = value; }
    }
}
