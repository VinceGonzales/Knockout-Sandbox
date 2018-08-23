using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Xolartek.Core.Fortnite
{
    [DataContract]
    public class MaterialCost : IMaterialCost
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public int Cost { get; set; }
        [DataMember]
        public int MaterialId { get; set; }
        [DataMember]
        public int SchematicId { get; set; }

        private IMaterial _material;
        [DataMember]
        public Material Material
        {
            get
            {
                return (Material)_material;
            }
            set
            {
                _material = (Material)value;
            }
        }
        IMaterial IMaterialCost.Material
        {
            get
            {
                return _material;
            }
            set
            {
                _material = value;
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
        ISchematic IMaterialCost.Schematic
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