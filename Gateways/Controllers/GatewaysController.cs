using AutoMapper;
using Gateways.Core.ServiceModels;
using Gateways.Core.ViewModels;
using Gateways.Service.PeripheralService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gateways.Controllers
{
    public class GatewaysController : Controller
    {
        private readonly IGatewayService gatewayService;
        private readonly IPeripheralService peripherialService;
        private readonly IMapper mapper;
        public GatewaysController(
              IGatewayService gatewayService, IPeripheralService peripherialService, IMapper mapper)
        {
            this.gatewayService = gatewayService;
            this.peripherialService = peripherialService;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var gateways = await gatewayService.GetAllGatewaysAsync();
            var gatewayViewModel = mapper.Map(gateways, new List<GatewayViewModel>());

            return View(gatewayViewModel);
        }

        public async Task<ActionResult> Details(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var gateway = await gatewayService.GetByIdAsync(id);
            if (gateway == null) return HttpNotFound();

            var gatewayViewModel = mapper.Map<GatewayViewModel>(gateway);

            return View(gatewayViewModel);
        }

        // GET: Gateway/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gateway/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GatewayViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var gateway = mapper.Map<Gateway>(data);
                    gatewayService.AddGatewayAsync(gateway);
                    await gatewayService.SaveChangesAsync();

                    TempData["success"] = true;
                    TempData["msg"] = "Gateway created successfully";

                    return RedirectToAction("Index");
                }

                return View(data);
            }
            catch
            {
                return View();
            }
        }
        // GET: Gateway/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var gateway = await gatewayService.GetByIdAsync(id);
            if (gateway == null)
                return HttpNotFound();

            var gatewayviewmodel = mapper.Map<GatewayViewModel>(gateway);

            return View(gatewayviewmodel);
        }

        // POST: Gateway/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GatewayViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var gateway = mapper.Map<Gateway>(data);

                    await gatewayService.UpdateGatewayAsync(gateway);
                    await gatewayService.SaveChangesAsync();

                    TempData["success"] = true;
                    TempData["msg"] = "Gateway edited successfully";

                    return RedirectToAction("Index");
                }

                return View(data);
            }
            catch
            {
                return View(data);
            }
        }


    }
}