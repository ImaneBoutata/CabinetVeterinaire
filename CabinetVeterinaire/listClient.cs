using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetVeterinaire
{
    public partial class listClient : Form
    {
        public listClient()
        {
            InitializeComponent();
           
        }

      

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            int a = RendezVousdb.howMany("select * from animal where categorie='chat'");
            int b = RendezVousdb.howMany("select * from animal where categorie='chien'");
            int c = RendezVousdb.howMany("select * from animal where categorie='oiseau'");
             //double[] values = { 789, 143, 283 };
             double[] values = { a, b, c };
             string[] labels = { "chat", "chien", "oiseau" };
             Color[] labelcolors = { Color.White, Color.White, Color.White, };
             Color[] slicecolors = { Color.Red, Color.Blue, Color.Gray };
             var pie = formsPlot1.Plot.AddPie(values);
             pie.SliceLabels = labels;
             pie.ShowLabels = true;
             pie.SliceFillColors = slicecolors;
             pie.SliceLabelColors = labelcolors;
             formsPlot1.Refresh();

        }
    }
    }

