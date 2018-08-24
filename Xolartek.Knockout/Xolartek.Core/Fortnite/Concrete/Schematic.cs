using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Xolartek.Core.Fortnite
{
    [DataContract]
    public class Schematic : ISchematic, IWeaponMelee, IWeaponRange, IWeaponTrap
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Durability { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public int Stars { get; set; }
        [DataMember]
        public int Damage { get; set; }
        [DataMember]
        public decimal CritChance { get; set; }
        [DataMember]
        public decimal CritDamage { get; set; }
        [DataMember]
        public decimal AttackRate { get; set; }
        [DataMember]
        public decimal DurabilityPerUse { get; set; }
        [DataMember]
        public int Impact { get; set; }
        [DataMember]
        public decimal ReloadTime { get; set; }
        [DataMember]
        public int MagazineSize { get; set; }
        [DataMember]
        public int Range { get; set; }
        [DataMember]
        public int AmmoCost { get; set; }

        private ICollection<ITraitImpact> _traits;
        [DataMember]
        public ICollection<TraitImpact> Traits
        {
            get
            {
                if (_traits == null)
                {
                    return null;
                }
                return _traits.Select(t => t as TraitImpact).ToList();
            }
            set
            {
                _traits = value.Select(t => t as ITraitImpact).ToList();
            }
        }
        ICollection<ITraitImpact> ISchematic.Traits
        {
            get
            {
                return _traits;
            }
            set
            {
                _traits = value;
            }
        }

        private ICollection<IMaterialCost> _materials;
        [DataMember]
        public ICollection<MaterialCost> Materials
        {
            get
            {
                if (_materials == null)
                {
                    return null;
                }
                return _materials.Select(m => (MaterialCost)m).ToList();
            }
            set
            {
                _materials = value.Select(m => m as IMaterialCost).ToList();
            }
        }
        ICollection<IMaterialCost> ISchematic.Materials
        {
            get
            {
                return _materials;
            }
            set
            {
                _materials = value;
            }
        }

        [DataMember]
        public int RarityId { get; set; }
        private ITrait _rarity { get; set; }
        [DataMember]
        public Rarity Rarity
        {
            get
            {
                return (Rarity)_rarity;
            }
            set
            {
                _rarity = (Rarity)value;
            }
        }
        ITrait ISchematic.Rarity
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

        [DataMember]
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
        IPicture ISchematic.Picture
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
        public int? WeaponEditionId { get; set; }
        private ITrait _weaponEdition;
        [DataMember]
        public WeaponEdition WeaponEdition
        {
            get
            {
                return (WeaponEdition)_weaponEdition;
            }
            set
            {
                _weaponEdition = (WeaponEdition)value;
            }
        }
        ITrait ISchematic.WeaponEdition
        {
            get
            {
                return _weaponEdition;
            }
            set
            {
                _weaponEdition = value;
            }
        }

        [DataMember]
        public int WeaponTypeId { get; set; }
        private ITrait _weaponType;
        [DataMember]
        public WeaponType WeaponType
        {
            get
            {
                return (WeaponType)_weaponType;
            }
            set
            {
                _weaponType = (WeaponType)value;
            }
        }
        ITrait ISchematic.WeaponType
        {
            get
            {
                return _weaponType;
            }
            set
            {
                _weaponType = value;
            }
        }
        
    }
}
