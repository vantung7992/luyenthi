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
            question.Noidung = questionViewModel.Noidung;
            question.Noidunghienthi = questionViewModel.Noidunghienthi;
            question.Goiy = questionViewModel.Goiy;
            question.Tag = questionViewModel.Tag;
            question.Image = questionViewModel.Image;
            question.Trangthai = questionViewModel.Trangthai;
            question.Ngaytao = questionViewModel.Ngaytao;
            question.Nguoitao = questionViewModel.Nguoitao;
            question.Ngaysua = questionViewModel.Ngaysua;
            question.Nguoisua = questionViewModel.Nguoisua;
            question.Ghichu = questionViewModel.Ghichu;
        }

        public static void UpdateDapan(this Answer dapan, AnswerViewModel dapanViewModel)
        {
            dapan.ID = dapanViewModel.ID;
            dapan.Noidung = dapanViewModel.Noidung;
            dapan.Ma = dapanViewModel.Ma;
            dapan.Thutu = dapanViewModel.Thutu;
            dapan.Dungsai = dapanViewModel.Dungsai;
            dapan.IDCauhoi = dapanViewModel.IDCauhoi;
            dapan.Image = dapanViewModel.Image;

            dapan.Trangthai = dapanViewModel.Trangthai;
            dapan.Ngaytao = dapanViewModel.Ngaytao;
            dapan.Nguoitao = dapanViewModel.Nguoitao;
            dapan.Ngaysua = dapanViewModel.Ngaysua;
            dapan.Nguoisua = dapanViewModel.Nguoisua;
            dapan.Ghichu = dapanViewModel.Ghichu;
        }

        public static void UpdateChudeCauhoi(this QuestionTopic chudeCauhoi, ChudequestionViewModel chudequestionViewModel)
        {
            chudeCauhoi.IDChude = chudequestionViewModel.IDChude;
            chudeCauhoi.IDCauhoi = chudequestionViewModel.IDCauhoi;
            chudeCauhoi.Thutu = chudequestionViewModel.Thutu;

            chudeCauhoi.Trangthai = chudequestionViewModel.Trangthai;
            chudeCauhoi.Ngaytao = chudequestionViewModel.Ngaytao;
            chudeCauhoi.Nguoitao = chudequestionViewModel.Nguoitao;
            chudeCauhoi.Ngaysua = chudequestionViewModel.Ngaysua;
            chudeCauhoi.Nguoisua = chudequestionViewModel.Nguoisua;
            chudeCauhoi.Ghichu = chudequestionViewModel.Ghichu;
        }

        public static void UpdateChudeDethi(this ExamTopic chudeDethi, ExamTopicViewModel chudeexamViewModel)
        {
            chudeDethi.IDChude = chudeexamViewModel.IDChude;
            chudeDethi.IDDethi = chudeexamViewModel.IDDethi;

            chudeDethi.Trangthai = chudeexamViewModel.Trangthai;
            chudeDethi.Ngaytao = chudeexamViewModel.Ngaytao;
            chudeDethi.Nguoitao = chudeexamViewModel.Nguoitao;
            chudeDethi.Ngaysua = chudeexamViewModel.Ngaysua;
            chudeDethi.Nguoisua = chudeexamViewModel.Nguoisua;
            chudeDethi.Ghichu = chudeexamViewModel.Ghichu;
        }

        public static void UpdateDethiCauhoi(this ExamDetail dethiCauhoi, ExamDetailViewModel dethiquestionViewModel)
        {
            dethiCauhoi.IDDethi = dethiquestionViewModel.IDDethi;
            dethiCauhoi.IDCauhoi = dethiquestionViewModel.IDCauhoi;
            dethiCauhoi.Thutu = dethiquestionViewModel.Thutu;

            dethiCauhoi.Trangthai = dethiquestionViewModel.Trangthai;
            dethiCauhoi.Ngaytao = dethiquestionViewModel.Ngaytao;
            dethiCauhoi.Nguoitao = dethiquestionViewModel.Nguoitao;
            dethiCauhoi.Ngaysua = dethiquestionViewModel.Ngaysua;
            dethiCauhoi.Nguoisua = dethiquestionViewModel.Nguoisua;
            dethiCauhoi.Ghichu = dethiquestionViewModel.Ghichu;
        }
    }
}