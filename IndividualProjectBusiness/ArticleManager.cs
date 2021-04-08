﻿using System.Collections.Generic;
using System.Linq;
using IndividualProjectData;

namespace IndividualProjectBusiness
{
    public class ArticleManager
    {
        public Article SelectedArticle { get; set; }

        public void Create(string articleId, string title, string authorName, string content)
        {
            var newArt = new Article() { ArticleId = articleId, Title = title, AuthorName = authorName, Content = content };
            using (var db = new SportsblogContext())
            {
                db.Articles.Add(newArt);
                db.SaveChanges();
            }
        }

        public void Update(string articleId, string title, string authorName, string content)
        {
            using (var db = new SportsblogContext())
            {
                SelectedArticle = db.Articles.Where(a => a.ArticleId == articleId).FirstOrDefault();
                SelectedArticle.Title = title;
                SelectedArticle.AuthorName = authorName;
                SelectedArticle.Content = content;
                // write changes to database
                db.SaveChanges();
            }
        }

        public void Delete(int articleId, string title, string content, int teamPageId)
        {
            using (var db = new SportsblogContext())
            {

                db.Articles.RemoveRange(SelectedArticle);
                db.SaveChanges();
            }
        }

        public List<Article> RetrieveAll()
        {
            using (var db = new SportsblogContext())
            {
                return db.Articles.ToList();
            }
        }

        public void SetSelectedArticle(object selectedItem)
        {
            SelectedArticle = (Article)selectedItem;
        }

        public bool CheckDuplicateArticles(string articleId)
        {
            using (var db = new SportsblogContext())
            {
                var findArticleByIdQuery = db.Articles.Where(ar => ar.ArticleId == articleId);

                if (findArticleByIdQuery.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}