using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            var Date = new DateController();

            var sberbank = new Bank(0.03, new DefaultPercentStrategy(), 1000, Date);
            var tinkoff = new Bank(0, new DefaultPercentStrategy(), 100000, Date);

            var Petya = new User("Petya", "3B", "Pushkin st, house n Kolotushkina");
            var Vasya = new User("Vasya", "9A", "Kolotushkin st, house n Pushkina", "Усы, лапы и хвост");

            var PetyaDebit = sberbank.AccountFactory.CreateDebitAccount(Petya, 1.5);
            var PetyaCredit = sberbank.AccountFactory.CreateCreditAccount(Petya, 300);
            var VasyaDebit = tinkoff.AccountFactory.CreateDebitAccount(Vasya, 3);
            var VasyaDeposit = tinkoff.AccountFactory.CreateDepositAccount(Vasya, 3, 1000);

            var PetyaDebitAddTransaction = sberbank.CreateTransactionBuilder().Add(PetyaDebit).Amount(350).Build();
            Console.WriteLine(PetyaDebit.Amount);
            PetyaDebitAddTransaction.TryMake();
            Console.WriteLine(PetyaDebit.Amount);

            var VasyaDebitAddTransaction = tinkoff.CreateTransactionBuilder().Add(VasyaDebit).Amount(15234).Build();
            Console.WriteLine(VasyaDebit.Amount);
            VasyaDebitAddTransaction.TryMake();
            Console.WriteLine(VasyaDebit.Amount);

            var VasyaDebitPetyaDebitTransction = sberbank.CreateTransactionBuilder().Add(PetyaDebit).Amount(135).Dec(VasyaDebit).Build();
            VasyaDebitPetyaDebitTransction.TryMake();
            Console.WriteLine(PetyaDebit.Amount);
            Console.WriteLine(VasyaDebit.Amount);

            Date.EndDay();
            Date.EndDay();
            Date.EndDay();
            Date.EndDay();
            Date.EndDay();
            Date.EndDay();
            Date.EndDay();
            Date.EndDay();
            Date.EndDay();
            Date.EndDay();
            Date.EndMonth();
            Console.WriteLine(PetyaDebit.Amount);

            


        }
    }
}