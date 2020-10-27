using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace TicketingSystem.Models
{
    public class Event
    {
        /// <summary>
        /// unique identifier for an event 
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// date of the event
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// start time of the event
        /// </summary>
        public DateTimeOffset From { get; set; }

        /// <summary>
        /// end time of the event
        /// </summary>
        public DateTimeOffset To { get; set; }

        /// <summary>
        /// name of the event
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// owner of this event
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// venue of the event
        /// </summary>
        public string Venue { get; set; }

        /// <summary>
        /// number of people 
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// general location for the event
        /// </summary>
        public int Location { get; set; }

        /// <summary>
        /// latitude location
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// longitude location
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// cost per ticket
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// age restriction
        /// </summary>
        public AgeRestriction Restriction { get; set; }

        /// <summary>
        /// description of the event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// image urls
        /// </summary>
        [JsonIgnore]
        public string ImageUrls { get; set; }

        /// <summary>
        /// list of images
        /// </summary>
        [NotMapped]
        public List<string> Images { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }

    /// <summary>
    /// age restriction
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AgeRestriction
    {
        /// <summary>
        /// event for children
        /// </summary>
        Children,

        /// <summary>
        /// general event
        /// </summary>
        General,

        /// <summary>
        /// events for adults
        /// </summary>
        Adult,
    }
}
