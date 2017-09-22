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
    [RoutePrefix("api/topic")]
    public class TopicController : ApiControllerBase
    {
        ITopicService _topicService;
        public TopicController(IErrorService errorService, ITopicService topicService)
            : base(errorService)
        {
            this._topicService = topicService;
        }

        [Route("deleteMultiple")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, string checkedTopic)
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
                    var listTopic = new JavaScriptSerializer().Deserialize<List<int>>(checkedTopic);
                    foreach (var item in listTopic)
                    {
                        _topicService.Delete(item);
                    }
                    _topicService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listTopic.Count);
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
                    var oldTopic = _topicService.Delete(id);
                    _topicService.SaveChanges();

                    var responData = Mapper.Map<Topic, TopicViewModel>(oldTopic);
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
                var model = _topicService.GetById(id);
                var responseData = Mapper.Map<Topic, TopicViewModel>(model);
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
                var model = _topicService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreatedDate).Skip(pageSize * page).Take(pageSize);

                var responData = Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicViewModel>>(query);
                var paginationSet = new PaginationSet<TopicViewModel>()
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
                var model = _topicService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, TopicViewModel topicVm)
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
                    var newTopic = new Topic();
                    newTopic.UpdateTopic(topicVm);
                    newTopic.CreatedDate = DateTime.Now;
                    _topicService.Add(newTopic);
                    _topicService.SaveChanges();
                    var responseData = Mapper.Map<Topic, TopicViewModel>(newTopic);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, TopicViewModel chudeVm)
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
                    var dbChude = _topicService.GetById(chudeVm.ID);
                    dbChude.UpdateTopic(chudeVm);
                    dbChude.CreatedDate = DateTime.Now;
                    _topicService.Update(dbChude);
                    _topicService.SaveChanges();
                    var responseData = Mapper.Map<Topic, TopicViewModel>(dbChude);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
    }
}