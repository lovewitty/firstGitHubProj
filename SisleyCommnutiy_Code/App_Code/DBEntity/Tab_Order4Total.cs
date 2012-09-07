using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Order4Total
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String OrderNo { get; set; }
		 public System.Int32? UserIdx_Fx { get; set; }
		 public System.String CounterNo { get; set; }
		 public System.Int32? CounterIdx { get; set; }
		 public System.Int32? TotalPoints { get; set; }
		 public System.String OrderStatus { get; set; }
		 public System.String SourcesData { get; set; }
		 public System.DateTime? DateCreated { get; set; }

	 public int AddNew(Tab_Order4Total model) 
 	 {
		string sql = "insert into Tab_Order4Total(OrderNo,UserIdx_Fx,CounterNo,CounterIdx,TotalPoints,OrderStatus,SourcesData,DateCreated)  values(@OrderNo,@UserIdx_Fx,@CounterNo,@CounterIdx,@TotalPoints,@OrderStatus,@SourcesData,@DateCreated); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@OrderNo", model.OrderNo)
			,new SqlParameter("@UserIdx_Fx", model.UserIdx_Fx)
			,new SqlParameter("@CounterNo", model.CounterNo)
			,new SqlParameter("@CounterIdx", model.CounterIdx)
			,new SqlParameter("@TotalPoints", model.TotalPoints)
			,new SqlParameter("@OrderStatus", model.OrderStatus)
			,new SqlParameter("@SourcesData", model.SourcesData)
			,new SqlParameter("@DateCreated", model.DateCreated)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Order4Total model) 
 	 {
		 string sql = "update Tab_Order4Total set OrderNo=@OrderNo,UserIdx_Fx=@UserIdx_Fx,CounterNo=@CounterNo,CounterIdx=@CounterIdx,TotalPoints=@TotalPoints,OrderStatus=@OrderStatus,SourcesData=@SourcesData,DateCreated=@DateCreated where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@OrderNo", model.OrderNo)
			 ,new SqlParameter("@UserIdx_Fx", model.UserIdx_Fx)
			 ,new SqlParameter("@CounterNo", model.CounterNo)
			 ,new SqlParameter("@CounterIdx", model.CounterIdx)
			 ,new SqlParameter("@TotalPoints", model.TotalPoints)
			 ,new SqlParameter("@OrderStatus", model.OrderStatus)
			 ,new SqlParameter("@SourcesData", model.SourcesData)
			 ,new SqlParameter("@DateCreated", model.DateCreated)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Order4Total where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Order4Total ToModel(DataRow row)
	{
		Tab_Order4Total model = new Tab_Order4Total();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.OrderNo = row.IsNull("OrderNo")?null:(System.String)row["OrderNo"];
		model.UserIdx_Fx = row.IsNull("UserIdx_Fx")?null:(System.Int32?)row["UserIdx_Fx"];
		model.CounterNo = row.IsNull("CounterNo")?null:(System.String)row["CounterNo"];
		model.CounterIdx = row.IsNull("CounterIdx")?null:(System.Int32?)row["CounterIdx"];
		model.TotalPoints = row.IsNull("TotalPoints")?null:(System.Int32?)row["TotalPoints"];
		model.OrderStatus = row.IsNull("OrderStatus")?null:(System.String)row["OrderStatus"];
		model.SourcesData = row.IsNull("SourcesData")?null:(System.String)row["SourcesData"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		return model;
	}

	public Tab_Order4Total Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Order4Total  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Order4Total model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Order4Total> ListAll()
	{
		List<Tab_Order4Total> list = new List<Tab_Order4Total>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Order4Total").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Order4Total> ListAll(string strSql)
	{
		List<Tab_Order4Total> list = new List<Tab_Order4Total>();
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
		string strSql = " select * from Tab_Order4Total";
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
