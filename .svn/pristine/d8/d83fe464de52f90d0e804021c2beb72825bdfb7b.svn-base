using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace CSM.Models
{
    public class DB
    {
        private SqlClient sqlHelper = new SqlClient("DB");
        public string tableName { get; set; }
        private string sql="";
        public string primarykey { get; set; }
        private DB(string vtableName)
        {
            tableName = vtableName;
        }
        /// <summary>
        /// 查询所有的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> all<T>(string where?=null) where T : class
        {
            sql = "select * from " + tableName + "where " + where;
            return sqlHelper.Query<T>(sql);
        }
        /// <summary>
        /// 根据主键条件查询单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> find<T>(string key) where T : class
        {
            sql = "select * from " + tableName + "key " + where;
            return sqlHelper.Query<T>(sql);
        }
        /// <summary>
        /// 根据where条件查询实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> where<T>(string where) where T : class
        {
            sql = "select * from " + tableName + "where " + where;
            return sqlHelper.Query<T>(sql);
        }
        /// <summary>
        /// 根据条件查询统计数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T>count<T>(string where) where T : class
        {
            sql = "select * from " + tableName + "where " + where;
            return sqlHelper.Query<T>(sql);
        }
        /// <summary>
        /// 增加一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> add<T>(string where) where T : class
        {
            sql = "select * from " + tableName + "where " + where;
            return sqlHelper.Query<T>(sql);
        }
        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> update<T>(string where) where T : class
        {
            sql = "select * from " + tableName + "where " + where;
            return sqlHelper.Query<T>(sql);
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> delete<T>(string where) where T : class
        {
            sql = "select * from " + tableName + "where " + where;
            return sqlHelper.Query<T>(sql);
        }
        /// <summary>
        /// 执行一段语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> exesql<T>(string where) where T : class
        {
            sql = "select * from " + tableName + "where " + where;
            return sqlHelper.Query<T>(sql);
        }


    }
}