using FinalAssignment.Repositories;
using SocialHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialHub.Controllers
{
    public class UsersController : ApiController
    {
        private UserRepository userRepository = new UserRepository();
        public IHttpActionResult Get()
        {

            return Ok(userRepository.GetAll());
        }
        public IHttpActionResult Get(int id)
        {
            User user = userRepository.Get(id);
            if (user != null)
            {
                return Ok(userRepository.Get(id));
            }
            return StatusCode(HttpStatusCode.NoContent);
           
        }

        public IHttpActionResult Post(User user )
        {
            this.userRepository.Insert(user);
            return Created("api/user/"+user.Username,user);
        }

    }
}
