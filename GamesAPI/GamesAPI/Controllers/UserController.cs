using GamesAPI.Models;
using GamesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamesAPI.Controllers
{
    public class UserController : ApiController
    {
        private UserRepository userRepository;
        public UserController()
        {
            userRepository = new UserRepository();
        }
        // GET api/user
        public UserModel[] Get()
        {
            return userRepository.GetAllUser();
            
        }

        public UserModel Get(int id)
        {
            return userRepository.GetUser(id);
            
        }

        // POST api/user
        public HttpResponseMessage Post(UserModel user)
        {
            ResultMessageModel result = this.userRepository.SaveUser(user);

            var response = Request.CreateResponse<ResultMessageModel>(System.Net.HttpStatusCode.OK, result);

            return response;
        }
    }
}
