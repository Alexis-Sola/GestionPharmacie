using PharmaManager.Produits;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Pharmacies
{
    abstract class Compte
    {
        private Pharmacie ph;

        protected double montantTresorerie;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="montantTresorerie"></param>
        protected Compte(double montantTresorerie)
        {
            MontantTresorerie = montantTresorerie;
        }

        public double MontantTresorerie { get => montantTresorerie; set => montantTresorerie = value; }
        public Pharmacie Ph { get => ph; set => ph = value; }

        /// <summary>
        /// Débite un montant de la trésorerie si c'est possible
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public bool Debiter(double montant)
        {
            if (MontantTresorerie > montant)
            {
                MontantTresorerie -= montant;
                Console.WriteLine($"Solde du compte de {ph.Nom} apres le debit : {MontantTresorerie}");
                return true;
            }
            Console.WriteLine($"Solde insufisant pour la pharmacie {ph.Nom}. Debit impossible");
            return false;
        }

        /// <summary>
        /// Crédite le compte du montant en paramètre
        /// </summary>
        /// <param name="montant"></param>
        public void Crediter(double montant)
        {
            MontantTresorerie += montant;
            Console.WriteLine($"Solde du compte de {ph.Nom} apres le debit : {MontantTresorerie}");
        }

        /// <summary>
        /// Méthode qui change de comportement en fontion du type de compte
        /// </summary>
        /// <param name="p"></param>
        public abstract void AcheterProduit(Produit p);
    }
}
