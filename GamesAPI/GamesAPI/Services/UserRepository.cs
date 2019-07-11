using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using GamesAPI.Models;

namespace GamesAPI.Services
{
    public class UserRepository
    {
        private const string CacheKey = "UserStore";
        public UserRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var users = new UserModel[]
                    {
                        new UserModel
                        {
                            UserID = 1, UserName = "admin"
                        }
                    };

                    ctx.Cache[CacheKey] = users;
                }
            }
        }
        public bool SaveUser(UserModel contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((UserModel[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
        public UserModel[] GetAllUser()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (UserModel[])ctx.Cache[CacheKey];
            }

            return new UserModel[]
                {
                    new UserModel
                    {
                        UserID = 0,
                        UserName = "Placeholder"
                    }
                };
        }
        public UserModel GetUser(int iUserID)
        {
            //var ctx = HttpContext.Current;

            //if (ctx != null)
            //{
            //    return (UserModel[])ctx.Cache[CacheKey];
            //}

            return
                new UserModel
                {
                    UserID = 0,
                    UserName = "Placeholder"
                };
               
        }
        //public string GetConnectionString()
        //{
        //    string sConnectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        //    return sConnectionString;
        //}
    }
}