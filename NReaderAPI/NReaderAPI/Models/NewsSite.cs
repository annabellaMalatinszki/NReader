using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NReaderAPI.Models
{
    public class NewsSite
    {
        private static int idCounter = 0;
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        public string RSSUrl { get; set; }

        public string LogoUrl { get; set; }

        public NewsSite() {
            Id = idCounter;
            idCounter++;
        }

        public NewsSite(string name, string RSSUrl, string logoUrl)
        {
            Id = idCounter;
            idCounter++;
            Name = name;
            this.RSSUrl = RSSUrl;
            LogoUrl = logoUrl;
        }
    }
}