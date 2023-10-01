namespace WebUI.Models
{
    public class CountryPlayer
    {
        public CountryPlayer ( string Color, string CountryName, string CountryCode, string PlayerUsername) {
            this.Color = Color;
            this.CountryName = CountryName;
            this.CountryCode = CountryCode;
            this.PlayerUsername = PlayerUsername;
        }

        public string Color { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string PlayerUsername { get; set; }
    }
}
