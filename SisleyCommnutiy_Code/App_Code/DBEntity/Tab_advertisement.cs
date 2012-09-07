using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Advertisement
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String AdPostion { get; set; }
		 public System.String AdImg { get; set; }
		 public System.String Links { get; set; }
		 public System.Object AdDescription { get; set; }
		 public System.DateTime? DateCreated { get; set; }
		 public System.Int32? OrderNumb { get; set; }

	 public int AddNew(Tab_Advertisement model) 
 	 {
		string sql = "insert into Tab_Advertisement(AdPostion,AdImg,Links,AdDescription,OrderNumb)  values(@AdPostion,@AdImg,@Links,@AdDescription,@OrderNumb); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@AdPostion", model.AdPostion)
			,new SqlParameter("@AdImg", model.AdImg)
			,new SqlParameter("@Links", model.Links)
			,new SqlParameter("@AdDescription", model.AdDescription)

			,new SqlParameter("@OrderNumb", model.OrderNumb)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Advertisement model) 
 	 {
		 string sql = "update Tab_Advertisement set AdPostion=@AdPostion,AdImg=@AdImg,Links=@Links,AdDescription=@AdDescription,DateCreated=@DateCreated,OrderNumb=@OrderNumb where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@AdPostion", model.AdPostion)
			 ,new SqlParameter("@AdImg", model.AdImg)
			 ,new SqlParameter("@Links", model.Links)
			 ,new SqlParameter("@AdDescription", model.AdDescription)
			 ,new SqlParameter("@DateCreated", model.DateCreated)
			 ,new SqlParameter("@OrderNumb", model.OrderNumb)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Advertisement where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Advertisement ToModel(DataRow row)
	{
		Tab_Advertisement model = new Tab_Advertisement();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.AdPostion = row.IsNull("AdPostion")?null:(System.String)row["AdPostion"];
		model.AdImg = row.IsNull("AdImg")?null:(System.String)row["AdImg"];
		model.Links = row.IsNull("Links")?null:(System.String)row["Links"];
		model.AdDescription = row.IsNull("AdDescription")?null:(System.Object)row["AdDescription"];
        model.DateCreated = row.IsNull("DateCreated") ? null : (System.DateTime?)row["DateCreated"];
		model.OrderNumb = row.IsNull("OrderNumb")?null:(System.Int32?)row["OrderNumb"];
		return model;
	}

    /// <summary>
    /// 根据 广告位 获取广告的实例
    /// </summary>
    /// <param name="AdPostion"></param>
    /// <returns></returns>
    public static Tab_Advertisement GetAdSingle(string AdPostion)
    {
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Advertisement  where AdPostion=@AdPostion",
                new SqlParameter("AdPostion", AdPostion)).Tables[0];
        if (dt.Rows.Count > 1)
        { throw new Exception("more than 1 row was found"); }

        if (dt.Rows.Count <= 0) { return null; }

        DataRow row = dt.Rows[0];
        Tab_Advertisement model = ToModel(row);
        return model;
    }

	public Tab_Advertisement Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Advertisement  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Advertisement model = ToModel(row);
		return model;
	}

    /// <summary>
    /// 根据广告位获取实体
    /// </summary>
    /// <param name="AdPostion"></param>
    /// <returns></returns>
    public Tab_Advertisement GetByPostionName(string AdPostion)
    {
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Advertisement  where AdPostion=@AdPostion",
                new SqlParameter("AdPostion", AdPostion)).Tables[0];
        if (dt.Rows.Count > 1)
        { throw new Exception("more than 1 row was found"); }

        if (dt.Rows.Count <= 0) { return null; }

        DataRow row = dt.Rows[0];
        Tab_Advertisement model = ToModel(row);
        return model;
    }

	public IEnumerable<Tab_Advertisement> ListAll()
	{
		List<Tab_Advertisement> list = new List<Tab_Advertisement>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Advertisement").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Advertisement> ListAll(string strSql)
	{
		List<Tab_Advertisement> list = new List<Tab_Advertisement>();
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
        string strSql = " select * from Tab_Advertisement";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and DateCreated >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and DateCreated <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (AdPostion like @keywords or AdDescription like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by AdPostion, OrderNumb";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
