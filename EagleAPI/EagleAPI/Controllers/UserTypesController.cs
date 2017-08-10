using Newtonsoft.Json;
using EagleBLL;
using EagleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace EagleAPI.Controllers
{
    public class UserTypeTypesController : ApiController
    {
        private UserTypeBLL userTypeBLL;

        public UserTypeBLL UserTypeBLL
        {
            get
            {
                if (userTypeBLL == null)
                    userTypeBLL = new UserTypeBLL();
                return userTypeBLL;
            }
        }


        /*private MeetingBLL meetingBLL;

        public MeetingBLL MeetingBLL
        {
            get
            {
                if (meetingBLL == null)
                    meetingBLL = new MeetingBLL();
                return meetingBLL;
            }
        }*/

        // GET api/values
        public JsonResult<List<UserType>> Get()
        {
            List<UserType> userTypes = UserTypeBLL.ListUserTypes();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(userTypes, serializerSettings);
        }

        /*public JsonResult<List<UserType>> Get(string partialName)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(UserTypeBLL.ListUserTypeTypeByPartialName(partialName),serializerSettings);
        }*/

        // GET api/values/5
        public JsonResult<UserType> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(UserTypeBLL.getUserTypeByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string userType)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            UserType u = JsonConvert.DeserializeObject<UserType>(userType, serializerSettings);
            return UserTypeBLL.InsertUserType(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string userType)
        {
            UserType u = JsonConvert.DeserializeObject<UserType>(userType);
            u.ID = id;
            return new { success = UserTypeBLL.UpdateUserType(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = UserTypeBLL.DeleteUserTypeByID(id) };
        }

        /*

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("userTypes/{userTypeID}/meetings")]
        public JsonResult<List<Meeting>> Meetings(int userTypeID)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(MeetingBLL.ListMeetingByUserTypeID(userTypeID), serializerSettings);
        }
        */
    }
}
