using System; 
using Microsoft.Extensions.Configuration;
using System.Data;
using MySql.Data.MySqlClient; 

namespace health_plan_signup_api.data
{
	public partial class HealthPlanSignUps 
	{

        private static IConfiguration Configuration { get; set; }
        private static string getConnectionString() 
        { 
            if (Configuration == null) 
            { 
                loadConfig(); 
            } 
            return Configuration["cn"]; 
        }             
        public static void loadConfig() 
        { 
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json"); 
            Configuration = builder.Build(); 
        }  		
	    public static long insertUpdateDeleteData(  MySqlCommand cmd)
	    {
	        long result = 0; 
	        using (MySqlConnection cn = new MySqlConnection(getConnectionString()))
	        { 
	                cmd.Connection = cn;  
	                cn.Open();
	                cmd.ExecuteNonQuery();
	                cn.Close();
	                result = cmd.LastInsertedId; 
	        }
	        return result;
	    }
	    public static DataTable fetchData(string sql)
	    {
	        DataTable dataTable = new DataTable();
	        using (MySqlConnection conn = new MySqlConnection(getConnectionString()))
	        { 
	            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
	            { 
	                conn.Open();
	                try
	                {
	                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
	                    {
	                        da.Fill(dataTable);
	                    }
	                }
	                catch (Exception ex)
	                {
	                }
	                conn.Close();
	            }
	        }
	        return dataTable;
	    }
	} 

 
 public partial class Enrollees_Table 
 {
     public long Id  
     {  
         get { return _Id; }  
         set { _Id = value;  }  
      }  
     long _Id;  
    
     public  string   Email  
     {  
         get { return _Email; }  
         set { _Email = value;  }  
      }  
      string   _Email;  
    
     public  string   First_name  
     {  
         get { return _First_name; }  
         set { _First_name = value;  }  
      }  
      string   _First_name;  
    
     public  string   Last_name  
     {  
         get { return _Last_name; }  
         set { _Last_name = value;  }  
      }  
      string   _Last_name;  
    
     public  string   Phone  
     {  
         get { return _Phone; }  
         set { _Phone = value;  }  
      }  
      string   _Phone;  
    
  }


}