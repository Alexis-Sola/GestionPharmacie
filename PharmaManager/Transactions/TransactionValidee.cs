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
            Console.WriteLine($"La Transaction {t.Id} a été ajouté dans la liste des transaction validée.");
        }

        public override void Annuler(TransactionPharma t)
        {
            Console.WriteLine($"Impossible d'annuler une transaction deja validee");
        }
    }
}
