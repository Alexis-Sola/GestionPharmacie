using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Produits
{
    abstract class Produit
    {
        private string nom;
        private double prixAchat;
        private double prixVente;
        private DateTime datePeremption;
        private int quantite;
        private string type;
        private string reference;

        public string Nom { get => nom; set => nom = value; }
        public double PrixAchat { get => prixAchat; set => prixAchat = value; }
        public double PrixVente { get => prixVente; set => prixVente = value; }
        public DateTime DatePeremption { get => datePeremption; set => datePeremption = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public string Type { get => type; set => type = value; }
        public string Reference { get => reference; set => reference = value; }

        protected Produit(string nom, double prixAchat, double prixVente, DateTime datePeremption, int quantite, string type, string reference)
        {
            Nom = nom;
            PrixAchat = prixAchat;
            PrixVente = prixVente;
            DatePeremption = datePeremption;
            Quantite = quantite;
            Type = type;
            Reference = reference;
        }
    }
}
