using SocialHub.Models;
using SocialHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialHub.Controllers
{
    public class CommentsController : ApiController
    {
        private CommentRepository commentRepository = new CommentRepository();
        public IHttpActionResult Post(Comment comment)
        {
            commentRepository.Insert(comment);
            return StatusCode(HttpStatusCode.Created);
            
        }
    }
}
