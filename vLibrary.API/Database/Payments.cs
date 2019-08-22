using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Payments
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public DateTime PaymantDate { get; set; }
        public int MemberId { get; set; }

        public virtual Member Member { get; set; }
    }
}
