﻿namespace JobBoard.API.Dtos
{
    public class LocationDto
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
    }
}
