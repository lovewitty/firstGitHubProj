using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
    public partial class Tab_Y_Article
    {
        public System.Int32? Idx { get; set; }
        public System.String Title { get; set; }
        public System.String Content { get; set; }
        public System.Int32? UserId { get; set; }
        public System.DateTime? CreateDate { get; set; }
        public System.Boolean? Aduit { get; set; }
        public System.Int32? BoardIdx { get; set; }
        public System.Int32? ProductIdx { get; set; }
        public System.Int32? ProductTypeIdx { get; set; }

        public int AddNew(Tab_Y_Article model)
        {
            string sql = "insert into Tab_Y_Article(Title,Content,UserId,CreateDate,Aduit,BoardIdx,ProductIdx,ProductTypeIdx)  values(@Title,@Content,@UserId,@CreateDate,@Aduit,@BoardIdx,@ProductIdx,@ProductTypeIdx); select @@identity ;";
            int Idx = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, sql
               , new SqlParameter("@Title", model.Title)
               , new SqlParameter("@Content", model.Content)
               , new SqlParameter("@UserId", model.UserId)
               , new SqlParameter("@CreateDate", model.CreateDate)
               , new SqlParameter("@Aduit", model.Aduit)
               , new SqlParameter("@BoardIdx", model.BoardIdx)
               , new SqlParameter("@ProductIdx", model.ProductIdx)
               , new SqlParameter("@ProductTypeIdx", model.ProductTypeIdx)
                ));
            return Idx;
        }

        public bool Update(Tab_Y_Article model)
        {
            string sql = "update Tab_Y_Article set Title=@Title,Content=@Content,UserId=@UserId,CreateDate=@CreateDate,Aduit=@Aduit,BoardIdx=@BoardIdx,ProductIdx=@ProductIdx,ProductTypeIdx=@ProductTypeIdx where Idx=@Idx";
            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
                , new SqlParameter("@Title", model.Title)
                , new SqlParameter("@Content", model.Content)
                , new SqlParameter("@UserId", model.UserId)
                , new SqlParameter("@CreateDate", model.CreateDate)
                , new SqlParameter("@Aduit", model.Aduit)
                , new SqlParameter("@BoardIdx", model.BoardIdx)
                , new SqlParameter("@ProductIdx", model.ProductIdx)
                , new SqlParameter("@ProductTypeIdx", model.ProductTypeIdx)
                , new SqlParameter("Idx", model.Idx)
                );
            return rows > 0;
        }

        public bool Delete(string Idx)
        {
            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, " delete from Tab_Y_Article where Idx=@Idx",
                 new SqlParameter("Idx", Idx));
            return rows > 0;
        }

        private static Tab_Y_Article ToModel(DataRow row)
        {
            Tab_Y_Article model = new Tab_Y_Article();
            model.Idx = row.IsNull("Idx") ? null : (System.Int32?)row["Idx"];
            model.Title = row.IsNull("Title") ? null : (System.String)row["Title"];
            model.Content = row.IsNull("Content") ? null : (System.String)row["Content"];
            model.UserId = row.IsNull("UserId") ? null : (System.Int32?)row["UserId"];
            model.CreateDate = row.IsNull("CreateDate") ? null : (System.DateTime?)row["CreateDate"];
            model.Aduit = row.IsNull("Aduit") ? null : (System.Boolean?)row["Aduit"];
            model.BoardIdx = row.IsNull("BoardIdx") ? null : (System.Int32?)row["BoardIdx"];
            model.ProductIdx = row.IsNull("ProductIdx") ? null : (System.Int32?)row["ProductIdx"];
            model.ProductTypeIdx = row.IsNull("ProductTypeIdx") ? null : (System.Int32?)row["ProductTypeIdx"];
            return model;
        }

        public Tab_Y_Article Get(string Idx)
        {
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Y_Article  where Idx=@Idx",
                    new SqlParameter("Idx", Idx)).Tables[0];
            if (dt.Rows.Count > 1)
            { throw new Exception("more than 1 row was found"); }

            if (dt.Rows.Count <= 0) { return null; }

            DataRow row = dt.Rows[0];
            Tab_Y_Article model = ToModel(row);
            return model;
        }

        public IEnumerable<Tab_Y_Article> ListAll()
        {
            List<Tab_Y_Article> list = new List<Tab_Y_Article>();
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, "select * from Tab_Y_Article").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }

        public IEnumerable<Tab_Y_Article> ListAll(string strSql)
        {
            List<Tab_Y_Article> list = new List<Tab_Y_Article>();
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
            string strSql = " select * from Tab_Y_Article";
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
