using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class DriverGainBLL
    {
        private DriverGainDAL driverGainDAL;

        public DriverGainDAL DriverGainDAL
        {
            get
            {
                if (driverGainDAL == null)
                    driverGainDAL = new DriverGainDAL();
                return driverGainDAL;
            }
        }

        public int InsertDriverGain(DriverGain driverGain)
        {
            return DriverGainDAL.InsertDriverGain(driverGain);
        }

        public bool UpdateDriverGain(DriverGain driverGain)
        {
            return DriverGainDAL.UpdateDriverGain(driverGain);
        }

        public DriverGain getDriverGainByID(int id)
        {
            return DriverGainDAL.getDriverGainByID(id);
        }

        public bool DeleteDriverGainByID(int id)
        {
            return DriverGainDAL.DeleteDriverGainByID(id);
        }

        public List<DriverGain> ListDriverGains()
        {
            return DriverGainDAL.ListDriverGains();
        }
    }
}

