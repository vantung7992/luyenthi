using LuyenThi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuyenThi.Service
{
    public interface IChudeService
    {
        void Add(Chude chude);
        void Update(Chude chude);
        void Delete(int id);
        IEnumerable<Chude> GetAll();
        IEnumerable<Chude> GetAllPaging(int page, int pageSize, out int totalRow);
        Chude GetById(int id);
        void SaveChanges();
    }
    public class ChudeService 
    {
       
    }
}
