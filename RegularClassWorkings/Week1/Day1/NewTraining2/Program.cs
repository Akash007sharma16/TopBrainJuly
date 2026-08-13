using System;
class Program
{
    static void Main()
    {
        int[] OddEvenArr = {10,20,30,40,50};
        int  evenCount = 0;
        int oddCount = 0;

        for(int i=0;i<OddEvenArr.Length;i++)
        {
            if(OddEvenArr[i]%2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }

        Console.WriteLine("Count of Even Numbers = "+ evenCount);
        Console.WriteLine("Count of Odd Numbers = "+oddCount);
    }
}
