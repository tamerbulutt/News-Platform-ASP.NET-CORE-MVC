using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsTK.Models;

namespace NewsTK.Models
{
    public class NewsAndComments
    {
        public News news { get; set; } //haberleri tutar
        public List<Comment> comments { get; set; } //yorumları tutar
    }
}
