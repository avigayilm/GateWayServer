using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigML;
//using System.Data;

namespace DAL
{
    public  class MLAdapter
    {
        public static async void CallML()
        {
            //Console.Write("user: ");
            // var user = Console.ReadLine();
            var user = "HUD";
            //Console.Write("key: ");
            //var apiKey = Console.ReadLine();
            var apiKey = "6a656110fb3dedf47be8e256f8dbd9228399eaf0";
            var client = new Client(user, apiKey);

            var filePath = @"RecipeSource.csv"; // change to your source
            string name = "Recipes File";

            // --- create a source from the data in a remote file ---

            // setting the parameters to be used in source creation
            //var parameters = new Source.Arguments();
            //parameters.Add("name", "my new source");
            //parameters.Add("name", "recipes source");
            // uploading a remote file
            //parameters.Add("remote", "https://static.bigml.com/csv/iris.csv");
            // if you need to upload a local file, change last line to
            // parameters.Add("file", "iris.csv");
            // Source object which will encapsulate the source information
            //Source source = await client.CreateSource(parameters);
            Source source = await client.CreateSource(filePath, name);
            // API calls are asynchronous, so you need to check that the source is finally
            // finished. To learn about the possible states for
            // BigML resources, please see http://bigml.com/api/status_codes
            source = await client.Get<Source>(source);
            while ((source = await client.Get<Source>(source))
                                            .StatusMessage
                                            .NotSuccessOrFail()
                                         )
            {
                await Task.Delay(5000);
            }


            var dataSet = await client.CreateDataset(source);

            // --- create a dataset from the previous source ---
            // setting the parameters to be used in dataset creation
            //var parameters2 = new DataSet.Arguments();
            //parameters2.Add("nameDS", "my new dataset");
            //// using the source ID as argument
            //parameters2.Add("source", source.Resource);
            //// Dataset object which will encapsulate the dataset information
            //DataSet dataset = await client.CreateDataset(parameters2);
            //// checking the dataset status
            while ((dataSet = await client.Get<DataSet>(dataSet))
                                          .StatusMessage
                                          .NotSuccessOrFail())
            {
                await Task.Delay(1000);
            }
            Console.WriteLine(dataSet.StatusMessage.ToString());


            var model = await client.CreateModel(dataSet);
            // No push, so we need to busy wait for the source to be processed.
            while ((model = await client.Get(model)).StatusMessage.NotSuccessOrFail()) await Task.Delay(1000);
            Console.WriteLine(model.StatusMessage.ToString());


            //// --- create a model from the previous dataset ---
            //// setting the parameters to be used in model creation
            //var parameters3 = new Model.Arguments();
            //parameters3.Add("name", "my new model");
            //// using the dataset ID as argument
            //parameters3.Add("dataset", dataset.Resource);
            //// Model object which will encapsulate the model information
            //Model model = await client.CreateModel(parameters3);
            //// checking the model status
            //while ((model = await client.Get<Model>(model))
            //                            .StatusMessage
            //                            .NotSuccessOrFail())
            //{
            //    await Task.Delay(5000);
            //}

            // --- create a prediction using the model ---
            // setting the parameters to be used in prediction creation
            var parameters4 = new Prediction.Arguments();
            // using the model ID as argument
            parameters4.Add("model", model.Resource);
            // set INPUT DATA for prediction: {'petal length': 5, 'sepal width': 2.5}
            //parameters4.InputData.Add("petal length", 5);
            //parameters4.InputData.Add("sepal width", 2.5);
            parameters4.InputData.Add("Weather", "Weather.Cold");
            parameters4.InputData.Add("Holiday", "Holiday.Hannuka");
            parameters4.InputData.Add("last category", "Soup");




            // SET MISSING STRATEGY and NAME
            //  parameters4.Add("missing_strategy", 1); //Proportional
            parameters4.Add("name", "prediction w/ PROPORTIONAL");
            // Prediction object which will encapsulate the prediction information
            Prediction prediction = await client.CreatePrediction(parameters4);
            // checking the prediction status
            while ((prediction = await client.Get<Prediction>(prediction))
                                             .StatusMessage
                                             .NotSuccessOrFail())
            {
                await Task.Delay(2000);
            }
            Console.WriteLine("------------------------------\nMissing strategy PROPORTIONAL");
            Console.WriteLine("Prediction: " + prediction.GetPredictionOutcome<string>());
            Console.WriteLine("Confidence: " + prediction.Confidence);


            // Test same input_data, but with missing_stategy = 0 (default value)
            // UPDATE MISSING STRATEGY and NAME
            parameters4.Update("missing_strategy", 0); //Last prediction
            parameters4.Update("name", "prediction w/ LAST PREDICTION");
            prediction = await client.CreatePrediction(parameters4);
            while ((prediction = await client.Get<Prediction>(prediction))
                                             .StatusMessage
                                             .NotSuccessOrFail())
            {
                await Task.Delay(2000);
            }

            Console.WriteLine("------------------------------\nMissing strat. LAST PREDICTION");
            Console.WriteLine("Prediction: " + prediction.GetPredictionOutcome<string>());
            Console.WriteLine("Confidence: " + prediction.Confidence);
            Console.WriteLine("------------------------------");

        }

       
        public async Task<string> Predict(string lastCat, string weather, string? holiday)
        {
            var user = "HUD";
            var apiKey = "6a656110fb3dedf47be8e256f8dbd9228399eaf0";
            var client = new Client(user, apiKey);


            var parameters = new Prediction.Arguments();
            parameters.Add("model", "model/635489454bbdc023b4005309"); //put your Id here
            parameters.InputData.Add("last category", lastCat);
            parameters.InputData.Add("Weather", weather);
            parameters.InputData.Add("Holiday", holiday);
            Prediction categoryPrediction = await client.CreatePrediction(parameters);
            return categoryPrediction.GetPredictionOutcome<string>();
            
            return (string)categoryPrediction.Fields.Root;
            //return categoryPrediction.Output;//.GetPredictionOutcome<string>();//.GetPredictionOutcome<string>();

        }

    }
}
