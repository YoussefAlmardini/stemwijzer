using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SA.Models
{
    class ImageResourceExtenstion : IMarkupExtension
    {
        public string ResourceID { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ResourceID == null)
            {
                return null;

            }
            // Do your translation lookup here, using whatever method you require 
            var imageSource = ImageSource.FromResource(ResourceID, typeof(ImageResourceExtenstion).GetTypeInfo().Assembly);
            return imageSource;

        }
    }
}
