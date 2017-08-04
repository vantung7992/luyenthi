using AutoMapper;
using LuyenThi.Model.Models;
using LuyenThi.Service;
using LuyenThi.Web.Infrastructure.Core;
using LuyenThi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LuyenThi.Web.Api
{
    [RoutePrefix("api/chude")]
    public class ChudeController : ApiControllerBase
    {
        IChudeService _chudeService;
        public ChudeController(IErrorService errorService, IChudeService chudeService)
            : base(errorService)
        {
            this._chudeService = chudeService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () => {
                var model = _chudeService.GetAll();
                var responData = Mapper.Map<IEnumerable<Chude>, IEnumerable<ChudeViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responData);
                return response;
            });
        }
    }
}