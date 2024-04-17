using Microsoft.AspNetCore.Mvc;
using GameUploadServer.Data;
using GameUploadServer.Modals;
using GameUploadServer.Modals.ViewModals;
using Microsoft.EntityFrameworkCore;

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

        public async Task <IEnumerable<ProjectData>> GetProjects()
        {
            var _data = await _appDBContext.UserProjects.ToListAsync();

            return _data;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var _data = _appDBContext.UserProjects.FirstOrDefault(x => x.Id == id);
            return Ok(_data);
        }



        [HttpPost]

        public IActionResult AddProject(ProjectViewModel data)
        {
            var _data = new ProjectData()
            {
                ProjectName = data.ProjectName,
                ProjectDescription = data.ProjectDescription,
                ProjectImage = data.ProjectImage,

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
                _data.ProjectImage = data.ProjectImage;


                _appDBContext.UserProjects.Update(_data);
                _appDBContext.SaveChanges();
            }

            return Ok(_data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var _data = _appDBContext.UserProjects.FirstOrDefault(x => x.Id == id);
            if (_data != null)
            {
                _appDBContext.UserProjects.Remove(_data);
                _appDBContext.SaveChanges();
            }

            return Ok();

        }


           
        }


    }



