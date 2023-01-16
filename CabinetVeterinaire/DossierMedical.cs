using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    internal class DossierMedical
    {
        String nomAnimal;
        String diagnostic;
        String vaccin;
        String ordonance;
        String analyseMedical;
        String radiologie;

        public DossierMedical(String nomAnimal, string diagnostic, string vaccin, string ordonance, string analyseMedical, string radiologie)
        {
            this.nomAnimal = nomAnimal;
            this.diagnostic = diagnostic;
            this.vaccin = vaccin;
            this.ordonance = ordonance;
            this.analyseMedical = analyseMedical;
            this.radiologie = radiologie;
          
        }

        public string Diagnostic { get => diagnostic; set => diagnostic = value; }
        public string Vaccin { get => vaccin; set => vaccin = value; }
        public string Ordonance { get => ordonance; set => ordonance = value; }
        public string AnalyseMedical { get => analyseMedical; set => analyseMedical = value; }
        public string Radiologie { get => radiologie; set => radiologie = value; }
        public string NomAnimal { get => nomAnimal; set => nomAnimal = value; }
    }
}
