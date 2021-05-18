using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTK.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstParagraph { get; set; }
        public string NewsText { get; set; }
        public string ImageUrl { get; set; }

        public string UserName { get; set; }

        public int Like { get; set; }
        public int Dislike { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public bool IsSelected { get; set; }
        public bool IsAccepted { get; set; }
        public string ApprovingJournalistId { get; set; }
        
    }
}
