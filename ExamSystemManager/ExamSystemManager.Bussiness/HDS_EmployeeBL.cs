using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamSystemManager.Data;

namespace ExamSystemManager.Bussiness
{
    public class HDS_EmployeeBL
    {

        public static string errMsg = "";
        public static List<HDS_Employee> getAll()
        {
            ExamSystemManagerDBEntities ExMana = new ExamSystemManagerDBEntities();
            List<HDS_Employee> Lst = ExMana.HDS_Employee.ToList();
            return Lst;
        }

        public static bool AddNew(HDS_Employee Emp)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                exMana.AddToHDS_Employee(Emp);
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


        public static bool Update(HDS_Employee Emp)
        {
            try
            {
                ExamSystemManagerDBEntities exMana = new ExamSystemManagerDBEntities();
                HDS_Employee obj = exMana.HDS_Employee.First(temp => temp.Emp_ID == Emp.Emp_ID);
                obj.Emp_Name = Emp.Emp_Name;
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
                HDS_Employee obj = exMana.HDS_Employee.First(temp => temp.Emp_ID == id);
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
