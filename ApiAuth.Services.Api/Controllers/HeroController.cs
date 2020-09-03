using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using ApiAuth.Services.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        #region Attributes
        private readonly IGenericRepository<Hero> _heroRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public HeroController(IGenericRepository<Hero> heroRepository, IMapper mapper) {
            this._heroRepository = heroRepository;
            this._mapper = mapper;
        }
        #endregion

        #region End points
        [HttpGet]
        [Route("heros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HeroViewDto>>> GetAll() {
            try {
                var result = await _heroRepository.GetAllAsync();

                return _mapper.Map<List<HeroViewDto>>(result);
            }
            catch (Exception) {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("hero/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HeroViewDto>> GetById(string id)
        {
            try
            {
                var result = await _heroRepository.GetByIdAsync(id);

                if (result is null)
                {
                    return NotFound();
                }

                return _mapper.Map<HeroViewDto>(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}