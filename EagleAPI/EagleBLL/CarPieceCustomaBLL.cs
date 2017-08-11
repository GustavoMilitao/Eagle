using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class CarPieceCustomaBLL
    {
        private CarPieceCustomaDAL carPieceCustomaDAL;

        public CarPieceCustomaDAL CarPieceCustomaDAL
        {
            get
            {
                if (carPieceCustomaDAL == null)
                    carPieceCustomaDAL = new CarPieceCustomaDAL();
                return carPieceCustomaDAL;
            }
        }

        public int InsertCarPieceCustoma(CarPieceCustoma carPieceCustoma)
        {
            return CarPieceCustomaDAL.InsertCarPieceCustoma(carPieceCustoma);
        }

        public bool UpdateCarPieceCustoma(CarPieceCustoma carPieceCustoma)
        {
            return CarPieceCustomaDAL.UpdateCarPieceCustoma(carPieceCustoma);
        }

        public CarPieceCustoma getCarPieceCustomaByID(int id)
        {
            return CarPieceCustomaDAL.getCarPieceCustomaByID(id);
        }

        public bool DeleteCarPieceCustomaByID(int id)
        {
            return CarPieceCustomaDAL.DeleteCarPieceCustomaByID(id);
        }

        public List<CarPieceCustoma> ListCarPieceCustomas()
        {
            return CarPieceCustomaDAL.ListCarPieceCustomas();
        }
    }
}

