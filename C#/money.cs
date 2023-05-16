public class Money
{
    public double Value = 0;

    public Money(double value)
    {
        Value = Math.Round(value, 2);
    }

    public Money(string value, string type)
    {
        var moneyValue = double.Parse(value);

        if (moneyValue < 0)
        {
            Console.WriteLine("Не может быть отрицательным!");
            return;
        }

        switch (type) 
        {
            case "р.":
                Value += moneyValue;
                break;
            case "коп.":
                Value += moneyValue / 100;
                break;
        }
    }

    public Money(string valueRub, string rub, string velueKop, string kop)
    {
        if (kop != "коп." || rub != "р.")
        {
            Console.WriteLine("Рубли и копейки перепутаны местами!");
            return;
        }
        var moneyValueKop = double.Parse(velueKop);
        var moneyValueRub = double.Parse(valueRub);

        if (moneyValueRub < 0 || moneyValueKop < 0)
        {
            Console.WriteLine("Не может быть отрицательным!");
            return;
        }

        Value += moneyValueKop / 100;
        Value += moneyValueRub;

        Value = Math.Round(Value, 2);
    }

    public static Money Sum(Money a, Money b)
    {
        return new Money(a.Value + b.Value);
    }

    public static Money Difference(Money a, Money b)
    {
        return new Money(a.Value - b.Value);
    }

    public void Print()
    {
        var result = Value.ToString().Split(".");
        int rub = int.Parse(result[0]);
        if (rub >= 1)
        {
            Console.Write($"{rub} р. ");
        }
        Console.WriteLine($"{Math.Round((Value - rub) * 100)} коп.");
    }

    public void PrintTransferCost(double procent)
    {
        var result = Math.Round(Value * (1 + procent), 2);
        var result2 = result.ToString().Split(".");
        int rub = int.Parse(result2[0]);
        if (rub >= 1)
        {
            Console.Write($"{rub} р. ");
        }
        Console.WriteLine($"{Math.Round((result - rub) * 100)} коп.");
    }
}