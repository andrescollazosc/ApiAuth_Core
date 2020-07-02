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
    public class UserController : ControllerBase
    {

        #region Attributes
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Controllers
        public UserController(IGenericRepository<Users> userRepository, IMapper mapper) {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        #endregion

        #region End points
        [HttpGet]
        [Route("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserViewDto>>> GetUsers() {
            try {
                var userList = await _userRepository.GetAllAsync();
                return _mapper.Map<List<UserViewDto>>(userList);
            }
            catch (Exception excpetion) {
                return BadRequest(excpetion.Message);
            }
        }

        [HttpGet]
        [Route("userbyid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserViewDto>> GetUser(int id)
        {
            try {
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null) {
                    return NotFound();
                }

                return Ok(_mapper.Map<UserViewDto>(user));
            }
            catch (Exception excpetion) {
                return BadRequest(excpetion.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserSignUpDto>> PostUser(UserSignUpDto userSignUpDto) {
            try {
                var newUser = await _userRepository.AddAsync(_mapper.Map<Users>(userSignUpDto));

                if (newUser == null) {
                    return BadRequest();
                }

                var newUserDto = _mapper.Map<UserSignUpDto>(newUser);
                return CreatedAtAction(nameof(PostUser), new { id = newUserDto.Id, newUserDto });
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }

        [HttpPut()]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserUpdateDto>> UpdateUser(int id, [FromBody]UserUpdateDto userSignUpDto) {
            try {
                if (userSignUpDto == null) {
                    return NotFound();
                }

                var result = await _userRepository.UpdateAsync(_mapper.Map<Users>(userSignUpDto));

                if (!result) {
                    return BadRequest();
                }

                return userSignUpDto;
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }

        [HttpDelete()]
        [Route("remove/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteUser(int id) {
            try {
                var result = await _userRepository.DeleteAsync(id);

                if (!result) {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }


        #endregion

    }
}