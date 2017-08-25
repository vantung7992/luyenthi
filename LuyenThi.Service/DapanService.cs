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
    public interface IDapanService
    {
        void Add(Dapan dapan);
        void Update(Dapan dapan);
        void Delete(int id);
        IEnumerable<Dapan> GetAllByCauhoi(int idCauhoi);
        void SaveChanges();
    }
    public class DapanService : IDapanService
    {
        IDapanRepository _dapanRepository;
        IUnitOfWork _unitOfWork;

        public DapanService(IDapanRepository dapanRepository, IUnitOfWork unitOfWork)
        {
            this._dapanRepository = dapanRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Dapan dapan)
        {
            _dapanRepository.Add(dapan);
        }

        public void Delete(int id)
        {
            _dapanRepository.Delete(id);
        }

        public IEnumerable<Dapan> GetAllByCauhoi(int idCauhoi)
        {
            return _dapanRepository.GetMulti(x => x.IDCauhoi == idCauhoi);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Dapan dapan)
        {
            _dapanRepository.Update(dapan);
        }
    }
}
