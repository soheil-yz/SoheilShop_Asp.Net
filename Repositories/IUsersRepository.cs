using SoheilShop.Data;
using SoheilShop.Models;
using System.Linq;

namespace SoheilShop.Repositories
{
    public interface IUsersRepository
    {
        bool IsExistUserEmail(string email);
        void AddUser(Users user);
        Users GetUserForLogin(string email, string password);
    }
    public class UserRepository : IUsersRepository
    {
        private SoheilShopContext _context;
        public UserRepository(SoheilShopContext context)
        {
            _context = context;
        }

        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.Users.SingleOrDefault(u=>u.Email == email && u.Password == password);
        }

        public bool IsExistUserEmail(string email)
        {
            return _context.Users.Any(u=>u.Email== email);
        }
    }
}
