// See https://aka.ms/new-console-template for more information

public enum TransactionType
{
    Withdrawal,
    Deposit
}

class Transaction
{
    public DateTime Dag { get; set; }
    public int Belopp { get; set; }
    public TransactionType TransactionType { get; set; }
}

internal class App
{
    //Lets say we have a function CheckForMoneyLaundry( ...transactions ) -> true eller false om det är misstänkta transaktioner
    public bool CheckForMoneyLaundry(List<Transaction> transactions)
    {
        foreach(var transaction in transactions)
        {
            //Check
        }
        return false;
    }
    public void Demo1Interface()
    {
        var t1 = new Transaction { Dag = DateTime.Now, Belopp = 1000, TransactionType = TransactionType.Withdrawal };
        var t2 = new Transaction { Dag = DateTime.Now.AddHours(5), Belopp = 11000, TransactionType = TransactionType.Withdrawal };
        var t3 = new Transaction { Dag = DateTime.Now.AddHours(20), Belopp = 12000, TransactionType = TransactionType.Deposit };
        var lista = new List<Transaction> { t1, t2, t3 };
        CheckForMoneyLaundry(lista);

        //Men om vi har array, eller dbset eller ngt annat...
        var lista2 = new[] { t1, t2, t3 };
        //CheckForMoneyLaundry(lista2);
    }

    public void Run()
    {
        Demo1Interface();
    }
}