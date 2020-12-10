using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Employes
{
    class Pharmacien : Employe
    {
        private int nbVentes;
        private SalairePharmacien salairePharmacien;

        public Pharmacien(string nom, string prenom, string adresse, double salaire, int nbVentes) : base(nom, prenom, adresse, salaire)
        {
            NbVentes = NbVentes;
        }

        public int NbVentes { get => nbVentes; set => nbVentes = value; }
    }
}
