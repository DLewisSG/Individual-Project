using System.Windows;
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
                ComboAuthor.ItemsSource = _articleManager.RetrieveAuthorName();
                ComboAuthor.Text = _articleManager.SelectedArticle.AuthorName;
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

            _articleManager.Update(TextId.Text, TextTitle.Text, ComboAuthor.Text, TextContent.Text);
            ListBoxArticle.ItemsSource = null;
            PopulateListBox();
            ListBoxArticle.SelectedItem = _articleManager.SelectedArticle;
            PopulateArticleFields();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _articleManager.Delete(TextId.Text, TextTitle.Text, ComboAuthor.Text, TextContent.Text);
            ListBoxArticle.ItemsSource = null;
            PopulateListBox();
            ListBoxArticle.SelectedItem = _articleManager.SelectedArticle;
            TextId.Text = string.Empty;
            TextTitle.Text = string.Empty;
            ComboAuthor.Text = string.Empty;
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