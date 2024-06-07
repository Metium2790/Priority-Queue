using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrioriyQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue_Priority queue = new Queue_Priority();

            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1-Add a new person");
                    Console.WriteLine("2-Choose the top person and remove it from queue");
                    Console.WriteLine("3-Upgrade the skill of one person");
                    Console.WriteLine("0-Exit");
                    Console.WriteLine("------------------------------------------------------------------");
                    queue.display();
                    Console.WriteLine("\n------------------------------------------------------------------");
                    Console.Write("CMD: ");
                    int cmd = Convert.ToInt32(Console.ReadLine());
                    switch (cmd)
                    {
                        case 1:
                            {
                                Console.Write("Please enter the age: ");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Please enter the skil(F-E-D-C-B-A): ");
                                string skill = Console.ReadLine();

                                PersonNode person = new PersonNode(age, skill);
                                queue.Add(person);
                                Console.WriteLine("Press to continue");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                queue.removehead();
                                Console.WriteLine("Top person chosen and removed");
                                Console.WriteLine("Press to continue");
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                Console.Write("Please choose the number of the person in queue: ");
                                int n = Convert.ToInt32(Console.ReadLine());
                                queue.skillup(n);
                                Console.WriteLine("Press to continue");
                                Console.ReadKey();
                                break;
                            }
                        case 0:
                            {
                                Console.WriteLine("Good Bye");
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            Console.WriteLine("Please use the right command");
                            Console.WriteLine("Press to continue");
                                Console.ReadKey();
                            break;

                    }
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                Console.ReadKey();
            }


        }
    }
}//coded by MohammadMahdi Mohammadi
