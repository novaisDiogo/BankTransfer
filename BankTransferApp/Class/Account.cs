using System;

namespace BankTransferApp
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name; 
        }

        public bool Withdraw(double value){
            if(this.Balance - value < (this.Credit * -1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Balance -= value;
            
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);

            return true;
        }

        public void Deposit(double value){
            this.Balance += value;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
        }

        public void Transfer(double value, Account targetAccount){
            if(this.Withdraw(value)){
                targetAccount.Deposit(value);
            }
        }

        public override string ToString(){
            string rturn = "";
            rturn += "Tipo Conta " + this.AccountType + " | ";
            rturn += "Nome " + this.Name + " | ";
            rturn += "Saldo " + this.Balance + " | ";
            rturn += "Crédito " + this.Credit + " | ";
            return rturn;
        }
    }
}