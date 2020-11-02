using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;
using System.Collections.Generic;


namespace lacrosseLib
{
    public class ProductServices
    {
        // this will include methods for both balls and sticks
        private IProductRepo prodRepo;

        public ProductServices(IProductRepo prodRepo)
        {
            this.prodRepo = prodRepo;
        }

        public void AddBall(Balls ball)
        {
            prodRepo.AddBall(ball);
        }

        public void AddStick(Sticks stick)
        {
            prodRepo.AddStick(stick);
        }

        public void UpdateBall(Balls ball)
        {
            prodRepo.UpdateBall(ball);
        }

        public void UpdateStick(Sticks stick)
        {
            prodRepo.UpdateStick(stick);
        }

        public void GetBallByBallId(int ballId)
        {
            Balls ball = prodRepo.GetBallByBallId(ballId);
            return ball;
        }

        public void GetStickByStickId(int stickId)
        {
            Sticks stick = prodRepo.GetStickByStickId(stickId);
            return stick;
        }

        public List<Balls> GetAllBalls()
        {
            List<Balls> balls = prodRepo.GetAllBalls();
            return balls;
        }

        public List<Sticks> GetAllSticks()
        {
            List<Sticks> sticks = prodRepo.GetAllSticks();
            return sticks;
        }

        public List<Balls> GetBallsByLocationId(int locationId)
        {
            List<Balls> balls = prodRepo.GetBallsByLocationId(locationId);
            return balls;
        }

        public List<Sticks> GetSticksByLocationId(int locationId)
        {
            List<Sticks> sticks = prodRepo.GetSticksByLocationId(locationId);
            return sticks;
        }

        public void DeleteBall(Balls ball)
        {
            prodRepo.DeleteBall(ball);
        }

        public void DeleteStick(Sticks stick)
        {
            prodRepo.DeleteStick(stick);
        }
    }
}