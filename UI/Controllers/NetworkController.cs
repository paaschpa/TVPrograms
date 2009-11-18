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

namespace UI.Controllers
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
            IList<Network> networks = _networkRepository.GetAll();
            ViewData["ddlNetworks"] = new SelectList(networks,"id","NetworkName");
            
            return View(networks);
        }

        public ActionResult ListJson()
        {
            IList<Network> networks = _networkRepository.GetAll();
            ViewData["ddlNetworks"] = new SelectList(networks, "id", "NetworkName");
            return View("");
        }
        public JsonResult ListJsonData(int id)
        {
            Network network = _networkRepository.GetById(id);
            object obj = _networkMapper.Map(network);
            return Json(obj);
        }

        [AcceptVerbs(HttpVerbs.Post)] 
        public ActionResult List(FormCollection formvalues)
        {
            Network[] networks = new Network[1];
            Network network = _networkRepository.GetById(Convert.ToInt32(formvalues["ddlNetworks"]));
            networks[0] = network;

            ViewData["ddlNetworks"] = new SelectList(_networkRepository.GetAll(), "id", "NetworkName",formvalues["ddlNetworks"]);
            return View(networks);
        }

    }
}

