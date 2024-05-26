using GameUploadServer.Data;
using GameUploadServer.Modals;
using Microsoft.AspNetCore.Mvc;

namespace GameUploadServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppDBContext _appDBContext;


        public UserController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]

        public IActionResult GetPortfolioData()
        {
            var _data = _appDBContext.UserDatas.ToList();

            return Ok(_data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var _data = _appDBContext.UserDatas.FirstOrDefault(x => x.Id == id);
            return Ok(_data);
        }

        [HttpPost]

        public IActionResult AddProject(UserData data)
        {
            var _data = new UserData()
            {
                UserName = data.UserName,
                UserEmail = data.UserEmail,
                UserId = data.UserId,

            };

            _appDBContext.UserDatas.Add(_data);
            _appDBContext.SaveChanges();

            return Ok(_data);
        }




        [HttpPut("{id}")]
        public IActionResult UpdatedById(int id, UserData data)
        {
            var _data = _appDBContext.UserDatas.FirstOrDefault(x => x.Id == id);

            if (_data != null)
            {
                _data.UserName = data.UserName;
                _data.UserEmail = data.UserEmail;
                _data.UserId = data.UserId;



                _appDBContext.UserDatas.Update(_data);
                _appDBContext.SaveChanges();
            }

            return Ok(_data);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var _data = _appDBContext.UserDatas.FirstOrDefault(x => x.Id == id);
            if (_data != null)
            {
                _appDBContext.UserDatas.Remove(_data);
                _appDBContext.SaveChanges();
            }

            return Ok();
        }

    }
}