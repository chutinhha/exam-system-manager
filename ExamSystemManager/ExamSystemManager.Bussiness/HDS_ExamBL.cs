using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_ExamBL
    {
        public static string errMsg = "";
        public static List<HDS_Exam> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_Exam> Lst = ExMana.HDS_Exam.ToList();
            return Lst;
        }

        public static bool AddNew(HDS_Exam Exa)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_Exam(Exa);
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


        public static bool Update(HDS_Exam Exa)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_Exam obj = exMana.HDS_Exam.First(temp => temp.Exa_ID == Exa.Exa_ID);
                obj.Emp_ID = Exa.Emp_ID;
                obj.Exa_FromDate = Exa.Exa_FromDate;
                obj.Exa_ToDate = Exa.Exa_ToDate;
                obj.Res_rating = Exa.Res_rating;
                obj.Res_Result = Exa.Res_Result;
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
                HDS_Exam obj = exMana.HDS_Exam.First(temp => temp.Exa_ID == id);
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
