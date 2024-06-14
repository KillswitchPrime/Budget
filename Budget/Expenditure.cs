namespace Budget;

public class Expenditure
{
    public string Month { get; set; }
    public int Year { get; set; }
    public double Amount { get; set; }
    public double Income { get; set; }

    public override string ToString()
    {
        return $"{Year} | {Month} | {Math.Round(Amount, 2)}";
    }
}