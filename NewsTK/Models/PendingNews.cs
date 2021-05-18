using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTK.Models
{
    public class PendingNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstParagraph { get; set; }
        public string NewsText { get; set; }
        public string ImageUrl { get; set; }
        public string AuthorUserName { get; set; }
        public string JournalistUserName { get; set; }
    }
}
