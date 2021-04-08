using System;
using System.Collections.Generic;
using System.Text;

namespace Individual-Project-Data

{
    public class Author
    {
        public string AuthorId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AuthorName { get; set; }

        public ICollection<Article> Articles { get; set; } = new ObservableCollection<Article>();
    }
}