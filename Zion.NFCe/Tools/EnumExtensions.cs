﻿using System;
using System.ComponentModel;
using System.Linq;

namespace Zion.NFCe.Tools
{
    public static class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
                return attributes.First().Description;

            return value.ToString();
        }
    }
}
