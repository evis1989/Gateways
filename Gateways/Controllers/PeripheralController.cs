using AutoMapper;
using Gateways.Core.ServiceModels;
using Gateways.Core.ViewModels;
using Gateways.Service.PeripheralService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gateways.Controllers
{
    public class PeripheralController : Controller
    {
        private readonly IGatewayService gatewayService;
        private readonly IPeripheralService peripherialService;
        private readonly IMapper mapper;
        public PeripheralController(
              IGatewayService gatewayService, IPeripheralService peripherialService, IMapper mapper)
        {
            this.gatewayService = gatewayService;
            this.peripherialService = peripherialService;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var peripherals = await peripherialService.GetAllPeripheralsAsync();
            var peripheralViewModel = mapper.Map(peripherals, new List<PeripheralViewModel>());

            return View(peripheralViewModel);
        }

        public async Task<ActionResult> Details(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var peripheral = await peripherialService.GetPeripheralByIdAsync(id);
            if (peripheral == null) return HttpNotFound();

            var peripheralViewModel = mapper.Map<PeripheralViewModel>(peripheral);

            return View(peripheralViewModel);
        }

        // GET: Gateway/Create
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            var gateways = await gatewayService.GetAllGatewaysAsync();
            var gatewaysViewModel = mapper.Map(gateways, new List<GatewayViewModel>());
            ViewBag.GatewayId = new SelectList(gatewaysViewModel, "Id", "Ipv4");
            return View();
        }

        // POST: Gateway/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PeripheralViewModel data)
        {
            if (ModelState.IsValid)
            {
                var peripheral = mapper.Map<Peripheral>(data);
                peripherialService.AddPeripheralAsync(peripheral);
                await peripherialService.SaveChangesAsync();

                TempData["success"] = true;
                TempData["msg"] = "Peripheral created successfully";

                return RedirectToAction("Index");
            }

            return View(data);
        }
        // GET: Gateway/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var peripheral = await peripherialService.GetPeripheralByIdAsync(id);
            if (peripheral == null)
                return HttpNotFound();
            var gateways = await gatewayService.GetAllGatewaysAsync();
            var gatewaysViewModel = mapper.Map(gateways, new List<GatewayViewModel>());
            ViewBag.GatewayId = new SelectList(gatewaysViewModel, "Id", "Ipv4");
            var peripheralViewModel = mapper.Map<PeripheralViewModel>(peripheral);

            return View(peripheralViewModel);
        }

        // POST: Gateway/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PeripheralViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var peripheral = mapper.Map<Peripheral>(data);

                    await peripherialService.UpdatePeripheralAsync(peripheral);
                    await peripherialService.SaveChangesAsync();

                    TempData["success"] = true;
                    TempData["msg"] = "Peripheral edited successfully";

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