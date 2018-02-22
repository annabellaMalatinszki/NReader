using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace NReaderAPI.Models
{
    public class RSSParser
    {
        // The RSSParser is a singleton.
        static RSSParser() { }

        // Call this method to retrieve NewsItem objects form NewsSites
        public static async Task ParallelRSSDownloadAsync()
        {
            List<string> urls = GetUrls();

            // Retrieve NewsItem objects from xml asynchronously.
            List<Task<List<NewsItem>>> tasks = new List<Task<List<NewsItem>>>();
            foreach (string url in urls)
            {
                tasks.Add(Task.Run(() => GetNewsItemsFromRSSAsync(url)));
            }

            var results = await Task.WhenAll(tasks);

            List<Task<string>> tasks2 = new List<Task<string>>();

            foreach (var resultList in results)
            {
                //Here you call the function that will add newsitems to the database.
                tasks2.Add(Task.Run(() => InsertToDatabaseAsync(resultList)));
            }

            var results2 = await Task.WhenAll(tasks2);
        }

        static List<NewsItem> GetNewsItemsFromRSSAsync(string url)
        {
            // Parse the file at the url and create NewsItem object from the xml.
            List<NewsItem> newsToAdd = new List<NewsItem>();

            XmlDocument doc = new XmlDocument();
            XmlNodeList nodes = doc.SelectNodes("rss/channel/item");

            doc.Load(url);
            foreach (XmlNode node in nodes)
            {
                NewsItem newsItem = new NewsItem();

                XmlNode subNode = node.SelectSingleNode("title");
                newsItem.Title = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("description");
                newsItem.Description = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("pubDate");
                newsItem.PublicationDate = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("link");
                newsItem.ArticleUrl = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("enclosure");
                newsItem.PicUrl = subNode != null ? subNode.InnerText : "";

                // this should be a bit more sophisticated right there, but will do for now.
                newsItem.NewsSiteId = 1;

                newsToAdd.Add(newsItem);
            }

            return newsToAdd;
        }

        private static List<string> GetUrls()
        {
            List<string> urls = new List<string>();
            // TODO: Here you should retrieve the urls of the sites that are to be checked from the database.

            // For now, here is some mock data:
            urls.Add("http://hvg.hu/rss");
            urls.Add("https://index.hu/24ora/rss/");
            return urls;
            ;
        }

        static async void InsertToDatabaseAsync(List<NewsItem> newsList)
        {
            // TODO: Here you should put the new NewsItems into the database.

        }

    }
}