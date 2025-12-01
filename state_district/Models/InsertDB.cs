using System.Data;
using System.Data.SqlClient;
namespace state_district.Models

{
    public class InsertDB
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-USLUAF59\SQLEXPRESS;database=aspcore;integrated security=true");
        
        public string insertdb(Insert clsobj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertstudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stid", clsobj.stid);
                cmd.Parameters.AddWithValue("@did", clsobj.did);
                cmd.Parameters.AddWithValue("@sna", clsobj.sname);
                cmd.Parameters.AddWithValue("@sag", clsobj.sage);
                cmd.Parameters.AddWithValue("@sphot", clsobj.sphoto);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Inserted successfully");
            }
            catch(Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
            
        }
        public List<stclass> selectstates()
        {
            var getdata = new List<stclass>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_state", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var o = new stclass
                    {
                        stid = Convert.ToInt32(sdr["stateid"]),
                        stname = sdr["statename"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
        public List<dclass> selectdistrict(int stateid)
        {
            var getdata = new List<dclass>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_district", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stid", stateid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var o = new dclass
                    {
                        did= Convert.ToInt32(sdr["districtid"]),
                        dname = sdr["districtname"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }
}
