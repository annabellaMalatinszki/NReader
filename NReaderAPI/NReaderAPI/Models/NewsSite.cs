using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NReaderAPI.Models
{
    public class NewsSite
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        public string RSSUrl { get; set; }

        public string LogoUrl { get; set; }

        public NewsSite() { }

        public NewsSite(string name, string RSSUrl, string logoUrl)
        {
            Name = name;
            this.RSSUrl = RSSUrl;
            LogoUrl = logoUrl;
        }
    }
}