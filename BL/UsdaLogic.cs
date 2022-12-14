using DP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using static DP.UsdaModel;
using static System.Net.Mime.MediaTypeNames;

namespace BL
{
    public class UsdaLogic
    {
        public Nutrient[] NutrientsInfo(string ingredients/*,string Keyword*/)
        {
            int? DailyValue;
            Nutrient[] recipeNutrients = new Nutrient[7];
            int counter = 1;
            Root myNutrients=null;
            DAL.UsdaAdapter dal = new DAL.UsdaAdapter();

            var myJson = dal.GetNutrients(ingredients);

            if (myJson != null)
            {
                myNutrients = JsonConvert.DeserializeObject<Root>(myJson);
            }

            foreach (var item in myNutrients.foods)
            {
                //if (Keyword == "-" || item.description.Contains(Keyword) == true)
                {
                    recipeNutrients[0] = new Nutrient { Name = "ServingSize", UnitName = item.servingSizeUnit, Value = item.servingSize };

                    foreach (var nutrient in item.foodNutrients)
                    {
                        if (nutrient.percentDailyValue == null)
                            DailyValue = null;
                        else
                            DailyValue = nutrient.percentDailyValue;
                        if (nutrient.nutrientId==1003|| nutrient.nutrientId == 1004|| nutrient.nutrientId == 1005|| nutrient.nutrientId == 1008|| nutrient.nutrientId == 1093|| nutrient.nutrientId == 2000)// we only add the nutritions of 1003=Protein,1004=Total lipid (fat),1005=Carbohydrate, by difference,1008=Energy,2000=Sugars, total including NLEA,1093=Sodium, Na
                        {
                            recipeNutrients[counter] =new Nutrient { Name=nutrient.nutrientName, UnitName=nutrient.unitName,Value=nutrient.value,DailyPercent=DailyValue };
                            counter++;
                        }
                    }
                    if (/*Keyword == "-"||*/counter==7)
                        break;
                }

            }
            if (recipeNutrients[0] == null)
                return null;
            else
                return recipeNutrients;
        }
    }
}
