using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class CarBLL
    {
        private CarDAL carDAL;

        public CarDAL CarDAL
        {
            get
            {
                if (carDAL == null)
                    carDAL = new CarDAL();
                return carDAL;
            }
        }

        public int InsertCar(Car car)
        {
            return CarDAL.InsertCar(car);
        }

        public bool UpdateCar(Car car)
        {
            return CarDAL.UpdateCar(car);
        }

        public Car getCarByID(int id)
        {
            return CarDAL.getCarByID(id);
        }

        public bool DeleteCarByID(int id)
        {
            return CarDAL.DeleteCarByID(id);
        }

        public List<Car> ListCars()
        {
            return CarDAL.ListCars();
        }
    }
}

