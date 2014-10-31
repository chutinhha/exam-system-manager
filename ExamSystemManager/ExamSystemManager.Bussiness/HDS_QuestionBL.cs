using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_QuestionBL
    {
        public static string errMsg = "";
        public static List<HDS_Question> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_Question> Lst = ExMana.HDS_Question.ToList();
            return Lst;
        }

        public static bool AddNew(HDS_Question Que)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_Question(Que);
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


        public static bool Update(HDS_Question Que)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_Question obj = exMana.HDS_Question.First(temp => temp.Que_ID == Que.Que_ID);
                obj.Lev_ID = Que.Lev_ID;
                obj.Cat_ID = Que.Cat_ID;
                obj.Typ_ID = Que.Typ_ID;
                obj.Que_Title = Que.Que_Title;
                obj.Que_Description = Que.Que_Description;
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
                HDS_Question obj = exMana.HDS_Question.First(temp => temp.Que_ID == id);
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
