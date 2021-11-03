using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Millenium.Application.DTO;
using Millenium.Application.Exceptions;
using Millenium.Application.IRepository;
using Millenium.Application.ViewModel;
using Millenium.Domain;

namespace Millenium.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public List<User> UsersList { get; set; }

        public UserRepository()
        {
            UsersList = new List<User>()
            {
                new User() {Id = new Guid("8de43091-d3e2-46b5-a177-6b625aa3ecf4"), FirstName = "John", LastName = "Frog", Age = 33},
                new User() {Id = new Guid("2401177c-1ec2-4ca7-9dd0-a21a463efbc5"), FirstName = "Eric", LastName = "Wall", Age = 36}
            };
        }

        public Task<List<UserVM>> BrowseAsync()
            => Task.FromResult(UsersList.Select(x => new UserVM(){Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Age = x.Age}).ToList());


        public Task<UserVM> GetAsync(Guid id)
        {
            var user = UsersList.FirstOrDefault(x => x.Id == id);
            if (user is null)
                throw new EntityNotFoundException(nameof(User), id);
            return Task.FromResult(new UserVM(){Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Age = user.Age});
        } 

        public Task<Guid> AddAsync(UserDto userDto)
        {
            var user = new User(Guid.NewGuid(), userDto.FirstName, userDto.LastName, userDto.Age);
            UsersList.Add(user);
            return Task.FromResult(user.Id);
        }

        public Task<UserVM> UpdateAsync(UserDto userDto, Guid Id)
        {
            var user = UsersList.FirstOrDefault(x => x.Id == Id);
            if (user is null)
                throw new EntityNotFoundException(nameof(User), Id);
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Age = userDto.Age;
            return Task.FromResult(new UserVM(){Id= user.Id, FirstName = user.FirstName, LastName = user.LastName, Age = user.Age});
        }

        public Task DeleteAsync(Guid id)
        {
            var user = UsersList.FirstOrDefault(x => x.Id == id);
            if (user is null)
                throw new EntityNotFoundException(nameof(User), id);

            UsersList.Remove(user);
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(Guid id)
            => Task.FromResult(UsersList.Any(x => x.Id == id));
    }
}