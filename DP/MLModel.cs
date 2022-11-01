using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    internal class MLModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class _000000
        {
            public int column_number { get; set; }
            public string datatype { get; set; }
            public string name { get; set; }
            public string optype { get; set; }
            public int order { get; set; }
            public bool preferred { get; set; }
            public TermAnalysis term_analysis { get; set; }
        }

        public class _000001
        {
            public int column_number { get; set; }
            public string datatype { get; set; }
            public string name { get; set; }
            public string optype { get; set; }
            public int order { get; set; }
            public bool preferred { get; set; }
            public TermAnalysis term_analysis { get; set; }
        }

        public class _000002
        {
            public int column_number { get; set; }
            public string datatype { get; set; }
            public string name { get; set; }
            public string optype { get; set; }
            public int order { get; set; }
            public bool preferred { get; set; }
            public TermAnalysis term_analysis { get; set; }
        }

        public class _000003
        {
            public int column_number { get; set; }
            public string datatype { get; set; }
            public string name { get; set; }
            public string optype { get; set; }
            public int order { get; set; }
            public bool preferred { get; set; }
            public TermAnalysis term_analysis { get; set; }
        }

        public class ConfidenceBounds
        {
        }

        public class ExpandedInputData
        {
            public string _000000 { get; set; }
            public string _000001 { get; set; }
            public string _000002 { get; set; }
        }

        public class Fields
        {
            public _000000 _000000 { get; set; }
            public _000001 _000001 { get; set; }
            public _000002 _000002 { get; set; }
            public _000003 _000003 { get; set; }
        }

        public class Importance
        {
            public double _000000 { get; set; }
            public double _000002 { get; set; }
        }

        public class InputData
        {
            public string Holiday { get; set; }
            public string Weather { get; set; }

            [JsonProperty("last category")]
            public string LastCategory { get; set; }
        }

        public class ObjectiveSummary
        {
            public List<List<object>> categories { get; set; }
        }

        public class Path
        {
            public string field { get; set; }
            public string @operator { get; set; }
            public string value { get; set; }
        }

        public class Prediction
        {
            public string _000003 { get; set; }
        }

        public class PredictionPath
        {
            public double confidence { get; set; }
            public int node_id { get; set; }
            public ObjectiveSummary objective_summary { get; set; }
            public List<Path> path { get; set; }
        }

        public class Root
        {
            public bool boosted_ensemble { get; set; }
            public int category { get; set; }
            public int code { get; set; }
            public double confidence { get; set; }
            public ConfidenceBounds confidence_bounds { get; set; }
            public List<List<object>> confidences { get; set; }
            public object configuration { get; set; }
            public bool configuration_status { get; set; }
            public DateTime created { get; set; }
            public string creator { get; set; }
            public string dataset { get; set; }
            public bool dataset_status { get; set; }
            public string description { get; set; }
            public ExpandedInputData expanded_input_data { get; set; }
            public object explanation { get; set; }
            public Fields fields { get; set; }
            public Importance importance { get; set; }
            public InputData input_data { get; set; }
            public string locale { get; set; }
            public int missing_strategy { get; set; }
            public string model { get; set; }
            public bool model_status { get; set; }
            public int model_type { get; set; }
            public string name { get; set; }
            public string name_options { get; set; }
            public int number_of_models { get; set; }
            public string objective_field { get; set; }
            public string objective_field_name { get; set; }
            public string objective_field_type { get; set; }
            public List<string> objective_fields { get; set; }
            public string operating_kind { get; set; }
            public string output { get; set; }
            public Prediction prediction { get; set; }
            public PredictionPath prediction_path { get; set; }
            public bool @private { get; set; }
            public List<List<object>> probabilities { get; set; }
            public double probability { get; set; }
            public object project { get; set; }
            public string query_string { get; set; }
            public string resource { get; set; }
            public bool shared { get; set; }
            public string source { get; set; }
            public bool source_status { get; set; }
            public Status status { get; set; }
            public bool subscription { get; set; }
            public List<object> tags { get; set; }
            public string task { get; set; }
            public int type { get; set; }
            public DateTime updated { get; set; }
        }

        public class Status
        {
            public int code { get; set; }
            public double elapsed { get; set; }
            public string message { get; set; }
            public int progress { get; set; }
        }

        public class TermAnalysis
        {
            public bool enabled { get; set; }
        }


    }
}
