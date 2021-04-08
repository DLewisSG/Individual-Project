using NUnit.Framework;
using IndividualProjectBusiness;
using IndividualProjectData;
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
            using (var db = new SportsblogContext())
            {
                var SelectedArticle =
                from ar in db.Articles
                where ar.ArticleId == "Test"
                select ar;

                db.Articles.RemoveRange(SelectedArticle);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewArticleIsAdded_TheNumberOfArticlesIncreasesBy1()
        {
            using (var db = new SportsblogContext())
            {
                var numberOfArticlesBefore = db.Articles.Count();
                _articleManager.Create("Test", "Test Article", "Dylan Lewis", "This article is a test");
                var numberOfArticlesAfter = db.Articles.Count();

                Assert.AreEqual(numberOfArticlesBefore + 1, numberOfArticlesAfter);
            }
        }

        [Test]
        public void WhenAnArticleIsChanged_TheDatabaseIsUpdated()
        {
            using (var db = new SportsblogContext())
            {
                _articleManager.Create("Test", "Test Article", "Dylan Lewis", "This article is a test article.");
                _articleManager.Update("Test", "Test Article", "Dylan Lewis", "This article is a test that has been updated.");

                var updatedArticle = db.Articles.Find("Test");
                Assert.AreEqual("This article is a test that has been updated.", updatedArticle.Content);
            }
        }

        [Test]
        public void WhenCreatingAnArticleWithADuplicateId_SystemThrowsAnError()
        {
            using (var db = new SportsblogContext())
            {
                _articleManager.Create("Test", "Test Article", "Dylan Lewis", "This article is a test article.");

                bool expected = true;
                bool result = _articleManager.CheckDuplicateArticles("Test");

                Assert.AreEqual(expected, result);

            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new SportsblogContext())
            {
                var SelectedArticle =
                from ar in db.Articles
                where ar.ArticleId == "Test"
                select ar;

                db.Articles.RemoveRange(SelectedArticle);
                db.SaveChanges();
            }
        }
    }
}