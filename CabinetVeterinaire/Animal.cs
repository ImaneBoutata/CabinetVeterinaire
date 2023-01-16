using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    internal class Animal
    {
        String cinClient;
        String nom;
        String categorie;
        int age;
        double poids;
        String sexe;
        String race;

        public Animal(String cinClient, string nom, string categorie, int age, double poids, string sexe, string race)
        {
            this.cinClient = cinClient;
            this.nom = nom;
            this.categorie = categorie;
            this.age = age;
            this.poids = poids;
            this.sexe = sexe;
            this.race = race;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public int Age { get => age; set => age = value; }
        public double Poids { get => poids; set => poids = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Race { get => race; set => race = value; }
        public string CinClient { get => cinClient; set => cinClient = value; }
    }
}
