using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Transactions
{
    class TransactionRefusee : EtatTransaction
    {
        public override void Add(TransactionPharma t)
        {
            t.DebitEffectue = false;
            t.LivresTransactions.TransactionRefusee.Add(t);
            DisplayAdd(t.Id);
        }

        public override void Annuler(TransactionPharma t)
        {
            DisplayAnnuler();
        }


        protected override void DisplayAdd(int id)
        {
            Console.WriteLine($"La Transaction {id} a été ajouté dans la liste des transactions refusees");
        }

        protected override void DisplayAnnuler()
        {
            Console.WriteLine($"Impossible d'annuler une transaction deja refusee");
        }
    }
}
