using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionRuche.DAL.Models;
using GestionRuche.DAL.Repository;

namespace GestionRuche.API.Controllers
{
    public class ActionController : ApiController
    {
         private ActionRepository action = new ActionRepository();

        // GET api/<controller>
        //public IEnumerable<Actions> Get()
        //{
        //    return new Actions[] { };
            
        //}

        // GET api/<controller>/5
        public Actions Get(int id)
        {
            return action.SelectAction(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Actions value)
        {

            action.InsertAction(value);

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Actions value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            
            action.DeleteAction(id);

        }
    }
}