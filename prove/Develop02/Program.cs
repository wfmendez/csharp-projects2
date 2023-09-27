using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();


        while (true)
        {
            Console.WriteLine("This is you Journal Program Menu: Remember that you are the best.");
            Console.WriteLine();
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Display your Journal Summary");
            Console.WriteLine("6. Exit");
            Console.Write("Please, Select an option: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    // How does this case work? When the user chooses "Write a new entry," 
                    // a new Entry instance is created with the current date, a question generated by PromptGenerator, and the answer provided by the user. 
                    // This entry is then added to the journal using the AddEntry method of the Journal class.
                    case 1:
                        string date = DateTime.Now.ToString("yyyy-MM-dd");
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Enter your response: ");
                        string response = Console.ReadLine();
                        journal.AddEntry(new Entry(date, prompt, response));
                        Console.WriteLine();
                        Console.WriteLine("Entry added successfully!");
                        break;

                    // // How does this case work? Uses the DisplayAll method of the Journal class to display all entries stored in the journal.
                    case 2:
                        Console.WriteLine();
                        journal.DisplayAll();
                        break;

                    // Save the journal to a file
                    case 3:
                        Console.WriteLine();
                        Console.Write("Enter the file name to save: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        Console.WriteLine("Journal saved to file successfully!");
                        Console.WriteLine();
                        break;

                    // Load the journal from a file
                    case 4:
                        Console.WriteLine();
                        Console.Write("Enter the file name to load: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadFromFile(loadFileName);
                        Console.WriteLine("Journal loaded from file successfully!");
                        break;

                    case 5:
                        Console.WriteLine();
                        // Show Journal Summary
                        Console.WriteLine("These are your Journal statistics:");
                        journal.DisplayJournalSummary();
                        break;

                    // Close the program
                    case 6:
                        Console.WriteLine();
                        Console.WriteLine("Exiting the program. See you tomorrow :)");
                        return;

                    // Response to invalid option
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Uppss, invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Uppss, invalid input. Please enter a valid option.");
            }
        }
    }   
}