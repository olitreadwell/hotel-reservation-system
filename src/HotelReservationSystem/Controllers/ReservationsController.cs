using HotelReservationSystemTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static readonly Random random = new Random(); // Reuse Random instance for better randomness

        // List of random last names
        private static readonly List<string> lastNames = new List<string>
        {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis"
        };

        // List of city names
        private static readonly List<string> cityNames = new List<string>
        {
            "New York", "Los Angeles", "Chicago", "Miami", "Seattle", "Denver", "Austin", "Boston"
        };

        // List of synonyms for "hotel"
        private static readonly List<string> hotelSynonyms = new List<string>
        {
            "Inn", "Resort", "Lodge", "Suites", "Retreat", "Villa", "Palace", "Oasis"
        };

        // List of reservation comment phrases
        private static readonly List<string> commentPhrases = new List<string>
        {
            "Requested late check-in.", "VIP customer with additional services.",
            "Allergic to pet dander, avoid pet-friendly rooms.", "Needs airport shuttle service.",
            "Celebrating an anniversary, add complimentary wine."
        };

        // GET: api/Reservations/ReservationID
        [HttpGet("{reservationid}", Name = "Get")]
        public CustomerReservation Get(int reservationid)
        {
            // Pretend to do some work
            Thread.SpinWait(int.MaxValue / 500);

            // Generate dummy data for the reservation
            DateTime checkin = DateTime.Now.AddDays(random.Next(1, 30));
            DateTime checkout = checkin.AddDays(random.Next(1, 14));
            
            return new CustomerReservation
            {
                ReservationID = reservationid,
                CustomerID = GenerateCustomerID(),
                CustomerLastName = lastNames[random.Next(lastNames.Count)],
                HotelID = GenerateHotelName(),
                Checkin = checkin,
                Checkout = checkout,
                NumberOfGuests = random.Next(1, 5),
                ReservationComments = GenerateRandomComment()
            };
        }

        // Generates a unique customer ID
        private string GenerateCustomerID()
        {
            return $"CUST-{random.Next(1000, 9999)}";
        }

        // Generates a random hotel name like "Seattle Villa" or "Miami Inn"
        private string GenerateHotelName()
        {
            string city = cityNames[random.Next(cityNames.Count)];
            string hotelType = hotelSynonyms[random.Next(hotelSynonyms.Count)];
            return $"{city} {hotelType}";
        }

        // Selects random comments or combination of comments
        private string GenerateRandomComment()
        {
            int commentCount = random.Next(1, commentPhrases.Count);
            List<string> selectedComments = new List<string>();
            
            for (int i = 0; i < commentCount; i++)
            {
                selectedComments.Add(commentPhrases[random.Next(commentPhrases.Count)]);
            }
            return string.Join(" ", selectedComments);
        }

        // Other CRUD methods...

        // POST: api/Reservations
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // Pretend to do some work
            Thread.SpinWait(int.MaxValue / 100);
        }

        // PUT: api/Reservations/ReservationID
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // Pretend to do some work
            Thread.SpinWait(int.MaxValue / 100);
        }

        // DELETE: api/ApiWithActions/ReservationID
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Pretend to do some work
            Thread.SpinWait(int.MaxValue / 50);
        }
    }
}
