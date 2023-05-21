using AreaInsted.Database;
using AreaInsted.Models;
using AreaInsted.Services;
using Microsoft.AspNetCore.Mvc;

namespace AreaInsted.Controllers
{
    [Route("api/area-insted/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private ClassService service;

        public ClassController(AreaInstedContext context) : base()
        {
            this.service = new ClassService(context);
        }

        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<ClassDto>> GetAll(int skip, int take)
        {
            try
            {
                List<ClassDto> classes = this.service.List(skip, take);
                return Ok(classes);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<ClassDto> Get(int id)
        {
            try
            {
                ClassDto dto = this.service.Select(id);
                return Ok(dto);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<ClassDto> Post([FromBody] ClassDto dto)
        {
            try
            {
                ClassDto result = this.service.Create(dto);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult<ClassDto> Put([FromBody] ClassDto dto)
        {
            try
            {
                ClassDto result = this.service.Update(dto);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public ActionResult<ClassDto> Delete([FromBody] ClassDto dto)
        {
            try
            {
                ClassDto result = this.service.Delete(dto);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ClassDto> DeleteById(int id)
        {
            try
            {
                ClassDto result = this.service.Delete(id);
                return Ok(result);
            }
            catch (Exception err)
            {
                return Problem(detail: err.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
