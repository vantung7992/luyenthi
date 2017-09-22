using LuyenThi.Data.Infrastructure;
using LuyenThi.Data.Repositories;
using LuyenThi.Model.Models;
using System.Collections.Generic;
using System;

namespace LuyenThi.Service
{
    public interface ITopicService
    {
        void Add(Topic topic);

        void Update(Topic topic);

        Topic Delete(int id);

        IEnumerable<Topic> GetAll();
        IEnumerable<Topic> GetAllParents(int id);

        IEnumerable<Topic> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Topic> GetAll(string keyword);

        Topic GetById(int id);

        void SaveChanges();
    }

    public class TopicService : ITopicService
    {
        private ITopicRepository _topicRepository;
        private IUnitOfWork _unitOfWork;

        public TopicService(ITopicRepository topicRepository, IUnitOfWork unitOfWork)
        {
            this._topicRepository = topicRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Topic Topic)
        {
            _topicRepository.Add(Topic);
        }

        public Topic Delete(int id)
        {
            return _topicRepository.Delete(id);
        }

        public IEnumerable<Topic> GetAll()
        {
            return _topicRepository.GetAll();
        }

        public IEnumerable<Topic> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
                return _topicRepository.GetMulti(x => x.Name.Contains(keyword) || x.Note.Contains(keyword));
            return _topicRepository.GetAll();
        }

        public IEnumerable<Topic> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _topicRepository.GetMultiPaging(x => x.Status == true, out totalRow, page, pageSize);
        }

        public IEnumerable<Topic> GetAllPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _topicRepository.GetMultiPaging(x => x.Status == true && x.Tag.Contains(tag), out totalRow, page, pageSize);
        }

        public IEnumerable<Topic> GetAllParents(int id)
        {
            return _topicRepository.GetMulti(x => x.ID != id);
        }

        public Topic GetById(int id)
        {
            return _topicRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Topic Topic)
        {
            _topicRepository.Update(Topic);
        }
    }
}