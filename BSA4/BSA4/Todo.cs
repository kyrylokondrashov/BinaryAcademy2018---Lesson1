using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA4
{
    class Todo
    {
        private int id;
        private DateTime createdAt;
        private string name;
        private bool isComplete;
        private int userId;


        public int UserId { get { return userId; } }
        public int Id { get { return id; } }
        public DateTime CreatedAt { get { return createdAt; } }
        public bool ISComplete { get { return isComplete; } }
        public string Name { get { return name; } }

        public Todo(int id, DateTime createdAt, string name, bool isComplete, int userId)
        {
            this.id = id;
            this.createdAt = createdAt;
            this.name = name;
            this.isComplete = isComplete;
            this.userId = userId;
        }

        public override string ToString()
        {
            string c = "";
            c += isComplete ? "completed" : "uncompleted";
            return "---This is todo element with id: " + id + " which was created at: " + createdAt + " for user: "+ userId + " has name: " + name + " and it is " + c;
        }
    }
}
