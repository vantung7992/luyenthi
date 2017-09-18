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

        IEnumerable GetAllByChude(int topicID, int pageIndex, int pageSize, out int totalRow);

        Exam GetAllById(int id);

        IEnumerable<Exam> GetAll();
        IEnumerable<Exam> GetAll(string keyword);
        void SaveChanges();
    }

    public class ExamService : IExamService
    {
        private IExamRepository _examRepository;
        private IExamDetailRepository _examDetailRepositpry;
        private IUnitOfWork _unitOfWork;

        public ExamService(IExamRepository examRepository, IExamDetailRepository examDetailRepository, IUnitOfWork unitOfWork)
        {
            this._examRepository = examRepository;
            this._examDetailRepositpry = examDetailRepository;
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

        public IEnumerable GetAllByChude(int idChude, int pageIndex, int pageSize, out int totalRow)
        {
            return _dethiRepository.GetAllByChude(idChude, pageIndex, pageSize, out totalRow);
        }

        public Exam GetAllById(int id)
        {
            return _dethiRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Exam dethi, List<int> listIdCauhoi)
        {
            _dethiRepository.Update(dethi);
            _dethiCauhoiRepositpry.DeleteMulti(x => x.IDDethi == dethi.ID);
            if (listIdCauhoi.Count > 0)
            {
                for (var i = 0; i < listIdCauhoi.Count; i++)
                {
                    ExamDetail dethicauhoi = new ExamDetail()
                    {
                        IDDethi = dethi.ID,
                        Thutu = i,
                        Trangthai = true,
                        Ngaytao = DateTime.Now,
                        Nguoitao = "Admin"
                    };
                    _dethiCauhoiRepositpry.Add(dethicauhoi);
                }
                _unitOfWork.Commit();
            }
        }
    }
}