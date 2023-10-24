using System.Text.Json.Serialization;

namespace WebAPITest.Modeles
{
    public class Counterpart
    {

        //Foreign Key
        public int ProjectID       { get; set; }

        // Handled by DB, so not needed for the api.
        [JsonIgnore]
        public int CounterpartID   { get; set; }

        public decimal? Amount     { get; set; }

        public string? Description { get; set; }

    }
}
