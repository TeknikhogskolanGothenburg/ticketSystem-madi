using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCWebCodeByMadi.Models
{
    public class TicketEvents
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public int TicketEventPrice { get; set; }

    }
}
