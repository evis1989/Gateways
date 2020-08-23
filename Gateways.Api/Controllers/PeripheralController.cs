using AutoMapper;
using Gateways.Api.Helpers.CustomErrors;
using Gateways.Core.ServiceModels;
using Gateways.Core.ViewModels;
using Gateways.Service.PeripheralService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gateways.Api.Controllers
{
    [RoutePrefix("api/peripheral")]
    public class PeripheralController : ApiController
    {
        private readonly IPeripheralService peripheralService;
        private IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="peripheralService"></param>
        /// 
        public PeripheralController(IPeripheralService peripheralService, IMapper mapper)
        {
            this.peripheralService = peripheralService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get all Gateways
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IEnumerable<Peripheral>> GetAllPeripheralsAsync()
        {
            var peripherals = await peripheralService.GetAllPeripheralsAsync();
            return mapper.Map(peripherals, new List<Peripheral>());
        }
        /// <summary>
        /// Get peripheral by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetPeripheralByIdAsync(long id)
        {
            try
            {

                var peripheral = await peripheralService.GetPeripheralByIdAsync(id);
                if (peripheral == null)
                {
                    return new NotFoundError("PERIPHERAL NOT FOUND");
                }

                return Ok(peripheral);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public async Task<IHttpActionResult> AddPeripheralAsync([FromBody]PeripheralViewModel peripheralviewmodel)
        {
            try
            {
                if (peripheralviewmodel == null)
                    return new BadRequestError("PERIPHERAL OBJECT IS NULL");
                var peripheral = mapper.Map<Peripheral>(peripheralviewmodel);
                var cantPeipherals = peripheralService.GetAllPeripheralsByGatewayIdAsync(peripheral.GatewayId).Result.Count();
                if(cantPeipherals>=10)
                    return new ServerError("NO MORE THAT 10 PERIPHERAL DEVICES ARE ALLOWED FOR A GATEWAY");
                peripheralService.AddPeripheralAsync(peripheral);
                var result = await peripheralService.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateGatewayAsync([FromBody] PeripheralViewModel peripheralviewmodel)
        {
            try
            {
                if (peripheralviewmodel == null)
                    return new BadRequestError("PERIPHERAL OBJECT IS NULL");
                var peripheral = mapper.Map<Peripheral>(peripheralviewmodel);
                await peripheralService.UpdatePeripheralAsync(peripheral);
                var result = await peripheralService.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


    }
}