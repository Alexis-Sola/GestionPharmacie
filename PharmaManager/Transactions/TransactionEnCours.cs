using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Transactions
{
    class TransactionEnCours : EtatTransaction
    {
        public override void Add(TransactionPharma t)
        {
            t.LivresTransactions.TransactionEnCours.Add(t);
            DisplayAdd(t.Id);
        }

        public override void Annuler(TransactionPharma t)
        {
            DisplayAnnuler();
        }

        protected override void DisplayAdd(int id)
        {
            Console.WriteLine($"La Transaction {id} ajouté dans la liste des transactions en cours");
        }

        protected override void DisplayAnnuler()
        {
            Console.WriteLine($"Annulation de la transaction...");
        }
    }
}
