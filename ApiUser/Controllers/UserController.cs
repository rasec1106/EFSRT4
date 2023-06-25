using ApiUser.DTOs;
using ApiUser.Models;
using ApiUser.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiUser.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Route("/GetUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return StatusCode(StatusCodes.Status200OK, await userRepository.GetUsers());
        }

        [Route("/GetUsers/page/{page}/size/{size}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK, await userRepository.GetUsers(page, size));
        }

        [Route("/GetUserById")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await userRepository.GetUserById(id));
        }

        [Route("/CreateUser")]
        [HttpPost]
        // ActionResult is inserted to help customize the kind of response we are sending
        public async Task<ActionResult<ResponseDto>> CreateUser(User user)
        {
            // We wrap it all into StatusCode
            return StatusCode(StatusCodes.Status201Created, await userRepository.CreateUser(user));

        }

        [Route("/Login")]
        [HttpPost]
        // ActionResult is inserted to help customize the kind of response we are sending
        public async Task<ActionResult<ResponseDto>> Login(string username, string password)
        {
            return StatusCode(StatusCodes.Status201Created, await userRepository.Login(username,password));

        }

        [Route("/UpdateUser")]
        [HttpPut]
        public async Task<ActionResult<ResponseDto>> UpdateUser(User user)
        {
            return StatusCode(StatusCodes.Status200OK, await userRepository.UpdateUser(user));
            /* Another way to do this is */
            // return Ok(await userRepository.UpdateUser(User));
        }

        [Route("/DeleteUser")]
        [HttpDelete]
        public async Task<ActionResult<ResponseDto>> DeleteUser(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await userRepository.DeleteUser(id));
        }
    }
}
