using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.PaiementClient
{
    /// <summary>
    /// Définition de la carte d'un client
    /// </summary>
    abstract class Carte
    {
        private static int id = 0;
        private string code;
        private string nomClient;
        private string cvc;
        protected double solde;
        private ReseauCarte reseau;
        private double newMontant;

        //Constructeur
        protected Carte(string code, string nomClient, string cvc, double solde, ReseauCarte reseau)
        {
            Code = code;
            NomClient = nomClient;
            Cvc = cvc;
            this.solde = solde;
            Reseau = reseau;
        }

        //Accesseurs
        public static int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string NomClient { get => nomClient; set => nomClient = value; }
        public string Cvc { get => cvc; set => cvc = value; }
        public double Solde { get => solde; set => solde = value; }
        internal ReseauCarte Reseau { get => reseau; set => reseau = value; }

        /// <summary>
        /// Débite le montant de la carte du client
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public bool Payer(double montant)
        {
            if (AuthorizePayment(montant))
            {
                DisplayPayer(newMontant);
                Solde -= montant;
                return true;
            }
            return false;
        }

        private void DisplayPayer(double montant)
        {
            Console.WriteLine($"Le montant a payer est : {montant}euro");
        }

        /// <summary>
        /// Autaurise le paiement si le solde est suffisant
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public bool AuthorizePayment(double montant)
        {
            //Calcul du montant en fonction du réseau utilisé
            newMontant = montant + (montant * Reseau.PourcentageRetenu / 100);
            if (Solde > newMontant)
                return true;

            Console.WriteLine("Solde insuffisant.");
            return false;
        }

        /// <summary>
        /// Remboursement du client en cas de litige
        /// </summary>
        /// <param name="montant"></param>
        public abstract void Rembourser(double montant);
    }
}
