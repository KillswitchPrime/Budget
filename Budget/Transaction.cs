namespace Budget;

public class Transaction
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public double Amount { get; set; }

    public override string ToString()
    {
        return $"Date of transaction: {Date.Date}\nName: {Name}\nAmount: {Amount}";
    }
}