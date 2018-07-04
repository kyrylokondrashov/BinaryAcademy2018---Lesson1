using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA4
{
    class Menu
    {
        public static bool Active { get; private set; } = true;


        public static void ChooseCommande()
        {
            Console.WriteLine("Commands: ");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3");
            Console.WriteLine("4. Task 4");
            Console.WriteLine("5. Task 5");
            Console.WriteLine("6. Task 6");
            Console.WriteLine("7. Close Programm");
            int commande = Int32.Parse(Console.ReadLine());
            switch (commande)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 6:
                    Task6();
                    break;
                case 7:
                    StopProgramme();
                    break;
                default:
                    throw new Exception("Unknown command");
            }
        }
        private static void StopProgramme()
        {
            Active = false;
        }

        private static void Task1()
        {
            Console.WriteLine("Enter user id (from 1 to 100)");
            int i = Int32.Parse(Console.ReadLine());
            if (i < 0 || i > 100)
            {
                throw new Exception("Not valid number");
            }
            User specificUser = DataStructure.users[i - 1];
            var postList = specificUser.posts.Select(p => new { postId = p.Id, postComments = p.comments.Count });
            if (postList.Count() != 0)
            {
                foreach (var post in postList)
                {
                    Console.WriteLine($"This is post with {post.postId} id and it have {post.postComments} comments.");
                }
            }
            else
            {
                Console.WriteLine("User did not post anthing.");
            }
        }

        private static void Task2()
        {
            Console.WriteLine("Enter user id (from 1 to 100)");
            int i = Int32.Parse(Console.ReadLine());
            if (i < 0 || i > 100)
            {
                throw new Exception("Not valid number");
            }
            User specificUser = DataStructure.users[i - 1];
            var commentList = specificUser.posts.Where(p => p.Body.Length < 50).SelectMany(x => x.comments);
            if (commentList.Count() != 0)
            {
                foreach (var comment in commentList)
                {
                    Console.WriteLine($" {comment}");
                }
            }
            else
            {
                Console.WriteLine("There is no comments that satisfy your condition.");
            }


        }

        private static void Task3()
        {
            Console.WriteLine("Enter user id (from 1 to 100)");
            int i = Int32.Parse(Console.ReadLine());
            if (i < 0 || i > 100)
            {
                throw new Exception("Not valid number");
            }
            User specificUser = DataStructure.users[i - 1];
            var todoComplete = specificUser.todos.Where(p => p.ISComplete == true).Select(p => new { Id = p.Id, Name = p.Name });
            if (todoComplete.Count() != 0)
            {
                foreach (var todo in todoComplete)
                {
                    Console.WriteLine($"This is todo with {todo.Id} id and it has name  {todo.Name} .");
                }
            }
            else
            {
                Console.WriteLine("User did not have todo list.");
            }
        }

        private static void Task4()
        {
            var res = DataStructure.users.OrderBy(x => x.Name).ThenBy(x => x.todos.OrderByDescending(t => t.Name.Length));
            foreach (var elem in res)
            {
                Console.WriteLine(elem);
            }

        }

        private static void Task5()
        {
            Console.WriteLine("Enter user id (from 1 to 100)");
            int i = Int32.Parse(Console.ReadLine());
            if (i < 0 || i > 100)
            {
                throw new Exception("Not valid number");
            }

            var structure = DataStructure.users.Where(u => u.Id == i).Select(
                                                            u => new
                                                            {
                                                                User = u,
                                                                LastPost = u.posts.OrderByDescending(t => t.CreatedAt).DefaultIfEmpty().First(),
                                                                LastPostComments = (u.posts.OrderByDescending(t => t.CreatedAt).DefaultIfEmpty().First())?.comments.Count,
                                                                FailedTodo = u.todos.Where(t => t.ISComplete == false)?.Count(),
                                                                PopularPostComment = u.posts.Where(p => p.Body.Length > 80).OrderByDescending(p => p.comments.Count).DefaultIfEmpty().First(),
                                                                PopularPostLike = u.posts.OrderByDescending(p => p.Likes).DefaultIfEmpty().First()
                                                            });
            foreach (var elem in structure)
            {
                Console.WriteLine($"Info about user with id {i}. His name is { elem.User.Name}");
                if (elem.LastPost == null)
                {
                    Console.WriteLine("Don't have any post");
                }
                else
                {
                    Console.WriteLine($"Here his last post {elem.LastPost.Id}. Post has {elem.LastPostComments}  comments");
                    if (elem.PopularPostComment == null)
                    {
                        Console.WriteLine("Don't have posts matched by this criteria");
                    }
                    else
                    {
                        Console.WriteLine($"Here his popular post by comment {elem.LastPost.Id}. Here it is \n {elem.PopularPostComment}");
                    }
                    Console.WriteLine($"Here his popular post by like {elem.LastPost.Id}.Here it is \n {elem.PopularPostLike} ");
                    
                }
                if (elem.FailedTodo == null)
                {
                    Console.WriteLine("Don't have a todo list");
                }
                else
                {
                    Console.WriteLine($"Here his count of uncompleted todo {elem.FailedTodo}");
                }

            }





        }

        private static void Task6()
        {
            Console.WriteLine("Enter post id (from 1 to 100)");
            int i = Int32.Parse(Console.ReadLine());
            if (i < 0 || i > 100)
            {
                throw new Exception("Not valid number");
            }

            var structure = (DataStructure.users.SelectMany(u => u.posts)).Where(x => x.Id == i).Select(p => new
            {
                Title = p.Title,
                Length = p.Body.Length,
                LargestComment = p.comments.OrderByDescending(x => x.Body.Length).DefaultIfEmpty().First(),
                PopularComment = p.comments.OrderByDescending(x => x.Likes).DefaultIfEmpty().First(),
                CommentWithSpecificConditions = p.Body.Length < 80 || p.Likes < 0 ? p.comments?.Count : null
            });

            foreach(var elem in structure)
            {
                Console.WriteLine($"Info about specified id. It has title {elem.Title}. And it's length is {elem.Length}");
                if(elem.LargestComment == null)
                {
                    Console.WriteLine($"Dosn't have any comments");
                }
                else
                {
                    Console.WriteLine($"Largest comment is {elem.LargestComment.Body}. It's length is {elem.LargestComment.Body.Length}");
                    Console.WriteLine($"Post with most likes is {elem.PopularComment.Body}. It has {elem.PopularComment.Likes} likes");
                }
                if (elem.CommentWithSpecificConditions == null)
                {
                    Console.WriteLine($"Don't matched by criteria");
                }
                else
                {
                    Console.WriteLine($"Comments under the post with matched criteria {elem.CommentWithSpecificConditions}");
                }


            }


        }

    }
}
