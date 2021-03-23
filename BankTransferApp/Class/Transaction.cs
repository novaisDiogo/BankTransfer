using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferApp
{
    public class Transaction
    {
        private TransactionType TransactionType { get; set; }
        private double Value { get; set; }
        public int AccountId { get; set; }

        public Transaction(TransactionType type, double value, int accountId)
        {
            this.TransactionType = type;
            this.Value = value;
            this.AccountId = accountId;
        }

        public override string ToString()
        {
            string rturn = "";
            rturn += "Tipo de transação: " + this.TransactionType + " | ";
            rturn += "Valor: " + this.Value + " | ";

            return rturn;
        }
    }
}
