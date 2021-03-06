﻿using AutoMapper;
using LuyenThi.Model.Models;
using LuyenThi.Web.Models;

namespace LuyenThi.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Topic, TopicViewModel>();
                cfg.CreateMap<Exam, ExamViewModel>();
                cfg.CreateMap<Question, QuestionViewModel>();
                cfg.CreateMap<Answer, AnswerViewModel>();
                cfg.CreateMap<ExamTopic, ExamTopicViewModel>();
            });
        }
    }
}