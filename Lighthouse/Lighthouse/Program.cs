// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

string UserString = Console.ReadLine();

ReverseString re = new ReverseString();
re.reverseString(UserString);

Console.ReadKey();

public interface IReverseString
{
    void reverseString(string sentance);
    void Print (string sentance);
}

public class ReverseString : IReverseString
{
    public void Print(string sentance)
    {
        Console.Write(sentance + "" + ' ');
    }

    public void reverseString(string sentance)
    {
        int temp;
        string[] a = sentance.Split(' ');
        int k = a.Length - 1;
        temp = k;
        for (int i = k; temp >= 0; k--)
        {
            Print(a[temp] + "" + ' ');
            --temp;
        }       
    }
}