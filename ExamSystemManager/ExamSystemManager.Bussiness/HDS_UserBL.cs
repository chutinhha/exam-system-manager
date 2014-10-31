using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_UserBL
    {
        public static string errMsg = "";
        public static object getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            return (from sc in ExMana.HDS_User.Include("HDS_Employee") select new { id = sc.Usr_ID, emp = sc.HDS_Employee.Emp_Name, username = sc.Usr_Username, pass = sc.Usr_Password, role = sc.Usr_Role, img = sc.Usr_Avata }).ToList();
            
        }

        public static HDS_User getByUsername(string UserName)
        {
            ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
            return exMana.HDS_User.First(temp => temp.Usr_Username == UserName);
        }

        public static HDS_User getById(int id)
        {
            ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
            return exMana.HDS_User.First(temp => temp.Usr_ID == id);
        }

        public static bool AddNew(HDS_User Usr)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_User(Usr);
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


        public static bool Update(HDS_User Usr)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_User obj = exMana.HDS_User.First(temp => temp.Usr_ID == Usr.Usr_ID);
                obj.Emp_ID = Usr.Emp_ID;
                obj.Usr_Username = Usr.Usr_Username;
                obj.Usr_Password = Usr.Usr_Password;
                obj.Usr_Role = Usr.Usr_Role;
                obj.Usr_Avata = Usr.Usr_Avata;
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

        public static bool Delete(int id, string curentUsername, string role)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_User obj = exMana.HDS_User.First(temp => temp.Usr_ID == id);
                if (curentUsername == obj.Usr_Username)
                {
                    errMsg = "You can't to delete yourself !";
                    return false;
                }
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

        public static bool checkLogin(string user, string pass, ref string role)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                role = exMana.HDS_User.First(temp => temp.Usr_Username == user && temp.Usr_Password == pass).Usr_Role;
                //role = NexMana.Employee.First(temp => temp.Username == user && temp.Password == pass).Role;
            }
            catch (Exception)
            {
                role = "";
                return false;
            }
            return true;
        }
    }
}
