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
    public class ProfileController : ControllerBase
    {
        #region Attributes
        private readonly IGenericGetRepository<ProfileEnt> _profileRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ProfileController(IGenericGetRepository<ProfileEnt> profileRepository, IMapper mapper)
        {
            this._profileRepository = profileRepository;
            this._mapper = mapper;
        }
        #endregion

        #region End points
        [HttpGet]
        [Route("profiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfileEntDto>>> GetAll() {
            try {
                var resultProfiles = await _profileRepository.GetAllAsync();
                return _mapper.Map<List<ProfileEntDto>>(resultProfiles);
            }
            catch (System.Exception) {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("profile/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfileEntDto>> GetById(int id) {
            try {
                var resultProfile = await _profileRepository.GetByIdAsync(id);

                if (resultProfile == null) {
                    return NotFound();
                }

                return _mapper.Map<ProfileEntDto>(resultProfile);
            }
            catch (System.Exception) {
                return BadRequest();
            }
        }

        #endregion
    }
}