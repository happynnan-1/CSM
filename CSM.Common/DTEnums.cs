using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;


namespace CSM.Common
{
    public class DTEnums
    {

        #region 订单支付状态
        /// <summary>
        /// 
        /// </summary>
        [Description("支付状态")]
        public enum PaymentStatus
        {
            [Description("未支付")]
            Unpaid = 1,

            [Description("已经支付")]
            Paid = 2,

            [Description("部分支付")]
            PartPaid = 3
        }

        #endregion


        /// <summary>
        /// 统一管理操作枚举
        /// </summary>
        public enum ActionEnum
        {
            /// <summary>
            /// 所有
            /// </summary>
            All,
            /// <summary>
            /// 显示
            /// </summary>
            Show,
            /// <summary>
            /// 查看
            /// </summary>
            View,
            /// <summary>
            /// 添加
            /// </summary>
            Add,
            /// <summary>
            /// 添加并提交
            /// </summary>
            AddAndSubmit,
            /// <summary>
            /// 修改
            /// </summary>
            Edit,
            /// <summary>
            /// 修改并提交
            /// </summary>
            EditAndSubmit,
            /// <summary>
            /// 提交
            /// </summary>
            Submit,
            /// <summary>
            /// 删除
            /// </summary>
            Delete,
            /// <summary>
            /// 审核
            /// </summary>
            Audit,
            /// <summary>
            /// 回复
            /// </summary>
            Reply,
            /// <summary>
            /// 确认
            /// </summary>
            Confirm,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel,
            /// <summary>
            /// 作废
            /// </summary>
            Invalid,
            /// <summary>
            /// 生成
            /// </summary>
            Build,
            /// <summary>
            /// 安装
            /// </summary>
            Instal,
            /// <summary>
            /// 卸载
            /// </summary>
            UnLoad,
            /// <summary>
            /// 登录
            /// </summary>
            Login,
            /// <summary>
            /// 备份
            /// </summary>
            Back,
            /// <summary>
            /// 还原
            /// </summary>
            Restore,
            /// <summary>
            /// 替换
            /// </summary>
            Replace,
            /// <summary>
            /// 复制
            /// </summary>
            Copy
        }

        /// <summary>
        /// 系统导航菜单类别枚举
        /// </summary>
        public enum NavigationEnum
        {
            /// <summary>
            /// 系统后台菜单
            /// </summary>
            System,
            /// <summary>
            /// 会员中心导航
            /// </summary>
            Users,
            /// <summary>
            /// 网站主导航
            /// </summary>
            WebSite
        }

        /// <summary>
        /// 用户生成码枚举
        /// </summary>
        public enum CodeEnum
        {
            /// <summary>
            /// 注册验证
            /// </summary>
            RegVerify,
            /// <summary>
            /// 邀请注册
            /// </summary>
            Register,
            /// <summary>
            /// 取回密码
            /// </summary>
            Password
        }

        /// <summary>
        /// 金额类型枚举
        /// </summary>
        public enum AmountTypeEnum
        {
            /// <summary>
            /// 系统赠送
            /// </summary>
            SysGive,
            /// <summary>
            /// 在线充值
            /// </summary>
            Recharge,
            /// <summary>
            /// 用户消费
            /// </summary>
            Consumption,
            /// <summary>
            /// 购买商品
            /// </summary>
            BuyGoods,
            /// <summary>
            /// 积分兑换
            /// </summary>
            Convert
        }

        /// <summary>
        /// 付款状态
        /// </summary>
        public enum payment_item
        {
            /// <summary>
            /// 未支付
            /// </summary>
            None = 1,
            /// <summary>
            /// 全部支付
            /// </summary>
            All = 2,
            /// <summary>
            /// 部分付款
            /// </summary>
            Part = 3

        }
        /// <summary>
        /// 缴费项目
        /// </summary>
        public enum property_item
        {
            /// <summary>
            /// 房租
            /// </summary>
            Rent = 1,
            /// <summary>
            /// 物业
            /// </summary>
            Pro = 2,

            /// <summary>
            /// 水
            /// </summary>
            Water = 3,
            /// <summary>
            /// 电
            /// </summary>
            Eletricity = 4,

            /// <summary>
            /// 煤气
            /// </summary>
            Gas = 5,
            /// <summary>
            /// 其他
            /// </summary>
            Other = 6

        }

        /// <summary>
        /// 缴费周期
        /// </summary>
        public enum payment_cycle
        {
            /// <summary>
            /// 月付
            /// </summary>
            One = 1,
            /// <summary>
            /// 季度付款
            /// </summary>
            Quarter = 3,
            /// <summary>
            /// 半年
            /// </summary>
            HalfYear = 6,
            /// <summary>
            /// 1年
            /// </summary>
            Year = 12,
            /// <summary>
            /// 其他
            /// </summary>
            Other = 0

        }

        /// <summary>
        /// 房租贷审核状态
        /// </summary>
        public enum audit_status
        {
            /// <summary>
            /// 待审核
            /// </summary>
            Apply = 1,

            /// <summary>
            /// 审核通过
            /// </summary>
            AuditPass = 2,

            /// <summary>
            /// 审核不通过
            /// </summary>
            AuditNotPass = 3,

            /// <summary>
            /// 发放
            /// </summary>
            Provide = 4,

            /// <summary>
            /// 收款
            /// </summary>
            Gathering = 5
        }

        public enum NoticeStatus
        {
            未发布 = 0,
            待审核 = 1,
            已发布 = 2,
            未通过 = 3,
            已删除 = 4
        }

    }
}
