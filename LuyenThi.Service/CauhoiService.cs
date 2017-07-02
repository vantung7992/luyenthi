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
    public interface ICauhoiService
    {
        void Add(Cauhoi cauhoi);
        void Update(Cauhoi cauhoi);
        void Delete(int id);
        IEnumerable GetAllByDethi(int idDethi);
        IEnumerable GetAllByChude(int idChude);
        void SaveChanges();
    }
    public class CauhoiService : ICauhoiService
    {
        ICauhoiRepository _cauhoiRepository;
        IUnitOfWork _unitOfWork;

        public CauhoiService(ICauhoiRepository cauhoiRepository, IUnitOfWork unitOfWork)
        {
            this._cauhoiRepository = cauhoiRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Cauhoi cauhoi)
        {
            _cauhoiRepository.Add(cauhoi);
        }

        public void Delete(int id)
        {
            _cauhoiRepository.Delete(id);
        }

        public IEnumerable GetAllByChude(int idChude)
        {
            return _cauhoiRepository.GetAllByChude(idChude);
        }

        public IEnumerable GetAllByDethi(int idDethi)
        {
            return _cauhoiRepository.GetAllbyDethi(idDethi);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Cauhoi cauhoi)
        {
            _cauhoiRepository.Update(cauhoi);
        }
    }
}
