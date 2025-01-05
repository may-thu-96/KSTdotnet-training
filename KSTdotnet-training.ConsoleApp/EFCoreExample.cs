using KSTdotnet_training.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();

            var lst = db.Blog.Where(x => x.DeleteFlag == false).ToList();

            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.DeleteFlag);
            }

        }

        public void Create(string title, string author, string content)
        {
            AppDbContext db = new AppDbContext();
            BlogDataModel model = new BlogDataModel
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };
            db.Add(model);
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Saving SuccessFul" : "Saving Failed");
        }

        public void Edit(int blogId)
        {
            AppDbContext db = new AppDbContext();
            //var item = db.Blog.Where(x => x.DeleteFlag == false && x.BlogID==blogId).FirstOrDefault();
            var item = db.Blog.FirstOrDefault(x => x.DeleteFlag == false && x.BlogID == blogId);
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            else
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.DeleteFlag);
            }

        }

        public void Update(int blogId, string title, string author, string content)
        {
            AppDbContext db = new AppDbContext();
            //var list = db.Blog.Where(x => x.DeleteFlag == false && x.BlogID==blogId).FirstOrDefault();
            var item = db.Blog.FirstOrDefault(x => x.DeleteFlag == false && x.BlogID == blogId);
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            if (!String.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }

            if (!String.IsNullOrEmpty(author))
            {
                item.BlogAuthor = author;
            }

            if (!String.IsNullOrEmpty(content))
            {
                item.BlogContent = content;
            }

            db.Entry(item).State=EntityState.Modified;
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Update SuccessFul" : "Update Failed");
        }
        public void Delete(int blogId)
        {
            AppDbContext db = new AppDbContext();
            //var list = db.Blog.Where(x => x.DeleteFlag == false && x.BlogID==blogId).FirstOrDefault();
            var item = db.Blog.FirstOrDefault(x => x.DeleteFlag == false && x.BlogID == blogId);
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            db.Entry(item).State = EntityState.Deleted; 
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Delete SuccessFul" : "Delete Failed");
        }
        }
}
