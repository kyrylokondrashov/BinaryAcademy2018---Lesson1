using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BSA4
{
    
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Data is preparing. Please wait...");
            PrepareDataStructure();
            Console.WriteLine("Data has been formed.");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            while (Menu.Active == true)
            {
                try
                {
                    Menu.ChooseCommande();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: \n {0}", ex.Message);
                }
                finally
                {
                    Console.WriteLine("\n");
                }
            }

        }
        public static void PrepareDataStructure()
        {
            string user = GetJson("https://5b128555d50a5c0014ef1204.mockapi.io/users");
            string post = GetJson("https://5b128555d50a5c0014ef1204.mockapi.io/posts");
            string todo = GetJson("https://5b128555d50a5c0014ef1204.mockapi.io/todos");
            string comment = GetJson("https://5b128555d50a5c0014ef1204.mockapi.io/comments");


            List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(todo);
            List<Comment> comments = JsonConvert.DeserializeObject<List<Comment>>(comment);
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(post);
            DataStructure.users = JsonConvert.DeserializeObject<List<User>>(user);


            foreach (Post p in posts)
            {
                var t = comments.Where(c => c.PostId == p.Id);
                foreach (var elem in t)
                {
                    p.comments.Add(elem);
                }
            }
            foreach (User u in DataStructure.users)
            {
                var t = posts.Where(p => p.UserId == u.Id);
                foreach (var elem in t)
                {
                    u.posts.Add(elem);
                }
                var t1 = todos.Where(ts => ts.UserId == u.Id);
                foreach (var elem in t1)
                {
                    u.todos.Add(elem);
                }
                //Console.WriteLine(u);
            }
        }
        public static string GetJson(string url)
        {
            string data = @"";
            using (HttpClient client1 = new HttpClient())
            {
                data += client1.GetStringAsync(url).Result;
            }
            return data;

        }
    }
}
