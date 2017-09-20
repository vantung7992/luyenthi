using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Luyenthi.UnitTest.RepositoryTest
{
    [TestClass]
    public class TopicRepositoryTest
    {
        IDbFactory dbFactory;
        IExamRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new ExamRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void Exam_Repository_Create()
        {
            Exam dt = new Exam();
            dt.Name = "Bằng lái xe A1";
            dt.CreatedDate = DateTime.Now;
            dt.CreatedBy = "Tungnv";
            dt.Status = true;

            var result = objRepository.Add(dt);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}