using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_LeverBL
    {
        public static string errMsg = "";

        public static List<HDS_Lever> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_Lever> Lst = ExMana.HDS_Lever.ToList();
            return Lst;
        }

        public static HDS_Lever getById(int id)
        {
            ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
            return exMana.HDS_Lever.First(temp => temp.Lev_ID == id);
        }

        public static bool AddNew(HDS_Lever Lev)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_Lever(Lev);
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


        public static bool Update(HDS_Lever lev)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_Lever obj = exMana.HDS_Lever.First(temp => temp.Lev_ID == lev.Lev_ID);
                obj.Lev_Name = lev.Lev_Name;
                obj.Lev_Description = lev.Lev_Description;
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
                HDS_Lever obj = exMana.HDS_Lever.First(temp => temp.Lev_ID == id);
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
