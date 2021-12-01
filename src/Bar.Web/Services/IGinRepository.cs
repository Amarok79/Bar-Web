// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Bar.Web.Services;

public interface IGinRepository
{
    Task<IEnumerable<Gin>> GetAllAsync();
}
