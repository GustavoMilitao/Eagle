using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class FreightBLL
    {
        private FreightDAL freightDAL;

        public FreightDAL FreightDAL
        {
            get
            {
                if (freightDAL == null)
                    freightDAL = new FreightDAL();
                return freightDAL;
            }
        }

        public int InsertFreight(Freight freight)
        {
            return FreightDAL.InsertFreight(freight);
        }

        public bool UpdateFreight(Freight freight)
        {
            return FreightDAL.UpdateFreight(freight);
        }

        public Freight getFreightByID(int id)
        {
            return FreightDAL.getFreightByID(id);
        }

        public bool DeleteFreightByID(int id)
        {
            return FreightDAL.DeleteFreightByID(id);
        }

        public List<Freight> ListFreights()
        {
            return FreightDAL.ListFreights();
        }
    }
}

