﻿using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class UserBLL
    {
        private UserDAL userDAL;

        public UserDAL UserDAL
        {
            get
            {
                if (userDAL == null)
                    userDAL = new UserDAL();
                return userDAL;
            }
        }

        public int InsertUser(User user)
        {
            return UserDAL.InsertUser(user);
        }

        public bool UpdateUser(User user)
        {
            return UserDAL.UpdateUser(user);
        }

        public User getUserByID(int id)
        {
            return UserDAL.getUserByID(id);
        }

        public User getUserByUserNameAndPassword(string username, string password)
        {
            return UserDAL.getUserByUserNameAndPassword(username, password);
        }

        public bool DeleteUserByID(int id)
        {
            return UserDAL.DeleteUserByID(id);
        }

        public List<User> ListUsersByPartialName(string partialName)
        {
            return UserDAL.ListUsersByPartialName(partialName);
        }

        public List<User> ListUsers()
        {
            return UserDAL.ListUsers();
        }
    }
}
