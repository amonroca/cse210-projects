// I'm storing prompsts and questions in a LiteDB instance.

using System;

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Menu menu = new Menu();
            menu.DisplayMenu();

            Console.Write("Select a choice from the menu: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity(Constants.BREATHING_ACTIVITY_NAME, Constants.BREATHING_ACTIVITY_DESCRIPTION);
                    breathingActivity.Run();
                    break;

                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity(Constants.REFLECTING_ACTIVITY_NAME, Constants.REFLECTING_ACTIVITY_DESCRIPTION);
                    reflectingActivity.Run();
                    break;

                case "3":
                    ListingActivity listingActivity = new ListingActivity(Constants.LISTING_ACTIVITY_NAME, Constants.LISTING_ACTIVITY_DESCRIPTION);
                    listingActivity.Run();
                    break;

                case "4":
                    Environment.Exit(0);
                    break;
            
                default:
                    Console.WriteLine("\nInvalid value. Please enter a valid value.\n");
                    break;
            }
        }
    }
}