using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_OrderDetail
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? OrdersIdx_Fx { get; set; }
		 public System.String CounterNo { get; set; }
		 public System.Int32? GiftId { get; set; }
		 public System.String IdOfGifts { get; set; }
		 public System.String RequiredPoints { get; set; }
		 public System.String ChildOrderStatus { get; set; }
		 public System.String SourcesData { get; set; }
		 public System.String CancelAgainstBool { get; set; }
		 public System.String CreatedDate { get; set; }

	 public int AddNew(Tab_OrderDetail model) 
 	 {
		string sql = "insert into Tab_OrderDetail(OrdersIdx_Fx,CounterNo,GiftId,IdOfGifts,RequiredPoints,ChildOrderStatus,SourcesData,CancelAgainstBool,CreatedDate)  values(@OrdersIdx_Fx,@CounterNo,@GiftId,@IdOfGifts,@RequiredPoints,@ChildOrderStatus,@SourcesData,@CancelAgainstBool,@CreatedDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@OrdersIdx_Fx", model.OrdersIdx_Fx)
			,new SqlParameter("@CounterNo", model.CounterNo)
			,new SqlParameter("@GiftId", model.GiftId)
			,new SqlParameter("@IdOfGifts", model.IdOfGifts)
			,new SqlParameter("@RequiredPoints", model.RequiredPoints)
			,new SqlParameter("@ChildOrderStatus", model.ChildOrderStatus)
			,new SqlParameter("@SourcesData", model.SourcesData)
			,new SqlParameter("@CancelAgainstBool", model.CancelAgainstBool)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_OrderDetail model) 
 	 {
		 string sql = "update Tab_OrderDetail set OrdersIdx_Fx=@OrdersIdx_Fx,CounterNo=@CounterNo,GiftId=@GiftId,IdOfGifts=@IdOfGifts,RequiredPoints=@RequiredPoints,ChildOrderStatus=@ChildOrderStatus,SourcesData=@SourcesData,CancelAgainstBool=@CancelAgainstBool,CreatedDate=@CreatedDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@OrdersIdx_Fx", model.OrdersIdx_Fx)
			 ,new SqlParameter("@CounterNo", model.CounterNo)
			 ,new SqlParameter("@GiftId", model.GiftId)
			 ,new SqlParameter("@IdOfGifts", model.IdOfGifts)
			 ,new SqlParameter("@RequiredPoints", model.RequiredPoints)
			 ,new SqlParameter("@ChildOrderStatus", model.ChildOrderStatus)
			 ,new SqlParameter("@SourcesData", model.SourcesData)
			 ,new SqlParameter("@CancelAgainstBool", model.CancelAgainstBool)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_OrderDetail where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_OrderDetail ToModel(DataRow row)
	{
		Tab_OrderDetail model = new Tab_OrderDetail();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.OrdersIdx_Fx = row.IsNull("OrdersIdx_Fx")?null:(System.Int32?)row["OrdersIdx_Fx"];
		model.CounterNo = row.IsNull("CounterNo")?null:(System.String)row["CounterNo"];
		model.GiftId = row.IsNull("GiftId")?null:(System.Int32?)row["GiftId"];
		model.IdOfGifts = row.IsNull("IdOfGifts")?null:(System.String)row["IdOfGifts"];
		model.RequiredPoints = row.IsNull("RequiredPoints")?null:(System.String)row["RequiredPoints"];
		model.ChildOrderStatus = row.IsNull("ChildOrderStatus")?null:(System.String)row["ChildOrderStatus"];
		model.SourcesData = row.IsNull("SourcesData")?null:(System.String)row["SourcesData"];
		model.CancelAgainstBool = row.IsNull("CancelAgainstBool")?null:(System.String)row["CancelAgainstBool"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.String)row["CreatedDate"];
		return model;
	}

	public Tab_OrderDetail Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_OrderDetail  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_OrderDetail model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_OrderDetail> ListAll()
	{
		List<Tab_OrderDetail> list = new List<Tab_OrderDetail>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_OrderDetail").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_OrderDetail> ListAll(string strSql)
	{
		List<Tab_OrderDetail> list = new List<Tab_OrderDetail>();
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
		string strSql = " select * from Tab_OrderDetail";
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
