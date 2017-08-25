using AutoMapper;
using LuyenThi.Model.Models;
using LuyenThi.Service;
using LuyenThi.Web.Infrastructure.Core;
using LuyenThi.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace LuyenThi.Web.Api
{
    public class DapanController : ApiControllerBase
    {
        private IDapanService _dapanService;

        public DapanController(IErrorService errorService, IDapanService dapanServie)
            : base(errorService)
        {
            this._dapanService = dapanServie;
        }

        public IEnumerable<DapanViewModel> GetAllByCauhoi(int idCauhoi)
        {
            var model = _dapanService.GetAllByCauhoi(idCauhoi);
            var query = model.OrderBy(x => x.Thutu);
            var responseData = Mapper.Map<IEnumerable<Dapan>, IEnumerable<DapanViewModel>>(query);
            return responseData;
        }
    }
}