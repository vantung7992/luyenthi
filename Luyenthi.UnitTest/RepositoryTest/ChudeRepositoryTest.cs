using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Luyenthi.UnitTest.RepositoryTest
{
    [TestClass]
    public class ChudeRepositoryTest
    {
        IDbFactory dbFactory;
        IDethiRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new ExamRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void Chude_Repository_Create()
        {
            Exam dt = new Exam();
            dt.Ten = "Bằng lái xe A1";
            dt.Ngaytao = DateTime.Now;
            dt.Nguoitao = "Tungnv";
            dt.Trangthai = true;

            var result = objRepository.Add(dt);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}