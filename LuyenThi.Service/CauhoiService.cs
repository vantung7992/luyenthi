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
        Cauhoi Add(Cauhoi cauhoi, IEnumerable<Dapan> listDapan);
        void Update(Cauhoi cauhoi, IEnumerable<Dapan> ListDapan);
        void Delete(int id);
        IEnumerable<Cauhoi> GetAll();
        IEnumerable<Cauhoi> GetAll(string keyword);
        Cauhoi GetAllById(int id);
        IEnumerable<Cauhoi> GetAllByDethi(int idDethi);
        IEnumerable<Cauhoi> GetAllByChude(int idChude);
        void SaveChanges();
    }
    public class CauhoiService : ICauhoiService
    {
        ICauhoiRepository _cauhoiRepository;
        IDapanRepository _dapanRepository;

        IUnitOfWork _unitOfWork;

        public CauhoiService(ICauhoiRepository cauhoiRepository, IDapanRepository dapanRepository, IUnitOfWork unitOfWork)
        {
            this._cauhoiRepository = cauhoiRepository;
            this._dapanRepository = dapanRepository;

            this._unitOfWork = unitOfWork;
        }

        public Cauhoi Add(Cauhoi cauhoi, IEnumerable<Dapan> listDapan)
        {
            var newCauhoi = _cauhoiRepository.Add(cauhoi);
            _unitOfWork.Commit();
            if (listDapan.Count() > 0)
            {
                foreach (var dapan in listDapan)
                {
                    dapan.IDCauhoi = newCauhoi.ID;
                    _dapanRepository.Add(dapan);
                }
                _unitOfWork.Commit();
            }
            return cauhoi;
        }

        public void Delete(int id)
        {
            _dapanRepository.DeleteMulti(x => x.IDCauhoi == id);
            _cauhoiRepository.Delete(id);
        }

        public IEnumerable GetAll()
        {
            return _cauhoiRepository.GetAll();
        }

        public IEnumerable GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
                return _cauhoiRepository.GetMulti(x => x.Noidung.Contains(keyword) || x.Ghichu.Contains(keyword));
            return _cauhoiRepository.GetAll();
        }

        public IEnumerable GetAllByChude(int idChude)
        {
            return _cauhoiRepository.GetAllByChude(idChude);
        }

        public IEnumerable GetAllByDethi(int idDethi)
        {
            return _cauhoiRepository.GetAllbyDethi(idDethi);
        }

        public Cauhoi GetAllById(int id)
        {
            return _cauhoiRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Cauhoi cauhoi, IEnumerable<Dapan> listDapan)
        {
            _cauhoiRepository.Update(cauhoi);
            _dapanRepository.DeleteMulti(x => x.IDCauhoi == cauhoi.ID);
            if (listDapan.Count() > 0)
                foreach (var dapan in listDapan)
                {
                    _dapanRepository.Add(dapan);
                }
        }

        IEnumerable<Cauhoi> ICauhoiService.GetAll()
        {
            return _cauhoiRepository.GetAll();
        }

        IEnumerable<Cauhoi> ICauhoiService.GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
                return _cauhoiRepository.GetMulti(x => x.Noidung.Contains(keyword) || x.Ghichu.Contains(keyword));
            return _cauhoiRepository.GetAll();
        }

        IEnumerable<Cauhoi> ICauhoiService.GetAllByChude(int idChude)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Cauhoi> ICauhoiService.GetAllByDethi(int idDethi)
        {
            throw new NotImplementedException();
        }
    }
}
