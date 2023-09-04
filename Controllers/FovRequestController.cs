using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ehsproject.Entities;
using ehsproject.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

namespace ehsproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FovRequestController : ControllerBase
    {
        private readonly EHS_Context dbContext;
        private readonly JwtServices jwtServices;

        public FovRequestController(EHS_Context dbContext, JwtServices jwtServices)
        {
            this.dbContext = dbContext;
            this.jwtServices = jwtServices;
        }


        [HttpPost]
        public IActionResult AddFovRequest(FovRequest fovRequest)
        {

            var data = dbContext.FovRequests.Where(rq => rq.FovRequestID == fovRequest.FovRequestID && rq.RequestNo == fovRequest.RequestNo);
            int? countVersion = 0;
            if (data.Any())
            {
                countVersion = data.Max(p => p.Count);
            }
            if (data != null && fovRequest.Status == "return")
            {
                countVersion = data.Max(p => p.Count) + 1;
            }


            var rq = new FovRequest()
            {
                FovRequestID = fovRequest.FovRequestID,
                RequestNo = fovRequest.RequestNo,
                Count = countVersion,
                Require = fovRequest.Require,
                SupplierCode = fovRequest.SupplierCode,
                Status = fovRequest.Status,
            };
            dbContext.FovRequests.Add(rq);
            dbContext.SaveChanges();
            return Ok("Success");
        }

        [HttpGet]
        public IActionResult GetRequest()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = jwtServices.Verify(jwt);
                var supplierCode = token.Issuer;

                var data = dbContext.FovRequests.Where(rq => rq.SupplierCode.Equals(supplierCode));
                return Ok(data);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}