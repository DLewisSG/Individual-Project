using NUnit.Framework;
using ProjectIt1Business;
using System.Linq;

namespace ProjectItTests
{
    public class Tests
    {
        ArticleManager _articleManager;
        [SetUp]
        public void Setup()
        {
            _articleManager = new ArticleManager();
            // remove test entry in DB if present
            using (var db = new SportsDbContext())
            {
                var SelectedArticle =
                from ar in db.Article
                where ar.Title == "Test Article"
                select ar;

                db.Article.RemoveRange(SelectedArticle);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewArticleIsAdded_TheNumberOfArticlesIncreasesBy1()
        {
            using (var db = new SportsDbContext())
            {
                var numberOfArticlesBefore = db.Article.Count();
                _articleManager.Create("Test Article", "This article is a test", 1);
                var numberOfArticlesAfter = db.Article.Count();

                Assert.AreEqual(numberOfArticlesBefore + 1, numberOfArticlesAfter);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new SportsDbContext())
            {
                var SelectedArticle =
                from ar in db.Article
                where ar.Title == "Test Article"
                select ar;

                db.Article.RemoveRange(SelectedArticle);
                db.SaveChanges();
            }
        }


        [Test]
        public void WhenAnArticleIsChanged_TheDatabaseIsUpdated()
        {
            using (var db = new SportsDbContext())
            {
                _articleManager.Update(6, "Hibs", "Hibs have now won 3 games in a row as they make a push for the title", 4);

                var updatedArticle = db.Article.Find(6);
                Assert.AreEqual("Hibs", updatedArticle.Title);
            }
        }
    }

}