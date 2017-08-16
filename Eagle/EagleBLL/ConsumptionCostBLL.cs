using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class ConsumptionCostBLL
    {
        private ConsumptionCostDAL consumptionCostDAL;

        public ConsumptionCostDAL ConsumptionCostDAL
        {
            get
            {
                if (consumptionCostDAL == null)
                    consumptionCostDAL = new ConsumptionCostDAL();
                return consumptionCostDAL;
            }
        }

        public int InsertConsumptionCost(ConsumptionCost consumptionCost)
        {
            return ConsumptionCostDAL.InsertConsumptionCost(consumptionCost);
        }

        public bool UpdateConsumptionCost(ConsumptionCost consumptionCost)
        {
            return ConsumptionCostDAL.UpdateConsumptionCost(consumptionCost);
        }

        public ConsumptionCost getConsumptionCostByID(int id)
        {
            return ConsumptionCostDAL.getConsumptionCostByID(id);
        }

        public bool DeleteConsumptionCostByID(int id)
        {
            return ConsumptionCostDAL.DeleteConsumptionCostByID(id);
        }

        public List<ConsumptionCost> ListConsumptionCosts()
        {
            return ConsumptionCostDAL.ListConsumptionCosts();
        }
    }
}

