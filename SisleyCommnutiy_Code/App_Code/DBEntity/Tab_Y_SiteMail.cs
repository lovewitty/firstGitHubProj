using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Y_SiteMail
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String Sender { get; set; }
		 public System.Int32? SenderIdx { get; set; }
		 public System.Int32? RecverIdx { get; set; }
		 public System.String RecverLoginName { get; set; }
		 public System.Boolean? IsSysMail { get; set; }
		 public System.String MailSubject { get; set; }
		 public System.String MailContent { get; set; }
		 public System.Boolean? IsOpened { get; set; }
		 public System.DateTime? CreateDate { get; set; }
		 public System.DateTime? FirstReadData { get; set; }

	 public int AddNew(Tab_Y_SiteMail model) 
 	 {
		string sql = "insert into Tab_Y_SiteMail(Sender,SenderIdx,RecverIdx,RecverLoginName,IsSysMail,MailSubject,MailContent,IsOpened,CreateDate,FirstReadData)  values(@Sender,@SenderIdx,@RecverIdx,@RecverLoginName,@IsSysMail,@MailSubject,@MailContent,@IsOpened,@CreateDate,@FirstReadData); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@Sender", model.Sender)
			,new SqlParameter("@SenderIdx", model.SenderIdx)
			,new SqlParameter("@RecverIdx", model.RecverIdx)
			,new SqlParameter("@RecverLoginName", model.RecverLoginName)
			,new SqlParameter("@IsSysMail", model.IsSysMail)
			,new SqlParameter("@MailSubject", model.MailSubject)
			,new SqlParameter("@MailContent", model.MailContent)
			,new SqlParameter("@IsOpened", model.IsOpened)
			,new SqlParameter("@CreateDate", model.CreateDate)
			,new SqlParameter("@FirstReadData", model.FirstReadData)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Y_SiteMail model) 
 	 {
		 string sql = "update Tab_Y_SiteMail set Sender=@Sender,SenderIdx=@SenderIdx,RecverIdx=@RecverIdx,RecverLoginName=@RecverLoginName,IsSysMail=@IsSysMail,MailSubject=@MailSubject,MailContent=@MailContent,IsOpened=@IsOpened,CreateDate=@CreateDate,FirstReadData=@FirstReadData where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@Sender", model.Sender)
			 ,new SqlParameter("@SenderIdx", model.SenderIdx)
			 ,new SqlParameter("@RecverIdx", model.RecverIdx)
			 ,new SqlParameter("@RecverLoginName", model.RecverLoginName)
			 ,new SqlParameter("@IsSysMail", model.IsSysMail)
			 ,new SqlParameter("@MailSubject", model.MailSubject)
			 ,new SqlParameter("@MailContent", model.MailContent)
			 ,new SqlParameter("@IsOpened", model.IsOpened)
			 ,new SqlParameter("@CreateDate", model.CreateDate)
			 ,new SqlParameter("@FirstReadData", model.FirstReadData)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Y_SiteMail where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Y_SiteMail ToModel(DataRow row)
	{
		Tab_Y_SiteMail model = new Tab_Y_SiteMail();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.Sender = row.IsNull("Sender")?null:(System.String)row["Sender"];
		model.SenderIdx = row.IsNull("SenderIdx")?null:(System.Int32?)row["SenderIdx"];
		model.RecverIdx = row.IsNull("RecverIdx")?null:(System.Int32?)row["RecverIdx"];
		model.RecverLoginName = row.IsNull("RecverLoginName")?null:(System.String)row["RecverLoginName"];
		model.IsSysMail = row.IsNull("IsSysMail")?null:(System.Boolean?)row["IsSysMail"];
		model.MailSubject = row.IsNull("MailSubject")?null:(System.String)row["MailSubject"];
		model.MailContent = row.IsNull("MailContent")?null:(System.String)row["MailContent"];
		model.IsOpened = row.IsNull("IsOpened")?null:(System.Boolean?)row["IsOpened"];
		model.CreateDate = row.IsNull("CreateDate")?null:(System.DateTime?)row["CreateDate"];
		model.FirstReadData = row.IsNull("FirstReadData")?null:(System.DateTime?)row["FirstReadData"];
		return model;
	}

	public Tab_Y_SiteMail Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Y_SiteMail  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Y_SiteMail model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Y_SiteMail> ListAll()
	{
		List<Tab_Y_SiteMail> list = new List<Tab_Y_SiteMail>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Y_SiteMail").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Y_SiteMail> ListAll(string strSql)
	{
		List<Tab_Y_SiteMail> list = new List<Tab_Y_SiteMail>();
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
		string strSql = " select * from Tab_Y_SiteMail";
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
