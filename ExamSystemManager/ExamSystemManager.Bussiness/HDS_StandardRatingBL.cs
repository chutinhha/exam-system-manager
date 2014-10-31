using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_StandardRatingBL
    {
        public static string errMsg = "";
        public static List<HDS_StandardRating> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_StandardRating> Lst = ExMana.HDS_StandardRating.ToList();
            return Lst;
        }

        public static bool AddNew(HDS_StandardRating Rat)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_StandardRating(Rat);
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


        public static bool Update(HDS_StandardRating Rat)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_StandardRating obj = exMana.HDS_StandardRating.First(temp => temp.Iex_ID == Rat.Iex_ID);
                obj.Iex_ID = Rat.Iex_ID;
                obj.Rat_FromMark = Rat.Rat_FromMark;
                obj.Rat_ToMark = Rat.Rat_ToMark;
                obj.Rat_Name = Rat.Rat_Name;
                obj.Rat_Description = Rat.Rat_Description;
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
                HDS_StandardRating obj = exMana.HDS_StandardRating.First(temp => temp.Rat_ID == id);
                if (!role.Equals("AdmRatstrator") || !role.Equals("Manager"))
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
