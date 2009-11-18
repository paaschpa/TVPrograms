using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.UI.WebControls;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.Core.Domain;
using TVPrograms.UI.Models.Forms;
using TVPrograms.UI.Models.Forms.Mappers;

namespace UI.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IProgramRepository _programRepository;
        private readonly IProgramMapper _programMapper;

        public ProgramController(IProgramRepository repository, IProgramMapper mapper) 
        {
            _programRepository = repository;
            _programMapper = mapper;
        }

        public ActionResult Index(int id)
        {
            Program program = _programRepository.GetById(id);
            IList<object[]> seasonreport = _programRepository.SeasonReport(id);
            ViewData["SeasonReport"] = seasonreport;
            return View(program);
        }

        public ActionResult IndexJson()
        {
            return View("");
        }

        public JsonResult IndexJsonData(int id)
        {
            IList<object[]> seasonreport = _programRepository.SeasonReport(id);
            List<object> objJson = new List<object>();
            int cnt = 1;

            foreach (object[] obj in seasonreport)
            {
               objJson.Add(new {id = cnt, cell = obj});
               cnt += 1;
            }

            var objJson1 = new { total = 1, records = seasonreport.Count, rows = objJson };
            return Json(objJson1);

        }
    }
}

