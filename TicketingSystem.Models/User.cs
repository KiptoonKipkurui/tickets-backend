using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketingSystem.Models
{
    /// <summary>
    /// user model
    /// </summary>
    public class User
    {
        /// <summary>
        /// unique identifier of a user
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// url to the photo supplied by google or facebook
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// kind of user
        /// </summary>
        public UserKind Kind { get; set; }

        /// <summary>
        /// events
        /// </summary>
        public ICollection<Event> Events { get; set; }

        /// <summary>
        /// tickets
        /// </summary>
        public ICollection<Ticket> Tickets { get; set; }
    }

    /// <summary>
    /// user kind
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserKind
    {
        /// <summary>
        /// consumer
        /// </summary>
        Consumer,

        /// <summary>
        /// merchant
        /// </summary>
        Merchant,

        /// <summary>
        /// administrator
        /// </summary>
        Admin,       
    }
}
