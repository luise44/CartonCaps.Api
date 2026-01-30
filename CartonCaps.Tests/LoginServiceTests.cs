using CartonCaps.Application;
using CartonCaps.Data.Entities;
using CartonCaps.Data.Interfaces;
using Moq;

namespace CartonCaps.Tests
{
    [TestClass]
    public class LoginServiceTests
    {
        [TestMethod]
        public void ValidateUser_ReturnsValidLogin()
        {
            var user = new User { Id = Guid.NewGuid(), Email = "test@test.com", Password = "Password" };
            var email = "test@test.com";
            var password = "Password";

            var userMockRepository = new Mock<IUserRepository>();
            userMockRepository.Setup(r => r.GetUserByEmail(It.IsAny<string>())).Returns(user);

            var loginService = new LoginService(userMockRepository.Object);

            var result = loginService.ValidateUser(email, password);

            Assert.IsTrue(result.IsLoginValid);
            Assert.IsNotNull(result.User);
        }

        [TestMethod]
        public void ValidateUser_NotFoundUser_ReturnsInvalidLogin()
        {
            var email = "test@test.com";
            var password = "Password";

            var userMockRepository = new Mock<IUserRepository>();
            userMockRepository.Setup(r => r.GetUserByEmail(It.IsAny<string>())).Returns((User?)null);

            var loginService = new LoginService(userMockRepository.Object);

            var result = loginService.ValidateUser(email, password);

            Assert.IsNull(result.User);
            Assert.IsFalse(result.IsLoginValid);
        }

        [TestMethod]
        public void ValidateUser_IncorrectPassword_ReturnsInvalidLogin()
        {
            var user = new User { Id = Guid.NewGuid(), Email = "test@test.com", Password = "Password" };
            var email = "test@test.com";
            var password = "Incorrect";

            var userMockRepository = new Mock<IUserRepository>();
            userMockRepository.Setup(r => r.GetUserByEmail(It.IsAny<string>())).Returns(user);

            var loginService = new LoginService(userMockRepository.Object);

            var result = loginService.ValidateUser(email, password);

            Assert.IsFalse(result.IsLoginValid);
        }
    }
}