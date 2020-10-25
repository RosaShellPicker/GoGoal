using System;
using System.Reflection;
using Xamarin.Forms;
namespace gogoal
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }

        public ImageResourceExtension()
        {
        }
    }
}
