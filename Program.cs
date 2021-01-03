using discover_camping.helpers;
using discover_camping.loggers;
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

            var logger = new FileLogger();

            using var poller = new ReservationPoller();

            try
            {
                var isAvailable = poller.IsReservationAvailable(XPath.BergLake);

                if (isAvailable)
                {
                    Console.WriteLine("\nReservations ARE available currently");
                    logger.Logger.Information("Reservations are available");

                    var notifier = new EmailNotifier();
                    logger.Logger.Information("Notification email sent");

                    notifier.Notify();
                }
                else
                {
                    Console.WriteLine("\nReservations ARE NOT available currently");
                    logger.Logger.Information("Reservations are not available");
                }
            }
            catch(Exception e)
            {
                logger.Logger.Error($"Error encountered:\n{e}");
                throw;
            }
        }
    }
}