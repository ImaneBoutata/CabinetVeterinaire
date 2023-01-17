using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    internal class Stock
    {
        String reference;
        String categorie;
        int qte;
        String prixUnitaire;

        public Stock(string reference, string categorie, int qte, string prixUnitaire)
        {
            this.reference = reference;
            this.categorie = categorie;
            this.qte = qte;
            this.prixUnitaire = prixUnitaire;
        }

        public string Reference { get => reference; set => reference = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public int Qte { get => qte; set => qte = value; }
        public string PrixUnitaire { get => prixUnitaire; set => prixUnitaire = value; }
    }
}
