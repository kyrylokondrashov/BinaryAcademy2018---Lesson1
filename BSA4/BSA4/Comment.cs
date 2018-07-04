using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA4
{
    class Comment
    {
        private int id;
        private DateTime createdAt;
        private string body;
        private int postId;
        private int userId;
        private int likes;
      
        public int PostId { get { return postId; } }
        public int Id { get { return id; } }
        public DateTime CreatedAt { get { return createdAt; } }

        public int UserId { get { return userId; } }

        public string Body { get { return body; } }
        public int Likes { get { return likes; } }

        public Comment(int id, DateTime createdAt, string body, int postId, int userId, int likes)
        {
            this.id = id;
            this.createdAt = createdAt;
            this.body = body;
            this.postId = postId;
            this.userId = userId;
            this.likes = likes;
        }


        public override string ToString()
        {
            return "----This comments has id: " + id + " createad at: " + createdAt + " by: " + userId + " under the post: " + postId + ". It says: " + body + " and have" + likes + " likes";
        }
    }
}
