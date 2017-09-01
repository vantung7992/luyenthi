using AutoMapper;
using LuyenThi.Model.Models;
using LuyenThi.Service;
using LuyenThi.Web.Infrastructure.Core;
using LuyenThi.Web.Infrastructure.Extensions;
using LuyenThi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace LuyenThi.Web.Api
{
    [RoutePrefix("api/dethi")]
    public class DethiController : ApiControllerBase
    {
        IDethiService _dethiService;
        public DethiController(IErrorService errorService, IDethiService dethiService) : base(errorService)
        {
            this._dethiService = dethiService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _dethiService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Ngaytao).Skip(pageSize * page).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Dethi>, IEnumerable<DethiViewModel>>(query);
                var paginationSet = new PaginationSet<DethiViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, ModelState);
                }
                else
                {
                    var oldDethi = _dethiService.Delete(id);
                    _dethiService.SaveChanges();

                    var responseData = Mapper.Map<Dethi, DethiViewModel>(oldDethi);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }


        [Route("deleteMultiple")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMutilple(HttpRequestMessage request, string checkDethi)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, ModelState);
                }
                else
                {
                    var listDethi = new JavaScriptSerializer().Deserialize<List<int>>(checkDethi);
                    foreach (var item in listDethi)
                    {
                        _dethiService.Delete(item);
                    }
                    _dethiService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listDethi.Count);
                }
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, DethiViewModel dethiVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, ModelState);
                }
                else
                {
                    var newdeThi = new Dethi();
                    newdeThi.UpdateDethi(dethiVm);
                    _dethiService.Add(newdeThi);
                    var responseData = Mapper.Map<Dethi, DethiViewModel>(newdeThi);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);

                }
                return response;
            });
        }
    }
}