using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    public class Nutrient
    {
        public string Name { get; set; }
        public string UnitName { get; set; }
        public double Value { get; set; }
        public int? DailyPercent { get; set; } = 0;
    }
    public class UsdaParamsDTO
    {
    }
}
