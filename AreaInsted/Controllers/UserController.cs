using AreaInsted.Database;
using AreaInsted.Models;
using AreaInsted.Services;
using Microsoft.AspNetCore.Mvc;

namespace AreaInsted.Controllers
{
    [Route("api/area-insted/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService service;

        public UserController(AreaInstedContext context) : base()
        {
            this.service = new UserService(context);
        }

        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<UserDto>> GetAll(int skip, int take)
        {
            try
            {
                List<UserDto> users = this.service.List(skip, take);
                return Ok(users);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserDto> Get(int id)
        {
            try
            {
                UserDto dto = this.service.Select(id);
                return Ok(dto);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<UserDto> Post([FromBody] UserDto dto)
        {
            try
            {
                UserDto result = this.service.Create(dto);
                return Ok(result);
            }
            catch(Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult<UserDto> Put([FromBody] UserDto dto)
        {
            try
            {
                UserDto result = this.service.Update(dto);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public ActionResult<UserDto> Delete([FromBody] UserDto dto)
        {
            try
            {
                UserDto result = this.service.Delete(dto);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UserDto> DeleteById(int id)
        {
            try
            {
                UserDto result = this.service.Delete(id);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
