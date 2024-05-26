using GameUploadServer.Data;
using GameUploadServer.Modals;
using GameUploadServer.Modals.ViewModals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameUploadServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {

        private readonly AppDBContext _appDBContext;


        public CommentController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task <IActionResult> GetCommentsForProject()
        {
            var _data = await _appDBContext.UserComments.ToListAsync();


            return Ok(_data);
        }
        [HttpGet("{ProjectDataId}")]
        public async Task<IActionResult> GetById(int ProjectDataId)
        {
            var comments = await _appDBContext.UserComments
                                           .Where(comment => comment.ProjectDataId == ProjectDataId)
                                            .ToListAsync();

            return Ok(comments);
        }



        [HttpPost]

        public async Task<IActionResult>AddComment([FromForm]CommentViewModel data)
        {
            var _data = new CommentData()
            {
                ProjectComment = data.ProjectComment,
                ProjectDataId = data.ProjectDataId,
                CommentOwner = data.CommentOwner,
                CommentName = data.CommentName


            };

          await _appDBContext.UserComments.AddAsync(_data);
          await  _appDBContext.SaveChangesAsync();

            return Ok(_data);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatedById(int id, CommentViewModel data)
        {
            var _data = _appDBContext.UserComments.FirstOrDefault(x => x.Id == id);

            if (_data != null)
            {
                _data.ProjectComment = data.ProjectComment;
                _data.ProjectDataId = data.ProjectDataId;
                _data.CommentOwner = data.CommentOwner;
                _data.CommentName = data.CommentName;





                _appDBContext.UserComments.Update(_data);
                _appDBContext.SaveChanges();
            }

            return Ok(_data);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var comment = _appDBContext.UserComments.FirstOrDefault(x => x.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            var comments = _appDBContext.UserComments.Where(comment => comment.ProjectDataId == id);
            _appDBContext.UserComments.RemoveRange(comments);

            _appDBContext.UserComments.Remove(comment);
            _appDBContext.SaveChanges();

            return Ok();

        }
    }
}
