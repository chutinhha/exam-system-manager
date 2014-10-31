using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_InitExamDetailBL
    {
        public static string errMsg = "";
        public static List<HDS_InitExamDetail> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_InitExamDetail> Lst = ExMana.HDS_InitExamDetail.ToList();
            return Lst;
        }

        public static bool AddNew(HDS_InitExamDetail Iexd)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_InitExamDetail(Iexd);
                exMana.SaveChanges();
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            errMsg = "";
            return true;
        }


        public static bool Update(HDS_InitExamDetail Iexd)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_InitExamDetail obj = exMana.HDS_InitExamDetail.First(temp => temp.Iex_ID == Iexd.Iex_ID);
                obj.Iex_ID = Iexd.Iex_ID;
                obj.Lev_ID = Iexd.Lev_ID;
                obj.Iexd_NumQuestion = Iexd.Iexd_NumQuestion;
                exMana.SaveChanges();
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            errMsg = "";
            return true;
        }

        public static bool Delete(int id, string role)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_InitExamDetail obj = exMana.HDS_InitExamDetail.First(temp => temp.Iexd_ID == id);
                if (!role.Equals("AdmIexdstIexdor") || !role.Equals("Manager"))
                {
                    errMsg = "You don't permission to delete this user !";
                    return false;
                }
                exMana.DeleteObject(obj);
                exMana.SaveChanges();
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            errMsg = "";
            return true;
        }
    }
}
