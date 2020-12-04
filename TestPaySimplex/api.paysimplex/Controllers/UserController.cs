namespace api.paysimplex.Controllers
{
    using domain.paysimplex.Contracts.Business;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    ///     
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        #region Attributes

        private readonly IUserBusiness _userBusiness;

        #endregion Attributes
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userBusiness"></param>
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

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
            var result = await _userBusiness.Get();

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
            var result = await _userBusiness.GetById(id);

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
            var result = await _userBusiness.GetByName(name);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        /// <response code="201">Register is created</response>
        /// <response code="400">Error to try create</response>  
        [HttpPost("{idUser}")]
        public async Task<IActionResult> Post(domain.paysimplex.Models.User User, long idUser)
        {
            var result = await _userBusiness.Save(User, idUser);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Created(string.Empty, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        /// <response code="200">Register is edited</response>
        /// <response code="400">Error to try edit</response>
        [HttpPut("{idUser}")]
        public async Task<IActionResult> Put(domain.paysimplex.Models.User user, long idUser)
        {
            var result = await _userBusiness.Update(user, idUser);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">Register is deleted</response>
        /// <response code="400">Error to try delete</response>  
        [HttpDelete]
        public async Task<IActionResult> Delete(domain.paysimplex.Models.User user)
        {
            var result = await _userBusiness.Delete(user);

            if (result.ToString().Contains("Error"))
                return BadRequest(result);
            else
                return await Delete(user);
        }

        #endregion Public Methods
    }
}
