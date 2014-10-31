using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_TypeQuestionBL
    {

        public static string errMsg = "";
        public static List<HDS_TypeQuestion> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_TypeQuestion> Lst = ExMana.HDS_TypeQuestion.ToList();
            return Lst;
        }

        public static HDS_TypeQuestion getById(int id)
        {
            ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
            return exMana.HDS_TypeQuestion.First(temp => temp.typ_ID == id);
        }

        public static bool AddNew(HDS_TypeQuestion Typ)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_TypeQuestion(Typ);
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


        public static bool Update(HDS_TypeQuestion Typ)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_TypeQuestion obj = exMana.HDS_TypeQuestion.First(temp => temp.typ_ID == Typ.typ_ID);
                obj.Typ_Name = Typ.Typ_Name;
                obj.Typ_Description = Typ.Typ_Description;
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
                HDS_TypeQuestion obj = exMana.HDS_TypeQuestion.First(temp => temp.typ_ID == id);
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
