using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.UI.Models.Forms;
using TVPrograms.UI.Models.Forms.Mappers;
using TVPrograms.Core.Domain;

namespace TVPrograms.UI.Controllers
{
    public class NetworkController : Controller
    {
        private readonly INetworkRepository _networkRepository;
        private readonly INetworkMapper _networkMapper;

        public NetworkController(INetworkRepository repository, INetworkMapper mapper)
        {
            _networkRepository = repository;
            _networkMapper = mapper;
        }

        public ActionResult List()
        {
            /* See, I told you - See page /Network/List.aspx to know why you just got served
             * a helping of I told you so...careful, don't get got in a recursive 'I told you so'
            */
            IList<Network> networks = _networkRepository.GetAll();
            ViewData["ddlNetworks"] = new SelectList(networks,"id","NetworkName");

            Network network = _networkRepository.GetById(networks[0].id);
            return View(network);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult List(FormCollection formvalues)
        {
            Network network = _networkRepository.GetById(Convert.ToInt32(formvalues["ddlNetworks"]));

            ViewData["ddlNetworks"] = new SelectList(_networkRepository.GetAll(), "id", "NetworkName", formvalues["ddlNetworks"]);
            return View(network);
        }

        public ActionResult ListJson()
        {
            IList<Network> networks = _networkRepository.GetAll();
            ViewData["ddlNetworks"] = new SelectList(networks, "id", "NetworkName");
            return View("");
        }

        public ActionResult ListData(int id)
        {
            Network network = _networkRepository.GetById(id);

            if (Request.IsAjaxRequest())
                return PartialView("ProgramAirDates", network.Programs);

            return View("");
        }

    }
}

