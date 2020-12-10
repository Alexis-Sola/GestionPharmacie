using System;
using System.Collections.Generic;
using System.Text;
using PharmaManager.Pharmacies;

namespace PharmaManager.Transactions
{
    class TransactionPharma
    {
        private static int id = 0;
        private LivresDesTransactions livresTransactions;
        private EtatTransaction etatTransaction;
        private double montant;
        private string credite;
        private string debite;
        private DateTime dateTransac;
        private DateTime dateDebit;
        private bool debitEffectue = false;

        public TransactionPharma(EtatTransaction etatTransaction, double montant, DateTime dateTransac, DateTime dateDebit, bool debitEffectue, string credite, string debite)
        {
            Id++;
            EtatTransaction = etatTransaction;
            Montant = montant;
            DateTransac = dateTransac;
            DateDebit = dateDebit;
            DebitEffectue = debitEffectue;
            LivresTransactions = LivresDesTransactions.GetInstance();
            Credite = credite;
            Debite = debite;

            Add();
        }

        public EtatTransaction EtatTransaction { get => etatTransaction; set => etatTransaction = value; }
        public double Montant { get => montant; set => montant = value; }
        public DateTime DateTransac { get => dateTransac; set => dateTransac = value; }
        public DateTime DateDebit { get => dateDebit; set => dateDebit = value; }
        public bool DebitEffectue { get => debitEffectue; set => debitEffectue = value; }
        public int Id { get => id; set => id = value; }
        internal LivresDesTransactions LivresTransactions { get => livresTransactions; set => livresTransactions = value; }
        internal string Credite { get => credite; set => credite = value; }
        internal string Debite { get => debite; set => debite = value; }

        /// <summary>
        /// Ajoute la transaction dans la liste des transactions
        /// </summary>
        public void Add()
        {
            etatTransaction.Add(this);
        }

        /// <summary>
        /// Annule uen transaction
        /// </summary>
        public void Annuler()
        {
            etatTransaction.Annuler(this);
        }
    }
}
