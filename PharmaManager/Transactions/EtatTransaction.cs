using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Transactions
{
    /// <summary>
    /// Définis les différents états d'une transaction
    /// </summary>
    abstract class EtatTransaction
    {
        protected TransactionPharma transaction;

        public abstract void Add(TransactionPharma t);

        public abstract void Annuler(TransactionPharma t);

        public void Modify(TransactionPharma t)
        {
            throw new NotImplementedException();
        }
    }
}
