using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Xolartek.Core.Fortnite;
using Xolartek.ORM;
using Xolartek.Web.Models;

namespace Xolartek.Web.Controllers
{
    [RoutePrefix("api/fortnite")]
    public class ServicesController : ApiController
    {
        [Route("heroes")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<Hero> GetHeroes()
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                return repo.GetHeroes();
            }
        }
        [Route("heroes/{id:int}")]
        public HeroVM GetHero(int id)
        {
            using (Repository repo = new Repository(new XolarDatabase()))
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
                foreach (Xolartek.Core.Fortnite.SubClass sub in repo.GetSubClass(id))
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
        }
        [HttpPost]
        [Route("heroes")]
        public HttpResponseMessage AddHeroes(List<HeroVM> heroes)
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                foreach (HeroVM hero in heroes)
                {
                    repo.PostHero(hero);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
        }
        [Route("subclass/{id:int}")]
        public DataViewModel GetSkills(int id)
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                DataViewModel result = new DataViewModel();
                result.Data = new List<SkillVM>();
                List<Xolartek.Core.Fortnite.SubClass> skills = repo.GetSubClass(id);
                result.Total = skills.Count;
                foreach (Xolartek.Core.Fortnite.SubClass sub in skills)
                {
                    SkillVM skill = new SkillVM();
                    skill.id = sub.Id;
                    skill.name = sub.Skill.Name;
                    skill.classname = sub.Name;
                    skill.description = sub.Skill.Description;
                    skill.issupport = sub.IsSupport;
                    skill.istactical = sub.IsTactical;
                    result.Data.Add(skill);
                }
                return result;
            }
        }
        [HttpPost]
        [Route("skills/{id:int}")]
        public HttpResponseMessage AddSkills(List<SkillVM> skills, int id)
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                string name = repo.GetHero(id).Name;
                foreach (SkillVM skill in skills)
                {
                    skill.heroname = name;
                    repo.PostSkill(skill);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
        }
        [HttpPost]
        [Route("skills/{name}")]
        public HttpResponseMessage AddSkills(List<SkillVM> skills, string name)
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                foreach (SkillVM skill in skills)
                {
                    skill.heroname = name;
                    repo.PostSkill(skill);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
        }
        [Route("schematics")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<SchematicVM> GetSchematics()
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                List<SchematicVM> result = new List<SchematicVM>();
                List<Schematic> schematics = repo.GetSchematics();
                foreach (Schematic sch in schematics)
                {
                    SchematicVM vm = new SchematicVM();
                    vm.id = sch.Id;
                    vm.name = sch.Name;
                    vm.imgurl = sch.Picture.Source;
                    vm.level = sch.Level;
                    vm.stars = sch.Stars;
                    vm.description = sch.Description;
                    vm.stat = new List<stat>();

                    List<TraitImpact> impacts = repo.GetTraitImpacts(sch.Id);
                    foreach (TraitImpact ti in impacts)
                    {
                        stat s = new stat();
                        s.name = ti.Trait.Description;
                        s.value = ti.Impact;
                        vm.stat.Add(s);
                    }

                    result.Add(vm);
                }
                return result;
            }
        }
        [HttpPost]
        [Route("schematics")]
        public HttpResponseMessage AddSchematic(List<SchematicVM> schematics)
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                foreach (SchematicVM schem in schematics)
                {
                    repo.PostSchematicA(schem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
        }
        [HttpPost]
        [Route("trait/{id:int}")]
        public HttpResponseMessage AddTrait(int id, List<TraitImpactVM> datalist)
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                foreach(TraitImpactVM data in datalist)
                {
                    Trait trait = repo.GetTraits().FirstOrDefault(t => t.Description.Equals(data.Trait));
                    if (trait != null)
                    {
                        repo.AddTraitImpact(data.Impact, id, trait.Id);
                    }
                    else
                    {
                        string fail = string.Format("Failed on {0} - {1}", data.Impact, data.Trait);
                        return Request.CreateResponse(HttpStatusCode.NotFound, fail);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
        }

        [Route("schematic/{id:int}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public SchematicVM GetTraits(int id)
        {
            using (Repository repo = new Repository(new XolarDatabase()))
            {
                List<TraitImpact> impacts = repo.GetTraitImpacts(id);

                SchematicVM result = new SchematicVM();
                result.id = impacts[0].SchematicId;
                result.name = impacts[0].Schematic.Name;
                result.level = impacts[0].Schematic.Level;
                result.stars = impacts[0].Schematic.Stars;
                result.description = impacts[0].Schematic.Description;
                result.stat = new List<stat>();

                foreach (TraitImpact ti in impacts)
                {
                    stat s = new stat();
                    s.id = ti.Id;
                    s.name = ti.Trait.Description;
                    s.value = ti.Impact;
                    result.stat.Add(s);
                }
                
                return result;
            }
        }
    }
}
