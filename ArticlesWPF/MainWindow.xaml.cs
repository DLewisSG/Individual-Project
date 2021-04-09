using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IndividualProjectBusiness;

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
                TextId.Text = _articleManager.SelectedArticle.ArticleId;
                TextTitle.Text = _articleManager.SelectedArticle.Title;
                TextAuthorName.Text = _articleManager.SelectedArticle.AuthorName;
                TextContent.Text = _articleManager.SelectedArticle.Content;
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

            _articleManager.Update(TextId.Text, TextTitle.Text, TextAuthorName.Text, TextContent.Text);
            ListBoxArticle.ItemsSource = null;
            // put back the screen data
            PopulateListBox();
            ListBoxArticle.SelectedItem = _articleManager.SelectedArticle;
            PopulateArticleFields();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _articleManager.Delete(TextId.Text, TextTitle.Text, TextAuthorName.Text, TextContent.Text);
            ListBoxArticle.ItemsSource = null;
            // put back the screen data
            PopulateListBox();
            ListBoxArticle.SelectedItem = _articleManager.SelectedArticle;
            TextId.Text = string.Empty;
            TextTitle.Text = string.Empty;
            TextAuthorName.Text = string.Empty;
            TextContent.Text = string.Empty;
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            ArticleWindow articleWindow = new ArticleWindow();
            articleWindow.Show();
            this.Close();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

    }
}