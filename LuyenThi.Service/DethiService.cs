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
        Dethi Add(Dethi dethi, List<int> listIdCauhoi);

        void Update(Dethi dethi, List<int> listIdCauhoi);

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
        private IDethiCauhoiRepository _dethiCauhoiRepositpry;
        private IUnitOfWork _unitOfWork;

        public DethiService(IDethiRepository dethiRepository, IDethiCauhoiRepository dethiCauhoiRepository, IUnitOfWork unitOfWork)
        {
            this._dethiRepository = dethiRepository;
            this._dethiCauhoiRepositpry = dethiCauhoiRepository;
            this._unitOfWork = unitOfWork;
        }

        public Dethi Add(Dethi dethi, List<int> listIdCauhoi)
        {
            _dethiRepository.Add(dethi);
            _unitOfWork.Commit();
            if (listIdCauhoi.Count > 0)
            {
                for (var i = 0; i < listIdCauhoi.Count; i++)
                {
                    DethiCauhoi dethicauhoi = new DethiCauhoi()
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
            return dethi;
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

        public void Update(Dethi dethi, List<int> listIdCauhoi)
        {
            _dethiRepository.Update(dethi);
            _dethiCauhoiRepositpry.DeleteMulti(x => x.IDDethi == dethi.ID);
            if (listIdCauhoi.Count > 0)
            {
                for (var i = 0; i < listIdCauhoi.Count; i++)
                {
                    DethiCauhoi dethicauhoi = new DethiCauhoi()
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