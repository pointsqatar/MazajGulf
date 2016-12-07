using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmltest
{
    public class Image
    {
        public string title { get; set; }
        public string url { get; set; }
        public string link { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string guid { get; set; }
        public string pubDate { get; set; }
    }

    public class Channel
    {
        public string title { get; set; }
        public List<object> link { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string lastBuildDate { get; set; }
        public string copyright { get; set; }
        public string docs { get; set; }
        public Image image { get; set; }
        public List<Item> item { get; set; }
    }

    public class Rss
    {
        public Channel channel { get; set; }
        public string atom { get; set; }
        public string version { get; set; }
    }

    public class FeedItem
    {
        public Rss rss { get; set; }
    }
}
