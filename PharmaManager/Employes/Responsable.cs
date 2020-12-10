using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Employes
{
    class Responsable : Pharmacien
    {
        public Responsable(string nom, string prenom, string adresse, double salaire, int nbVentes) : base(nom, prenom, adresse, salaire, nbVentes)
        {}
    }
}
