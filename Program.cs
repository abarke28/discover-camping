using discover_camping.Helpers;
using System;

namespace discover_camping
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("CHECKING BERG LAKE FOR AVAILABILITY\n");

            using var poller = new ReservationTests();
            var isAvailable = poller.IsReservationAvailable(XPath.BergLake);

            if (isAvailable)
            {
                Console.WriteLine("Reservations ARE available");
            }
            else
            {
                Console.WriteLine("Reservations ARE NOT available currently");
            }
        }
    }
}