using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Employes
{
    abstract class Employe : Subject
    {
        private string nom;
        private string prenom;
        private string adresse;
        private double salaire;

        protected Employe(string nom, string prenom, string adresse, double salaire)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Salaire = salaire;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public double Salaire { get => salaire; set => salaire = value; }

        public override void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
