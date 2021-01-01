using discover_camping.Helpers;
using discover_camping.notifiers;
using System;

namespace discover_camping
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("CHECKING BERG LAKE FOR AVAILABILITY\n");

            using var poller = new ReservationPoller();
            var isAvailable = poller.IsReservationAvailable(XPath.BergLake);

            if (isAvailable)
            {
                Console.WriteLine("Reservations ARE available");
                
                using var notifier = new EmailNotifier();

                notifier.Notify();
            }
            else
            {
                Console.WriteLine("Reservations ARE NOT available currently");
            }
        }
    }
}