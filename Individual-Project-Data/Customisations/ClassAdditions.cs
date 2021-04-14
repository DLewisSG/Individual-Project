namespace IndividualProjectData
{
    public partial class Article
    {
        public override string ToString()
        {
            return $"Article: {Title}";
        }
    }

    public partial class Author
    {
        public override string ToString()
        {
            return AuthorName;
        }
    }
}
