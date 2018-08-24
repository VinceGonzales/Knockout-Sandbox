using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xolartek.ORM;
using Xolartek.Web.Models;

namespace Xolartek.Web.Controllers
{
    public class ServicesController : ApiController
    {
        private Repository repo = new Repository(new XolarDatabase());
        // GET: api/Services
        public IEnumerable<Xolartek.Core.Fortnite.Rarity> Get()
        {
            return repo.GetRarities();
        }

        // GET: api/Services/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post(List<HeroVM> heroes)
        {
            foreach(HeroVM hero in heroes)
            {
                repo.PostHero(hero);
            }
        }

        // PUT: api/Services/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Services/5
        public void Delete(int id)
        {
        }
    }
}
