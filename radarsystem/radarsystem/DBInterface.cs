using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace radarsystem
{
    /// <summary>
    /// 封装Access数据连接，增，删，改，查的操作
    /// </summary>
    public class DBInterface
    {
        //获得数据库连接
        public OleDbConnection getConn(string constr)
        {
            return new OleDbConnection(constr);
        }


        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="constr">数据库连接语句</param>
        /// <param name="sql">sql查询语句</param>
        /// <param name="tableDesp">查询得到的结果表的描述</param>
        /// <returns>查询结果</returns>
        public DataSet query(string constr, string sql, string tableDesp)
        {
            DataSet ds = new DataSet();
            OleDbConnection con = getConn(constr);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
            dataAdapter.Fill(ds, tableDesp);
            if (con.State == ConnectionState.Open) con.Close();
            return ds;
        }

        public bool dbInsertUpdateDelete(string constr, string sql)
        {
            try
            {
                OleDbConnection con = getConn(constr);
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) con.Close();
                return true;
            }
            catch (Exception ex)
            {
             }
            return false;

        }

    }
}
