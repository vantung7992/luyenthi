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
    [RoutePrefix("api/cauhoi")]
    public class CauhoiController : ApiControllerBase
    {
        private ICauhoiService _cauhoiService;

        public CauhoiController(IErrorService errorService, ICauhoiService cauhoiService)
            : base(errorService)
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

                var paginationSet = new PaginationSet<CauhoiViewModel>()
                {
                    Items = responData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _cauhoiService.GetAllById(id);
                var responData = Mapper.Map<Cauhoi, CauhoiViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, CauhoiViewModel cauhoiVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listDapanVm = new List<DapanViewModel>();
                    var listDapan = new List<Dapan>();
                    if (!String.IsNullOrEmpty(cauhoiVm.strJsonDapan))
                    {
                        listDapanVm = new JavaScriptSerializer().Deserialize<List<DapanViewModel>>(cauhoiVm.strJsonDapan);
                        foreach (var dapanVm in listDapanVm)
                        {
                            var newDapan = new Dapan();
                            newDapan.UpdateDapan(dapanVm);
                            listDapan.Add(newDapan);
                        }
                    }
                    var newCauhoi = new Cauhoi();
                    newCauhoi.UpdateCauhoi(cauhoiVm);
                    _cauhoiService.Add(newCauhoi, listDapan);
                    _cauhoiService.SaveChanges();
                    var responData = Mapper.Map<Cauhoi, CauhoiViewModel>(newCauhoi);
                    response = request.CreateResponse(HttpStatusCode.Created, responData);
                };
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CauhoiViewModel cauhoiVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listDapanVm = new List<DapanViewModel>();
                    var listDapan = new List<Dapan>();
                    if (!String.IsNullOrEmpty(cauhoiVm.strJsonDapan))
                    {
                        listDapanVm = new JavaScriptSerializer().Deserialize<List<DapanViewModel>>(cauhoiVm.strJsonDapan);
                        foreach (var dapanVm in listDapanVm)
                        {
                            var newDapan = new Dapan();
                            newDapan.UpdateDapan(dapanVm);
                            listDapan.Add(newDapan);
                        }
                    }
                    var newCauhoi = new Cauhoi();
                    newCauhoi.UpdateCauhoi(cauhoiVm);
                    _cauhoiService.Update(newCauhoi,listDapan);
                    _cauhoiService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                };
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

        [Route("deleteMultiple")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMultiple(HttpRequestMessage request, string checkedCauhoi)
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
                    var listCauhoi = new JavaScriptSerializer().Deserialize<List<int>>(checkedCauhoi);
                    foreach (var cauhoi in listCauhoi)
                    {
                        _cauhoiService.Delete(cauhoi);
                    }
                    _cauhoiService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listCauhoi.Count);
                }
                return response;
            });
        }
    }
}