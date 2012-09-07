using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Order3Detail
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Guid? OrderUUID { get; set; }
		 public System.Int32? OrdersIdx_Fx { get; set; }
		 public System.String CounterIdx_Fx { get; set; }
		 public System.Int32? GiftIdx_Fx { get; set; }
		 public System.Int32? GiftCount { get; set; }
		 public System.Int32? NeedPoint { get; set; }
		 public System.String ChildOrderStatus { get; set; }
		 public System.String SourcesData { get; set; }
		 public System.String CancelAgainstBool { get; set; }
		 public System.String OrderStatus { get; set; }
		 public System.DateTime? CreatedDate { get; set; }

	 public int AddNew(Tab_Order3Detail model) 
 	 {
		string sql = "insert into Tab_Order3Detail(OrderUUID,OrdersIdx_Fx,CounterIdx_Fx,GiftIdx_Fx,GiftCount,NeedPoint,ChildOrderStatus,SourcesData,CancelAgainstBool,OrderStatus,CreatedDate)  values(@OrderUUID,@OrdersIdx_Fx,@CounterIdx_Fx,@GiftIdx_Fx,@GiftCount,@NeedPoint,@ChildOrderStatus,@SourcesData,@CancelAgainstBool,@OrderStatus,@CreatedDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@OrderUUID", model.OrderUUID)
			,new SqlParameter("@OrdersIdx_Fx", model.OrdersIdx_Fx)
			,new SqlParameter("@CounterIdx_Fx", model.CounterIdx_Fx)
			,new SqlParameter("@GiftIdx_Fx", model.GiftIdx_Fx)
			,new SqlParameter("@GiftCount", model.GiftCount)
			,new SqlParameter("@NeedPoint", model.NeedPoint)
			,new SqlParameter("@ChildOrderStatus", model.ChildOrderStatus)
			,new SqlParameter("@SourcesData", model.SourcesData)
			,new SqlParameter("@CancelAgainstBool", model.CancelAgainstBool)
			,new SqlParameter("@OrderStatus", model.OrderStatus)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Order3Detail model) 
 	 {
		 string sql = "update Tab_Order3Detail set OrderUUID=@OrderUUID,OrdersIdx_Fx=@OrdersIdx_Fx,CounterIdx_Fx=@CounterIdx_Fx,GiftIdx_Fx=@GiftIdx_Fx,GiftCount=@GiftCount,NeedPoint=@NeedPoint,ChildOrderStatus=@ChildOrderStatus,SourcesData=@SourcesData,CancelAgainstBool=@CancelAgainstBool,OrderStatus=@OrderStatus,CreatedDate=@CreatedDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@OrderUUID", model.OrderUUID)
			 ,new SqlParameter("@OrdersIdx_Fx", model.OrdersIdx_Fx)
			 ,new SqlParameter("@CounterIdx_Fx", model.CounterIdx_Fx)
			 ,new SqlParameter("@GiftIdx_Fx", model.GiftIdx_Fx)
			 ,new SqlParameter("@GiftCount", model.GiftCount)
			 ,new SqlParameter("@NeedPoint", model.NeedPoint)
			 ,new SqlParameter("@ChildOrderStatus", model.ChildOrderStatus)
			 ,new SqlParameter("@SourcesData", model.SourcesData)
			 ,new SqlParameter("@CancelAgainstBool", model.CancelAgainstBool)
			 ,new SqlParameter("@OrderStatus", model.OrderStatus)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Order3Detail where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Order3Detail ToModel(DataRow row)
	{
		Tab_Order3Detail model = new Tab_Order3Detail();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.OrderUUID = row.IsNull("OrderUUID")?null:(System.Guid?)row["OrderUUID"];
		model.OrdersIdx_Fx = row.IsNull("OrdersIdx_Fx")?null:(System.Int32?)row["OrdersIdx_Fx"];
		model.CounterIdx_Fx = row.IsNull("CounterIdx_Fx")?null:(System.String)row["CounterIdx_Fx"];
		model.GiftIdx_Fx = row.IsNull("GiftIdx_Fx")?null:(System.Int32?)row["GiftIdx_Fx"];
		model.GiftCount = row.IsNull("GiftCount")?null:(System.Int32?)row["GiftCount"];
		model.NeedPoint = row.IsNull("NeedPoint")?null:(System.Int32?)row["NeedPoint"];
		model.ChildOrderStatus = row.IsNull("ChildOrderStatus")?null:(System.String)row["ChildOrderStatus"];
		model.SourcesData = row.IsNull("SourcesData")?null:(System.String)row["SourcesData"];
		model.CancelAgainstBool = row.IsNull("CancelAgainstBool")?null:(System.String)row["CancelAgainstBool"];
		model.OrderStatus = row.IsNull("OrderStatus")?null:(System.String)row["OrderStatus"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		return model;
	}

	public Tab_Order3Detail Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Order3Detail  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Order3Detail model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Order3Detail> ListAll()
	{
		List<Tab_Order3Detail> list = new List<Tab_Order3Detail>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Order3Detail").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Order3Detail> ListAll(string strSql)
	{
		List<Tab_Order3Detail> list = new List<Tab_Order3Detail>();
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
		string strSql = " select * from Tab_Order3Detail";
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
