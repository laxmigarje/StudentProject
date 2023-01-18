using Microsoft.Extensions.Configuration;
using StudentProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.DAL
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public StudentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Student> GetAllStudent()
        {
            List<Student> studentlist = new List<Student>();
            String qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.id = Convert.ToInt32(dr["id"]);//Id name same as per table in db
                    student.firstname = dr["firstname"].ToString();
                    student.lastname = dr["lastname"].ToString();
                    student.age = Convert.ToInt32(dr["age"]);
                    student.gender = dr["gender"].ToString();
                    student.address = dr["address"].ToString();
                    student.password = dr["password"].ToString();
                    studentlist.Add(student);

                }
            }
            con.Close();
            return studentlist;
        }

        public Student GetStudentById(int id)
        {
            Student student = new Student();
            String qry = "select * from student where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.id = Convert.ToInt32(dr["id"]);//Id name same as per table in db
                    student.firstname = dr["firstname"].ToString();
                    student.lastname = dr["lastname"].ToString();
                    student.age = Convert.ToInt32(dr["age"]);
                    student.gender = dr["gender"].ToString();
                    student.address = dr["address"].ToString();
                    student.password = dr["password"].ToString();


                }
            }
            con.Close();
            return student;

        }

        public int AddStudent(Student stud)
        {
            string qry = "insert into Employee values(@id,@firstname,@lastname,@age,@gender,@address,@password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", stud.Id);
            cmd.Parameters.AddWithValue("@firstname", stud.firstname);
            cmd.Parameters.AddWithValue("@lastname", stud.lastname);
            cmd.Parameters.AddWithValue("@age", stud.age);
            cmd.Parameters.AddWithValue("@gender", stud.gender);
            cmd.Parameters.AddWithValue("@address", stud.address);
            cmd.Parameters.AddWithValue("@password", stud.password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateStudent(Student stud)
        {
            string qry = "update Employee set @id,@firstname,@lastname,@age,@gender,@address,@password where Id =@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", stud.Id);
            cmd.Parameters.AddWithValue("@firstname", stud.firstname);
            cmd.Parameters.AddWithValue("@lastname", stud.lastname);
            cmd.Parameters.AddWithValue("@age", stud.age);
            cmd.Parameters.AddWithValue("@gender", stud.gender);
            cmd.Parameters.AddWithValue("@address", stud.address);
            cmd.Parameters.AddWithValue("@password", stud.password);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteStudent(int id)
        {
            string qry = "delete from Student where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

    }
}
