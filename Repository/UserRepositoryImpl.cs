using ThreadsFeature.Data;
using ThreadsFeature.IRepository;
using ThreadsFeature.Models;

namespace ThreadsFeature.Repository
{
    public class UserRepositoryImpl : UserRepository
    {
        private ILogger<UserRepositoryImpl> _logger;
        private readonly ThreadsFeatureDbContext _context;
        public UserRepositoryImpl(ILogger<UserRepositoryImpl> logger, ThreadsFeatureDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public User CreateUser(User user)
        {
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch
            {
                throw new Exception("Creation of user Unsusccessful");
            }
        }

        public User DeleteUser(string id)
        {
            try
            {
                User? user = _context.users.Find(id);
                if (user == null) throw new Exception($"User doesn't exixits with {id}");
                _context.users.Remove(user);
                return user;
            }
            catch
            {
                throw new Exception("Deletion of user Unsusccessful");
            }
        }

        public User GetUserById(string id)
        {
            try
            {
                User? user = _context.users.Find(id);
                if (user == null) throw new Exception($"No User Find with {id}");
                return user;
            }
            catch
            {
                throw new Exception("Getting of user Unsusccessful");
            }
        }

        public User UpdateUser(User user, string id)
        {
            try
            {
                User? exisitingUser = _context.users.Find(id);
                if (user == null) throw new Exception($"No User Find with {id}");
                _context.users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch
            {
                throw new Exception("Updation of user Unsusccessful");
            }
        }
    }
}
