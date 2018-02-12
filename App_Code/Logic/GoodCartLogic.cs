using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using SuperMarket.Model;
using SuperMarket.Utility;

namespace SuperMarket.Logic
{
    /// <summary>
    /// GoodCartLogic 的摘要说明:关于商品销售购物车的业务处理类
    /// </summary>
    public class GoodCartLogic
    {
        private string errMessage;  /*保存业务处理的逻辑错误信息*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*根据员工编号查询该员工的商品销售购物车信息并返回结果集*/
        public static DataSet QueryGoodCartInfo(string employeeNo)
        {
            string sqlString = "select * from [goodCartInfo] where employeeNo='" + employeeNo + "'";
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        /*根据商品购物车记录编号和要修改的销售数目执行更新操作*/
        public bool UpdateGoodCartInfo(int goodCartId, int goodCount)
        {
            /*根据商品购物车记录编号得到该对应的商品编号*/
            string sqlString = "select goodNo from [goodCartInfo] where goodCartId=" + goodCartId;
            string goodNo = DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).ToString();
            /*取得该商品剩下的总的库存*/
            sqlString = "select goodCount from [goodStockInfo] where goodNo='" + goodNo + "'";
            int leftGoodCount = Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null));
            /*取得购物车信息中原来的数目*/
            sqlString = "select goodCount from [goodCartInfo] where goodCartId=" + goodCartId;
            int oldGoodCount = Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null));
            /*下面进行商品库存数量的购买,如果库存不足需要设置逻辑错误信息*/
            leftGoodCount = leftGoodCount + oldGoodCount - goodCount;
            if (leftGoodCount < 0)
            {
                this.errMessage = "商品库存不足,请确认销售数目!";
                return false;
            }
            /*更新购物车信息表*/
            sqlString = "update [goodCartInfo] set goodCount=" + goodCount + " where goodCartId=" + goodCartId;
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "修改商品购物车信息时发生了错误!";
                return false;
            }
            /*更新该商品的剩余库存信息*/
            sqlString = "update [goodStockInfo] set goodCount=" + leftGoodCount + " where goodNo='" + goodNo + "'";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "更新商品剩余库存信息时发生了错误!";
                return false;
            }
            return true;
        }
        /*根据商品销售购物车编号实现该记录的删除操作*/
        public bool DeleteGoodCartInfo(int goodCartId)
        {
            /*根据商品购物车记录编号得到该对应的商品编号*/
            string sqlString = "select goodNo from [goodCartInfo] where goodCartId=" + goodCartId;
            string goodNo = DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).ToString();
            /*取得购物车信息中商品的数目*/
            sqlString = "select goodCount from [goodCartInfo] where goodCartId=" + goodCartId;
            int goodCount = Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null));
            /*执行购物车中该记录的删除操作*/
            sqlString = "delete from [goodCartInfo] where goodCartId=" + goodCartId;
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "删除商品销售购物车信息时发生了错误!";
                return false;
            }
            /*更新商品的库存信息*/
            sqlString = "update [goodStockInfo] set goodCount=goodCount+" + goodCount + " where goodNo='" + goodNo + "'";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "修改商品库存时发生了错误!";
                return false;
            }
            return true;
        }
        /*传入商品销售购物车信息模型对象，将商品销售信息加入到系统中*/
        public bool AddGoodCartInfo(GoodCartInfoModel goodCartInfoModel)
        {
            /*进行相关的验证*/
            if (goodCartInfoModel.GoodNo == "")
            {
                this.errMessage = "请输入商品编号信息！";
                return false;
            }
            string sqlString = "select * from [goodInfo] where goodNo='" + goodCartInfoModel.GoodNo + "'";
            if (!DBOperation.ExecuteReader(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).Read())
            {
                this.errMessage = "你输入的商品编号信息不存在!";
                return false;
            }
            /*验证商品的库存是否够卖*/
            sqlString = "select goodCount from [goodStockInfo] where goodNo='" + goodCartInfoModel.GoodNo + "'";
            int goodCount = Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null));
            if (goodCartInfoModel.GoodCount > goodCount)
            {
                this.errMessage = "你输入的商品销售数目超出了系统库存";
                return false;
            }
            /*将商品销售信息加入到购物车信息表中*/
            sqlString = "insert into [goodCartInfo] (employeeNo,goodNo,goodCount) values ('";
            sqlString += goodCartInfoModel.EmployeeNo + "','";
            sqlString += goodCartInfoModel.GoodNo + "',";
            sqlString += goodCartInfoModel.GoodCount + ")";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "将商品销售信息加入到购物车信息表时发生了错误！";
                return false;
            }
            sqlString = "update [goodStockInfo] set goodCount = goodCount -" + goodCartInfoModel.GoodCount + " where goodNo='" + goodCartInfoModel.GoodNo + "'";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "添加商品销售信息修改商品库存失败！";
                return false;
            }
            return true;
        }
        /*根据员工编号得到购物车中总的商品数量*/
        public static int GetTotalGoodCountInCart(string employeeNo)
        {
            string sqlString = "select sum(goodCount) as totalGoodCount from [goodCartInfo] where employeeNo='" + employeeNo + "'";
            return Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null));
        }
        /*根据员工编号得到购物车中商品的总价格*/
        public static float GetTotalPriceInCart(string employeeNo)
        {
            float totalPrice = 0.0f;
            /*查询该员工的购物车*/
            string sqlString = "select * from [goodCartInfo] where employeeNo='" + employeeNo + "'";
            DataSet cartInfoDs = DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
            /*遍历购物车中每条商品销售记录并计算总的价格*/
            for (int i = 0; i < cartInfoDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = cartInfoDs.Tables[0].Rows[i];
                float price = Convert.ToSingle(dr["goodPrice"]);
                int number = Convert.ToInt32(dr["goodCount"]);
                totalPrice += (price * number);
            }
            return totalPrice;
        }
        /*根据传递过来的销售小票号和员工编号实现对应购物车中商品销售信息的登记,然后清空购物车*/
        public static bool AddGoodSellInfoInCart(string sellNo, string employeeNo)
        {
            bool isSuccessful = true;
            /*查询该员工的商品销售购物车中信息*/
            string sqlString = "select * from [goodCartInfo] where employeeNo='" + employeeNo + "'";
            DataSet goodCartInfoDs = DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
            /*将每条商品销售信息登记入商品销售信息表*/
            for (int i = 0; i < goodCartInfoDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = goodCartInfoDs.Tables[0].Rows[i];
                SellInfoModel sellInfoModel = new SellInfoModel();
                sellInfoModel.SellNo = sellNo;
                sellInfoModel.GoodNo = dr["goodNo"].ToString();
                sellInfoModel.Price = Convert.ToSingle(dr["goodPrice"]);
                sellInfoModel.Number = Convert.ToInt32(dr["goodCount"]);
                sellInfoModel.TotalPrice = sellInfoModel.Price * sellInfoModel.Number;
                sellInfoModel.SellTime = DateTime.Now;
                sellInfoModel.EmployeeNo = employeeNo;
                if (!SellLogic.AddSellInfo(sellInfoModel))
                    isSuccessful = false;
            }
            /*然后清空该员工的商品购物车*/
            sqlString = "delete from [goodCartInfo] where employeeNo='" + employeeNo + "'";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
                isSuccessful = false;
            return isSuccessful;
        }
        public GoodCartLogic()
        {
            this.errMessage = "";
        }
    }
}

