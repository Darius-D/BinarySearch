using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Channels;
using System.Transactions;

namespace DariusBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            IsInList(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            GuessMyNumberHuman(new Random().Next(0, 1001));
            GuessMyNumberComputer(85);

        }
        // Implement bisection algorithm; had fun testing out the ?? to throw an exception 
        public static bool IsInList(int[] arr)
        {
            int? value = null;

            try
            {
                Console.WriteLine("please insert a number between 0 and 10: ");
                value = int.Parse(Console.ReadLine() ?? throw new Exception());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                IsInList(arr);
            }

            var firstIndex = 0;
            var lastIndex = arr.Length - 1;
            
            while (firstIndex <= lastIndex)
            {
                var midIndex = (firstIndex + lastIndex) / 2;

                if (arr[midIndex] == value)
                {
                    Console.WriteLine($"The value {value} was in the array at index {midIndex} which the element value was {arr[midIndex]}");
                    
                    return true;
                }
                if (arr[midIndex] > value)
                {
                    Console.WriteLine($"I have not found it yet, value is less than the mid value at index  {midIndex} which held the element value of {arr[(midIndex)]}, moving endpoint  to the middle point minus 1 ");
                    
                    lastIndex = midIndex - 1;
                    Console.Write("next array being searched is: ");
                    for (var i = firstIndex; i <= lastIndex; i++)
                    {
                        Console.Write(arr[i] + ",");
                    }

                    Console.WriteLine($" Next mid point will be index {(midIndex - 1) / 2} which holds the value of {arr[(midIndex-1)/2]} ");
                }
                else if (arr[midIndex] < value)
                {
                    firstIndex = midIndex + 1;
                    Console.WriteLine($"I have not found it yet, value is greater than the mid value at index {midIndex} which held the element value of {arr[midIndex]}, moving starting index to the middle point plus 1 ");
                    Console.Write("next array being searched is: ");
                    for (var i = firstIndex; i <= lastIndex; i++)
                    {
                        Console.Write(arr[i] + ",");
                    }

                    Console.WriteLine($" Next mid point will be index {(firstIndex + lastIndex)/2} which holds the value of {arr[(firstIndex + lastIndex) / 2]} ");
                }


            }

            Console.WriteLine($"\n The value of {value} was not found in this array!");
            return false;
        }

        // Guess my number, Human Plays. Lowest amount of tries it took me averaged between 8 and 11.
        public static bool GuessMyNumberHuman(int computersNumber)
        {
            var count = 0;
            int usersGuess;
            do
            {
                count += 1;
                Console.WriteLine("Please guess a number between 1 and 1000");
                usersGuess = int.Parse(Console.ReadLine() ?? "0");

                if (usersGuess < computersNumber)
                {
                    Console.WriteLine($"you guessed the number {usersGuess} which was to low. Try again! ");
                }

                if (usersGuess > computersNumber)
                {
                    Console.WriteLine($"You guessed the number {usersGuess} which was to high. Try again!");
                }
            } while (usersGuess != computersNumber);

            Console.WriteLine($"You finally guessed the number {computersNumber} correctly! if only took you {count} tries. ");
            return true;
        }

        //Computer Guess. Average was around 5 attempts. 
        public static bool GuessMyNumberComputer(int usersNumber)
        {
            var computersGuess = 50;
            var max = 100;
            var min = 0;
            var count = 0;
            while (computersGuess != usersNumber)
            {
                count++;
                Console.WriteLine(computersGuess + " " + usersNumber);
                
                if (computersGuess > usersNumber)
                {
                    max = computersGuess -1;
                    computersGuess = (min + max) / 2;

                } 
                if (computersGuess < usersNumber)
                {
                    min = computersGuess +1;
                    computersGuess = (min + max) / 2;
                }

                
            }
            Console.WriteLine($"found it! after only {count} tries");
            return true;
        }
    }
}
