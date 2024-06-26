﻿using System.ComponentModel.DataAnnotations;

namespace Asp.NetAPIAssignment02.WebApp.Helper
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is DateTime dob)
            {
                return dob <= DateTime.Now;
            }
            return true; 
        }
    }
}