using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.TicketManager
{
    public struct Ticket
    {
        public string FlightId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{FlightId} on {Date:dd/mm/yy}, {Price:0.00} EUR";
        }
    }

    public class TicketManager
    {
        public static Ticket DefaultTicket { get; } = new Ticket { FlightId = "DE0001", Date = DateTime.Today, Price = 100.0m };
        public static int SoldTickets { get; set; } = 1;

        public decimal ApplyDiscount(decimal amount, int type, int years)
        {
            decimal result = 0;
            decimal discount = (years > 5) ? (decimal)5 / 100 : (decimal)years / 100;

            // Discount type 1: no discount
            // Discount type 2: early access customer
            // Discount type 3: employee
            // Discount type 4: friend

            if (type == 1)
            {
                result = amount;
            }
            else if (type == 2)
            {
                result = (amount - (0.1m * amount)) - discount * (amount - (0.1m * amount));
            }
            else if (type == 3)
            {
                result = (0.7m * amount) - discount * (0.7m * amount);
            }
            else if (type == 4)
            {
                result = (amount - (0.5m * amount)) - discount * (amount - (0.5m * amount));
            }

            return result;
        }

        public bool CheckFlightNumber(string number)
        {
            if (number == "DE0001" || number == "DE0002" || number == "DE9999") return true;
            return false;
        }

        public Ticket BuyTicket(string flightNumber, DateTime date, int discount)
        {
            var ticket = DefaultTicket;
            ticket.FlightId = flightNumber;
            ticket.Date = date;
            ticket.Price = ApplyDiscount(ticket.Price, discount, 3);

            if (!CheckFlightNumber(flightNumber)) throw new ArgumentException($"Flight number {flightNumber} incorrect");

            SoldTickets++;

            if (SoldTickets > 1) ticket.Price = ticket.Price - ((0.01m * SoldTickets) * ticket.Price);

            return ticket;
        }
    }
}