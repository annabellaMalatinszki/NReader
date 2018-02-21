using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NReaderAPI.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }

        public string Description { get; set; }

        public string PublicationDate { get; set; }

        public string ArticleUrl { get; set; }

        public string PicUrl { get; set; }

        // Foreign key
        public int NewsSiteId { get; set; }

        // Navigation property
        public NewsSite NewsSite { get; set; }

        public NewsItem() { }

        public NewsItem(string title, string description, string publicationDate, string articleUrl, string picUrl)
        {
            Title = title;
            Description = description;
            PublicationDate = ParseDate(publicationDate);
            ArticleUrl = articleUrl;
            PicUrl = picUrl;
        }

        public static string ParseDate(string date)
        {
            DateTime parsedDate;
            string pattern = "ddd, dd MMM yyyy HH:mm:ss GMT";
            string pattern2 = "ddd, dd MMM yyyy HH:mm:ss";

            if (DateTime.TryParseExact(date, pattern, null, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate.ToString();
            }
            else if (DateTime.TryParseExact(date, pattern2, null, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate.ToString();
            }

            return DateTime.Now.ToString();
        }


    }
}