using Microsoft.AspNetCore.Mvc;
using TecnologyRepair.Shared.Entities;

namespace TecnologyRepair.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToRepairsController : ControllerBase
    {
        private List<ToRepair> _toRepair;

        public ToRepairsController()
        {
            _toRepair = new List<ToRepair>
            {
               new ToRepair {Id = 1, TypeOfEquipment = "", Brand = "", DateOfAdmission = DateTime.Now , RetirementDate = DateTime.Now, OwnerNames = "", OwnerLastName = "",  OwnerPhone = "", OwnerEmail = "", DiagnosisOfTheDamage = "", TechnicianComments = "" , RepairStatus = "", RepairPrice = 10000 },
               new ToRepair {Id = 2, TypeOfEquipment = "", Brand = "", DateOfAdmission = DateTime.Now , RetirementDate = DateTime.Now, OwnerNames = "", OwnerLastName = "",  OwnerPhone = "", OwnerEmail = "", DiagnosisOfTheDamage = "", TechnicianComments = "" , RepairStatus = "", RepairPrice = 10000 },
               new ToRepair {Id = 3, TypeOfEquipment = "", Brand = "", DateOfAdmission = DateTime.Now , RetirementDate = DateTime.Now, OwnerNames = "", OwnerLastName = "",  OwnerPhone = "", OwnerEmail = "", DiagnosisOfTheDamage = "", TechnicianComments = "" , RepairStatus = "", RepairPrice = 10000 },
              };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_toRepair);
        }

        [HttpPost]
        public IActionResult Post(ToRepair toRepair)
        {
            _toRepair.Add(toRepair);

            return Ok(toRepair);
        }

        [HttpPut]
        public IActionResult Put(ToRepair toRepair)
        {
            var repair = _toRepair.FirstOrDefault(t => t.Id == toRepair.Id);
            if (repair == null)
            {
                return NotFound();
            }
            repair.TypeOfEquipment = toRepair.TypeOfEquipment;
            repair.Brand = toRepair.Brand;
            repair.DateOfAdmission = DateTime.Now;
            repair.RetirementDate = DateTime.Now;
            repair.OwnerNames = toRepair.OwnerNames;
            repair.OwnerLastName = toRepair.OwnerLastName;
            repair.OwnerPhone = toRepair.OwnerPhone;
            repair.OwnerEmail = toRepair.OwnerEmail;
            repair.DiagnosisOfTheDamage = toRepair.DiagnosisOfTheDamage;
            repair.TechnicianComments = toRepair.TechnicianComments;
            repair.RepairStatus = toRepair.RepairStatus;
            repair.RepairPrice = toRepair.RepairPrice;

            return Ok(repair);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var repair = _toRepair.FirstOrDefault(t => t.Id == id);
            if (repair == null)
            {
                return NotFound();
            }

            _toRepair.Remove(repair);
            return NoContent();
        }

    }
}
