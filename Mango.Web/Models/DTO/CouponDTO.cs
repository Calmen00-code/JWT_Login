﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.DTO
{
    public class CouponDTO
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        [Required]
        public int MinAmount { get; set; }
    }
}
