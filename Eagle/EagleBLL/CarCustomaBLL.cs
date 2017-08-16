using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class CarCustomaBLL
    {
        private CarCustomaDAL carCustomaDAL;

        public CarCustomaDAL CarCustomaDAL
        {
            get
            {
                if (carCustomaDAL == null)
                    carCustomaDAL = new CarCustomaDAL();
                return carCustomaDAL;
            }
        }

        public int InsertCarCustoma(CarCustoma carCustoma)
        {
            return CarCustomaDAL.InsertCarCustoma(carCustoma);
        }

        public bool UpdateCarCustoma(CarCustoma carCustoma)
        {
            return CarCustomaDAL.UpdateCarCustoma(carCustoma);
        }

        public CarCustoma getCarCustomaByID(int id)
        {
            return CarCustomaDAL.getCarCustomaByID(id);
        }

        public bool DeleteCarCustomaByID(int id)
        {
            return CarCustomaDAL.DeleteCarCustomaByID(id);
        }

        public List<CarCustoma> ListCarCustomas()
        {
            return CarCustomaDAL.ListCarCustomas();
        }
    }
}

