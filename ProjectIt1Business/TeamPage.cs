using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectIt1Business
{
    public class TeamPage
    {
        public int TeamPageId { get; set; }
        public string TeamName { get; set; }

        public List<Article> Articles { get; } = new List<Article>();

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
