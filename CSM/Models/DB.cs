using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace CSM.Models
{
    public class DB
    {
        private static string database = "DB";
        private SqlClient sqlHelper = new SqlClient(database);
        public string tableName { get; set; }
        private string sql = "";
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

        public virtual IEnumerable<T> all<T>() where T : class
        {
            //sql = "select * from " + tableName;
            return sqlHelper.QueryAll<T>(true);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagesize"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> QueryByPage<T>(int pagesize, int pagecount) where T : class
        {
            sql = string.Format("select * from " + tableName);
            return sqlHelper.QueryByPage<T>(sql, pagesize, pagecount);

        }
        /// <summary>
        /// 根据主键条件查询单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> find<T>(string key) where T : class
        {
            sql = string.Format("select * from " + tableName + "where GUID = @guid", key);
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
        public int? count<T>(string where) where T : class
        {
            sql = "select count(*) from " + tableName + "where " + where;
            return sqlHelper.QueryScalar<int>(sql);
        }
        /// <summary>
        /// 增加一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual dynamic add<T>(T entity) where T : class
        {

            return sqlHelper.Add<T>(entity);

            //sql = "select * from " + tableName + "where " + where;
            //return sqlHelper.Query<T>(sql);
        }
        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool update<T>(T whereEntity) where T : class
        {
            return sqlHelper.Update<T>(whereEntity);

        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool delete<T>(T whereEntity) where T : class
        {

            return sqlHelper.Delete<T>(whereEntity);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereEntity"></param>
        public void deleteList<T>(Func<T, bool> whereEntity) where T : class
        {

            var list = sqlHelper.QueryAll<T>().Where(whereEntity);

            using (var tran = new Transaction(database))
            {
                foreach (var l in list)
                {
                    sqlHelper.Delete<T>(l);
                }
                tran.Complete();
            }
            //whereEntity();
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


            // deleteList<TestEntity>(i => i.Id == "1" && i.Id =="2" );
        }

        public bool deletest(TestEntity t)
        {
            List<TestEntity> LL = new List<TestEntity>();

            t = new TestEntity();
            t.Id = "2";
            t.Name = "2";
            t.Age = 12;
            LL.Add(t);
            return true;
        }

        public class TestEntity
        {
            [Key(KeyType.Assigned)]
            public string Id { get; set; }
            [Column("Name")]
            public string Name { get; set; }
            [Ignore]
            public int Age { get; set; }
        }

    }
}