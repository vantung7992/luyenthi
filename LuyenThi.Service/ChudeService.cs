using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using System.Collections.Generic;
using System;

namespace LuyenThi.Service
{
    public interface IChudeService
    {
        void Add(Chude chude);

        void Update(Chude chude);

        Chude Delete(int id);

        IEnumerable<Chude> GetAll();

        IEnumerable<Chude> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Chude> GetAll(string keyword);

        Chude GetById(int id);

        void SaveChanges();
    }

    public class ChudeService : IChudeService
    {
        private IChudeRepository _chudeRepository;
        private IUnitOfWork _unitOfWork;

        public ChudeService(IChudeRepository chudeRepository, IUnitOfWork unitOfWork)
        {
            this._chudeRepository = chudeRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Chude chude)
        {
            _chudeRepository.Add(chude);
        }

        public Chude Delete(int id)
        {
            return _chudeRepository.Delete(id);
        }

        public IEnumerable<Chude> GetAll()
        {
            return _chudeRepository.GetAll();
        }

        public IEnumerable<Chude> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
                return _chudeRepository.GetMulti(x => x.Ten.Contains(keyword) || x.Ghichu.Contains(keyword));
            return _chudeRepository.GetAll();
        }

        public IEnumerable<Chude> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _chudeRepository.GetMultiPaging(x => x.Trangthai, out totalRow, page, pageSize);
        }

        public IEnumerable<Chude> GetAllPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _chudeRepository.GetMultiPaging(x => x.Trangthai && x.Tag.Contains(tag), out totalRow, page, pageSize);
        }

        public Chude GetById(int id)
        {
            return _chudeRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Chude chude)
        {
            _chudeRepository.Update(chude);
        }
    }
}