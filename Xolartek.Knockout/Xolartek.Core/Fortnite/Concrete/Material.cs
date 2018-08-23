using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xolartek.Core.Fortnite
{
    public class Material : Trait, IMaterial
    {
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
