using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    internal class Client
    {
        String nom;
        String prenom;
        String cin;
        String email;
        String adresse;
        String telephone;


        public Client(string nom, string prenom, string cin, string email, string adresse, string telephone)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            this.email = email;
            this.adresse = adresse;
            this.telephone = telephone;
        
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Cin { get => cin; set => cin = value; }
        public string Email { get => email; set => email = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        
    }
}
