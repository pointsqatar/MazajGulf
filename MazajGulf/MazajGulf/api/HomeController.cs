using MazajGulf.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MazajGulf.api
{
    public class HomeController : ApiController
    {
        MazajGulfEntities dbContext;

        public HomeController()
        {
            dbContext = new MazajGulfEntities();
        }
        [HttpGet]
        public IHttpActionResult Shows()
        {
            var result = dbContext.Shows.Select(x => x).ToList();
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult News()
        {
            var result = dbContext.News.Select(x => x);
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Horoscope()
        {
            var result = dbContext.Horoscopes.Select(x => x);
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult HappenToday()
        {
            var result = dbContext.HappenTodays.Select(x => x);
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Lifestyle()
        {
            var result = dbContext.LifeStyles.Select(x => x);
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Fashion()
        {
            var result = dbContext.Fashions.Select(x => x);
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Sports()
        {
            var result = dbContext.Sports.Select(x => x);
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Weather()
        {
            var result = dbContext.Weathers.Select(x => x);
            return Json(result);
        }
    }
}
