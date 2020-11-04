using System;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using Xunit;

namespace lacrosseTest
{
    public class ManagerRepoTest
    {
        [Fact]
        public void UpdateManShouldUpdateMan()
        {
            using var tester = new lacrosseContext();
            IManagerRepo manRepo = new DBRepo(tester);
            Manager man = new Manager();
            man.FirstName = "manFirst";
            man.LastName = "manLast";
            manRepo.AddManager(man);

            man.LastName = "NewLast";
            manRepo.UpdateManager(man);
            var result = manRepo.GetManagerByName(man.FirstName, man.LastName);
            Assert.Equal("NewLast", man.LastName);
            manRepo.DeleteManager(man);
        }
    }
}
