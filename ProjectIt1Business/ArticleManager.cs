using System.Collections.Generic;
using System.Linq;

namespace ProjectIt1Business
{
    public class ArticleManager
    {
        public Article SelectedArticle { get; set; }

        public void Create(string title, string content, int teamPageId)
        {
            var newArt = new Article() { Title = title, Content = content, TeamPageId = teamPageId };
            using (var db = new SportsDbContext())
            {
                db.Article.Add(newArt);
                db.SaveChanges();
            }
        }

        public void Update(int articleId, string title, string content, int teamPageId)
        {
            using (var db = new SportsDbContext())
            {
                SelectedArticle = db.Article.Where(a => a.ArticleId == articleId).FirstOrDefault();
                SelectedArticle.Title = title;
                SelectedArticle.Content = content;
                SelectedArticle.TeamPageId = teamPageId;
                // write changes to database
                db.SaveChanges();
            }
        }

        public void Delete(int articleId, string title, string content, int teamPageId)
        {
            using (var db = new SportsDbContext())
            {

                db.Article.RemoveRange(SelectedArticle);
                db.SaveChanges();
            }
        }

        public List<Article> RetrieveAll()
        {
            using (var db = new SportsDbContext())
            {
                return db.Article.ToList();
            }
        }

        public void SetSelectedArticle(object selectedItem)
        {
            SelectedArticle = (Article)selectedItem;
        }
    }
}
