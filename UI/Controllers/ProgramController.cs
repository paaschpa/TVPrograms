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

        /* This is more an exercise of using AutoMapper to make your model...wait for it...
        * more handsome (especailly with IndexJsonEpisodes since formatting JSON
        * is something I don't know how to do well) .  Nobody likes working with Dates so lets convert them to strings with 
        * the help of AutoMapper (see EpisodeFrom.cs for conversion). Strings make Dates easy and everyone 
        * likes an easy Date...am I right...yeah you good-looking people know what I'm talking about. 
        */
        public ActionResult Index(int id, string sidx, string sord)
        {
            Program program = _programRepository.GetById(id);
            ProgramForm programForm = _programMapper.Map(program);
            IList<object[]> seasonreport = _programRepository.SeasonReport(id, sidx, sord);
            ViewData["SeasonReport"] = seasonreport;
            return View(programForm);
        }

        public ActionResult IndexJson()
        {
            return View("");
        }

        public JsonResult IndexJsonEpisodes(int id, string sidx, string sord)
        {
            Program program = _programRepository.GetById(id);
            ProgramForm programForm = _programMapper.Map(program);
            return Json(programForm);
        }

        /* jQuery uses magic to populate the parmeters sidx, sord, page, rows
         * As much as I like jQuery, if it turns out to be a witch we should still 
         * burn it at the stake. It's the right thing to do.
        */
        public JsonResult IndexJsonSeasonData(int id, string sidx, string sord, int page, int rows)
        {
            IList<object[]> seasonreport = _programRepository.SeasonReport(id, sidx, sord);
            List<object> objJsonRows = new List<object>();
            
            int cnt = 1;
            foreach (object[] obj in seasonreport)
            {
               objJsonRows.Add(new {id = cnt, cell = obj});
               cnt += 1;
            }

            var JsonForJQGrid = new { total = 1, records = seasonreport.Count, rows = objJsonRows };
            return Json(JsonForJQGrid);

        }
    }
}

