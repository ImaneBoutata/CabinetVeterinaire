using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    internal class Facture
    {
        String cinClient;
        String nomAnimal;
        String reference;
        double montant;
        String modePaiement;


        public Facture(String cinClient, String nomAnimal, String reference,double montant, string modePaiement)
        {
            this.cinClient = cinClient;
            this.nomAnimal = nomAnimal;
            this.reference = reference;
            this.montant = montant;
            this.modePaiement = modePaiement;
        }

        public double Montant { get => montant; set => montant = value; }
        public string ModePaiement { get => modePaiement; set => modePaiement = value; }
        public string CinClient { get => cinClient; set => cinClient = value; }
        public string NomAnimal { get => nomAnimal; set => nomAnimal = value; }
        public string Reference { get => reference; set => reference = value; }
    }
}
