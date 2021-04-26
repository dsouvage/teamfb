using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teamfb.Models
{
    public class DashboardModel
    {
        string type = "bar";

        public Data data = new Data();

        string options = null;

        public class Data
        {
            public string[] labels = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            public datasetsmodel datasets = new datasetsmodel();

            public class datasetsmodel
            {
                public string label = "Quantity of sales per month";
                public int[] data { get; set; }
                public string backgroundColor = null;
                public string borderColor = null;
            }
        }
    }
}