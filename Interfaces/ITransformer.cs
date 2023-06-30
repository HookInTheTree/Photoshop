﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Interfaces
{
    public interface ITransformer<TParameters>
        where TParameters:IParameters
    {
        Size TransformSize(Size size, TParameters parameters);
        Point? TransformPoint(Point point, Size size, TParameters parameters);
    }
}
