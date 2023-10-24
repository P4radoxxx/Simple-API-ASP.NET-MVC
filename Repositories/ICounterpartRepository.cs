using WebAPITest.Modeles;

namespace WebAPITest.Repositories
{
    public interface ICounterpartRepository
    {
        public void CreateCounterpart(Counterpart counterpart);
        public Counterpart ReadCounterpartID(int id);
        public void UpdateCounterpart(Counterpart counterpart);
        public void DeleteCounterpart(int id);
        public List<Counterpart> GetAllCounterparts();
    }
}
