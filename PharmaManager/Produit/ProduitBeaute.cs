using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Produits
{
    class ProduitBeaute : Produit
    {
        private int nbEtoiles;
        private List<string> avis = new List<string>();


        public ProduitBeaute(int nbEtoiles,
            string nom,
            double prixAchat, double prixVente,
            DateTime datePeremption, int quantite,
            string type,
            string reference) : base(nom, prixAchat, prixVente, datePeremption, quantite, type, reference)
        {
            NbEtoiles = nbEtoiles;
        }

        public int NbEtoiles { get => nbEtoiles; set => nbEtoiles = value; }
        public List<string> Avis { get => avis; set => avis = value; }
    }
}
