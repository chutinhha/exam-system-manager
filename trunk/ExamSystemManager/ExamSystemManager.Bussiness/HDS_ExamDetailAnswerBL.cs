using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_ExamDetailAnswerAnswerBL
    {
        public static string errMsg = "";
        public static List<HDS_ExamDetailAnswer> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_ExamDetailAnswer> Lst = ExMana.HDS_ExamDetailAnswer.ToList();
            return Lst;
        }

        public static bool AddNew(HDS_ExamDetailAnswer Exda)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_ExamDetailAnswer(Exda);
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


        public static bool Update(HDS_ExamDetailAnswer Exda)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_ExamDetailAnswer obj = exMana.HDS_ExamDetailAnswer.First(temp => temp.Exda_ID == Exda.Exda_ID);
                obj.Exd_ID = Exda.Exd_ID;
                obj.Exda_Answer = Exda.Exda_Answer;
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
                HDS_ExamDetailAnswer obj = exMana.HDS_ExamDetailAnswer.First(temp => temp.Exda_ID == id);
                if (!role.Equals("AdmExastExaor") || !role.Equals("Manager"))
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
