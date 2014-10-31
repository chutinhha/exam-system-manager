using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_ExamDetailDetailBL
    {
        public static string errMsg = "";
        public static List<HDS_ExamDetail> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_ExamDetail> Lst = ExMana.HDS_ExamDetail.ToList();
            return Lst;
        }

        public static bool AddNew(HDS_ExamDetail Exd)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_ExamDetail(Exd);
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


        public static bool Update(HDS_ExamDetail Exd)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_ExamDetail obj = exMana.HDS_ExamDetail.First(temp => temp.Exd_ID == Exd.Exd_ID);
                obj.Que_ID = Exd.Que_ID;
                obj.Exa_ID = Exd.Exa_ID;
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
                HDS_ExamDetail obj = exMana.HDS_ExamDetail.First(temp => temp.Exd_ID == id);
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
