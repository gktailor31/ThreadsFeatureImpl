using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThreadsFeature.DTO;
using ThreadsFeature.IServices;
using ThreadsFeature.Models;
using ThreadsFeature.utils;

namespace ThreadsFeature.Controllers
{
    [ApiController]
    [Route("api/thread")]
    public class ThreadController : Controller
    {
        private readonly ILogger<ThreadController> _logger;
        private readonly ThreadService _threadService;
        private readonly HelperService _helperService;

        public ThreadController(ILogger<ThreadController> logger, ThreadService threadService, HelperService helperService)
        {
            _logger = logger;
            _threadService = threadService;
            _helperService = helperService;
        }

        [HttpGet("{commentId}")]
        public ActionResult<CommentResponseDTO> GetComment(string commentId)
        {
            return Ok(_helperService.ConvertCommentToCommentResponse(_threadService.GetComment(commentId)));
        }

        [HttpPost]
        public ActionResult<CommentResponseDTO> CreateComment(CommentDTO commentDTO)
        {
            return Ok(_threadService.CreateComment(commentDTO));
        }

        [HttpPost("/like")]
        public ActionResult<bool> LikeOperation(LikeRequestDTO likeRequestDTO)
        {
            return Ok(_threadService.LikeOps(likeRequestDTO.CommentId, likeRequestDTO.UserID, true));
        }
        [HttpPost("/remove-like")]
        public ActionResult<bool> RemoveLikeOperation(LikeRequestDTO likeRequestDTO)
        {
            return Ok(_threadService.LikeOps(likeRequestDTO.CommentId, likeRequestDTO.UserID, false));
        }

        [HttpGet("/children/{commentId}")]
        public ActionResult<List<CommentResponseDTO>> GetAllChildren(string commentId)
        {

            return Ok(_threadService.GetReplies(commentId));
        }

        [HttpGet("/parent/{commentId}")]
        public ActionResult<CommentResponseDTO> GetParent(string commentId)
        {
            return Ok(_threadService.GetParentComment(commentId));
        }

        [HttpGet("/likes/{commentId}")]
        public ActionResult<List<UserResponseDTO> >GetLikesUser(string commentId)
        {
            return Ok(_threadService.GetUsersLikedTheComment(commentId));
        }

        [HttpDelete("{commentId}")]
        public ActionResult<bool> DeleteComment(string commentId)
        {
            return Ok(_threadService.DeleteComment(commentId));
        }

        [HttpPut("{commentId}")]
        public ActionResult<CommentResponseDTO> UpdateComment([FromBody] CommentDTO commentDTO, string commentId)
        {
            return Ok(_helperService.ConvertCommentToCommentResponse(_threadService.UpdateComment(commentDTO, commentId)));
        }

    }
}
