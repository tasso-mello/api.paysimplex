using System;
using System.Collections.Generic;
using System.Text;

namespace domain.paysimplex.Models.Base
{
    public class BaseModel
    {
        public DateTime? InsertDate { get; set; }
        public long? UserInsert { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UserUpdate { get; set; }
    }
}
