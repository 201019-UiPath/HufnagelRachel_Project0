using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;
using System.Collections.Generic;

namespace lacrosseLib
{
    public class ManagerServices
    {
        private IManagerRepo managerRepo;

        public ManagerServices(IManagerRepo managerRepo)
        {
            this.managerRepo = managerRepo;
        }

        public void AddManager(Manager manager)
        {
            managerRepo.AddManager(manager);
        }

        public void UpdateManager(Manager manager)
        {
            managerRepo.UpdateManager(manager);
        }

        public Manager GetManagerByManId(int manId)
        {
            Manager manager = managerRepo.GetManagerByManId(manId);
            return manager;
        }

        public Manager GetManagerByName(string firstName, string lastName)
        {
            Manager manager = managerRepo.GetManagerByName(firstName, lastName);
            return manager;
        }

        public List<Manager> GetAllManagers()
        {
            List<Manager> managers = managerRepo.GetAllManagers();
            return managers;
        }

        public void DeleteManager(Manager manager)
        {
            managerRepo.DeleteManager(manager);
        }

    }
}