using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Millenium.Application.DTO;
using Millenium.Application.ViewModel;

namespace Millennium.WebApi.Controllers
{
    public class UserController : ApiControllerBase
    {
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserVM>> GetAsync(Guid id)
            => OkOrNotFound(await UserRepository.GetAsync(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> PostAsync(UserDto dto)
        {
            var userId = await UserRepository.AddAsync(dto);
            if (userId == Guid.Empty)
                return BadRequest();
            return CreatedAtAction("Get", new {id = userId}, userId);
        }
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task DeleteAsync(Guid id)
            => await UserRepository.DeleteAsync(id);

        [HttpPut]
        public async Task<ActionResult<UserVM>> PutAsync(UserDto dto, Guid id)
            => await UserRepository.UpdateAsync(dto, id);
        
    }
}