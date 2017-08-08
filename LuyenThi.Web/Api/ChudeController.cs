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
        public HttpResponseMessage Create(HttpRequestMessage request, ChudeViewModel chudeVm)
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
                    var newChude = new Chude();
                    newChude.UpdateChude(chudeVm);
                    _chudeService.Add(newChude);
                    _chudeService.SaveChanges();
                    var responseData = Mapper.Map<Chude, ChudeViewModel>(newChude);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
    }
}