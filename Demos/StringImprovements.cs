using System;

namespace DevIQ.NewInCSharpSixDemo.Demos
{
    public class StandardPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        { 
            get { return FirstName + " " + LastName; }
        }
        public override string ToString()
        {
            string displayedFirstName = "FirstName: " + FirstName;
            string displayedLastName = "LastName: " + LastName;
            return "StandardPerson - " + displayedFirstName + "\n" + displayedLastName;
        }
    }

    public class ImprovedPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public override string ToString() 
        {
            string displayedFirstName = $"{nameof(FirstName)}: {FirstName}";
            string displayedLastName = $"{nameof(LastName)}: {LastName}";
            return $"{nameof(ImprovedPerson)} - {displayedFirstName}\n{displayedLastName}";
        }
    }

    public class StringImprovements
    {
        public static void RunDemo()
        {
            var steve = new StandardPerson() { FirstName = "Steve", LastName = "Smith" };
            var brendan = new ImprovedPerson() { FirstName = "Brendan", LastName = "Enrick" };

            Console.WriteLine(steve.FullName);
            Console.WriteLine(steve);
            Console.WriteLine();
            Console.WriteLine(brendan.FullName);
            Console.WriteLine(brendan);
            Console.WriteLine();
        }
    }
}