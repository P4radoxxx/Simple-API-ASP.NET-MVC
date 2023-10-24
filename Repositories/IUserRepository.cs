using WebAPITest.Modeles;

namespace WebAPITest.Repositories
{
    public interface IUserRepository
    {

        public Users CreateUser(Users user);        
        public Users ReadUserID(int id);
        public void  UpdateUser(Users user);
        public void  DeleteUser(int id);
        public List<Users> GetAllUsers();
        Users GetUserByEmail(string email);
    }
}
