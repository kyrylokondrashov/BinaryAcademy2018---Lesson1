using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA4
{
    class User
    {
        private int id;
        private DateTime createdAt;
        private string name;
        private string avatar;
        private string email;
        public List<Post> posts = new List<Post>();
        public List<Todo> todos = new List<Todo>();

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } }
        public string Avatar { get { return avatar; } }
        public string Email { get { return email; } }

        public User(int id, DateTime createdAt, string name, string avatar, string email)
        {
            this.id = id;
            this.createdAt = createdAt;
            this.name = name;
            this.avatar = avatar;
            this.email = email;
        }
 
        public override string ToString()
        {
            string text = "Here is information about user with id: "+id + "and name: " + name + "\n He have created " + posts.Count + " posts. Here they are. \n";
            foreach(Post p in posts)
            {
                text += p.ToString() + "\n";
            }
            text += "He also have todo list with " + todos.Count + " elements. Here they are. \n";
            foreach(Todo t in todos)
            {
                text += t.ToString() + "\n";
            }
            text += "_________________________________________________________________________________________________________________";
            return text;
        }

    }
}
