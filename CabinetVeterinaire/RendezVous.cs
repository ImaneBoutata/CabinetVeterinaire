using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    internal class RendezVous
    {
        String cinClient;
        String nomAnimal;
        String dateRdv;
        String heure;
        String local;

        public RendezVous(string cinClient, string nomAnimal, string dateRdv, string heure, string local)
        {
            this.cinClient = cinClient;
            this.nomAnimal = nomAnimal;
            this.dateRdv = dateRdv;
            this.heure = heure;
            this.local = local;

        }

        public string CinClient { get => cinClient; set => cinClient = value; }
        public string NomAnimal { get => nomAnimal; set => nomAnimal = value; }
        public string DateRdv { get => dateRdv; set => dateRdv = value; }
        public string Heure { get => heure; set => heure = value; }
        public string Local { get => local; set => local = value; }
    }
}
