using lacrosseDB.Models;
using System.Collections.Generic;

namespace lacrosseDB.Repos
{
    public interface IProductRepo
    {
        void AddStick (Sticks stick);
        void UpdateStick(Sticks stick);
        Sticks GetStickByStickId(int stickId);
        List<Sticks> GetAllSticks();
        List<Sticks> GetSticksByLocationId (int locationId);
        void DeleteAStick(Sticks stick);

        void AddBall (Balls ball);
        void UpdateBall(Balls ball);
        Balls GetBallByBallId(int ballId);
        List<Balls> GetAllBalls();
        List<Balls> GetBallsByLocationId (int locationId);
        void DeleteABall(Balls ball);
    }
}