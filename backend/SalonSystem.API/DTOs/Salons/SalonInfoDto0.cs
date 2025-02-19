namespace SalonSystem.API.DTOs.Salon
{
    public class SalonInfoDto
    {
        public int SalonId { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string ZipCode { get; set; } = "";
    }
}
