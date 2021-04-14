using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDataBaseContext>, ICarDal
    {
        public List<CarDetailDto> GetDetails()
        {
            using (ReCapProjectDataBaseContext context = new ReCapProjectDataBaseContext())

            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.BrandName,
                                 CarName = car.CarName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };

                return result.ToList();
            }


        }
    }
}
