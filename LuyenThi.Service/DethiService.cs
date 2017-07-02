using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using System.Collections;

namespace LuyenThi.Service
{
    public interface IDethiService
    {
        void Add(Dethi dethi);

        void Update(Dethi dethi);

        void Delete(int id);

        IEnumerable GetAllByChude(int idChude, int pageIndex, int pageSize, out int totalRow);

        Dethi GetAllById(int id);

        IEnumerable GetAll();

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

        public void Delete(int id)
        {
            _dethiRepository.Delete(id);
        }

        public IEnumerable GetAll()
        {
            return _dethiRepository.GetAll(new string[] { "ChudeDethi" });
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