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
            //Car car2 = new Car() {Id=2, BrandId=2, ColorId=2, DailyPrice=10, ModelYear=2014, Description="Hasarsiz"};

            //CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.ModelYear);
            //}

            //carManager.Delete(car2);
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //brandManager.Add(new Brand() { BrandId = 1, BrandName = "Audi" });
            //colorManager.Add(new Color() { ColorId = 1, ColorName = "White" });
            //carManager.Add(new Car() {CarId =1, BrandId =1, ColorId =1, DailyPrice =500, ModelYear = 2012, Description ="Çıtır Hasarlı", CarName="A4"  });

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4} / {5} / {6}", car.CarId, car.BrandName, car.CarName, car.ModelYear,car.ColorName, car.Description, car.DailyPrice);
            }
           
        }
    }
}
