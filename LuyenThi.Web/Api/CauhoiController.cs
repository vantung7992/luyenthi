using AutoMapper;
using LuyenThi.Model.Models;
using LuyenThi.Service;
using LuyenThi.Web.Infrastructure.Core;
using LuyenThi.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _cauhoiService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderBy(x => x.Ngaytao).Skip(pageSize * page).Take(pageSize);
                var responData = Mapper.Map<IEnumerable<Cauhoi>, IEnumerable<CauhoiViewModel>>(query);

                var paginationSet = new PaginationSet<CauhoiViewModel>() {
                    Items = responData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        public HttpResponseMessage Create(HttpRequestMessage request, Cauhoi cauhoi)
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

        public HttpResponseMessage Update(HttpRequestMessage request, Cauhoi cauhoi)
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