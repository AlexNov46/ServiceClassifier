using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace ServiceClassifierWEB.DataModel
{
    public class ClassifierOutputs : ClassifierData
    {
        [ColumnName("PredictedOut")]
        public string Type { get; set; }
    }
}
