using ThreadsFeature.Models;

namespace ThreadsFeature.IRepository
{
    public interface UserRepository
    {
        public User CreateUser(User user);
        public User UpdateUser(User user, string id);
        public User GetUserById(string id);
        public User DeleteUser(string id);
    }
}
