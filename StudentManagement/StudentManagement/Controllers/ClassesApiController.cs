using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebAPI.EFcore;
using ShoppingWebAPI.Model;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingWebAPI.Controllers
{

    [ApiController]
    public class ClassesApiController : ControllerBase
    {

        private readonly DBHelper _db;
        public ClassesApiController(EF_DataContext db1 )
        {
            _db = new DBHelper(db1);
        }



        // GET: api/<ShoppingApiController>
        [HttpGet]
        [Route("api/[controller]/GetStudents")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<StudentModel> data = _db.GetStudents();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // GET api/<ShoppingApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetStudentById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                StudentModel data = _db.GetStudentByID(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // POST api/<ShoppingApiController>
        [HttpPost]
        [Route("api/[controller]/SaveClass")]
        public IActionResult Post([FromBody] ClassModel model)
        {
            ClassValidator validationRules = new ClassValidator();

            try
            {
                ValidationResult result = validationRules.Validate(model);
                if (!result.IsValid)
                {
                    ResponseType type = ResponseType.Error;
                    var error = result.Errors;
                    return BadRequest(ResponseHandler.GetAppResponse(type, result.Errors));
                }
                else
                {

                    _db.SaveClass(model);
                    ResponseType type = ResponseType.Success;
                    
                    return Ok(ResponseHandler.GetAppResponse(type, model));
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }


        }

        // PUT api/<ShoppingApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateClass")]
        public IActionResult Put([FromBody] ClassModel model)
        {
            try
            {
                _db.SaveClass(model);
                ResponseType type = ResponseType.Success;
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ShoppingApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteClass/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.DeleteClass(id);
                ResponseType type = ResponseType.Success;
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
