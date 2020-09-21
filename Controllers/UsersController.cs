using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using stockValues_backend.Data;
using stockValues_backend.Models;
using stockValues_backend.Dtos;
using System.Linq;

namespace stockValues_backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDbRepo _repository;
        private IMapper _mapper;
        private readonly UserContext _context;

        public UsersController(IDbRepo repository, IMapper mapper, UserContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        //GET api/users/
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            if (users != null)
            {
                return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
            }
            return NotFound();
        }

        //GET api/user/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            return NotFound();
        }

        //POST api/user/
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);

            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id }, userReadDto);
        }

        //DELETE api/user/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        private IActionResult ValidateUser(string email, string password){
            var emailDb = _context.Users.Where(u => u.Email == email).FirstOrDefault().ToString();
            var passwordDb = _context.Users.Where(u => u.Password == password).FirstOrDefault().ToString();

            if(emailDb == email && passwordDb == password)
            {
                return Ok(GetAllUsers());
            }
            return NotFound();
        }
    }
}
