using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    public class Bucket
    {
        public string Number { get; set; } = string.Empty;
        public int Date { get; set; }
        public Bucket(string number, int date)
        {
            Number = number;
            Date = date;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var buckets = new List<(Bucket, int)>()
            {
             (new("Ferris State University", 3), 4),
             (new("Michigan Tech University", 2), 2),
             (new("Ohio State University", 4), 1),
             (new("Michigan State University", 1), 5),
             (new("Angie Woods", 5), 3)
            };
             
            var BucketQueue = new PriorityQueue<Bucket, int>(buckets);
            int selection = Menu();
            string date;
            int number, priority;
            while (selection != 4)
            {
                switch (selection)
                {
                    case 1: 
                        Console.WriteLine("When Are You Going?: ");
                        date = Console.ReadLine();
                        Console.WriteLine("Flight Number: ");
                        number = int.Parse(Console.ReadLine());
                        Console.WriteLine("On a scale from 1-10 Priority: ");
                        priority = int.Parse(Console.ReadLine());
                        BucketQueue.Enqueue(new Bucket(date, number), priority);
                        break;
                    case 2:
                        BucketQueue.TryPeek(out Bucket nextBucket, out int patientPriority);
                        Console.WriteLine($"College on List: Number {nextBucket.Date} pick, Location: {nextBucket.Number}");
                        break;
                    case 3: 
                        BucketQueue.TryDequeue(out Bucket dischargeBucket, out int dischargePriority);
                        Console.WriteLine($"Internship Acceptance: Number{dischargeBucket.Date}, Location: {dischargeBucket.Number}");
                        break;
                    default:
                        Console.WriteLine("You have made an invalid selection, please try again");
                        break;
                }
                selection = Menu();
            }

        }
        static int Menu()
        {
            Console.WriteLine("Patient Priority Queue");
            Console.WriteLine("1 to Go To Paris\n2 to Finish College\n3 to Start an Internship\n4 to Quit and Retire");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
