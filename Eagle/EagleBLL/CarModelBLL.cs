using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class CarModelBLL
    {
        private CarModelDAL carModelDAL;

        public CarModelDAL CarModelDAL
        {
            get
            {
                if (carModelDAL == null)
                    carModelDAL = new CarModelDAL();
                return carModelDAL;
            }
        }

        public int InsertCarModel(CarModel carModel)
        {
            return CarModelDAL.InsertCarModel(carModel);
        }

        public bool UpdateCarModel(CarModel carModel)
        {
            return CarModelDAL.UpdateCarModel(carModel);
        }

        public CarModel getCarModelByID(int id)
        {
            return CarModelDAL.getCarModelByID(id);
        }

        public bool DeleteCarModelByID(int id)
        {
            return CarModelDAL.DeleteCarModelByID(id);
        }

        public List<CarModel> ListCarModels()
        {
            return CarModelDAL.ListCarModels();
        }
    }
}

