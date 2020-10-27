using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.Models
{
    /// <summary>
    /// ticket to an event
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// id of the ticket
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// event id this ticket belongs to
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// id of the user this ticket belongs to
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// number of tickets
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// total amount
        /// </summary>
        public double Amount { get; set; }
    }
}
