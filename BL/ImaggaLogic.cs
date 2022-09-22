using DP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static DP.ImaggaModel;

namespace BL
{
    /// <summary>
    /// This class does the logic of the imagga
    /// </summary>
    public class ImaggaLogic
    {
        /// <summary>
        /// This class make sure that its an appropriate picture 
        /// </summary>
        /// <param name="ImageUrl">the url of the image</param>
        /// <param name="Name">the name of the category by which we check the image</param>
        /// <returns></returns>
        public bool FittingImage(ImaggaParamsDTO data)
        {
            Root myImage = null;
            DAL.ImaggaAdapter dal = new DAL.ImaggaAdapter();
            string myJson = dal.GetImageInformation(data.ImageUrl);
            if (myJson != null)
            {
                myImage = JsonConvert.DeserializeObject<Root> (myJson);
            }
            foreach (var item in myImage.result.tags)
            {
                if (item.confidence > 80)
                {
                    if (item.tag.en == data.Name)
                        return true;
                }
                else
                    return false;
            }
            return false;
        }
    }
}
