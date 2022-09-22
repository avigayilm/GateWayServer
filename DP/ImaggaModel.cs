using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    /// <summary>
    /// Creating a class that expresses the json file
    /// </summary>
    public class ImaggaModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Result
        {
            public List<Tag> tags { get; set; }
        }

        public class Root
        {
            public Result result { get; set; }
            public Status status { get; set; }
        }

        public class Status
        {
            public string text { get; set; }
            public string type { get; set; }
        }

        public class Tag
        {
            public double confidence { get; set; }
            public Tag2 tag { get; set; }
        }

        public class Tag2
        {
            public string en { get; set; }
        }

    }

}

