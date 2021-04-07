using System.Windows;
using System;
using ProjectIt1Business;

namespace ArticlesWPF
{

    public partial class MainWindow : Window
    {
        private ArticleManager _articleManager = new ArticleManager();
        public MainWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            ListBoxArticle.ItemsSource = _articleManager.RetrieveAll();
        }

        private void PopulateArticleFields()
        {
            if (_articleManager.SelectedArticle != null)
            {
                TextId.Text = _articleManager.SelectedArticle.ArticleId.ToString();
                TextTitle.Text = _articleManager.SelectedArticle.Title;
                TextContent.Text = _articleManager.SelectedArticle.Content;
                TextTeamPageId.Text = _articleManager.SelectedArticle.TeamPageId.ToString();
            }
        }

        private void ListBoxArticle_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxArticle.SelectedItem != null)
            {
                _articleManager.SetSelectedArticle(ListBoxArticle.SelectedItem);
                PopulateArticleFields();
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {

            _articleManager.Update(Int32.Parse(TextId.Text), TextTitle.Text, TextContent.Text, Int32.Parse(TextTeamPageId.Text));
            ListBoxArticle.ItemsSource = null;
            // put back the screen data
            PopulateListBox();
            ListBoxArticle.SelectedItem = _articleManager.SelectedArticle;
            PopulateArticleFields();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            _articleManager.Create(TextTitle.Text, TextContent.Text, Int32.Parse(TextTeamPageId.Text));
            ListBoxArticle.ItemsSource = null;
            PopulateListBox();

        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _articleManager.Delete(Int32.Parse(TextId.Text), TextTitle.Text, TextContent.Text, Int32.Parse(TextTeamPageId.Text));
            ListBoxArticle.ItemsSource = null;
            // put back the screen data
            PopulateListBox();
            ListBoxArticle.SelectedItem = _articleManager.SelectedArticle;

        } 
    }
}

