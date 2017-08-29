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
    [RoutePrefix("api/chude")]
    public class ChudeController : ApiControllerBase
    {
        IChudeService _chudeService;
        public ChudeController(IErrorService errorService, IChudeService chudeService)
            : base(errorService)
        {
            this._chudeService = chudeService;
        }

        [Route("deleteMultiple")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, string checkedChude)
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
                    var listChude = new JavaScriptSerializer().Deserialize<List<int>>(checkedChude);
                    foreach (var item in listChude)
                    {
                        _chudeService.Delete(item);
                    }
                    _chudeService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listChude.Count);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
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
                    var oldChude = _chudeService.Delete(id);
                    _chudeService.SaveChanges();

                    var responData = Mapper.Map<Chude, ChudeViewModel>(oldChude);
                    response = request.CreateResponse(HttpStatusCode.OK, responData);
                }
                return response;
            });
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _chudeService.GetById(id);
                var responseData = Mapper.Map<Chude, ChudeViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _chudeService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.Ngaytao).Skip(pageSize * page).Take(pageSize);

                var responData = Mapper.Map<IEnumerable<Chude>, IEnumerable<ChudeViewModel>>(query);
                var paginationSet = new PaginationSet<ChudeViewModel>()
                {
                    Items = responData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _chudeService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Chude>, IEnumerable<ChudeViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ChudeViewModel chudeVm)
        {
            var chude = chudeVm;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newChude = new Chude();
                    newChude.UpdateChude(chudeVm);
                    newChude.Ngaytao = DateTime.Now;
                    _chudeService.Add(newChude);
                    _chudeService.SaveChanges();
                    var responseData = Mapper.Map<Chude, ChudeViewModel>(newChude);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ChudeViewModel chudeVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbChude = _chudeService.GetById(chudeVm.ID);
                    dbChude.UpdateChude(chudeVm);
                    dbChude.Ngaytao = DateTime.Now;
                    _chudeService.Update(dbChude);
                    _chudeService.SaveChanges();
                    var responseData = Mapper.Map<Chude, ChudeViewModel>(dbChude);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
    }
}