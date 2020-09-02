using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using ApiAuth.Services.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuth.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IGenericGetRepository<Menu> _menurepository;
        private readonly IMapper _mapper;

        public MenuController(IGenericGetRepository<Menu> _menurepository, IMapper mapper)
        {
            this._menurepository = _menurepository;
            this._mapper = mapper;
        }


        [HttpGet]
        [Route("menus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MenuDto>>> GetAll() {
            try {
                var result = await _menurepository.GetAllAsync();

                return _mapper.Map<List<MenuDto>>(result);
            }
            catch (Exception exception) {
                return BadRequest(exception.Message);
            }   
        }


    }
}