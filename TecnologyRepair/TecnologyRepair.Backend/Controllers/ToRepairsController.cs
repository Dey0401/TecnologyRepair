using Microsoft.AspNetCore.Mvc;
using TecnologyRepair.Backend.Data;
using TecnologyRepair.Shared.Entities;

namespace TecnologyRepair.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToRepairsController : ControllerBase
    {
        private readonly DataContext _context;

        public ToRepairsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.ToRepairs.OrderBy(t => t.DateOfAdmission).ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var task = _context.ToRepairs.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Post(ToRepair toRepair)
        {
            _context.Add(toRepair);
            _context.SaveChanges();
            return Ok(toRepair);
        }

        [HttpPut]
        public IActionResult Put(ToRepair toRepair)
        {
            var repair = _context.ToRepairs.FirstOrDefault(x => x.Id == toRepair.Id);
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

            _context.Update(repair);
            _context.SaveChanges();
            return Ok(repair);
          
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repair = _context.ToRepairs.FirstOrDefault(x => x.Id == id);
            if (repair == null)
            {
                return NotFound();
            }
            _context.Remove(repair);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
