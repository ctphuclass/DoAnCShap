using GamesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamesAPI.Controllers
{
    public class UserActionController : ApiController
    {
        //// GET: api/UserAction
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/UserAction/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/UserAction
        public HttpResponseMessage Post()
        {
            ResultMessageModel result = new ResultMessageModel();

            var response = Request.CreateResponse<ResultMessageModel>(System.Net.HttpStatusCode.OK, result);

            return response;
        }

        //// PUT: api/UserAction/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/UserAction/5
        //public void Delete(int id)
        //{
        //}
    }
}
