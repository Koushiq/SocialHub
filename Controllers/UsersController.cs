using FinalAssignment.Repositories;
using SocialHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SocialHub.Controllers
{
    
    public class UsersController : ApiController
    {
        private UserRepository userRepository = new UserRepository();

        public IHttpActionResult Get()
        {
            return Ok(userRepository.GetAll());
        }
        public IHttpActionResult Post(User user)
        {
             User logggedInUser = userRepository.GetAll().Where(s => s.Username == user.Username && s.Password == user.Password).FirstOrDefault();
             if (logggedInUser != null)
             {
                 return Ok(logggedInUser);
             }
             return StatusCode(HttpStatusCode.Unauthorized); 
            

        }
    }
}
