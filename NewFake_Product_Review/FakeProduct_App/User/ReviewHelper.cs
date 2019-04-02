using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeProduct_App.User
{
    public class ReviewHelper
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Review { get; set; }
        public DateTime? Date { get; set; }
        public int? Rating { get; set; }
        public double? Score { get; set; }
        public string Prediction { get; set; }




    }
}