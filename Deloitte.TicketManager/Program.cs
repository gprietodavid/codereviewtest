using System;

namespace Deloitte.TicketManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            decimal total = 0.0m;

            Console.Write("Flight number? ");
            var flightNumber = Console.ReadLine();
            Console.Write("How many tickets do you want? ");
            var amount = Convert.ToInt16(Console.ReadLine());
            Console.Write("Do you have any discount? ");
            var discount = Convert.ToInt16(Console.ReadLine());

            if (amount > 1)
            {
                var ticketManager = new TicketManager();

                for (int i = 0; i < amount; i++)
                {
                    var ticket = ticketManager.BuyTicket(flightNumber, DateTime.Today, discount);
                    Console.WriteLine($"Your ticket: {ticket}");

                    total = total + ticket.Price;
                }

                Console.WriteLine($"Total: {total:0.00} EUR");
            }
            else
            {
                var ticketManager = new TicketManager();
                var ticket = ticketManager.BuyTicket(flightNumber, DateTime.Today, discount);
                Console.WriteLine($"Your ticket: {ticket}");
                Console.WriteLine($"Total: {total:0.00} EUR");
            }

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }
    }
}