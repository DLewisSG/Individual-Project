using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IndividualProjectBusiness;

namespace ArticlesWPF
{
    public partial class ArticleWindow : Window
    {
        private ArticleManager _articleManager = new ArticleManager();
        public ArticleWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            _articleManager.Create(TextId.Text, TextTitle.Text, TextAuthorName.Text, TextContent.Text);
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
