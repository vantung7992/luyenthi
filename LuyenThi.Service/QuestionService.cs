using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuyenThi.Service
{
    public interface IQuestionService
    {
        Question Add(Question question, IEnumerable<Answer> listAnswer);

        void Update(Question question, IEnumerable<Answer> listAnswer);

        void Delete(int id);

        IEnumerable<Question> GetAll();

        IEnumerable<Question> GetAll(string keyword, int topicID);

        Question GetAllById(int id);

        IEnumerable<Question> GetAllByExam(int examID);

        IEnumerable<Question> GetAllByTopic(int topicID);

        void SaveChanges();
    }

    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _questionRepository;
        private IAnswerRepository _answerRepository;

        private IUnitOfWork _unitOfWork;

        public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IUnitOfWork unitOfWork)
        {
            this._questionRepository = questionRepository;
            this._answerRepository = answerRepository;

            this._unitOfWork = unitOfWork;
        }

        public Question Add(Question question, IEnumerable<Answer> answers)
        {
            var newCauhoi = _questionRepository.Add(question);
            _unitOfWork.Commit();
            if (answers.Count() > 0)
            {
                foreach (var answer in answers)
                {
                    answer.QuestionID = newCauhoi.ID;
                    _answerRepository.Add(answer);
                }
                _unitOfWork.Commit();
            }
            return question;
        }

        public void Delete(int id)
        {
            _answerRepository.DeleteMulti(x => x.QuestionID == id);
            _questionRepository.Delete(id);
        }

        public Question GetAllById(int id)
        {
            return _questionRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Question question, IEnumerable<Answer> listAnswer)
        {
            _questionRepository.Update(question);
            _answerRepository.DeleteMulti(x => x.QuestionID == question.ID);
            if (listAnswer.Count() > 0)
                foreach (var answer in listAnswer)
                {
                    answer.QuestionID = question.ID;
                    _answerRepository.Add(answer);
                }
            _unitOfWork.Commit();
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }

        public IEnumerable<Question> GetAll(string keyword, int topicID = -1)
        {
            if (topicID == -1)
            {
                if (!String.IsNullOrEmpty(keyword))
                    return _questionRepository.GetMulti(x => x.Content.Contains(keyword) || x.Note.Contains(keyword));
                else
                    return _questionRepository.GetAll();
            }
            else
            {
                if (!String.IsNullOrEmpty(keyword))
                    return _questionRepository.GetMulti(x => x.Content.Contains(keyword) || x.Note.Contains(keyword) && x.TopicID == topicID);
                else
                    return _questionRepository.GetMulti(x => x.TopicID == topicID);
            }
        }

        public IEnumerable<Question> GetAllByTopic(int topicID)
        {
            return _questionRepository.GetAllByTopic(topicID);
        }

        public IEnumerable<Question> GetAllByExam(int examID)
        {
            return _questionRepository.GetAllbyExam(examID);
        }
    }
}