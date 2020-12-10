using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Transactions
{
    /// <summary>
    /// Répertorie toutes les transactions effectuees et les classe correctement
    /// </summary>
    class LivresDesTransactions
    {
        private static LivresDesTransactions _instance = null;

        //Trier les list en fonction de l'état des transaction
        private List<TransactionPharma> transactionEnCours = new List<TransactionPharma>();
        private List<TransactionPharma> transactionValidee = new List<TransactionPharma>();
        private List<TransactionPharma> transactionRefusee = new List<TransactionPharma>();

        private LivresDesTransactions()
        { }

        internal List<TransactionPharma> TransactionEnCours { get => transactionEnCours; set => transactionEnCours = value; }
        internal List<TransactionPharma> TransactionValidee { get => transactionValidee; set => transactionValidee = value; }
        internal List<TransactionPharma> TransactionRefusee { get => transactionRefusee; set => transactionRefusee = value; }

        public static LivresDesTransactions GetInstance()
        {
            if (_instance == null)
                _instance = new LivresDesTransactions();
            return _instance;
        }
    }
}
