using System.IO;
using Tp1.Droid.Implements;
using Tp1.Implements;
using Application = Android.App.Application;

[assembly: Xamarin.Forms.Dependency(typeof(AssetFile_Implements))]
namespace Tp1.Droid.Implements
{
    public class AssetFile_Implements : IAssetFile
    {
        public string GetJson_FromAssetFile(string fileName)
        {
            string response;
            using (StreamReader streamReader = new StreamReader(Application.Context.Assets.Open(fileName)))
            {
                response = streamReader.ReadToEnd();
            }
            return response;
        }
    }
}