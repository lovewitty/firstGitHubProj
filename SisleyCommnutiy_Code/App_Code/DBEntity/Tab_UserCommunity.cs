using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserCommunity
	 {
         public System.Int32? Idx { get; set; }
         public System.String UserEmail { get; set; }
         public System.String Password { get; set; }
         public System.String HeadPhoto { get; set; }
         public System.String QqWeibo_Id { get; set; }
         public System.String KaixinWeibo_Id { get; set; }
         public System.String SinaWeibo_Id { get; set; }
         public System.Int32? UserlevelIdx_FxIdx { get; set; }
         public System.String VipCardNo { get; set; }
         public System.String VipBool { get; set; }
         public System.String V_SignBool { get; set; }
         public System.String SubscribeBool { get; set; }
         public System.String RegViladBool { get; set; }
         public System.String RealName { get; set; }
         public System.DateTime? Birthday { get; set; }
         public System.String MobilePhone { get; set; }
         public System.String Province { get; set; }
         public System.String City { get; set; }
         public System.String Address { get; set; }
         public System.String ZipCode { get; set; }
         public System.String LastLoginIp { get; set; }
         public System.DateTime? CreatedDate { get; set; }
         public System.DateTime? LastModificationDate { get; set; }
         public System.String RegViladCode { get; set; }
         public System.Decimal? AvailablePoints { get; set; }
         public System.Decimal? TotalPoints { get; set; }
         public System.Decimal? RedemptionPoints { get; set; }

         public static string GetCount_UserCommunity()
         {
             string strSql = "select count(1) from Tab_UserCommunity";
             return SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString();
         }

         public Tab_UserCommunity Get(int Idx) { return Get(Idx.ToString()); }

         public Tab_UserCommunity Get(string Idx)
         {
             DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_UserCommunity  where Idx=@Idx",
                     new SqlParameter("Idx", Idx)).Tables[0];
             if (dt.Rows.Count > 1)
             { throw new Exception("more than 1 row was found"); }

             if (dt.Rows.Count <= 0) { return null; }

             DataRow row = dt.Rows[0];
             Tab_UserCommunity model = ToModel(row);
             return model;
         }

         public Tab_UserCommunity GetByRegCode(string RegViladCode)
         {
             DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select top 1 * from Tab_UserCommunity  where RegViladCode=@RegViladCode",
                     new SqlParameter("RegViladCode", RegViladCode)).Tables[0];
             if (dt.Rows.Count > 1)
             { throw new Exception("more than 1 row was found"); }

             if (dt.Rows.Count <= 0) { return null; }

             DataRow row = dt.Rows[0];
             Tab_UserCommunity model = ToModel(row);
             return model;
         }

         /// <summary>
         /// 检测是否存在 Email
         /// </summary>
         /// <param name="UserEmail"></param>
         /// <returns></returns>
         public static int HasEmail(string UserEmail)
         {
             string strSql = "select count(1) from Tab_UserCommunity where UserEmail=@UserEmail";
             return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql, new SqlParameter("@UserEmail", UserEmail)));
         }

	 public int AddNew(Tab_UserCommunity model) 
 	 {
		string sql = "insert into Tab_UserCommunity(UserEmail,Password,HeadPhoto,QqWeibo_Id,KaixinWeibo_Id,SinaWeibo_Id,UserlevelIdx_FxIdx,VipCardNo,VipBool,V_SignBool,SubscribeBool,RegViladBool,RealName,Birthday,MobilePhone,Province,City,Address,ZipCode,LastLoginIp,CreatedDate,LastModificationDate,RegViladCode)  values(@UserEmail,@Password,@HeadPhoto,@QqWeibo_Id,@KaixinWeibo_Id,@SinaWeibo_Id,@UserlevelIdx_FxIdx,@VipCardNo,@VipBool,@V_SignBool,@SubscribeBool,@RegViladBool,@RealName,@Birthday,@MobilePhone,@Province,@City,@Address,@ZipCode,@LastLoginIp,@CreatedDate,@LastModificationDate,@RegViladCode); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserEmail", model.UserEmail)
			,new SqlParameter("@Password", model.Password)
			,new SqlParameter("@HeadPhoto", model.HeadPhoto)
			,new SqlParameter("@QqWeibo_Id", model.QqWeibo_Id)
			,new SqlParameter("@KaixinWeibo_Id", model.KaixinWeibo_Id)
			,new SqlParameter("@SinaWeibo_Id", model.SinaWeibo_Id)
			,new SqlParameter("@UserlevelIdx_FxIdx", model.UserlevelIdx_FxIdx)
			,new SqlParameter("@VipCardNo", model.VipCardNo)
			,new SqlParameter("@VipBool", model.VipBool)
			,new SqlParameter("@V_SignBool", model.V_SignBool)
			,new SqlParameter("@SubscribeBool", model.SubscribeBool)
			,new SqlParameter("@RegViladBool", model.RegViladBool)
			,new SqlParameter("@RealName", model.RealName)
			,new SqlParameter("@Birthday", model.Birthday)
			,new SqlParameter("@MobilePhone", model.MobilePhone)
			,new SqlParameter("@Province", model.Province)
			,new SqlParameter("@City", model.City)
			,new SqlParameter("@Address", model.Address)
			,new SqlParameter("@ZipCode", model.ZipCode)
			,new SqlParameter("@LastLoginIp", model.LastLoginIp)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			,new SqlParameter("@LastModificationDate", model.LastModificationDate)
			,new SqlParameter("@RegViladCode", model.RegViladCode)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserCommunity model) 
 	 {
		 string sql = "update Tab_UserCommunity set UserEmail=@UserEmail,Password=@Password,HeadPhoto=@HeadPhoto,QqWeibo_Id=@QqWeibo_Id,KaixinWeibo_Id=@KaixinWeibo_Id,SinaWeibo_Id=@SinaWeibo_Id,UserlevelIdx_FxIdx=@UserlevelIdx_FxIdx,VipCardNo=@VipCardNo,VipBool=@VipBool,V_SignBool=@V_SignBool,SubscribeBool=@SubscribeBool,RegViladBool=@RegViladBool,RealName=@RealName,Birthday=@Birthday,MobilePhone=@MobilePhone,Province=@Province,City=@City,Address=@Address,ZipCode=@ZipCode,LastLoginIp=@LastLoginIp,CreatedDate=@CreatedDate,LastModificationDate=@LastModificationDate,RegViladCode=@RegViladCode where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserEmail", model.UserEmail)
			 ,new SqlParameter("@Password", model.Password)
			 ,new SqlParameter("@HeadPhoto", model.HeadPhoto)
			 ,new SqlParameter("@QqWeibo_Id", model.QqWeibo_Id)
			 ,new SqlParameter("@KaixinWeibo_Id", model.KaixinWeibo_Id)
			 ,new SqlParameter("@SinaWeibo_Id", model.SinaWeibo_Id)
			 ,new SqlParameter("@UserlevelIdx_FxIdx", model.UserlevelIdx_FxIdx)
			 ,new SqlParameter("@VipCardNo", model.VipCardNo)
			 ,new SqlParameter("@VipBool", model.VipBool)
			 ,new SqlParameter("@V_SignBool", model.V_SignBool)
			 ,new SqlParameter("@SubscribeBool", model.SubscribeBool)
			 ,new SqlParameter("@RegViladBool", model.RegViladBool)
			 ,new SqlParameter("@RealName", model.RealName)
			 ,new SqlParameter("@Birthday", model.Birthday)
			 ,new SqlParameter("@MobilePhone", model.MobilePhone)
			 ,new SqlParameter("@Province", model.Province)
			 ,new SqlParameter("@City", model.City)
			 ,new SqlParameter("@Address", model.Address)
			 ,new SqlParameter("@ZipCode", model.ZipCode)
			 ,new SqlParameter("@LastLoginIp", model.LastLoginIp)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("@LastModificationDate", model.LastModificationDate)
			 ,new SqlParameter("@RegViladCode", model.RegViladCode)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserCommunity where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

     private static Tab_UserCommunity ToModel(DataRow row)
     {
         Tab_UserCommunity model = new Tab_UserCommunity();
         model.Idx = row.IsNull("Idx") ? null : (System.Int32?)row["Idx"];
         model.UserEmail = row.IsNull("UserEmail") ? null : (System.String)row["UserEmail"];
         model.Password = row.IsNull("Password") ? null : (System.String)row["Password"];
         model.HeadPhoto = row.IsNull("HeadPhoto") ? null : (System.String)row["HeadPhoto"];
         model.QqWeibo_Id = row.IsNull("QqWeibo_Id") ? null : (System.String)row["QqWeibo_Id"];
         model.KaixinWeibo_Id = row.IsNull("KaixinWeibo_Id") ? null : (System.String)row["KaixinWeibo_Id"];
         model.SinaWeibo_Id = row.IsNull("SinaWeibo_Id") ? null : (System.String)row["SinaWeibo_Id"];
         model.UserlevelIdx_FxIdx = row.IsNull("UserlevelIdx_FxIdx") ? null : (System.Int32?)row["UserlevelIdx_FxIdx"];
         model.VipCardNo = row.IsNull("VipCardNo") ? null : (System.String)row["VipCardNo"];
         model.VipBool = row.IsNull("VipBool") ? null : (System.String)row["VipBool"];
         model.V_SignBool = row.IsNull("V_SignBool") ? null : (System.String)row["V_SignBool"];
         model.SubscribeBool = row.IsNull("SubscribeBool") ? null : (System.String)row["SubscribeBool"];
         model.RegViladBool = row.IsNull("RegViladBool") ? null : (System.String)row["RegViladBool"];
         model.RealName = row.IsNull("RealName") ? null : (System.String)row["RealName"];
         model.Birthday = row.IsNull("Birthday") ? null : (System.DateTime?)row["Birthday"];
         model.MobilePhone = row.IsNull("MobilePhone") ? null : (System.String)row["MobilePhone"];
         model.Province = row.IsNull("Province") ? null : (System.String)row["Province"];
         model.City = row.IsNull("City") ? null : (System.String)row["City"];
         model.Address = row.IsNull("Address") ? null : (System.String)row["Address"];
         model.ZipCode = row.IsNull("ZipCode") ? null : (System.String)row["ZipCode"];
         model.LastLoginIp = row.IsNull("LastLoginIp") ? null : (System.String)row["LastLoginIp"];
         model.CreatedDate = row.IsNull("CreatedDate") ? null : (System.DateTime?)row["CreatedDate"];
         model.LastModificationDate = row.IsNull("LastModificationDate") ? null : (System.DateTime?)row["LastModificationDate"];
         model.RegViladCode = row.IsNull("RegViladCode") ? null : (System.String)row["RegViladCode"];
         model.AvailablePoints = row.IsNull("AvailablePoints") ? null : (System.Decimal?)row["AvailablePoints"];
         model.TotalPoints = row.IsNull("TotalPoints") ? null : (System.Decimal?)row["TotalPoints"];
         model.RedemptionPoints = row.IsNull("RedemptionPoints") ? null : (System.Decimal?)row["RedemptionPoints"];
         return model;
     }

   

    /// <summary>
    /// 根据用户名获取用户的实例
    /// </summary>
    /// <param name="UserEmail"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public static Tab_UserCommunity Get(string UserEmail, string Password)
    {
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_UserCommunity  where UserEmail=@UserEmail and Password=@Password",
                new SqlParameter("UserEmail", UserEmail), new SqlParameter("Password", Password)).Tables[0];
        if (dt.Rows.Count > 1)
        { throw new Exception("more than 1 row was found"); }

        if (dt.Rows.Count <= 0) { return null; }

        DataRow row = dt.Rows[0];
        Tab_UserCommunity model = ToModel(row);
        return model;
    }

    public static Tab_UserCommunity GetBySinaId(string SinaWeibo_Id)
    {
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_UserCommunity  where SinaWeibo_Id=@SinaWeibo_Id",
                new SqlParameter("SinaWeibo_Id", SinaWeibo_Id)).Tables[0];

       
        if (dt.Rows.Count > 1)
        {
            Cmn.Log.Write("SinaWeibo_Id=" + SinaWeibo_Id);
            throw new Exception("more than 1 row was found"); }

        if (dt.Rows.Count <= 0) { return null; }

        DataRow row = dt.Rows[0];
        Tab_UserCommunity model = ToModel(row);
        return model;
    }

    public static int GetByEmail(string UserEmail)
    {
        int iResult = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, "select count(1) from Tab_UserCommunity  where UserEmail=@UserEmail",
                  new SqlParameter("UserEmail", UserEmail)));
        return iResult;
    }

	public IEnumerable<Tab_UserCommunity> ListAll()
	{
		List<Tab_UserCommunity> list = new List<Tab_UserCommunity>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserCommunity").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserCommunity> ListAll(string strSql)
	{
		List<Tab_UserCommunity> list = new List<Tab_UserCommunity>();
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
		string strSql = " select * from Tab_UserCommunity";
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
