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
    [RoutePrefix("api/exam")]
    public class ExamController : ApiControllerBase
    {
        IExamService _examService;
        public ExamController(IErrorService errorService, IExamService _examService) : base(errorService)
        {
            this._examService = _examService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _examService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(pageSize * page).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Exam>, IEnumerable<ExamViewModel>>(query);
                var paginationSet = new PaginationSet<ExamViewModel>()
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
                    var oldDethi = _examService.Delete(id);
                    _examService.SaveChanges();

                    var responseData = Mapper.Map<Exam, ExamViewModel>(oldDethi);
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
                        _examService.Delete(item);
                    }
                    _examService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listDethi.Count);
                }
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ExamViewModel examVm)
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
                    List<int> ListQuestionID = new JavaScriptSerializer().Deserialize<List<int>>(examVm.ListQuestionID);
                    var newExam = new Exam();
                    newExam.UpdateExam(examVm);
                    _examService.Add(newExam, ListQuestionID);
                    _examService.SaveChanges();
                    var responseData = Mapper.Map<Exam, ExamViewModel>(newExam);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ExamViewModel dethiVm)
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
                    List<int> ListIdCauhoi = new JavaScriptSerializer().Deserialize<List<int>>(dethiVm.ListQuestionID);
                    var newdeThi = new Exam();
                    newdeThi.UpdateExam(dethiVm);
                    _examService.Update(newdeThi, ListIdCauhoi);
                    _examService.SaveChanges();
                    var responseData = Mapper.Map<Exam, ExamViewModel>(newdeThi);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }
    }
}