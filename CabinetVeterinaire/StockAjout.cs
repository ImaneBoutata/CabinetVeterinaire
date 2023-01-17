﻿using System;
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
    public partial class StockAjout : Form
    {
        private readonly StockListecs _parent;
        public StockAjout(StockListecs parent)
        {
            _parent = parent;
            InitializeComponent();
        }
        public string reference, categorie, prix;
        public int id;
        public int qte;


        public void UpdateInfo()
        {
            // textForm.Text = "Modifier un client ";
            Ajouterbtn.Text = "Modifier";
            referencebox.Text = reference;
            CategorieCombo.Text = categorie;
            qtebox.Text = qte.ToString();
            prixbox.Text = prix;



        }
        public void Clear()
        {
            referencebox.Text = CategorieCombo.Text = qtebox.Text = prixbox.Text = String.Empty;
        }
        private void Ajouterbtn_Click(object sender, EventArgs e)
        {
            if (Ajouterbtn.Text == "Ajouter")
            {

                Stock c = new Stock(referencebox.Text.Trim(), CategorieCombo.Text.Trim(), Convert.ToInt16(qtebox.Text.Trim()), prixbox.Text.Trim());
               // Stockdb.AddRdv(c);
                Clear();

            }
            if (Ajouterbtn.Text == "Modifier")
            {

                Stock c = new Stock(referencebox.Text.Trim(), CategorieCombo.Text.Trim(), Convert.ToInt16(qtebox.Text.Trim()), prixbox.Text.Trim());

                //Stockdb.UpdateRdv(c, id);
                //Clear();

            }
            _parent.Display();
        }
    }
}
