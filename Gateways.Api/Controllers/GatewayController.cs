using AutoMapper;
using Gateways.Api.Helpers.CustomErrors;
using Gateways.Core.ServiceModels;
using Gateways.Core.ViewModels;
using Gateways.Service.PeripheralService;
using Gateways.Infastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gateways.Api.Controllers
{
    [RoutePrefix("api/gateways")]
    public class GatewayController : ApiController
    {
        private readonly IGatewayService gatewayService;
        private readonly IPeripheralService peripheralService;
        private IMapper mapper;

        /// <summary></summary>
        /// <param name="eventService"></param>
        /// <param name="cardService"></param>
        /// <param name="mapper"></param>
        public GatewayController(IGatewayService gatewayService, IPeripheralService peripheralService, IMapper mapper)
        {
            this.gatewayService = gatewayService;
            this.peripheralService = peripheralService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all Gateways
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IEnumerable<Gateway>> GetAllGatewaysAsync()
        {
            var gateways = await gatewayService.GetAllGatewaysAsync();
            return mapper.Map(gateways, new List<Gateway>());
        }

        /// <summary>
        /// Get gateway by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IHttpActionResult> GetByIdAsync(long id)
        {
            try
            {
                var gateway = await gatewayService.GetByIdAsync(id);
                if (gateway == null)
                {
                    return new NotFoundError("GATEWAY NOT FOUND");
                }

                return Ok(mapper.Map<GatewayViewModel>(gateway));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> AddGatewayAsync([FromBody]GatewayViewModel gatewayviewmodel)
        {
            try
            {
                if (gatewayviewmodel == null)
                    return new BadRequestError("GATEWAY OBJECT IS NULL");
                if(!Util.ValidateIP(gatewayviewmodel.Ipv4))
                    return new BadRequestError("GATEWAY IP IS NOT VALID");
                var gateway = mapper.Map<Gateway>(gatewayviewmodel);
                gatewayService.AddGatewayAsync(gateway);
                var result = await gatewayService.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateGatewayAsync([FromBody] GatewayViewModel gatewayviewmodel)
        {
            try
            {
                if (gatewayviewmodel == null)
                    return new BadRequestError("GATEWAY OBJECT IS NULL");
                var gateway = mapper.Map<Gateway>(gatewayviewmodel);
                await gatewayService.UpdateGatewayAsync(gateway);
                var result = await gatewayService.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
