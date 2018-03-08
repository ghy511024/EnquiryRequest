﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnquiryRequest.Models
{
    public class InvoiceReminder
    {
        [Key]
        public int InvoiceReminderId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime InvoiceReminderDate { get; set; }

        [Required]
        public int InvoiceReminderTypeId { get; set; }
        public virtual  InvoiceReminderType InvoiceReminderType { get; set; }
    }
}