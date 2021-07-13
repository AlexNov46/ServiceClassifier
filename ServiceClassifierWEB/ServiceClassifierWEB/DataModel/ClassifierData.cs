using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;
namespace ServiceClassifierWEB.DataModel
{
    public class ClassifierData
    {
        [LoadColumn(0)]
        [ColumnName("Input")]
        public string InputText;

        [LoadColumn(1)]
        [ColumnName("Output")]
        public string output;
    }
}
