using ThreadsFeature.DTO;
using ThreadsFeature.Models;

namespace ThreadsFeature.IServices
{
    public interface UserService
    {
        public User CreateUser(UserDTO user);
        public User UpdateUser(UserDTO user, string id);
        public User DeleteUser(string id);
        public User GetUser(string id);
        public List<CommentResponseDTO> GetAllTweets(string userId);
        public List<CommentResponseDTO> GetAllReplies(string userId);

    }
}
