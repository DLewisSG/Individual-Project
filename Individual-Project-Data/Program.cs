using System;
using System.Linq;

namespace IndividualProjectData
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddAuthor("MCL", "Mikey1886", "m.abs@email.com", "password", "Mike Abs");
            AddAuthor("DYL", "Dyl1967", "dyl_l@email.com", "password", "Dylan Lewis");
            AddAuthor("MRT", "MartyBWHUFC", "marty@email.com", "password", "Martin Boyle");
            AddAuthor("JHN", "JWalker1888", "johnwalker@email.com", "password", "John Walker");


            AddArticle("ASNL", "Arsenal beat Spurs", "Mike Abs", 
                "Arsenal have beaten Spurs by 3 goals, winning the match 4-1");

            AddArticle("PLCE", "Arsenal Lose ", "Mike Abs", 
                "Arsenal were beaten by Crystal Palace 2-1");

            AddArticle("CLTC", "Celtic end awful streak", "Dylan Lewis", 
                "Celtic ended their 3 game losing streak by beating Motherwell 2-0");

            AddArticle("SPTH",  "Speith wins masters", "Dylan Lewis",
                "Speith has won his second green jacket");

            AddArticle("WHUD", "West Ham win champions league", "Martin Boyle",
                "West Ham win champions league as they thrash Bayern Munich 4-1.");

            AddArticle("HMLT", "Lewis Hamilton wins the Grand Prix", "John Walker",
                "Lewis Hamilton won the Portuguese Grand Prix");
        }

        static void AddAuthor(string authorId, string username, string email, string password, string authorName)
        {
            using (SportsblogContext db = new SportsblogContext())
            {
                Author newAuthor = new Author
                {
                    AuthorId = authorId,
                    Username = username,
                    Email = email,
                    Password = password,
                    AuthorName = authorName
                };

                db.Authors.Add(newAuthor);

                db.SaveChanges();
            }

            Console.WriteLine($"Added User '{username}'");
        }

        static void AddArticle(string articleId, string title, string authorName, string content)
        {
            using (SportsblogContext db = new SportsblogContext())
            {
                Article newArticle = new Article
                {
                    ArticleId = articleId,
                    Title = title,
                    AuthorName = authorName,
                    Content = content
                };

                db.Articles.Add(newArticle);

                db.SaveChanges();
            }

            Console.WriteLine($"Added a new article");
        }
    }
}