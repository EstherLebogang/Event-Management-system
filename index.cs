using System;
using System.Collections.Generic;

// Base class
public class Event
{
    public string EventName { get; set; }
    public int EventID { get; set; }
    public int Capacity { get; set; }

    public Event() { }

    public Event(string eventName, int eventID, int capacity)
    {
        if (capacity < 0)
            throw new ArgumentException("Capacity cannot be negative.");

        EventName = eventName;
        EventID = eventID;
        Capacity = capacity;
    }

    // Method Overloading: DisplayEvent
    public virtual void DisplayEvent()
    {
        Console.WriteLine($"Event ID: {EventID}, Name: {EventName}, Capacity: {Capacity}");
    }

    public void DisplayEvent(string prefix)
    {
        Console.WriteLine($"{prefix} - ID: {EventID}, Name: {EventName}, Capacity: {Capacity}");
    }
}
 

// Derived class: Workshop
public class Workshop : Event
{
    public string Topic { get; set; }
    public string Company { get; set; }

    public Workshop(string eventName, int eventID, int capacity, string topic, string company)
        : base(eventName, eventID, capacity)
    {
        Topic = topic;
        Company = company;
    }

    public override void DisplayEvent()
    {
        base.DisplayEvent();
        Console.WriteLine($"Type: Workshop | Topic: {Topic} | Company: {Company}\n");
    }
}
 

// Derived class: Seminar
public class Seminar : Event
{
    public string Speaker { get; set; }

    public Seminar(string eventName, int eventID, int capacity, string speaker)
        : base(eventName, eventID, capacity)
    {
        Speaker = speaker;
    }

    public override void DisplayEvent()
    {
        base.DisplayEvent();
        Console.WriteLine($"Type: Seminar | Speaker: {Speaker}\n");
    }
}
 
 
// Main Program
class Program
{
    static List<Event> events = new List<Event>();
    static int nextEventID = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Conference Center Menu =====");
            Console.WriteLine("1. Add a Workshop");
            Console.WriteLine("2. Add a Seminar");
            Console.WriteLine("3. View All Events");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddWorkshop();
                        break;
                    case 2:
                        AddSeminar();
                        break;
                    case 3:
                        ViewEvents();
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid menu choice. Please enter 1 to 4.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }

    static void AddWorkshop()
    {
        Console.Write("Enter event name: ");
        string name = Console.ReadLine();
        Console.Write("Enter capacity: ");
        int capacity = int.Parse(Console.ReadLine());
        Console.Write("Enter topic: ");
        string topic = Console.ReadLine();
        Console.Write("Enter company: ");
        string company = Console.ReadLine();

        Workshop workshop = new Workshop(name, nextEventID++, capacity, topic, company);
        events.Add(workshop);
        Console.WriteLine("Workshop added successfully!");
    }

    static void AddSeminar()
    {
        Console.Write("Enter event name: ");
        string name = Console.ReadLine();
        Console.Write("Enter capacity: ");
        int capacity = int.Parse(Console.ReadLine());
        Console.Write("Enter speaker: ");
        string speaker = Console.ReadLine();

        Seminar seminar = new Seminar(name, nextEventID++, capacity, speaker);
        events.Add(seminar);
        Console.WriteLine("Seminar added successfully!");
    }

    static void ViewEvents()
    {
        if (events.Count == 0)
        {
            Console.WriteLine("No events to display.");
            return;
        }

        Console.WriteLine("\n--- List of Events ---");
        foreach (var ev in events)
        {
            ev.DisplayEvent();
        }
    }
}
