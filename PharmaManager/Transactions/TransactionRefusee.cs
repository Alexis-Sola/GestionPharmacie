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
            Console.WriteLine($"La Transaction {t.Id} a été ajouté dans la liste des transactions refusees");
        }

        public override void Annuler(TransactionPharma t)
        {
            Console.WriteLine($"Impossible d'annuler une transaction deja refusee");
        }
    }
}
