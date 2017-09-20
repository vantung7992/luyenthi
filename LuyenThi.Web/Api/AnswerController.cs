using AutoMapper;
using LuyenThi.Model.Models;
using LuyenThi.Service;
using LuyenThi.Web.Infrastructure.Core;
using LuyenThi.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LuyenThi.Web.Api
{
    [RoutePrefix("api/answer")]
    public class AnswerController : ApiControllerBase
    {
        private IAnswerService _answerService;

        public AnswerController(IErrorService errorService, IAnswerService answerService)
            : base(errorService)
        {
            this._answerService = answerService;
        }

        [Route("getbyquestion/{questionID:int}")]
        [HttpGet]
        public IEnumerable<AnswerViewModel> GetAllByQuestion(int questionID)
        {
            var model = _answerService.GetAllByQuestion(questionID);
            var query = model.OrderBy(x => x.Order);
            var responseData = Mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerViewModel>>(query);
            return responseData;
        }
    }
}