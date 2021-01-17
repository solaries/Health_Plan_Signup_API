using health_plan_signup_api.data;
using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;
 
namespace health_plan_signup_api.Models 
{ 
    public class Enrollees 
    { 
         
        public string add_enrollees(Enrollees_Table new_enrollees, bool returnID = false ) 
         {
              
             string result = "";
             if(returnID){
                result = "0";
             }
             try
             {
                 string query = "INSERT INTO enrollees( email,first_name,last_name,phone ) " +
                                "VALUES ( @email,@first_name,@last_name,@phone ) ";
                 MySqlCommand cmd = new MySqlCommand(query);
                 cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value =   new_enrollees.Email ;
                 cmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value =   new_enrollees.First_name ;
                 cmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value =   new_enrollees.Last_name ;
                 cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value =   new_enrollees.Phone ;
                 var x = HealthPlanSignUps.insertUpdateDeleteData(cmd);
                if(returnID){
                    result =x.ToString().Trim();
                }

            } 
            catch (Exception dd) 
            { 

                 result = dd.Message;
             }
             return result;
         }
         public List<Enrollees_Table> get_enrollees(string sql)
         {
            var actual = new List<Enrollees_Table>();
            DataTable dt = HealthPlanSignUps.fetchData("select  id ,  email ,  first_name ,  last_name ,  phone   from enrollees"  + sql);
             if (dt != null)
             {
                 if (dt.Rows.Count > 0)
                 {
                     actual = (from rw in dt.AsEnumerable()
                               select new Enrollees_Table()
                                {

                                        Id   = Convert.ToInt64(rw["id"]   ),
                                        Email  =   rw["email"].ToString(),
                                        First_name  =   rw["first_name"].ToString(),
                                        Last_name  =   rw["last_name"].ToString(),
                                        Phone  =   rw["phone"].ToString()
                                }).ToList();
                 }
             }

             return actual;
         }  
     }
 
 }