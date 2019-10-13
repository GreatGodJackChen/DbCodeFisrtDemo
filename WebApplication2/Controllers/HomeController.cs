using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DB;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TestGroupby();
            using (var contex = new EFCoreDBContext())
            {
                var q = from a in contex.User
                        join b in contex.Mid on a.Id equals b.UserId
                        join c in contex.Com on b.ComId equals c.Id
                        where a.Id == 1
                        group a.Id by new
                        {
                            Id=a.Id,
                            aName=a.Name,
                            com=c.ComName
                        };
                var t = q.ToList();
                var qq = from a in contex.User
                         join b in contex.Mid on a.Id equals b.UserId
                         join c in contex.Com on b.ComId equals c.Id
                         where a.Id == 1
                         select a;
                var tt = qq.ToList();
            }
                return View();
        }
        public List<Dto> TestGroupby()
        {
            var list = new List<Dto>();
            using (var contex = new EFCoreDBContext())
            {
                var q = from a in contex.User
                        join b in contex.Mid on a.Id equals b.UserId
                        join c in contex.Com on b.ComId equals c.Id
                        where a.Id == 1
                        group new Dto
                        {
                            Id = a.Id,
                            aName = a.Name,
                            com = c.ComName
                        }
                        by new { a.Id,c.ComName}  into g
                        select g.ToList();
                       
               // var t = q.ToList();
                foreach (var item in q)
                {
                    list = item.ToList();
                }
                return list;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class Dto
    { 
        public int Id { get; set; }
        public string aName { get; set; }
        
        public string com { get; set; }
    }
}
