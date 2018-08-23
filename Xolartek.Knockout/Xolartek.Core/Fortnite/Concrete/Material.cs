using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Xolartek.Core.Fortnite
{
    public class Material : IMaterial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int? PictureId { get; set; }
        private IPicture _picture;
        [DataMember]
        public Picture Picture
        {
            get
            {
                return (Picture)_picture;
            }
            set
            {
                _picture = (Picture)value;
            }
        }
        IPicture IMaterial.Picture
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
        [DataMember]
        public ICollection<MaterialCost> MaterialCosts { get; set; }
    }
}
