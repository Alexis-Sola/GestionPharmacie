using PharmaManager.Produits;
using PharmaManager.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Pharmacies
{
    class CompteInde : Compte
    {
        public CompteInde(double montantTresorerie) : base(montantTresorerie)
        { }

        /// <summary>
        /// Permet d'acheter un produit sans réductions
        /// </summary>
        /// <param name="p"></param>
        public override void AcheterProduit(Produit p)
        {
            if (Debiter(p.PrixAchat))
            {
                Ph.Stock.Add(p);
                DisplayAchat(p);
                new TransactionPharma(new TransactionValidee(), 10, DateTime.Now, DateTime.Now, true, "Fournisseur", Ph.Nom);
            }
            else
                new TransactionPharma(new TransactionRefusee(), 10, DateTime.Now, DateTime.Now, true, "Fourniseur", Ph.Nom);
        }

        /// <summary>
        /// Affiche l'achat d'un produit
        /// </summary>
        /// <param name="p"></param>
        private void DisplayAchat(Produit p)
        {
            Console.WriteLine($"La phamacie {Ph.Nom} achete le produit {p.Nom} pour un montant de {p.PrixAchat}euro");
        }
    }
}
