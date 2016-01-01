using DataCollector.DomainModel;
using DataCollector.Entities;
using DataCollector.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace DataCollector.Mvc.Controllers
{
    public class KeyValueController : ApiController
    {


        public IHttpActionResult Get()
        {
            var currentUserId = User.Identity.GetUserId();

            List<KeyValueOutputViewModel> result;
            using (var dataRepo = new DataStoreRepository())
            {
                result = dataRepo.GetAllDataOfCurrentUser(currentUserId);
            }

            return Ok(result);
        }

        public IHttpActionResult Post(KeyValueDataViewModel vm)
        {
            var currentUserId = User.Identity.GetUserId();
            bool result;
            if (ModelState.IsValid)
            {
                using (var dataRepo = new DataStoreRepository())
                {
                    result = dataRepo.SaveData(vm, currentUserId);
                }

                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}
