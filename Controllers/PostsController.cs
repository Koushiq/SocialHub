using SocialHub.Models;
using SocialHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SocialHub.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        private PostRepository postRepository = new PostRepository();
        private CommentRepository commentRepository = new CommentRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            List <Post> posts =  postRepository.GetAll().OrderByDescending(s => s.CreatedAt).ToList();
            //List<Comment> comments = new List<Comment>();
            foreach(var post in posts)
            {
                post.Comments=(from comments in commentRepository.GetAll().OrderByDescending(s=>s.CreatedAt)
                 where comments.PostID == post.PostID
                  select comments).ToList();
            }
            return Ok(posts);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(postRepository.Get(id));
        
        }
        [Route("")]
        public IHttpActionResult Post(Post post)
        {
            if(ModelState.IsValid)
            {
                postRepository.Insert(post);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest(ModelState);
            }
               
           
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id,[FromBody]Post post)
        {
            post.PostID = id;
            if (ModelState.IsValid)
            {
                postRepository.Update(post);
                return Ok(post);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
           
            postRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
