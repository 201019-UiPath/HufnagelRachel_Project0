using System;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using Xunit;

namespace IManagerRepoTest
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
            man.LocationId = 3;
            manRepo.AddManager(man);

            man.LocationId = 1;
            manRepo.UpdateManager(man);
            var result = manRepo.GetManagerByLocationId(man.LocationId);
            Assert.Equal(1, man.LocationId);
            //manRepo.DeleteManager(man);
        }
    }
}
