using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
    public partial class Tab_Y_ProIndvalItem
    {
        public System.Int32? Idx { get; set; }
        public System.Int32? ProductTypeIdx { get; set; }
        public System.String IndvalItemName { get; set; }
        public System.String Descript { get; set; }
        public System.Int32? IndvalItemVlu { get; set; }

        public int AddNew(Tab_Y_ProIndvalItem model)
        {
            string sql = "insert into Tab_Y_ProIndvalItem(ProductTypeIdx,IndvalItemName,Descript,IndvalItemVlu)  values(@ProductTypeIdx,@IndvalItemName,@Descript,@IndvalItemVlu); select @@identity ;";
            int Idx = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, sql
               , new SqlParameter("@ProductTypeIdx", model.ProductTypeIdx)
               , new SqlParameter("@IndvalItemName", model.IndvalItemName)
               , new SqlParameter("@Descript", model.Descript)
               , new SqlParameter("@IndvalItemVlu", model.IndvalItemVlu)
                ));
            return Idx;
        }

        public bool Update(Tab_Y_ProIndvalItem model)
        {
            string sql = "update Tab_Y_ProIndvalItem set ProductTypeIdx=@ProductTypeIdx,IndvalItemName=@IndvalItemName,Descript=@Descript,IndvalItemVlu=@IndvalItemVlu where Idx=@Idx";
            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
                , new SqlParameter("@ProductTypeIdx", model.ProductTypeIdx)
                , new SqlParameter("@IndvalItemName", model.IndvalItemName)
                , new SqlParameter("@Descript", model.Descript)
                , new SqlParameter("@IndvalItemVlu", model.IndvalItemVlu)
                , new SqlParameter("Idx", model.Idx)
                );
            return rows > 0;
        }

        public bool Delete(string Idx)
        {
            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, " delete from Tab_Y_ProIndvalItem where Idx=@Idx",
                 new SqlParameter("Idx", Idx));
            return rows > 0;
        }

        private static Tab_Y_ProIndvalItem ToModel(DataRow row)
        {
            Tab_Y_ProIndvalItem model = new Tab_Y_ProIndvalItem();
            model.Idx = row.IsNull("Idx") ? null : (System.Int32?)row["Idx"];
            model.ProductTypeIdx = row.IsNull("ProductTypeIdx") ? null : (System.Int32?)row["ProductTypeIdx"];
            model.IndvalItemName = row.IsNull("IndvalItemName") ? null : (System.String)row["IndvalItemName"];
            model.Descript = row.IsNull("Descript") ? null : (System.String)row["Descript"];
            model.IndvalItemVlu = row.IsNull("IndvalItemVlu") ? null : (System.Int32?)row["IndvalItemVlu"];
            return model;
        }

        public Tab_Y_ProIndvalItem Get(string Idx)
        {
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Y_ProIndvalItem  where Idx=@Idx",
                    new SqlParameter("Idx", Idx)).Tables[0];
            if (dt.Rows.Count > 1)
            { throw new Exception("more than 1 row was found"); }

            if (dt.Rows.Count <= 0) { return null; }

            DataRow row = dt.Rows[0];
            Tab_Y_ProIndvalItem model = ToModel(row);
            return model;
        }

        public IEnumerable<Tab_Y_ProIndvalItem> ListAll()
        {
            List<Tab_Y_ProIndvalItem> list = new List<Tab_Y_ProIndvalItem>();
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Y_ProIndvalItem").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }

        public IEnumerable<Tab_Y_ProIndvalItem> ListAll(string strSql)
        {
            List<Tab_Y_ProIndvalItem> list = new List<Tab_Y_ProIndvalItem>();
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
            string strSql = " select * from Tab_Y_ProIndvalItem";
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
