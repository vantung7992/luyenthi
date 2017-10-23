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
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize, int topicID = -1)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _questionService.GetAll(keyword, topicID);
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

        [Route("getchecked")]
        [HttpGet]
        public HttpResponseMessage GetChecked(HttpRequestMessage request, string checkedQuestion)
        {
            return CreateHttpResponse(request, () =>
            {
                List<int> listCheckedQuestion = new JavaScriptSerializer().Deserialize<List<int>>(checkedQuestion);
                var model = _questionService.GetAll();
                var query = model.Where(x => listCheckedQuestion.Contains(x.ID));
                var responseData = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getnoselectedquestion")]
        [HttpGet]
        public HttpResponseMessage GetNoSelectedQuestion(HttpRequestMessage request, string selectedQuestion,string keyword, int topicID = -1)
        {

            return CreateHttpResponse(request, () =>
            {
                if (string.IsNullOrEmpty(selectedQuestion))
                {
                    var model = _questionService.GetAll(keyword, topicID);
                    var responseData = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(model);
                    HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);
                    return response;
                }
                else
                {

                    List<int> listCheckedQuestion = new JavaScriptSerializer().Deserialize<List<int>>(selectedQuestion);
                    var model = _questionService.GetAll(keyword,topicID);
                    var query = model.Where(x => !listCheckedQuestion.Contains(x.ID)).OrderBy(x => x.ID);
                    var responseData = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(query);
                    HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);
                    return response;
                }
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, QuestionViewModel questionVm, string selectedQuestion)
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
                    var newQuestion = new Question();
                    newQuestion.UpdateQuestion(questionVm);
                    _questionService.Update(newQuestion, listAnswer);
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
        public HttpResponseMessage DeleteMultiple(HttpRequestMessage request, string checkedQuestion)
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
                    var listQuestion = new JavaScriptSerializer().Deserialize<List<int>>(checkedQuestion);
                    foreach (var cauhoi in listQuestion)
                    {
                        _questionService.Delete(cauhoi);
                    }
                    _questionService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listQuestion.Count);
                }
                return response;
            });
        }
    }
}