using System;
using System.Collections.Generic;

namespace BizCare.Model
{
    public class UserAccess
    {
        public Guid ID { get; set; }

        public Guid UserId { get; set; }

        public string FullName { get; set; }

        public int ObjectType { get; set; }

        public string ObjectName { get; set; }

        public bool IsOpen { get; set; }

        public bool IsAdd { get; set; }

        public bool IsEdit { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
