using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car() {Id=2, BrandId=2, ColorId=2, DailyPrice=0, ModelYear=2014, Description="Hasarsız"};
            
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }

            //carManager.Delete();

        }
    }
}
