using System;
using System.Data.SqlTypes;

public class Human
{
    public double AmountSeance { get; set; }
    public double Price { get; set; }
    public double AmountTicket { get; set; }
    public double TotalСost { get; set; }

    public Human(double amountSeance, double price, double amountTicket)
    {
        AmountSeance = amountSeance;
        Price = price;
        AmountTicket = amountTicket;
        TotalСost = 0;
    }
}

public class Viewer : Human
{
    public Viewer(double amountSeance, double price, double amountTicket) : base(amountSeance, price, amountTicket)
    {
        TotalСost = amountTicket * price;
         Console.WriteLine(Math.Round(TotalСost, 2));
    }
}

public class Regular : Human
{
    public Regular(double amountSeance, double price, double amountTicket) : base(amountSeance, price, amountTicket)
    {
        double skidkaDo = Math.Floor(amountSeance / 10);
        
        for (double i = amountSeance + 1; i <= (amountSeance + amountTicket); i++)
        {
            if (i % 10 == 0 && skidkaDo < 20)
                skidkaDo++;

            TotalСost += price * (1 - skidkaDo / 100);
        }
        Console.WriteLine(Math.Round(TotalСost, 2));
    }
}

public class Student : Human
{
    public Student(double amountSeance, double price, double amountTicket) : base(amountSeance, price, amountTicket)
    {
        double countWithSale = 0;
        double countWithOutSale = 0;
        for (double i = amountSeance + 1; i <= (amountSeance + amountTicket); i++)
        {
            if (i % 3 == 0)
                countWithSale++;
            else
                countWithOutSale++;
        }
        TotalСost = (countWithOutSale * price) + (countWithSale * price / 2);
         Console.WriteLine(Math.Round(TotalСost, 2));
    }
}
public class Pensioner : Human
{
    public Pensioner(double amountSeance, double price, double amountTicket) : base(amountSeance, price, amountTicket)
    {
        double countWithSale = 0;
        for (double i = amountSeance + 1; i <= (amountSeance + amountTicket); i++)
            if (i % 5 != 0)
                countWithSale++;
        TotalСost = countWithSale * price / 2;
        Console.WriteLine(Math.Round(TotalСost, 2));
    }
}

class Mainclass
{
    public static void Main(string[] args)
    {
        var vvod = Console.ReadLine().Split(" ");

        double amountSeance = double.Parse(vvod[1]);
        double price = double.Parse(vvod[2]);
        double amountTicket = double.Parse(vvod[3]);

        Human a;
        switch (vvod[0])
        {
            case "viewer":
                a = new Viewer(amountSeance, price, amountTicket);
                break;
            case "regular":
                a = new Regular(amountSeance, price, amountTicket);
                break;
            case "student":
                a = new Student(amountSeance, price, amountTicket);
                break;
            case "pensioner":
                a = new Pensioner(amountSeance, price, amountTicket);
                break;
        }
    }
}