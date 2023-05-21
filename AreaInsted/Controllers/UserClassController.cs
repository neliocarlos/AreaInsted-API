using AreaInsted.Database;
using AreaInsted.Models;
using AreaInsted.Services;
using Microsoft.AspNetCore.Mvc;

namespace AreaInsted.Controllers
{
    [Route("api/area-insted/[controller]")]
    [ApiController]
    public class UserClassController : ControllerBase
    {
        private UserClassService service;

        public UserClassController(AreaInstedContext context) : base()
        {
            this.service = new UserClassService(context);
        }

        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<UserClassDto>> GetAll(int skip, int take)
        {
            try
            {
                List<UserClassDto> userClass = this.service.List(skip, take);
                return Ok(userClass);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserClassDto> Get(int id)
        {
            try
            {
                UserClassDto dto = this.service.Select(id);
                return Ok(dto);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<UserClassDto> Post([FromBody] UserClassDto dto)
        {
            try
            {
                UserClassDto result = this.service.Create(dto);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult<UserClassDto> Put([FromBody] UserClassDto dto)
        {
            try
            {
                UserClassDto result = this.service.Update(dto);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public ActionResult<UserClassDto> Delete([FromBody] UserClassDto dto)
        {
            try
            {
                UserClassDto result = this.service.Delete(dto);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UserClassDto> DeleteById(int id)
        {
            try
            {
                UserClassDto result = this.service.Delete(id);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
