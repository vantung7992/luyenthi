using LuyenThi.Model.Models;
using LuyenThi.Service;
using LuyenThi.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LuyenThi.Web.Api
{
    [RoutePrefix("api/cauhoi")]
    public class CauhoiController : ApiControllerBase
    {
        private ICauhoiService _cauhoiService;

        public CauhoiController(IErrorService errorService, ICauhoiService cauhoiService) : base(errorService)
        {
            this._cauhoiService = cauhoiService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCauhoi = _cauhoiService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCauhoi);
                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, Cauhoi cauhoi)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var rCauhoi = _cauhoiService.Add(cauhoi);
                    _cauhoiService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, rCauhoi);
                };
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, Cauhoi cauhoi)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _cauhoiService.Update(cauhoi);
                    _cauhoiService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                };
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _cauhoiService.Delete(id);
                    _cauhoiService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                };
                return response;
            });
        }
    }
}