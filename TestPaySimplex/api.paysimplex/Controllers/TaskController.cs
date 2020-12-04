namespace api.paysimplex.Controllers
{
    using domain.paysimplex.Contracts.Business;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        #region Attributes

        private readonly ITaskBusiness _taskBusiness;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskBusiness"></param>
        public TaskController(ITaskBusiness taskBusiness)
        {
            _taskBusiness = taskBusiness;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Json list</response>
        /// <response code="400">Error to try get by name</response>  
        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            var result = await _taskBusiness.Get();

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Json object</response>
        /// <response code="400">Error to try get by name</response>  
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] long id)
        {
            var result = await _taskBusiness.GetById(id);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <response code="200">Json object</response>
        /// <response code="400">Error to try get by name</response>  
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _taskBusiness.GetByName(name);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        /// <response code="201">Register is created</response>
        /// <response code="400">Error to try create</response>  
        [HttpPost("{idUser}")]
        public async Task<IActionResult> Post(domain.paysimplex.Models.Task task, long idUser)
        {
            var result = await _taskBusiness.Save(task, idUser);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Created(string.Empty, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        /// <response code="200">Register is edited</response>
        /// <response code="400">Error to try edit</response>
        [HttpPut("{idUser}")]
        public async Task<IActionResult> Put(domain.paysimplex.Models.Task task, long idUser)
        {
            var result = await _taskBusiness.Update(task, idUser);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="idTask"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        /// <response code="200">Register is edited</response>
        /// <response code="400">Error to try edit</response>
        [HttpPut("{idTask}/{idUser}")]
        public async Task<IActionResult> Put(IFormFile file, long idTask ,long idUser)
        {
            var result = await _taskBusiness.AttachTaskFile(file, idTask, idUser);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <response code="200">Register is deleted</response>
        /// <response code="400">Error to try delete</response>  
        [HttpDelete]
        public async Task<IActionResult> Delete(domain.paysimplex.Models.Task task)
        {
            var result = await _taskBusiness.Delete(task);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return await Delete(task);
        }

        #endregion Public Methods
    }
}
