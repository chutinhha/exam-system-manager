using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_InitExamBL
    {
        public static string errMsg = "";
        public static List<HDS_InitExam> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_InitExam> Lst = ExMana.HDS_InitExam.ToList();
            return Lst;
        }

        public static bool AddNew(HDS_InitExam Ini)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_InitExam(Ini);
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


        public static bool Update(HDS_InitExam Ini)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_InitExam obj = exMana.HDS_InitExam.First(temp => temp.Iex_ID == Ini.Iex_ID);
                obj.Iex_Name = Ini.Iex_Name;
                obj.Iex_Description = Ini.Iex_Description;
                obj.Iex_Date = Ini.Iex_Date;
                obj.Lev_ID = Ini.Lev_ID;
                obj.Cat_ID = Ini.Cat_ID;
                obj.Typ_ID = Ini.Typ_ID;
                obj.Iex_NumQuestion = Ini.Iex_NumQuestion;
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
                HDS_InitExam obj = exMana.HDS_InitExam.First(temp => temp.Iex_ID == id);
                if (!role.Equals("Administrator") || !role.Equals("Manager"))
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
