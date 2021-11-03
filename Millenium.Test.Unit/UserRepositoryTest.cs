using System;
using Millenium.Application.IRepository;
using NSubstitute;
using Xunit;

namespace Millenium.Test.Unit
{
    public class UserRepository
    {
        private readonly IUserRepository _userRepository; 
        public UserRepository()
        {
            _userRepository = Substitute.For<IUserRepository>();
        }
        [Fact]
        public void Test1()
        {
        }
        
        
    }
}