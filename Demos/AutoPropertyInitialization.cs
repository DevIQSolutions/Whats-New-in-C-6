using System;
namespace DevIQ.NewInCSharpSixDemo.Demos
{
    public class AutoPropPerson
    {
        public string FirstName { get; set; } = "Viq";
        public string LastName { get; set; } = "Smith";
    }
    
    public class AutoPropertyInitialization
    {
        public static void RunDemo()
        {
            var viq = new AutoPropPerson();
            Console.WriteLine(string.Format("AutoPropPerson: {0} {1}", viq.FirstName, viq.LastName));
        }
    }
}