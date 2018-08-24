using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}
