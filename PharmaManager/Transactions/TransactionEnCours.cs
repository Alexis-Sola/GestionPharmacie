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
            Console.WriteLine($"La Transaction {t.Id} ajouté dans la liste des transactions en cours");
        }

        public override void Annuler(TransactionPharma t)
        {
            Console.WriteLine($"Annulation de la transaction...");
        }
    }
}
