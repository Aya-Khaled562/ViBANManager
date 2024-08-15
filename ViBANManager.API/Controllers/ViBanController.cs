using System;
using System.Threading.Tasks;
using System.Web.Http;
using ViBANManager.API.Interfaces;
using ViBANManager.Infrastructure.Repositories;

namespace ViBANManager.API.Controllers
{
    [RoutePrefix("api/viban")]
    public class ViBanController : ApiController
    {
        private readonly IBankConfigurationRepository _bankConfiguration;
        private readonly IBankServiceFactory _serviceFactory;

        public ViBanController(IBankConfigurationRepository bankConfiguration, IBankServiceFactory serviceFactory)
        {
            _bankConfiguration = bankConfiguration;
            _serviceFactory = serviceFactory;
        }

        [Route("create/{bankName}")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateViBAN(string bankName , [FromBody] object request)
        {
            try
            {
                var vibanService = _serviceFactory.GetViBANService(bankName);
                var result = await vibanService.CreateViBANAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("activate/{bankName}")]
        [HttpPost]
        public async Task<IHttpActionResult> ActivateViBAN(string bankName, [FromBody] object request)
        {
            try
            {
                var vibanService = _serviceFactory.GetViBANService(bankName);
                var result = await vibanService.CreateViBANAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("deactivate/{bankName}")]
        [HttpPost]
        public async Task<IHttpActionResult> DeactivateViBAN(string bankName, [FromBody] object request)
        {
            try
            {
                var vibanService = _serviceFactory.GetViBANService(bankName);
                var result = await vibanService.CreateViBANAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("inquiry/{bankName}")]
        [HttpPost]
        public async Task<IHttpActionResult> AccountInquiryViBANs(string bankName, [FromBody] object request)
        {
            try
            {
                var vibanService = _serviceFactory.GetViBANService(bankName);
                var result = await vibanService.CreateViBANAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
