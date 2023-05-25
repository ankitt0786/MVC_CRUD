using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MVC_CRUD.Models
{
    public class StudentDB
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-BQJ4FSHQ\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
        public bool AddStudent(Student student)
        {
            SqlCommand cmd = new SqlCommand("sp_students", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FLAG","3");
            cmd.Parameters.AddWithValue("@NAME", student.Name);
            cmd.Parameters.AddWithValue("@AGE", student.Age);
            cmd.Parameters.AddWithValue("@CLASS", student.Class);
            cmd.Parameters.AddWithValue("@FATHERNAME", student.FatherName);
            cmd.Parameters.AddWithValue("@ADMISSIONDATE", student.AdmissionDate);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {
                return true;
            }
            return false;
        }

        public bool update(Student student)
        {
            SqlCommand cmd = new SqlCommand("sp_students", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FLAG", "4");
            cmd.Parameters.AddWithValue("@ID", student.Id);
            cmd.Parameters.AddWithValue("@NAME", student.Name);
            cmd.Parameters.AddWithValue("@AGE", student.Age);
            cmd.Parameters.AddWithValue("@CLASS", student.Class);
            cmd.Parameters.AddWithValue("@FATHERNAME", student.FatherName);
            cmd.Parameters.AddWithValue("@ADMISSIONDATE", student.AdmissionDate);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_students", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FLAG", "5");
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            return false;
        }

        public List<Student> GetStudentList()
        {
            List<Student> list = new List<Student>();
            SqlCommand cmd = new SqlCommand("sp_students", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FLAG", "1");
            SqlDataAdapter sda= new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            sda.Fill(dt);   
            if(dt.Rows.Count > 0)
            {
                list.Add(new Student()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["ID"]),
                    Name = dt.Rows[0]["NAME"].ToString(),
                    Age = dt.Rows[0]["AGE"].ToString(),
                    Class = dt.Rows[0]["CLASS"].ToString(),
                    FatherName = dt.Rows[0]["FATHERNAME"].ToString(),
                    AdmissionDate = Convert.ToDateTime(dt.Rows[0]["ADMISSIONDATE"]),
                });
            }
            return list;
        }

        public List<Student> GetStudent(int id)
        {
            List<Student> list = new List<Student>();
            SqlCommand cmd = new SqlCommand("sp_students", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FLAG", "2");
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                list.Add(new Student()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["ID"]),
                    Name = dt.Rows[0]["NAME"].ToString(),
                    Age = dt.Rows[0]["AGE"].ToString(),
                    Class = dt.Rows[0]["CLASS"].ToString(),
                    FatherName = dt.Rows[0]["FATHERNAME"].ToString(),
                    AdmissionDate = Convert.ToDateTime(dt.Rows[0]["ADMISSIONDATE"]),
                });
            }
            return list;
        }


    }
}