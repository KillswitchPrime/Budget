using System.Globalization;
using Budget;

var file = File.ReadAllLines(@"");
var fmt = new NumberFormatInfo
{
    CurrencyDecimalSeparator = ".",
    NegativeSign = "-"
};

var transactions = file
    .Select(line => line.Split(';'))
    .Where(x => DateTime.TryParse(x[0], out _))
    .Select(items => new Transaction
    {
        Amount = string.IsNullOrWhiteSpace(items[11]) 
            ? double.Parse(items[10], fmt) 
            : double.Parse(items[11], fmt), 
        Date = DateTime.Parse(items[0]), 
        Name = items[3]
    })
    .ToList();

var expenditures = transactions.GroupBy(x => $"{x.Date.Year},{x.Date.Month}")
    .Select(month => new Expenditure
    {
        Month = int.Parse(month.Key.Split(",")[1]) switch
        {
            1 => "January",
            2 => "February",
            3 => "March",
            4 => "April",
            5 => "May",
            6 => "June",
            7 => "July",
            8 => "August",
            9 => "September",
            10 => "October",
            11 => "November",
            12 => "December",
            _ => "Unknown"
        },
        Amount = month
            //.Where(x => x.Amount < 0)
            //.Where(x => x.Amount > -25_000)
            .Sum(x => x.Amount),
        Year = month.First().Date.Year
    })
    .ToList();

foreach (var expenditure in expenditures)
{
    Console.WriteLine(expenditure);
}