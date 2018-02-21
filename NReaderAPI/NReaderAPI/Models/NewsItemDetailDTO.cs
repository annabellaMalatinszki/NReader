using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NReaderAPI.Models
{
    public class NewsItemDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }
        public string ArticleUrl { get; set; }
        public string PicUrl { get; set; }
        public string NewsSiteName { get; set; }
    }
}