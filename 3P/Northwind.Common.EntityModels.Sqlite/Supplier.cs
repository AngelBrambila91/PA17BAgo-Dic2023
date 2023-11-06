﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Common.Entities;

[Index("CompanyName", Name = "CompanyNameSuppliers")]
[Index("PostalCode", Name = "PostalCodeSuppliers")]
public partial class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar (40)")]
    public string CompanyName { get; set; } = null!;

    [Column(TypeName = "nvarchar (30)")]
    public string? ContactName { get; set; }

    [Column(TypeName = "nvarchar (30)")]
    public string? ContactTitle { get; set; }

    [Column(TypeName = "nvarchar (60)")]
    public string? Address { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    public string? City { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    public string? Region { get; set; }

    [Column(TypeName = "nvarchar (10)")]
    public string? PostalCode { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    public string? Country { get; set; }

    [Column(TypeName = "nvarchar (24)")]
    public string? Phone { get; set; }

    [Column(TypeName = "nvarchar (24)")]
    public string? Fax { get; set; }

    [Column(TypeName = "ntext")]
    public string? HomePage { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
