using PharmaManager.Employes;
using PharmaManager.Produits;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Pharmacies
{
    class PharmacieFranchise : Pharmacie
    {
        private List<PharmacieFranchise> pharmasF = new List<PharmacieFranchise>();
        CompteFranchise compte;
        double royalties = 0;

        public PharmacieFranchise(string nom, double chiffreAffaireMois, string siret, CompteFranchise _compte, Responsable responsable) : base(nom, chiffreAffaireMois, siret, responsable)
        {
            Compte = _compte;
            Compte.Ph = this;
            Compte.PhF = this;
        }

        internal List<PharmacieFranchise> PharmasF { get => pharmasF; set => pharmasF = value; }
        internal CompteFranchise Compte { get => compte; set => compte = value; }

        /// <summary>
        /// Calcul le pourcentage que perçoit une pharmacie franchisee en fonction
        /// du nombre de pharmacie qu'elle gère
        /// </summary>
        /// <returns></returns>
        private double CalculPourcentageFranchise()
        {
            double montantEarned = ChiffreAffaireMois;

            if (pharmasF.Count >= 2 && pharmasF.Count <= 4)
                return montantEarned * 0.01;
            if (pharmasF.Count >= 5 && pharmasF.Count <= 10)
                return montantEarned * 0.02;

            return montantEarned * 0.03;
        }

        /// <summary>
        /// Débite les comptes des pharmacies filles
        /// Crédite le compte de la pharmacie père
        /// </summary>
        internal void MajRoyalties()
        {
            double montantEarned = CalculPourcentageFranchise();
            double montantRoyalTies = montantEarned / pharmasF.Count;

            if (pharmasF != null && pharmasF.Count > 1)
            {
                foreach (PharmacieFranchise ph in pharmasF)
                {
                    ph.royalties = montantRoyalTies;
                    ph.ChiffreAffaireMois -= montantRoyalTies;
                    DisplayMontantDue(ph);
                }
                ChiffreAffaireMois += montantEarned;
                DisplayMontantGagner(montantEarned);
            }
        }

        /// <summary>
        /// Affiche le montant due
        /// </summary>
        /// <param name="ph"></param>
        private void DisplayMontantDue(PharmacieFranchise ph)
        {
            Console.WriteLine($"La pharmacie {ph.Nom} doit payer {ph.royalties}euro à {Nom}");
        }

        /// <summary>
        /// Affiche le montant gagner
        /// </summary>
        /// <param name="montant"></param>
        private void DisplayMontantGagner(double montant)
        {
            Console.WriteLine($"{Nom} voit son chiffre d'affaire augmenter de {montant}euro");
        }

        /// <summary>
        /// Achat d'un produit mais avec les avantages des pharmacies franchisées
        /// </summary>
        /// <param name="p"></param>
        public override void AchatProduit(Produit p)
        {
            Compte.AcheterProduit(p);
        }
    }
}
