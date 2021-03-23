using System;
using System.Collections.Generic;
using System.Linq;

namespace BankTransferApp
{
    class Program
    {
        static List<Account> accounts = new List<Account>();
        static List<Transaction> transactions = new List<Transaction>();
        static void Main(string[] args)
        {
            string opcaoUsuario = GetUserOption();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        WithDraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "E":
                        Statement();
                        break;
                    default:
                        Console.WriteLine("A opção digitada não existe! insira as opções listadas!");
                        break;
                }

                opcaoUsuario = GetUserOption();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

        }

        private static void Statement()
        {
            try
            {
                Console.WriteLine("Digite o numero da conta: ");
                int conta = int.Parse(Console.ReadLine());

                var trans = transactions.Where(c => c.AccountId == conta).ToList();

                if (trans.Count == 0)
                {
                    Console.WriteLine("Nenhuma transação encontrada");
                }
                else
                {
                    foreach (var t in trans)
                    {
                        Console.WriteLine(t);
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro, Formato digitado não valido, numero da conta deve ser numero inteiro!");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Erro, Formato digitado não valido, numero da conta deve ser numero inteiro!");
                Console.WriteLine("Erro: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }
        }

        private static void Transfer()
        {
            try
            {
                Console.Write("Digite o número da conta de origem: ");
                int indiceContaOrigem = int.Parse(Console.ReadLine());

                Console.Write("Digite o número da conta de destino: ");
                int indiceContaDestino = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser transferido: ");
                double valorTransferencia = double.Parse(Console.ReadLine());

                accounts[indiceContaOrigem].Transfer(valorTransferencia, accounts[indiceContaDestino]);
                Transaction transaction = new Transaction(type: (TransactionType)3, value: valorTransferencia, accountId: indiceContaOrigem);
                transactions.Add(transaction);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Conta digitada não existe!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro, Formato digitado não valido, numero da conta deve ser numero inteiro e valor numero decimal!");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Erro, confira os numeros das contas e o valor inserido e tente novamente!");
                Console.WriteLine("Erro: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }
        }

        private static void Deposit()
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser depositado: ");
                double valorDeposito = double.Parse(Console.ReadLine());

                accounts[indiceConta].Deposit(valorDeposito);
                Transaction transaction = new Transaction(type: (TransactionType)1, value: valorDeposito, accountId: indiceConta);
                transactions.Add(transaction);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Conta digitada não existe!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro, Formato digitado não valido, numero da conta deve ser numero inteiro e valor numero decimal!");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Erro, confira o numero da conta e o valor inserido e tente novamente!");
                Console.WriteLine("Erro: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }
        }

        private static void WithDraw()
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser sacado: ");
                double valorSaque = double.Parse(Console.ReadLine());

                accounts[indiceConta].Withdraw(valorSaque);
                Transaction transaction = new Transaction(type: (TransactionType)2, value: valorSaque, accountId: indiceConta);
                transactions.Add(transaction);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Conta digitada não existe!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro, Formato digitado não valido, numero da conta deve ser numero inteiro e valor numero decimal!");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Erro, confira os numero da conta e o valor inserido e tente novamente!");
                Console.WriteLine("Erro: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }
        }

        private static void ListAccounts()
        {
            Console.WriteLine("Listar contas");

            if (accounts.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < accounts.Count; i++)
            {
                Account conta = accounts[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InsertAccount()
        {
            try
            {
                Console.WriteLine("Inserir nova conta");

                Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
                int entradaTipoConta = int.Parse(Console.ReadLine());

                if(entradaTipoConta != 1 && entradaTipoConta != 2)
                {
                    Console.WriteLine("Tipo de conta não existe! Digite 1 para Conta Fisica ou 2 para Juridica!");

                    return;
                }

                Console.Write("Digite o Nome do Cliente: ");
                string entradaNome = Console.ReadLine();

                Console.Write("Digite o saldo inicial: ");
                double entradaSaldo = double.Parse(Console.ReadLine());

                Console.Write("Digite o crédito: ");
                double entradaCredito = double.Parse(Console.ReadLine());

                Account newAccount = new Account(accountType: (AccountType)entradaTipoConta,
                                            balance: entradaSaldo,
                                            credit: entradaCredito,
                                            name: entradaNome);

                accounts.Add(newAccount);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erro, Formato digitado não valido, Tipo de conta deve ser numero inteiro e valores de saldo e crédito decimal!");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Erro, Confira os dados digitados e tente novamente!");
                Console.WriteLine("Erro: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DI Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("E- Extrato");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
