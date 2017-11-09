using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalProject.Services
{
    public class AgilityPackService
    {
        public string Scrape(string url)
        {

            //var html = @"https://www.yelp.com/biz/mo-ran-gak-restaurant-garden-grove";

            var html = @url;

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            return node.InnerHtml;
            //Console.WriteLine(node.InnerHtml);
            //    Console.ReadLine();
        }
    }
}