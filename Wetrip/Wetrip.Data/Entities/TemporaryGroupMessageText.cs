﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TemporaryGroupMessageText
{
    public int MessageId { get; set; }

    public string MessageText { get; set; }

    public virtual TemporaryGroupMessage Message { get; set; }
}