using Member.Data.Interface;
using Member.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Member.Data.Repository
{
    public class MembersRepository : IMembers
    {
        public string connString = "Data Source=.;Initial Catalog=mydb;Integrated Security=True";
        private DataTable dataTable = new DataTable();
        
        public DataTable getData()
        {
            string query = "select * from dbo.assignmentdata";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            return dataTable;
        }
            
        
        public void dataToList ()
        {
            List<Members> lisMembers = new List<Members>();
            for (int i=1;i<=getData().Rows.Count;i++)
            {
                Members member = new Members();
                member.MemberId = System.Convert.ToInt32(getData().Rows[i]["Id"]);
                member.FirstName = getData().Rows[i]["FirstName"].ToString();
                member.LastName = getData().Rows[i]["LastName"].ToString();
                lisMembers.Add(member);
            }
        }
        public List<Members> GetAllMember()
        {
            
            DataTable dt = getData();
            List<Members> lisMembers = new List<Members>();
            for (int i = 0; i < (dt.Rows.Count-1); i++)
            {
                Members member = new Members();
                member.MemberId = System.Convert.ToInt32(dt.Rows[i]["Id"]);
                member.FirstName = dt.Rows[i]["FirstName"].ToString();
                member.LastName = dt.Rows[i]["LastName"].ToString();
                lisMembers.Add(member);
            }
            return lisMembers;
        }

        public Members GetMember(int id)
        {
            throw new System.NotImplementedException();
        }


    }
}