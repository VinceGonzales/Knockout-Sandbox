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
    [RoutePrefix("api/fortnite")]
    public class ServicesController : ApiController
    {
        private Repository repo = new Repository(new XolarDatabase());

        [Route("heroes")]
        public IEnumerable<Xolartek.Core.Fortnite.Hero> GetHeroes()
        {
            return repo.GetHeroes();
        }

        [Route("heroes/{id:int}")]
        public HeroVM GetHero(int id)
        {
            var hero = repo.GetHero(id);
            HeroVM result = new HeroVM();
            result.Id = hero.Id;
            result.Name = hero.Name;
            result.Rarity = hero.Rarity.Description;
            result.ImgUrl = hero.Picture.Source;
            result.Stars = hero.Stars;
            result.Level = hero.Level;
            result.Description = hero.Description;
            result.Skills = new List<SkillVM>();
            foreach(Xolartek.Core.Fortnite.SubClass sub in repo.GetSubClass(id))
            {
                SkillVM skill = new SkillVM();
                skill.id = sub.Id;
                skill.name = sub.Skill.Name;
                skill.heroname = result.Name;
                skill.classname = sub.Name;
                skill.description = sub.Skill.Description;
                skill.issupport = sub.IsSupport;
                skill.istactical = sub.IsTactical;
                result.Skills.Add(skill);
            }
            return result;
        }
        
        [HttpPost]
        [Route("heroes")]
        public HttpResponseMessage AddHeroes(List<HeroVM> heroes)
        {
            foreach(HeroVM hero in heroes)
            {
                repo.PostHero(hero);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        [HttpPost]
        [Route("skills/{name}/{tactical}")]
        public HttpResponseMessage AddSkills(List<SkillVM> skills, string name, bool tactical)
        {
            foreach (SkillVM skill in skills)
            {
                if(tactical)
                {
                    skill.issupport = false;
                    skill.istactical = true;
                }
                else
                {
                    skill.issupport = true;
                    skill.istactical = false;
                }
                skill.heroname = name;
                repo.PostSkill(skill);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Services/5
        public void Delete(int id)
        {
        }
    }
}
