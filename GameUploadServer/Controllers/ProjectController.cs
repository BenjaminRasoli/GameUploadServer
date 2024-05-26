using Microsoft.AspNetCore.Mvc;
using GameUploadServer.Data;
using GameUploadServer.Modals;
using GameUploadServer.Modals.ViewModals;
using Microsoft.EntityFrameworkCore;
using static GameUploadServer.Modals.ViewModals.ProjectViewModel;

namespace GameUploadServer.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {

        private readonly AppDBContext _appDBContext;


        public ProjectController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }


        [HttpGet]

        public async Task <IActionResult> GetProjects()
        {
            var _data = await _appDBContext.UserProjects
                .Select(c => new ProjectCommentViewModel()
                {
                    Id=c.Id,
                    ProjectName = c.ProjectName,
                    ProjectDescription = c.ProjectDescription,
                    ProjectImageUrl = c.ProjectImageUrl,
                    ProjectGameId = c.ProjectGameId,
                    ProjectOwner = c.ProjectOwner,
                    Comments = c.Comments.Select(comment => comment.ProjectComment).ToList()
                }).ToListAsync();

            return Ok(_data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var _data = _appDBContext.UserProjects.FirstOrDefault(x => x.Id == id);
            return Ok(_data);
        }



        [HttpPost]

        public IActionResult AddProject([FromForm]ProjectViewModel data)
        {
            var _data = new ProjectData()
            {
                ProjectName = data.ProjectName,
                ProjectDescription = data.ProjectDescription,
                ProjectImageUrl = data.ProjectImageUrl,
                ProjectGameId = data.ProjectGameId,
                ProjectOwner = data.ProjectOwner,
            };

      

            _appDBContext.UserProjects.Add(_data);
            _appDBContext.SaveChanges();

            return Ok(_data);


        }

        [HttpPut("{id}")]
        public IActionResult UpdatedById(int id, ProjectViewModel data)
        {
            var _data = _appDBContext.UserProjects.FirstOrDefault(x => x.Id == id);

            if (_data != null)
            {
                _data.ProjectName = data.ProjectName;
                _data.ProjectDescription = data.ProjectDescription;
                _data.ProjectImageUrl = data.ProjectImageUrl;
                _data.ProjectGameId = data.ProjectGameId;
                _data.ProjectOwner = data.ProjectOwner;


                _appDBContext.UserProjects.Update(_data);
                _appDBContext.SaveChanges();
            }

            return Ok(_data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var project = _appDBContext.UserProjects.FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                return NotFound(); 
            }

            var comments = _appDBContext.UserComments.Where(comment => comment.ProjectDataId == id);
            _appDBContext.UserComments.RemoveRange(comments);

            _appDBContext.UserProjects.Remove(project);
            _appDBContext.SaveChanges();

            return Ok();

        }


           
        }


    }



