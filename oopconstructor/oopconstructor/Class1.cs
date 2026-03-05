using System;

class program
{
    static void Main(string[] args)
    {
        Date d1 = new Date(1, 1, 1);
        Console.WriteLine(d1.day);
    }
}

public class Date
{
    public int day;
    public int month;
    public int year;

    public Date(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }
}