using System.Text.Json.Serialization;

namespace WebAPITest.Modeles
{
    public class Project
    {
        //Foreign key
        public int UserID              { get; set; }
        [JsonIgnore]
        public int ProjectID           { get; set; }
        public string? Name            { get; set; }
        public decimal? Amount         { get; set; }
        public DateTime? Created       { get; set; }
        public DateTime? DateAvailable { get; set; }
        public DateTime? EndingDate    { get; set; }

    }
}
