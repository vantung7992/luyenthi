using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using System.Collections;
using System.Collections.Generic;
using System;

namespace LuyenThi.Service
{
    public interface IDethiService
    {
        void Add(Dethi dethi);

        void Update(Dethi dethi);

        Dethi Delete(int id);

        IEnumerable GetAllByChude(int idChude, int pageIndex, int pageSize, out int totalRow);

        Dethi GetAllById(int id);

        IEnumerable<Dethi> GetAll();
        IEnumerable<Dethi> GetAll(string keyword);
        void SaveChanges();
    }

    public class DethiService : IDethiService
    {
        private IDethiRepository _dethiRepository;
        private IUnitOfWork _unitOfWork;

        public DethiService(IDethiRepository dethiRepository, IUnitOfWork unitOfWork)
        {
            this._dethiRepository = dethiRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Dethi dethi)
        {
            _dethiRepository.Add(dethi);
        }

        public Dethi Delete(int id)
        {
            return _dethiRepository.Delete(id);
        }

        public IEnumerable<Dethi> GetAll()
        {
            return _dethiRepository.GetAll(new string[] { "ChudeDethi" });
        }

        public IEnumerable<Dethi> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _dethiRepository.GetMulti(x => x.Ten.Contains(keyword) || x.Ghichu.Contains(keyword));
            return _dethiRepository.GetAll();
        }

        public IEnumerable GetAllByChude(int idChude, int pageIndex, int pageSize, out int totalRow)
        {
            return _dethiRepository.GetAllByChude(idChude, pageIndex, pageSize, out totalRow);
        }

        public Dethi GetAllById(int id)
        {
            return _dethiRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Dethi dethi)
        {
            _dethiRepository.Update(dethi);
        }
    }
}