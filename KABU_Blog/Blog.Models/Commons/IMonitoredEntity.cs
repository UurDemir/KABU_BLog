﻿using System;

namespace Blog.Models.Commons
{
    public interface IMonitoredEntity
    {
        string CreatedId { get; set; }
        string UpdatedId { get; set; }

        DateTime Created { get; set; }
        DateTime Updated { get; set; }
        User CreatedBy { get; set; }
        User UpdatedBy { get; set; }
    }
}