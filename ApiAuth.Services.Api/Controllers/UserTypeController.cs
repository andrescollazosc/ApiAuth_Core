using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using ApiAuth.Services.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        #region Attributes
        private readonly IGenericGetRepository<UserType> _userTypeRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public UserTypeController(IGenericGetRepository<UserType> userTypeRepository, IMapper mapper)
        {
            this._userTypeRepository = userTypeRepository;
            this._mapper = mapper;
        }
        #endregion

        #region End points
        [HttpGet]
        [Route("userTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserTypeDto>>> GetAll()
        {
            try
            {
                var resultUserTypes = await _userTypeRepository.GetAllAsync();
                return _mapper.Map<List<UserTypeDto>>(resultUserTypes);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("userType/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserTypeDto>> GetById(int id)
        {
            try
            {
                var resultUserType = await _userTypeRepository.GetByIdAsync(id);

                if (resultUserType == null) {
                    return NotFound();
                }

                return _mapper.Map<UserTypeDto>(resultUserType);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}