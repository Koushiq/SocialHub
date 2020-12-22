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
    [RoutePrefix("api/posts/{id}/comments")]
    public class CommentsController : ApiController
    {
        private CommentRepository commentRepository = new CommentRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(commentRepository.GetAll());
        }

        [Route("{cid}")]
        public IHttpActionResult Get(int cid)
        {
            return Ok(commentRepository.Get(cid));
        }

        [Route("")]
        public IHttpActionResult Post(Comment comment)
        {
            if (ModelState.IsValid)
            {
                commentRepository.Insert(comment);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest(ModelState);
            }
               
            
        }

        [Route("{cid}")]
        public IHttpActionResult Put([FromUri]int cid,[FromBody]Comment comment)
        {
            comment.CommentID = cid;
            if (ModelState.IsValid)
            {
                commentRepository.Update(comment);
                return Ok(comment);
            }
            else
            {
                return BadRequest(ModelState);
            }
                
        }

        [Route("{cid}")]
        public IHttpActionResult Delete(int cid)
        {
            commentRepository.Delete(cid);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
