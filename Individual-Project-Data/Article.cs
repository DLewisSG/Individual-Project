﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IndividualProjectData
{
    public partial class Article
    {
        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }

        public Author Author { get; set; }
    }
}