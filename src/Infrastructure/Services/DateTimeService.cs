﻿using Movies.Application.Common.Interfaces;
using System;

namespace Movies.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
