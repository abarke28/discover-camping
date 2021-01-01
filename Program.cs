using System;

namespace discover_camping
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Checking Berg Lake for availability");

            var tests = new SuiteTests();

            tests.Berg();
        }
    }
}