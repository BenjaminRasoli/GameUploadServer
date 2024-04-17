using GameUploadServer.Data;
using GameUploadServer.Modals;
using GameUploadServer.Modals.ViewModals;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{projectId}/comments")]
        public IActionResult GetCommentsForProject(int projectId)
        {
            var _data = _appDBContext.UserProjects.FirstOrDefault(x => x.Id == projectId);


            return Ok(_data);
        }


        [HttpPost]

        public async Task<IActionResult>AddComment([FromForm]CommentViewModel data)
        {
            var _data = new CommentData()
            {
                ProjectComment = data.ProjectComment,
                ProjectDataId = data.ProjectDataId


            };

          await _appDBContext.UserComments.AddAsync(_data);
          await  _appDBContext.SaveChangesAsync();

            return Ok(_data);
        }
    }
}
