using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Produits
{
    class Vaccin : Produit
    {
        private string description;
        private string notice;
        private double efficacite;

        public string Description { get => description; set => description = value; }
        public string Notice { get => notice; set => notice = value; }
        public double Efficacite { get => efficacite; set => efficacite = value; }

        public Vaccin(string description,
            string notice,
            string nom,
            double efficacite,
            double prixAchat, double prixVente,
            DateTime datePeremption, int quantite,
            string type,
            string reference) : base(nom, prixAchat, prixVente, datePeremption, quantite, type, reference)
        {
            Description = description;
            Notice = notice;
            Efficacite = efficacite;
        }
    }
}
