﻿namespace DeskBooker.Core.Domain
{
    public class DeskBookingRequest
    {
        

        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}