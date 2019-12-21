using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Order2
    {
        public int income_code_ID { get; set; }

        public int? income_user_FK { get; set; }

        public int? income_guide_FK { get; set; }

        public DateTime? income_date { get; set; }

        public decimal? income_size { get; set; }

        public int income_guide_code_ID { get; set; }


        public string income_type { get; set; }
    }
}
