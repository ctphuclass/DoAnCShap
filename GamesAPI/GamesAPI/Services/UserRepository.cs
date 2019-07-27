using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using GamesAPI.DataAccess;
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

        public ResultMessageModel SaveUser(UserModel contact)
        {
            var ctx = HttpContext.Current;
            ResultMessageModel result = new ResultMessageModel();
            if (ctx != null)
            {
                try
                {
                    UserDataAccess userDataAccess = new UserDataAccess();
                    result = userDataAccess.CreateUser(contact);
                    if(result.Result > 0)
                    {
                        // Email Message Code

                        var currentData = ((UserModel[])ctx.Cache[CacheKey]).ToList();
                        currentData.Add(contact);
                        ctx.Cache[CacheKey] = currentData.ToArray();

                        return result;
                    }
                    else
                    {
                        return result;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    result.Result = -1;
                    result.ResultMessage = ex.ToString();
                    return result;
                }
            }

            result.Result = -1;
            result.ResultMessage = "DONT_HAVE_CONTEXT";
            return result;
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
            
            UserDataAccess userDataAccess = new UserDataAccess();
            UserModel user = userDataAccess.GetUserByUserID(iUserID);
            return user;
            ////var ctx = HttpContext.Current;

            ////if (ctx != null)
            ////{
            ////    return (UserModel[])ctx.Cache[CacheKey];
            ////}

            //return
            //    new UserModel
            //    {
            //        UserID = 0,
            //        UserName = "Placeholder"
            //    };

        }
        public string GetConnectionString()
        {
            string sConnectionString = WebConfigurationManager.AppSettings["ConnectionString"];
            return sConnectionString;
        }
    }
}