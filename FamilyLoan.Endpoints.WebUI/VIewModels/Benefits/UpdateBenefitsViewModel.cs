﻿using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Benefits
{
    public class UpdateBenefitsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
