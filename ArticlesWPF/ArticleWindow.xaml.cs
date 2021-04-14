using System.Windows;
using IndividualProjectBusiness;

namespace ArticlesWPF
{
    public partial class ArticleWindow : Window
    {
        private ArticleManager _articleManager = new ArticleManager();
        public ArticleWindow()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            ComboAuthor.ItemsSource = _articleManager.RetrieveAuthorName();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            _articleManager.Create(TextId.Text, TextTitle.Text, ComboAuthor.Text, TextContent.Text);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
