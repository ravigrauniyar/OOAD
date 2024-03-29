﻿using ExamPrep.DesignPatterns;
namespace ExamPrep
{
    /// <summary>
    /// Represents the entry point and user interface for demonstrating various design patterns.
    /// </summary>
    public class View
    {
        /// <summary>
        /// Main method responsible for displaying a menu and executing chosen design pattern demos.
        /// </summary>
        /// <remarks>
        /// The Main method continuously displays a menu of design pattern options to the user. 
        /// Steps: 
        /// 1. Display a menu with options for different design pattern demos. 
        /// 2. Read user input to determine the chosen option. 
        /// 3. Based on the user's choice, execute the corresponding design pattern demo method. 
        /// 4. Repeat steps 1-3 until the user chooses to exit. 
        /// </remarks>
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine(
                    "\nMENU\n" +
                    "1. Adapter\n" +
                    "2. Factory\n" +
                    "3. Observer\n" +
                    "4. ShapeFactory2017\n" +
                    "5. Singleton\n" +
                    "6. Exit\n" +
                    "\nChoose an option for demo:"
                );
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AdapterDemo.TestAdapter();
                            break;
                        case 2:
                            FactoryDemo.TestFactory();
                            break;
                        case 3:
                            ObserverDemo.TestObserver();
                            break;
                        case 4:
                            ShapeFactoryDemo.TestShapeFactory();
                            break;
                        case 5:
                            SingletonDemo.TestSingleton();
                            break;
                        case 6:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            throw new Exception("Invalid choice!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nException: {0}.\n", ex.Message);
                }
            }
        }
    }
}
