using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Xolartek.Core.Fortnite
{
    public class Hero : IHero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Stars { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string HeroClass { get; set; }

        public int? Health { get; set; }
        public int? HealthRegenRate { get; set; }
        public int? Shield { get; set; }
        public int? ShieldRegenRate { get; set; }
        public int? ShieldRegenDelay { get; set; }
        public decimal? HeroAbilityDmg { get; set; }
        public decimal? HeroHealingMod { get; set; }
        public int? RunSpeed { get; set; }
        public int? SprintSpeed { get; set; }

        public int RarityId { get; set; }
        private ITrait _rarity { get; set; }
        public Rarity Rarity
        {
            get
            {
                return (Rarity)_rarity;
            }
            set
            {
                _rarity = value;
            }
        }
        ITrait IHero.Rarity
        {
            get
            {
                return _rarity;
            }
            set
            {
                _rarity = value;
            }
        }

        public int? PictureId { get; set; }
        private IPicture _picture;
        public Picture Picture
        {
            get
            {
                return (Picture)_picture;
            }
            set
            {
                _picture = value;
            }
        }
        IPicture IHero.Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
            }
        }

        private ICollection<ISubClass> _subclasses;
        public ICollection<SubClass> SubClassAbilities
        {
            get
            {
                if (_subclasses == null)
                {
                    return null;
                }
                return _subclasses.Select(s => s as SubClass).ToList();
            }
            set
            {
                _subclasses = value.Select(s => s as ISubClass).ToList();
            }
        }
        ICollection<ISubClass> IHero.SubClassAbilities
        {
            get
            {
                return _subclasses;
            }
            set
            {
                _subclasses = value;
            }
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}
