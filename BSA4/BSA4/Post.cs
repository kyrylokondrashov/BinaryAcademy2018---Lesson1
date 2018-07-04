using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA4
{
    class Post
    {
        private int id;
        private DateTime createdAt;
        private string title;
        private string body;
        private int likes;
        private int userId;
        public List<Comment> comments = new List<Comment>();
        public int Id { get { return id; } }
        public int UserId { get { return userId; } }
        public int Likes { get { return likes; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public String Title { get { return title; } }
        public String Body { get { return body; } }

        public Post(int id, DateTime createdAt, string title, string body, int likes, int userId)
        {
            this.id = id;
            this.createdAt = createdAt;
            this.title = title;
            this.body = body;
            this.likes = likes;
            this.userId = userId;
        }


        public override string ToString()
        {
            string text = "---This post have id: " + id + " was createad at: " + createdAt + " by user: " + userId + " . It has this title: " + title + " and body: " + body + " . Have " + likes + " likes and " + comments.Count + " comments. Here they are \n";  
            foreach(Comment c in comments)
            {
                text += c.ToString() + "\n";
            }
            return text;
        }
    }
}
