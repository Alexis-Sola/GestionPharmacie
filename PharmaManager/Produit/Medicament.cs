using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Produits
{
    class Medicament : Produit
    {
        private int niveauConduite;
        private string description;

        public Medicament(int niveauConduite, 
            string description, string nom, 
            double prixAchat, double prixVente, 
            DateTime datePeremption, int quantite, 
            string type, 
            string reference): base(nom, prixAchat, prixVente, datePeremption, quantite, type, reference)
        {
            NiveauConduite = niveauConduite;
            Description = description;
        }

        public int NiveauConduite { get => niveauConduite; set => niveauConduite = value; }
        public string Description { get => description; set => description = value; }
    }
}
