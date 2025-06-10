using Module._25.Entities;
using Module._25.Repositories;

namespace Module._25.Tests;

/// <summary>
/// Тесты на проверку CRUD комманд для репозитория пользователя
/// </summary>
public class UserRepositoryTests
{
    [Fact]
    public void CreateNewMustCorrect()
    {
        using (var appContext = new AppContext())
        {
            var user = new User
            {
                Name = "testName",
            };

            IUserRepository userRepository = new UserRepository(appContext);

            userRepository.Create(user);

            Assert.True(user.Name == userRepository.GetAll().Where(u => u.Name == "testName").First().Name);
        }
    }

    [Fact]
    public void UpdateAndReadMustCorrect()
    {
        using (var appContext = new AppContext())
        {
            IUserRepository userRepository = new UserRepository(appContext);
            var user = userRepository.GetAll().Where(u => u.Name == "testName").First();
            user.Email = "1@1.1";

            userRepository.Update(user);

            Assert.True(user.Email == userRepository.GetAll().Where(u => u.Name == "testName").First().Email);
        }
    }

    [Fact]
    public void DeleteByIdMustCorrect()
    {
        using (var appContext = new AppContext())
        {
            IUserRepository userRepository = new UserRepository(appContext);
            var user = userRepository.GetAll().Where(u => u.Name == "testName").First();

            userRepository.Delete(user);

            Assert.True(null == userRepository.GetAll().Where(u => u.Name == "testName").FirstOrDefault());
        }
    }

    [Fact]
    public void AnotherTestsMustCorrect()
    {
        using (var appContext = new AppContext())
        {
            var userRep = new UserRepository(appContext);

            Assert.True(userRep.HasBook("Cry", 1));
            Assert.True(userRep.GetBookCount(1) == 2);
        }
    }
}
