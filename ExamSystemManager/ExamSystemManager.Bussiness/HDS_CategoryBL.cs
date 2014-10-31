using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_CategoryBL
    {
        public static string errMsg = "";
        public static List<HDS_Category> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_Category> catLst = ExMana.HDS_Category.ToList();
            return catLst;
        }

        public static bool AddNew(HDS_Category cat)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_Category(cat);
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


        public static bool Update(HDS_Category cat)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_Category obj = exMana.HDS_Category.First(temp => temp.Cat_ID == cat.Cat_ID);
                obj.Cat_Name = cat.Cat_Name;
                obj.Cat_Description = cat.Cat_Description;
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
                HDS_Category obj = exMana.HDS_Category.First(temp => temp.Cat_ID == id);
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
