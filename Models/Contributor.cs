namespace WebAPITest.Modeles
{
    public class Contributor
    {

        // foreign key
        public int UserID                 { get; set; }

        // foreign key
        public string? CounterpartID      { get; set; }


        public DateTime? DateContribution { get; set; }
    }
}
