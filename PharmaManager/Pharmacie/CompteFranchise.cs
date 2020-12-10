using PharmaManager.Produits;
using PharmaManager.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Pharmacies
{
    class CompteFranchise : Compte
    {
        private PharmacieFranchise phF;
        private bool addStock = false;

        public CompteFranchise(double montantTresorerie) : base(montantTresorerie)
        { }

        public PharmacieFranchise PhF { get => phF; set => phF = value; }

        /// <summary>
        /// Permet d'acheter un produit avec les reductions adéquates
        /// </summary>
        /// <param name="p"></param>
        public override void AcheterProduit(Produit p)
        {
            //On test dans quelle config on est
            if (PhF.PharmasF != null && PhF.PharmasF.Count != 0)
            {
                int nbGerer = PhF.PharmasF.Count;
                double newMontant = p.PrixAchat;

                //On cherche quelle est la bonne réduction
                if (nbGerer >= 2 && nbGerer <= 4)
                {
                    newMontant -= p.PrixAchat * 0.025;
                    ValidateTransaction(newMontant);
                }
                else if (nbGerer >= 5 && nbGerer <= 10)
                {
                    newMontant -= p.PrixAchat * 0.05;
                    ValidateTransaction(newMontant);

                }
                else if (nbGerer > 10)
                {
                    newMontant -= p.PrixAchat * 0.075;
                    ValidateTransaction(newMontant);
                }
                else
                    RefusedTransaction(p.PrixAchat);

                if (addStock)
                {
                    Console.WriteLine($"La phamacie {Ph.Nom} achete le produit {p.Nom} pour un montant de {newMontant}euro au lieu de {p.PrixAchat}euro");
                    Ph.Stock.Add(p);
                }

            }
            else
            {
                if (Debiter(p.PrixAchat))
                {
                    Ph.Stock.Add(p);
                    new TransactionPharma(new TransactionValidee(), p.PrixAchat, DateTime.Now, DateTime.Now, true, "Fournisseur", Ph.Nom);
                    Console.WriteLine($"La phamacie {Ph.Nom} achete le produit {p.Nom} pour un montant de {p.PrixAchat}euro");
                }
                else
                    RefusedTransaction(p.PrixAchat);
            }

        }

        /// <summary>
        /// Valide une transaction en créant une nouvelle 
        /// </summary>
        /// <param name="montant"></param>
        private void ValidateTransaction(double montant)
        {
            if (Debiter(montant))
            { 
                addStock = true;
                new TransactionPharma(new TransactionValidee(), montant, DateTime.Now, DateTime.Now, true, "Fournisseur", Ph.Nom);
            }
        }

        /// <summary>
        /// Refuse une transaction
        /// </summary>
        /// <param name="montant"></param>
        private void RefusedTransaction(double montant)
        {
            new TransactionPharma(new TransactionRefusee(), montant, DateTime.Now, DateTime.Now, true, "Fournisseur", Ph.Nom);
        }
    }
}
