namespace Core
{
    public class Location : BaseObject
    {
        public string Country { get; set; }
        public string City { get; set; }

        public float TrafficJamFactor { get; set; }
        public float PublicTransport { get; set; }

        public Location(string id) : base(id)
        {
        }
        
        public Location(Save.Location locationSave) : base(locationSave.Id)
        {
            Country = locationSave.Country;
            City = locationSave.City;
            TrafficJamFactor = locationSave.TrafficJamFactor;
            PublicTransport = locationSave.PublicTransport;
        }

        public override string ToString()
        {
            return $"{Country}, {City}";
        }
    }
}