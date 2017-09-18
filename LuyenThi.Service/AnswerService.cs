using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuyenThi.Service
{
    public interface IAnswerService
    {
        void Add(Answer answer);
        void Update(Answer answer);
        void Delete(int id);
        IEnumerable<Answer> GetAllByQuestion(int questionID);
        void SaveChanges();
    }
    public class AnswerService : IAnswerService
    {
        IAnswerRepository _answerRepository;
        IUnitOfWork _unitOfWork;

        public AnswerService(IAnswerRepository answerRepository, IUnitOfWork unitOfWork)
        {
            this._answerRepository = answerRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Answer dapan)
        {
            _answerRepository.Add(dapan);
        }

        public void Delete(int id)
        {
            _answerRepository.Delete(id);
        }

        public IEnumerable<Answer> GetAllByQuestion(int questionID)
        {
            return _answerRepository.GetMulti(x => x.QuestionID == questionID);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Answer answer)
        {
            _answerRepository.Update(answer);
        }
    }
}
