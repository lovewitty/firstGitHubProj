using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
    public partial class Tab_xw_FlashItem
    {
        public System.Int32? Idx { get; set; }
        public System.String aTitle { get; set; }
        public System.String aLink { get; set; }
        public System.String aImg { get; set; }
        public System.String aTypeName { get; set; }
        public System.DateTime? aCreatedate { get; set; }
        public System.Int32? aOrderNumb { get; set; }

        public int AddNew(Tab_xw_FlashItem model)
        {
            string sql = "insert into Tab_xw_FlashItem(aTitle,aLink,aImg,aTypeName,aCreatedate,aOrderNumb)  values(@aTitle,@aLink,@aImg,@aTypeName,@aCreatedate,@aOrderNumb); select @@identity ;";
            int Idx = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, sql
               , new SqlParameter("@aTitle", model.aTitle)
               , new SqlParameter("@aLink", model.aLink)
               , new SqlParameter("@aImg", model.aImg)
               , new SqlParameter("@aTypeName", model.aTypeName)
               , new SqlParameter("@aCreatedate", model.aCreatedate)
               , new SqlParameter("@aOrderNumb", model.aOrderNumb)
                ));
            return Idx;
        }

        public bool Update(Tab_xw_FlashItem model)
        {
            string sql = "update Tab_xw_FlashItem set aTitle=@aTitle,aLink=@aLink,aImg=@aImg,aTypeName=@aTypeName,aCreatedate=@aCreatedate,aOrderNumb=@aOrderNumb where Idx=@Idx";
            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
                , new SqlParameter("@aTitle", model.aTitle)
                , new SqlParameter("@aLink", model.aLink)
                , new SqlParameter("@aImg", model.aImg)
                , new SqlParameter("@aTypeName", model.aTypeName)
                , new SqlParameter("@aCreatedate", model.aCreatedate)
                , new SqlParameter("@aOrderNumb", model.aOrderNumb)
                , new SqlParameter("Idx", model.Idx)
                );
            return rows > 0;
        }

        public bool Delete(string Idx)
        {
            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, " delete from Tab_xw_FlashItem where Idx=@Idx",
                 new SqlParameter("Idx", Idx));
            return rows > 0;
        }

        private static Tab_xw_FlashItem ToModel(DataRow row)
        {
            Tab_xw_FlashItem model = new Tab_xw_FlashItem();
            model.Idx = row.IsNull("Idx") ? null : (System.Int32?)row["Idx"];
            model.aTitle = row.IsNull("aTitle") ? null : (System.String)row["aTitle"];
            model.aLink = row.IsNull("aLink") ? null : (System.String)row["aLink"];
            model.aImg = row.IsNull("aImg") ? null : (System.String)row["aImg"];
            model.aTypeName = row.IsNull("aTypeName") ? null : (System.String)row["aTypeName"];
            model.aCreatedate = row.IsNull("aCreatedate") ? null : (System.DateTime?)row["aCreatedate"];
            model.aOrderNumb = row.IsNull("aOrderNumb") ? null : (System.Int32?)row["aOrderNumb"];
            return model;
        }

        public Tab_xw_FlashItem Get(string Idx)
        {
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_xw_FlashItem  where Idx=@Idx",
                    new SqlParameter("Idx", Idx)).Tables[0];
            if (dt.Rows.Count > 1)
            { throw new Exception("more than 1 row was found"); }

            if (dt.Rows.Count <= 0) { return null; }

            DataRow row = dt.Rows[0];
            Tab_xw_FlashItem model = ToModel(row);
            return model;
        }

        public IEnumerable<Tab_xw_FlashItem> ListAll()
        {
            List<Tab_xw_FlashItem> list = new List<Tab_xw_FlashItem>();
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_xw_FlashItem").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }

        public IEnumerable<Tab_xw_FlashItem> ListAll(string strSql)
        {
            List<Tab_xw_FlashItem> list = new List<Tab_xw_FlashItem>();
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }

        public static DataSet GetDs_Where(string beginDate, string endDate, string keywords)
        {
            List<SqlParameter> spsList = new List<SqlParameter>();
            string strSql = " select * from Tab_xw_FlashItem";
            string strWhere = " where 1=1 ";
            if (!String.IsNullOrEmpty(beginDate))
            {
                strWhere = strWhere + " and aCreatedate >= @beginDate";
                spsList.Add(new SqlParameter("@beginDate", beginDate));
            }
            if (!String.IsNullOrEmpty(endDate))
            {
                strWhere = strWhere + " and aCreatedate <= @endDate";
                spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
            }
            if (!String.IsNullOrEmpty(keywords))
            {
                keywords = keywords.Replace("'", "''");
                strWhere = strWhere + " and (aTitle like @keywords or aTypeName like @keywords)";
                spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }

            strSql = strSql + strWhere + " order by aTypeName,aOrderNumb,aTitle";
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
            return ds;
        }
    }
}
