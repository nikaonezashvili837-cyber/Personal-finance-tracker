namespace PersonalFinanceTracker
{
    partial class Program
    {
        public static void ViewTransactions()
        {
            string jsonContent = File.ReadAllText("transactions.json");
            if (jsonContent == "")
            {
                Console.WriteLine("No transactions present");
                return;
            }
            Console.WriteLine(jsonContent);
        }
    }
}