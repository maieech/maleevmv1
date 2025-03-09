using System;

namespace RepairRequestApp
{
    public class RepairRequest
    {
        public string Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string DeviceType { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"{Id}: {ClientName} - {DeviceType} ({Status})";
        }
    }
}
