using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class UserTypeBLL
    {
        private UserTypeDAL userTypeDAL;

        public UserTypeDAL UserTypeDAL
        {
            get
            {
                if (userTypeDAL == null)
                    userTypeDAL = new UserTypeDAL();
                return userTypeDAL;
            }
        }

        public int InsertUserType(UserType userType)
        {
            return UserTypeDAL.InsertUserType(userType);
        }

        public bool UpdateUserType(UserType userType)
        {
            return UserTypeDAL.UpdateUserType(userType);
        }

        public UserType getUserTypeByID(int id)
        {
            return UserTypeDAL.getUserTypeByID(id);
        }

        public bool DeleteUserTypeByID(int id)
        {
            return UserTypeDAL.DeleteUserTypeByID(id);
        }

        public List<UserType> ListUserTypes()
        {
            return UserTypeDAL.ListUserTypes();
        }
    }
}
