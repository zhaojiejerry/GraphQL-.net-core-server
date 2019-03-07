using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo.Orders.Models
{
    public class OrderInput
    {
        //产品名称
        public int Id { get; set; }
        public string Name { get; set; }
        //客户名称
        public int UserId { get; set; }
        //创建时间
        public DateTime CreateDate { get; set; }
        //单价
        public double Price { get; set; }
        //数量
        public int Number { get; set; }
        //总价
        public double TotalAmount { get; set; }
        //枚举类型订单评分
        public OrderRating OrderRating { get; set; }
    }
}
