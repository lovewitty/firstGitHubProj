using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserManager
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String uName { get; set; }
		 public System.String uPwd { get; set; }
		 public System.String uRole { get; set; }
		 public System.DateTime? uCreatedDate { get; set; }

	 public int AddNew(Tab_UserManager model) 
 	 {
		string sql = "insert into Tab_UserManager(uName,uPwd,uRole,uCreatedDate)  values(@uName,@uPwd,@uRole,@uCreatedDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@uName", model.uName)
			,new SqlParameter("@uPwd", model.uPwd)
			,new SqlParameter("@uRole", model.uRole)
			,new SqlParameter("@uCreatedDate", model.uCreatedDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserManager model) 
 	 {
		 string sql = "update Tab_UserManager set uName=@uName,uPwd=@uPwd,uRole=@uRole,uCreatedDate=@uCreatedDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@uName", model.uName)
			 ,new SqlParameter("@uPwd", model.uPwd)
			 ,new SqlParameter("@uRole", model.uRole)
			 ,new SqlParameter("@uCreatedDate", model.uCreatedDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserManager where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserManager ToModel(DataRow row)
	{
		Tab_UserManager model = new Tab_UserManager();
		model.Idx = row.IsNull("idx")?null:(System.Int32?)row["idx"];
		model.uName = row.IsNull("uName")?null:(System.String)row["uName"];
		model.uPwd = row.IsNull("uPwd")?null:(System.String)row["uPwd"];
		model.uRole = row.IsNull("uRole")?null:(System.String)row["uRole"];
		model.uCreatedDate = row.IsNull("uCreatedDate")?null:(System.DateTime?)row["uCreatedDate"];
		return model;
	}


    public Tab_UserManager CheckAccount(string uName, string pwd)
    {
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_UserManager  where uName=@uName and uPwd=@uPwd"
                 , new SqlParameter("@uName", uName)
                 , new SqlParameter("@uPwd", pwd)).Tables[0];
        if (dt.Rows.Count > 1)
        { throw new Exception("more than 1 row was found"); }

        if (dt.Rows.Count <= 0) { return null; }

        DataRow row = dt.Rows[0];
        Tab_UserManager model = ToModel(row);
        return model;
    }

	public Tab_UserManager Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserManager  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserManager model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserManager> ListAll()
	{
		List<Tab_UserManager> list = new List<Tab_UserManager>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserManager").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserManager> ListAll(string strSql)
	{
		List<Tab_UserManager> list = new List<Tab_UserManager>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,strSql).Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public static DataSet GetDs_Where(string beginDate,string endDate,string keywords)
	{
		List<SqlParameter> spsList = new List<SqlParameter>();
		string strSql = " select * from Tab_UserManager";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
		strWhere = strWhere + " and courseCreatedDate >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
			strWhere = strWhere + " and courseCreatedDate <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
			strWhere = strWhere + " and (courseTitle like @keywords or courseText like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
		strSql = strSql + strWhere + " order by courseCreatedDate desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
