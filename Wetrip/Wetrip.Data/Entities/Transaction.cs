﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public decimal Money { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Type { get; set; }

    public int WalletId { get; set; }

    public virtual Wallet Wallet { get; set; }
}