using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
    public partial class Tab_Order1Counter
    {
        public System.Int32? Idx { get; set; }
        public System.String CounterNo { get; set; }
        public System.String CounterName { get; set; }
        public System.String CounterCity { get; set; }
        public System.String CounterDistct { get; set; }
        public System.String CounterPhone { get; set; }
        public System.String CounterAddr { get; set; }

        public int AddNew(Tab_Order1Counter model)
        {
            string sql = "insert into Tab_Order1Counter(CounterNo,CounterName,CounterCity,CounterDistct,CounterPhone,CounterAddr)  values(@CounterNo,@CounterName,@CounterCity,@CounterDistct,@CounterPhone,@CounterAddr); select @@identity ;";
            int Idx = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, sql
               , new SqlParameter("@CounterNo", model.CounterNo)
               , new SqlParameter("@CounterName", model.CounterName)
               , new SqlParameter("@CounterCity", model.CounterCity)
               , new SqlParameter("@CounterDistct", model.CounterDistct)
               , new SqlParameter("@CounterPhone", model.CounterPhone)
               , new SqlParameter("@CounterAddr", model.CounterAddr)
                ));
            return Idx;
        }

        public bool Update(Tab_Order1Counter model)
        {
            string sql = "update Tab_Order1Counter set CounterNo=@CounterNo,CounterName=@CounterName,CounterCity=@CounterCity,CounterDistct=@CounterDistct,CounterPhone=@CounterPhone,CounterAddr=@CounterAddr where Idx=@Idx";
            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
                , new SqlParameter("@CounterNo", model.CounterNo)
                , new SqlParameter("@CounterName", model.CounterName)
                , new SqlParameter("@CounterCity", model.CounterCity)
                , new SqlParameter("@CounterDistct", model.CounterDistct)
                , new SqlParameter("@CounterPhone", model.CounterPhone)
                , new SqlParameter("@CounterAddr", model.CounterAddr)
                , new SqlParameter("Idx", model.Idx)
                );
            return rows > 0;
        }

        public bool Delete(string Idx)
        {
            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, " delete from Tab_Order1Counter where Idx=@Idx",
                 new SqlParameter("Idx", Idx));
            return rows > 0;
        }

        private static Tab_Order1Counter ToModel(DataRow row)
        {
            Tab_Order1Counter model = new Tab_Order1Counter();
            model.Idx = row.IsNull("Idx") ? null : (System.Int32?)row["Idx"];
            model.CounterNo = row.IsNull("CounterNo") ? null : (System.String)row["CounterNo"];
            model.CounterName = row.IsNull("CounterName") ? null : (System.String)row["CounterName"];
            model.CounterCity = row.IsNull("CounterCity") ? null : (System.String)row["CounterCity"];
            model.CounterDistct = row.IsNull("CounterDistct") ? null : (System.String)row["CounterDistct"];
            model.CounterPhone = row.IsNull("CounterPhone") ? null : (System.String)row["CounterPhone"];
            model.CounterAddr = row.IsNull("CounterAddr") ? null : (System.String)row["CounterAddr"];
            return model;
        }

        public Tab_Order1Counter Get(string Idx)
        {
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Order1Counter  where Idx=@Idx",
                    new SqlParameter("Idx", Idx)).Tables[0];
            if (dt.Rows.Count > 1)
            { throw new Exception("more than 1 row was found"); }

            if (dt.Rows.Count <= 0) { return null; }

            DataRow row = dt.Rows[0];
            Tab_Order1Counter model = ToModel(row);
            return model;
        }

        public IEnumerable<Tab_Order1Counter> ListAll()
        {
            List<Tab_Order1Counter> list = new List<Tab_Order1Counter>();
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Order1Counter").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }

        public IEnumerable<Tab_Order1Counter> ListAll(string strSql)
        {
            List<Tab_Order1Counter> list = new List<Tab_Order1Counter>();
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
            string strSql = " select * from Tab_Order1Counter";
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
