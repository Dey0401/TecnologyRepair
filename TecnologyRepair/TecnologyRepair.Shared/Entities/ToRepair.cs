using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnologyRepair.Shared.Entities
{
    public class ToRepair
    {
        #region Properties
        public int Id { get; set; }
        public string TechnicianComments { get; set; } = null!;
        [Required]
        [MaxLength(200)]
        public string TypeOfEquipment { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public DateTime DateOfAdmission { get; set; }
        public DateTime RetirementDate { get; set; }
        public string OwnerNames { get; set; } = null!;
        public string OwnerLastName { get; set; } = null!;
        public string OwnerPhone { get; set; } = null!;
        public string OwnerEmail { get; set; } = null!;
        public string DiagnosisOfTheDamage { get; set; } = null!;
        public string RepairStatus { get; set; } = null!;
        public decimal RepairPrice { get; set; }

        #endregion
    }
}
