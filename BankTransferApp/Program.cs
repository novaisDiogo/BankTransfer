using System;
using System.Collections.Generic;

namespace BankTransferApp
{
    class Program
    {
		static List<Account> accounts = new List<Account>();
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

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = GetUserOption();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();

		}

        private static void Transfer()
        {
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

			Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

			accounts[indiceContaOrigem].Transfer(valorTransferencia, accounts[indiceContaDestino]);
		}

        private static void Deposit()
        {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

			accounts[indiceConta].Deposit(valorDeposito);
		}

        private static void WithDraw()
        {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

			accounts[indiceConta].Withdraw(valorSaque);
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
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

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

        private static string GetUserOption(){
            Console.WriteLine();
			Console.WriteLine("DI Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
        }
    }
}
