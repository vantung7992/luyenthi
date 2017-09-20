using LuyenThi.Model.Models;
using LuyenThi.Web.Models;

namespace LuyenThi.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateTopic(this Topic topic, TopicViewModel topicViewModel)
        {
            topic.ID = topicViewModel.ID;
            topic.Name = topicViewModel.Name;
            topic.Tag = topicViewModel.Tag;
            topic.ParentID = topicViewModel.ParentID;
            topic.Description = topicViewModel.Description;
            topic.Seo = topicViewModel.Seo;
            topic.Tag = topicViewModel.Tag;
            topic.Image = topicViewModel.Image;
            topic.HomeFlag = topicViewModel.HomeFlag;
            topic.HotFlag = topicViewModel.HotFlag;
            topic.ViewCount = topicViewModel.ViewCount;
            topic.Status = topicViewModel.Status;
            topic.CreatedDate = topicViewModel.CreatedDate;
            topic.CreatedBy = topicViewModel.CreatedBy;
            topic.UpdatedDate = topicViewModel.UpdatedDate;
            topic.UpdatedBy = topicViewModel.UpdatedBy;
            topic.Note = topicViewModel.Note;
        }

        public static void UpdateExam(this Exam exam, ExamViewModel examViewModel)
        {
            exam.ID = examViewModel.ID;
            exam.Name = examViewModel.Name;
            exam.Seo = examViewModel.Seo;
            exam.Tag = examViewModel.Tag;
            exam.Description = examViewModel.Description;
            exam.Image = examViewModel.Image;
            exam.TimeToDo = examViewModel.TimeToDo;
            exam.HotFlag = examViewModel.HotFlag;
            exam.HomeFlag = examViewModel.HomeFlag;
            exam.ViewCount = examViewModel.ViewCount;
            exam.Status = examViewModel.Status;
            exam.CreatedDate = examViewModel.CreatedDate;
            exam.CreatedBy = examViewModel.CreatedBy;
            exam.UpdatedDate = examViewModel.UpdatedDate;
            exam.UpdatedBy = examViewModel.UpdatedBy;
            exam.Note = examViewModel.Note;
        }

        public static void UpdateQuestion(this Question question, QuestionViewModel questionViewModel)
        {
            question.ID = questionViewModel.ID;
            question.TopicID = questionViewModel.TopicID;
            question.Content = questionViewModel.Content;
            question.DisplayContent = questionViewModel.DisplayContent;
            question.Suggest = questionViewModel.Suggest;
            question.Tag = questionViewModel.Tag;
            question.Image = questionViewModel.Image;
            question.Status = questionViewModel.Status;
            question.CreatedDate = questionViewModel.CreatedDate;
            question.CreatedBy = questionViewModel.CreatedBy;
            question.UpdatedDate = questionViewModel.UpdatedDate;
            question.UpdatedBy = questionViewModel.UpdatedBy;
            question.Note = questionViewModel.Note;
        }

        public static void UpdateAnswer(this Answer answer, AnswerViewModel answerViewModel)
        {
            answer.ID = answerViewModel.ID;
            answer.QuestionID = answerViewModel.QuestionID;
            answer.Content = answerViewModel.Content;
            answer.Code = answerViewModel.Code;
            answer.Order = answerViewModel.Order;
            answer.TrueAnswer = answerViewModel.TrueAnswer;
            answer.Image = answerViewModel.Image;
            answer.Status = answerViewModel.Status;
            answer.CreatedDate = answerViewModel.CreatedDate;
            answer.CreatedBy = answerViewModel.CreatedBy;
            answer.UpdatedDate = answerViewModel.UpdatedDate;
            answer.UpdatedBy = answerViewModel.UpdatedBy;
            answer.Note = answerViewModel.Note;
        }

        public static void UpdateExamTopic(this ExamTopic examTopic, ExamTopicViewModel examTopicViewModel)
        {
            examTopic.TopicID = examTopicViewModel.TopicID;
            examTopic.ExamID = examTopicViewModel.ExamID;
            examTopic.Status = examTopicViewModel.Status;
            examTopic.CreatedDate = examTopicViewModel.CreatedDate;
            examTopic.CreatedBy = examTopicViewModel.CreatedBy;
            examTopic.UpdatedDate = examTopicViewModel.UpdatedDate;
            examTopic.UpdatedBy = examTopicViewModel.UpdatedBy;
            examTopic.Note = examTopicViewModel.Note;
        }

        public static void UpdateDethiCauhoi(this ExamDetail examDetail, ExamDetailViewModel dethiquestionViewModel)
        {
            examDetail.ExamID = dethiquestionViewModel.ExamID;
            examDetail.QuestionID = dethiquestionViewModel.QuestionID;
            examDetail.Order = dethiquestionViewModel.Order;
            examDetail.Status = dethiquestionViewModel.Status;
            examDetail.CreatedDate = dethiquestionViewModel.CreatedDate;
            examDetail.CreatedBy = dethiquestionViewModel.CreatedBy;
            examDetail.UpdatedDate = dethiquestionViewModel.UpdatedDate;
            examDetail.UpdatedBy = dethiquestionViewModel.UpdatedBy;
            examDetail.Note = dethiquestionViewModel.Note;
        }
    }
}