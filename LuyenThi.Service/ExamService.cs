using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using System.Collections;
using System.Collections.Generic;
using System;

namespace LuyenThi.Service
{
    public interface IExamService
    {
        Exam Add(Exam exam, List<int> listQuestionID);
        void Update(Exam exam, List<int> listQuestionID);
        Exam Delete(int id);
        IEnumerable<Exam> GetAllByTopic(int topicID, int pageIndex, int pageSize, out int totalRow);
        Exam GetAllById(int id);
        IEnumerable<Exam> GetAll();
        IEnumerable<Exam> GetAll(string keyword);
        IEnumerable<Question> GetAllByExam(int id);
        void SaveChanges();
    }

    public class ExamService : IExamService
    {
        private IExamRepository _examRepository;
        private IExamDetailRepository _examDetailRepositpry;
        private IQuestionRepository _questionRepository;
        private IUnitOfWork _unitOfWork;

        public ExamService(IExamRepository examRepository, IExamDetailRepository examDetailRepository, IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            this._examRepository = examRepository;
            this._examDetailRepositpry = examDetailRepository;
            this._questionRepository = questionRepository;
            this._unitOfWork = unitOfWork;
        }

        public Exam Add(Exam exam, List<int> listQuestionID)
        {
            _examRepository.Add(exam);
            _unitOfWork.Commit();
            if (listQuestionID.Count > 0)
            {
                for (var i = 0; i < listQuestionID.Count; i++)
                {
                    ExamDetail examDetail = new ExamDetail()
                    {
                        ExamID = exam.ID,
                        QuestionID = listQuestionID[i],
                        Order = i,
                        Status = true,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "Admin"
                    };
                    _examDetailRepositpry.Add(examDetail);
                }
                _unitOfWork.Commit();
            }
            return exam;
        }

        public Exam Delete(int id)
        {
            return _examRepository.Delete(id);
        }

        public IEnumerable<Exam> GetAll()
        {
            return _examRepository.GetAll();
        }

        public IEnumerable<Exam> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _examRepository.GetMulti(x => x.Name.Contains(keyword) || x.Note.Contains(keyword));
            return _examRepository.GetAll();
        }

        public IEnumerable<Exam> GetAllByTopic(int topicID, int pageIndex, int pageSize, out int totalRow)
        {
            return _examRepository.GetAllByTopic(topicID, pageIndex, pageSize, out totalRow);
        }

        public Exam GetAllById(int id)
        {
            return _examRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Exam exam, List<int> listQuestionID)
        {
            _examRepository.Update(exam);
            _examDetailRepositpry.DeleteMulti(x => x.ExamID == exam.ID);
            if (listQuestionID.Count > 0)
            {
                for (var i = 0; i < listQuestionID.Count; i++)
                {
                    ExamDetail examDetail = new ExamDetail()
                    {
                        ExamID = exam.ID,
                        QuestionID = listQuestionID[i],
                        Order = i,
                        Status = true,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "Tungnv"
                    };
                    _examDetailRepositpry.Add(examDetail);
                }
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<Question> GetAllByExam(int id)
        {
           return _questionRepository.GetAllbyExam(id);
        }
    }
}