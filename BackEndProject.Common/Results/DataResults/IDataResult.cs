﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Results.DataResults
{
    public interface IDataResult<T> : IResults
    {
        T Data { get; }
    }
}
