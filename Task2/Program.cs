﻿using System.Threading;
namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            char option = '0';

            do
            {
                Console.WriteLine(" P - Print Numbers");
                Console.WriteLine(" A - Add a number");
                Console.WriteLine(" M - Display Mean of the numbers");
                Console.WriteLine(" S - Display the smallest number");
                Console.WriteLine(" L - Display the largest number");
                Console.WriteLine(" F - Find number");
                Console.WriteLine(" C - Clear the whole list");
                Console.WriteLine(" D - Delete number at specific index");
                Console.WriteLine(" Q - Quit");

                Console.Write("Your Option: ");

                option = char.Parse(Console.ReadLine().ToLower()); 

                switch (option)
                {
                    case 'p':
                        if (numbers.Count > 0)
                        {
                            
                            Console.Write("List : [ " );
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                Console.Write(numbers[i] + " " );
                            }
                            Console.WriteLine(']');
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            Console.WriteLine("[ ] The list is empty.");
                        }
                        Console.WriteLine("==============================\n");
                        break;

                    case 'a':
                        Console.WriteLine("Please Enter the number you want to add: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        if (numbers.Count > 0)
                        {
                            bool isDuplicate = false;
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == num)
                                {
                                    Console.WriteLine("The number is already in the list, do you wish to add it anyway? (y/n)");
                                    char ans = Console.ReadLine().ToLower()[0];
                                    if (ans == 'y')
                                    {
                                        numbers.Add(num);
                                        Console.WriteLine($"{num} added successfully.");
                                        numbers.TrimExcess();
                                        isDuplicate = true;
                                        break; // Exit loop after adding the number
                                    }
                                    else if (ans == 'n')
                                    {
                                        Console.WriteLine("The number was not added as it already in the list.");
                                        isDuplicate = true;
                                        break; // Exit loop without adding the number
                                    }
                                }
                            }

                            if (!isDuplicate) // If no duplicate was found, add the number
                            {
                                numbers.Add(num);
                                Console.WriteLine($"{num} added successfully.");
                                numbers.TrimExcess();
                            }
                        }
                        else
                        {
                            numbers.Add(num);
                            Console.WriteLine($"{num} added successfully.");
                            numbers.TrimExcess();
                        }

                        Console.WriteLine("==============================\n");
                        break;

                    case 'm':
                        if (numbers.Count > 0)
                        {
                            double mean = 0;
                            double sum = 0;
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                sum += numbers[i];
                            }
                            mean = sum / numbers.Count;
                            Console.WriteLine($"Mean is {mean}");
                        }
                        else
                        {
                            Console.WriteLine("Unable to calculate the mean as List is empty");
                        }
                        Console.WriteLine("==============================\n");
                        break;

                    case 's':
                        if (numbers.Count > 0)
                        {
                            int smallest = int.MaxValue;
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] < smallest)
                                {
                                    smallest = numbers[i];
                                }
                            }
                            Console.WriteLine($"Smallest number in the list = {smallest}");
                        }
                        else
                        {
                            Console.WriteLine("[ ] The list is empty.");
                        }
                        Console.WriteLine("==============================\n");
                        break;

                    case 'l':
                        if (numbers.Count > 0)
                        {
                            int largest = int.MinValue;
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] > largest)
                                {
                                    largest = numbers[i];
                                }
                            }
                            Console.WriteLine($"Largest number in the list = {largest}");
                        }
                        else
                        {
                            Console.WriteLine("[ ] The list is empty");
                        }
                        Console.WriteLine("==============================\n");
                        break;

                    case 'f':
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine("Please enter the number to search for: ");
                            int numToFind = Convert.ToInt32(Console.ReadLine());
                            bool found = false;

                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == numToFind)
                                {
                                    found = true;
                                    Console.WriteLine($"{numToFind} is found at index {i}");
                                    break;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine($"{numToFind} is not found in the list.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("[ ] The list is empty.");
                        }
                        Console.WriteLine("==============================\n");
                        break;

                    case 'c':
                        
                        if ( numbers.Count > 0)
                        {
                            numbers.Clear();
                            Console.WriteLine(" [ ] List has been cleared successfully.");
                        }else
                            Console.WriteLine("List is already empty.");
                       
                        Console.WriteLine("==============================\n");
                        break;
                    

                    case 'q':

                        Console.WriteLine("Quitting the program...");
                        Thread.Sleep(2000); // Sleep for 2 seconds
                        break;


                    case 'd': 
                        if (numbers.Count > 0)
                        {
                            Console.Write("Enter the index of the number you want to delete: ");
                            int indexToDelete = Convert.ToInt32(Console.ReadLine());

                            // Check if the index is valid
                            if (indexToDelete >= 0 && indexToDelete < numbers.Count)
                            {
                                numbers.RemoveAt(indexToDelete); 
                                Console.WriteLine("Number deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid index.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("[ ] The list is empty.");
                        }
                        Console.WriteLine("==============================\n");
                        break;

                    default:
                        Console.WriteLine("Invalid Input. Please select a valid option.");
                        Console.WriteLine("==============================\n");
                        break;
                }

            } while (option != 'q');
        }
    }
}
