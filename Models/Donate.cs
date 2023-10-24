namespace WebAPITest.Modeles
{
    public class Donate
    {

        public int UserID             { get; set; }
        public string? ProjectID      { get; set; }
        public DateOnly? DonationDate { get; set; }
        public decimal? Amount        { get; set; }

    }
}
