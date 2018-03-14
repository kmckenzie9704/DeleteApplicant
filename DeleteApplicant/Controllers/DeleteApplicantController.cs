using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DeleteApplicant.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DeleteApplicant.Controllers
{
    [Route("api/DeleteApplicant")]
    public class DeleteApplicantController : Controller
    {
        private DatabaseContext _context;

        public DeleteApplicantController(DatabaseContext context)
        {
            _context = context;
        }

        // GET api/DeleteApplicant
        [HttpGet]
        public string Get()
        {
            string strDeleteApplicant = "Delete the specified Applicant from the database.";
            return strDeleteApplicant;
        }

        // POST api/DeleteApplicant
        [HttpPost]
        public string DeleteApplicant([FromBody]Applicant applicant)
        {
            string strUniqueCode = applicant.appUniqueCode;
            PostToDB(strUniqueCode);
            return strUniqueCode;
        }

        private void PostToDB(string strUniqueCode)
        {
            using (_context)
            {

                Applicant newApplicant = _context.Applicants.FirstOrDefault(a => a.appUniqueCode == strUniqueCode);
                if (newApplicant != null)
                {
                    _context.Applicants.Remove(newApplicant);
                    _context.SaveChanges();
                }
            }
        }

    }

}
