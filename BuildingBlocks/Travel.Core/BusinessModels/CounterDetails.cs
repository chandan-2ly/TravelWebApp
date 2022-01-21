﻿using System;

namespace Travel.Core.BusinessModels
{
    public class CounterDetails
    {
        public Guid AdminUserId { get; set; }
        public string CounterName { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Zone { get; set; }
        public string Province { get; set; }
        public string ContactNo { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDisabled { get; set; }
    }
}
