class Transaction
{
    public int AccountId;
    public double Amount;
    public string Timestamp;
    public string MerchantName;

    public Transaction(int accountId,double amount, string timestamp,string merchantName)
    {
        AccountId = accountId;
        Amount = amount;
        Timestamp = timestamp;
        MerchantName = merchantName;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Transaction[] transactions =
        {
            new Transaction(101,5000,"10:30","Amazon"),
            new Transaction(102,200000,"11:00","Apple"),
            new Transaction(101,7000,"11:20","Flipkart"),
            new Transaction(103,3000,"12:00","NetFlix")
        };

        for(int i=0;i<transactions.Length;i++)
        {
            Console.WriteLine("Account Id: "+ transactions[i].AccountId);
            Console.WriteLine("Amount : "+ transactions[i].Amount);
            Console.WriteLine("Time : "+transactions[i].Timestamp);
            Console.WriteLine("Merchant : "+transactions[i].MerchantName);
            Console.WriteLine();
        }

        Console.WriteLine("Duplicate Transactions ");

        for(int i=0;i<transactions.Length;i++)
        {
            for(int j=i+1;j<transactions.Length;j++)
            {
                if(transactions[i].AccountId == transactions[j].AccountId && 
                transactions[i].Amount == transactions[j].Amount && 
                transactions[i].MerchantName == transactions[j].MerchantName)
                {
                    Console.WriteLine("Duplicate Found");
                    Console.WriteLine(transactions[i].AccountId);
                }
            }
        }
    }
}