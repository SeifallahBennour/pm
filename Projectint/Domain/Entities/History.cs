using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class History
    {
        public int historyId { get; set; }
        public DateTime date { get; set; }

        public virtual Member team_member { get; set; }
        public virtual TeamLeader team_leader { get; set; }

    }
}
