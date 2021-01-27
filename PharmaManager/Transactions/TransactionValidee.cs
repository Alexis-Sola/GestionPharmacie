using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Transactions
{
    class TransactionValidee : EtatTransaction
    {
        public override void Add(TransactionPharma t)
        {
            t.LivresTransactions.TransactionValidee.Add(t);
            DisplayAdd(t.Id);
        }

        public override void Annuler(TransactionPharma t)
        {
            DisplayAnnuler();
        }

        protected override void DisplayAdd(int id)
        {
            Console.WriteLine($"La Transaction {id} a été ajouté dans la liste des transaction validée.");
        }

        protected override void DisplayAnnuler()
        {
            Console.WriteLine($"Impossible d'annuler une transaction deja validee");
        }
    }
}
