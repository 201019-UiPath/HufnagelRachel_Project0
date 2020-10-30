using System.Collections.Generic;
using lacrosseDB.Models;
using System.Threading.Tasks;

namespace lacrosseDB
{
    public interface ILocationRepo
    {
         List<Locations> GetStoreLocations();
         Task<Manager> GetManagerByLocation(int LocationId);
    }
}