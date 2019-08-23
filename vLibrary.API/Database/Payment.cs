using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public class Payment : Entity
    {
        public string Title { get; set; }
        public DateTime PaymantDate { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

    }
}
