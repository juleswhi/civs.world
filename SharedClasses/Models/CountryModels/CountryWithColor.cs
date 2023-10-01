namespace SharedClasses.Models.CountryModels
{
    public class CountryWithColor
    {
        public CountryWithColor (string Country, string Color, string Code, string Username) {
            this.Country = Country;
            this.Color = Color;
            this.Code = Code;
            this.Username = Username;
        }

        public string Country { get; set; }
        public string Color { get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
    }
}
