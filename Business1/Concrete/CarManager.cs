using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInavlid);
            }
            
            else if(car.DailyPrice<=0)
            {

                return new ErrorResult(Messages.CarPriceInvalid);

            }

            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            
            

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
                
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(),true,Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CarsListedByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CarsListedByColorId);
        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.CarGetById);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
            
        }
    }
}
