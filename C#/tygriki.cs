using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

public class CoWorker
{
    private double _tygriki;
    public double Tygriki
    {
        get => _tygriki;
        set => _tygriki = Math.Round(value, MidpointRounding.AwayFromZero);
    }

    public int Coffee { get; set; }
    public double Sheet { get; set; }

    public void RankIs(char rankNumber)
    {
        if (rankNumber == '2')
            Tygriki = Tygriki + Tygriki / 4;
        else if (rankNumber == '3')
            Tygriki = Tygriki + Tygriki / 2;
    }

    public void DepartmentHead()
    {
        Tygriki = Tygriki + Tygriki / 2;
        Coffee = Coffee * 2;
        Sheet = 0;
    }
}

public class Manager : CoWorker
{
    public Manager()
    {
        Tygriki = 50000;
        Coffee = 20;
        Sheet = 200;
    }
}
public class Marketer : CoWorker
{
    public Marketer()
    {
        Tygriki = 40000;
        Coffee = 15;
        Sheet = 150;
    }
}
public class Engineer : CoWorker
{
    public Engineer()
    {
        Tygriki = 20000;
        Coffee = 5;
        Sheet = 50;
    }
}
public class Analyst : CoWorker
{
    public Analyst()
    {
        Tygriki = 80000;
        Coffee = 50;
        Sheet = 5;
    }
}

public class Department
{
    public string Name { get; set; }

    public int CountOfCoWorckers { get; set; }

    private double _countOfTygrik;
    public double CountOfTygriki 
    { 
        get => _countOfTygrik; 
        set => _countOfTygrik = Math.Round(value, 2, MidpointRounding.AwayFromZero); 
    }

    public int CountOfCoffee { get; set; }

    private double _countOfSheet;
    public double CountOfSheet 
    {
        get => _countOfSheet;
        set => _countOfSheet = Math.Round(value, 2, MidpointRounding.AwayFromZero);
    }

    public Department(string name)
    {
        Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
    }

    public void Calculate(CoWorker coWorker, int count)
    {
        CountOfCoWorckers += count;
        CountOfTygriki = CountOfTygriki + coWorker.Tygriki * count;
        CountOfCoffee = CountOfCoffee + coWorker.Coffee * count;
        CountOfSheet = CountOfSheet + coWorker.Sheet * count;
    }
}

class Mainclass
{
    private static List<Department> _departments = new List<Department>();
    public static void Main(string[] args)
    {
        for (int i = 0; i < 4; i++)
        {
            _departments.Add(Read());
        }
        Print();
    }

    public static Department Read()
    {
        var vvodColon = Console.ReadLine().Split(": ");
        var departmentName = vvodColon[0].Split(" ")[1];                        //закупок
        string posleColon = vvodColon[1];

        var departmentAlo = new Department(departmentName);

        var vvodPlus = posleColon.Split(" + ");
        string departmentHead = vvodPlus[1];                                    //руководитель департамента manager2
        var departmentHeadArray = departmentHead.Split(" ");
        string levelDepartmentHead = departmentHeadArray[2];                    //уровень руководителя   "manager2"

        var rukLevelArray = levelDepartmentHead[levelDepartmentHead.Length - 1];
        var rukCoworkerType = levelDepartmentHead.Substring(0, levelDepartmentHead.Length - 1);

        var coWorker = CreateCoWorker(rukCoworkerType);

        coWorker.RankIs(rukLevelArray);
        coWorker.DepartmentHead();
        departmentAlo.Calculate(coWorker, 1);

        string coworkers = vvodPlus[0];
        var coworkersArray = coworkers.Split(", ");                             //9*manager1     3*manager2   и т.д.

        foreach (var coworker in coworkersArray)
        {
            var splittedCoworker = coworker.Split('*');
            int countOfCoworker = int.Parse(splittedCoworker[0]);               // 9

            var coworkerWithRank = splittedCoworker[1];
            var rankNumber = coworkerWithRank[coworkerWithRank.Length - 1];  // 1

            var coworkerType = coworkerWithRank.Substring(0, coworkerWithRank.Length - 1);      //manager

            coWorker = CreateCoWorker(coworkerType);
            coWorker.RankIs(rankNumber);
            departmentAlo.Calculate(coWorker, countOfCoworker);
        }
        return departmentAlo;
    }

    public static CoWorker CreateCoWorker(string coworkerType)
    {
        switch (coworkerType)
        {
            case "manager":
                return new Manager();
            case "marketer":
                return new Marketer();
            case "engineer":
                return new Engineer();
            case "analyst":
                return new Analyst();
            default:
                return new CoWorker();
        }
    }

    public static void Print()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Департамент").Append(' ', 5);
        var departmentLength = "Департамент".Length + 5;

        sb.Append("Сотрудников").Append(' ', 5);
        var coworkerLength = "Сотрудников".Length + 5;

        sb.Append("Тугрики").Append(' ', 5);
        var tugrikLength = "Тугрики".Length + 5;

        sb.Append("Кофе").Append(' ', 5);
        var coffeeLength = "Кофе".Length + 5;

        sb.Append("Страницы").Append(' ', 5);
        var sheetLength = "Страницы".Length + 5;

        sb.Append("Тугр./стр.");
        var headerTableLength = sb.ToString().Length;

        sb.AppendLine().Append('-', headerTableLength).AppendLine();

        int sumOfCoworkers = 0, sumOfCoffee = 0;
        double sumOfTugrik = 0, sumOfSheet = 0;
        foreach (var department in _departments)
        {
            var lenthprobel1 = departmentLength - department.Name.Length;
            sb.Append(department.Name).Append(' ', lenthprobel1);

            lenthprobel1 = coworkerLength - department.CountOfCoWorckers.ToString().Length;
            sb.Append(department.CountOfCoWorckers).Append(' ', lenthprobel1);
            sumOfCoworkers += department.CountOfCoWorckers;

            lenthprobel1 = tugrikLength - department.CountOfTygriki.ToString().Length;
            sb.Append(department.CountOfTygriki).Append(' ', lenthprobel1);
            sumOfTugrik += department.CountOfTygriki;

            lenthprobel1 = coffeeLength - department.CountOfCoffee.ToString().Length;
            sb.Append(department.CountOfCoffee).Append(' ', lenthprobel1);
            sumOfCoffee += department.CountOfCoffee;

            lenthprobel1 = sheetLength - department.CountOfSheet.ToString().Length;
            sb.Append(department.CountOfSheet).Append(' ', lenthprobel1);
            sumOfSheet += department.CountOfSheet;

            var tugBySheet = Math.Round(department.CountOfTygriki / department.CountOfSheet, 2, MidpointRounding.AwayFromZero);
            sb.Append(tugBySheet).AppendLine();
        }
        sb.Append('-', headerTableLength).AppendLine();

        var lenthprobel = departmentLength - "Всего".Length;
        sb.Append("Всего").Append(' ', lenthprobel);

        lenthprobel = coworkerLength - sumOfCoworkers.ToString().Length;
        sb.Append(sumOfCoworkers).Append(' ', lenthprobel);

        lenthprobel = tugrikLength - sumOfTugrik.ToString().Length;
        sb.Append(sumOfTugrik).Append(' ', lenthprobel);

        lenthprobel = coffeeLength - sumOfCoffee.ToString().Length;
        sb.Append(sumOfCoffee).Append(' ', lenthprobel);

        lenthprobel = sheetLength - sumOfSheet.ToString().Length;
        sb.Append(sumOfSheet).Append(' ', lenthprobel);

        var sumTugBySheet = Math.Round(sumOfTugrik / sumOfSheet, 2, MidpointRounding.AwayFromZero);
        sb.Append(sumTugBySheet);

        Console.WriteLine(sb.ToString());
    }
}