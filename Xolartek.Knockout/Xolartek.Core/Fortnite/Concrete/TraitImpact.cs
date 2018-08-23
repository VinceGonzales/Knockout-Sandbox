using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Xolartek.Core.Fortnite
{
    [DataContract]
    public class TraitImpact : ITraitImpact
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public string Impact { get; set; }
        [DataMember]
        public int WeaponClass { get; set; }
        [DataMember]
        public int TraitId { get; set; }
        [DataMember]
        public int SchematicId { get; set; }

        private ITrait _trait { get; set; }
        [DataMember]
        public Trait Trait
        {
            get
            {
                return (Trait)_trait;
            }
            set
            {
                _trait = (Trait)value;
            }
        }
        [DataMember]
        ITrait ITraitImpact.Trait
        {
            get
            {
                return _trait;
            }
            set
            {
                _trait = value;
            }
        }

        private ISchematic _schematic;
        [DataMember]
        public Schematic Schematic
        {
            get
            {
                return (Schematic)_schematic;
            }
            set
            {
                _schematic = (Schematic)value;
            }
        }
        [DataMember]
        ISchematic ITraitImpact.Schematic
        {
            get
            {
                return _schematic;
            }
            set
            {
                _schematic = value;
            }
        }
    }
}