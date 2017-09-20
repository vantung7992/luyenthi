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
    [RoutePrefix("api/question")]
    public class QuestionController : ApiControllerBase
    {
        private IQuestionService _questionService;

        public QuestionController(IErrorService errorService, IQuestionService questionService)
            : base(errorService)
        {
            this._questionService = questionService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _questionService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderBy(x => x.CreatedDate).Skip(pageSize * page).Take(pageSize);
                var responData = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(query);

                var paginationSet = new PaginationSet<QuestionViewModel>()
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
                var model = _questionService.GetAllById(id);
                var responData = Mapper.Map<Question, QuestionViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, QuestionViewModel questionVm)
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
                    var listAnswerVm = new List<AnswerViewModel>();
                    var listAnswer = new List<Answer>();
                    if (!String.IsNullOrEmpty(questionVm.StringJsonAnswer))
                    {
                        listAnswerVm = new JavaScriptSerializer().Deserialize<List<AnswerViewModel>>(questionVm.StringJsonAnswer);
                        foreach (var answerVm in listAnswerVm)
                        {
                            var newDapan = new Answer();
                            newDapan.UpdateAnswer(answerVm);
                            listAnswer.Add(newDapan);
                        }
                    }
                    var newQuestion = new Question();
                    newQuestion.UpdateQuestion(questionVm);
                    _questionService.Add(newQuestion, listAnswer);
                    _questionService.SaveChanges();
                    var responData = Mapper.Map<Question, QuestionViewModel>(newQuestion);
                    response = request.CreateResponse(HttpStatusCode.Created, responData);
                };
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, QuestionViewModel questionVm)
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
                    var listAnswerVm = new List<AnswerViewModel>();
                    var listAnswer = new List<Answer>();
                    if (!String.IsNullOrEmpty(questionVm.StringJsonAnswer))
                    {
                        listAnswerVm = new JavaScriptSerializer().Deserialize<List<AnswerViewModel>>(questionVm.StringJsonAnswer);
                        foreach (var answerVm in listAnswerVm)
                        {
                            var newAnswer = new Answer();
                            newAnswer.UpdateAnswer(answerVm);
                            listAnswer.Add(newAnswer);
                        }
                    }
                    var newCauhoi = new Question();
                    newCauhoi.UpdateQuestion(questionVm);
                    _questionService.Update(newCauhoi, listAnswer);
                    _questionService.SaveChanges();
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
                    _questionService.Delete(id);
                    _questionService.SaveChanges();
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
                        _questionService.Delete(cauhoi);
                    }
                    _questionService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listCauhoi.Count);
                }
                return response;
            });
        }
    }
}