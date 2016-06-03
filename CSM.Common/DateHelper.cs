using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSM.Common
{
    public class DateHelper
    {
        /// <summary>
        /// 已重载.计算两个日期的时间间隔,返回的是时间间隔的日期差的绝对值.
        /// </summary>
        /// <param name="DateTime1">第一个日期和时间</param>
        /// <param name="DateTime2">第二个日期和时间</param>
        /// <returns></returns>
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                if (ts.Days.ToString() != "0")
                {
                    dateDiff += ts.Days.ToString() + "天";
                }
                if (ts.Hours.ToString() != "0")
                {
                    dateDiff += ts.Hours.ToString() + "小时";
                }
                if (ts.Minutes.ToString() != "0")
                {
                    dateDiff += ts.Minutes.ToString() + "分钟";
                }
                if (ts.Seconds.ToString() != "0")
                {
                    dateDiff += ts.Seconds.ToString() + "秒";
                }

            }
            catch
            {

            }
            return dateDiff;
        }

    }
}
