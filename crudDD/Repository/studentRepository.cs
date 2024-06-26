using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using crudDD.Models;

namespace crudDD.Repository
{
    public class studentRepository
    {
        private SqlConnection con;
        private void connectionBuilder()
        {
            string cs =ConfigurationManager.ConnectionStrings["conStr"].ToString();
            con = new SqlConnection(cs);
        }

        public bool insertStudent( Student stu)
        {
            connectionBuilder();
            SqlCommand com = new SqlCommand("insertStudent",con);
            com.CommandType = CommandType.StoredProcedure;
            
            com.Parameters.AddWithValue("@Name", stu.Name);
            com.Parameters.AddWithValue("@Guardian_name",stu.Guardian_Name);
            com.Parameters.AddWithValue("@Class_id", stu.Class_id);
            com.Parameters.AddWithValue("@DOB", stu.DOB);
            com.Parameters.AddWithValue("@Admission_date", stu.Admission_date);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Showing Student Records start

        public List<Student> show_table()
        {
            List<Student> stu_list = new List<Student>();
            connectionBuilder();
            SqlCommand cmd = new SqlCommand("show_tables", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count>0)
            {

                for(int i=0;i<dt.Rows.Count;i++)
                {
                    Student std = new Student();
                    std.stu_id = dt.Rows[i]["stu_id"].ToString();
                    std.Name = dt.Rows[i]["Name"].ToString();
                    std.Guardian_Name = dt.Rows[i]["Guardian_name"].ToString();
                    std.Class_id = Convert.ToInt32(dt.Rows[i]["class_id"]);
                    std.DOB = Convert.ToString(dt.Rows[i]["DOB"]);
                    std.Admission_date = Convert.ToString(dt.Rows[i]["Admission_date"]);
                    stu_list.Add(std);
                }
            }
            con.Close();
            return stu_list;
        }

        //Showing students end

        //Delete student record start
        public bool deleteRecord(string id)
        {
            int stu_id = Convert.ToInt32(id);
            connectionBuilder();
            SqlCommand com = new SqlCommand("delete_record",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@stu_id", stu_id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        //Delete student record end


        //Updating data start
        public List<Student> bindingSingleData(string id)
        {
            int stu_id = Convert.ToInt32(id);
            List<Student> stu_data=new List<Student>();
            connectionBuilder();
            SqlCommand com = new SqlCommand("updatingRecords", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@procId", "bindSingleData");
            com.Parameters.AddWithValue("@stu_id", id);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count>0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    Student st = new Student();
                    st.stu_id =  dt.Rows[i]["stu_id"].ToString();
                    st.Name = dt.Rows[i]["Name"].ToString();
                    st.Guardian_Name = dt.Rows[i]["Guardian_name"].ToString();
                    st.Class_id = Convert.ToInt32(dt.Rows[i]["class_id"]);  
                    st.DOB = dt.Rows[i]["DOB"].ToString();
                    st.Admission_date = dt.Rows[i]["Admission_date"].ToString();
                    stu_data.Add(st);
                }
            }
            con.Close();
            return stu_data;
        }



        public bool updateRecord(Student st)
        {
            connectionBuilder();
            SqlCommand com = new SqlCommand("updatingRecords", con);
            com.CommandType = CommandType.StoredProcedure;
            
            com.Parameters.AddWithValue("@procId", "upadteData");
            com.Parameters.AddWithValue("@stu_id", Convert.ToInt32(st.stu_id));
            com.Parameters.AddWithValue("@Name", st.Name);
            com.Parameters.AddWithValue("@Guardian_name", st.Guardian_Name);
            com.Parameters.AddWithValue("@class_id", st.Class_id);
            com.Parameters.AddWithValue("@DOB", st.DOB);
            com.Parameters.AddWithValue("@Admission_date", st.Admission_date);
            con.Open();
            int key = com.ExecuteNonQuery();
            con.Close();
            if (key>0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
            
        }

       
        //updating data end
    }
}