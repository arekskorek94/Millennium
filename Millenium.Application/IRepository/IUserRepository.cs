using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Millenium.Application.DTO;
using Millenium.Application.ViewModel;

namespace Millenium.Application.IRepository
{
    public interface IUserRepository
    {
        Task<List<UserVM>> BrowseAsync();
        Task<UserVM> GetAsync(Guid id);
        Task<Guid> AddAsync(UserDto userDto);
        Task<UserVM> UpdateAsync(UserDto userDto, Guid id);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}