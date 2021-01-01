using discover_camping.Helpers;
using System;

namespace discover_camping
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Checking Berg Lake for availability`n");

            using var poller = new ReservationTests();
            var isAvailable = poller.IsReservationAvailable(XPath.BergLake);

            if (isAvailable)
            {

            }
        }
    }
}