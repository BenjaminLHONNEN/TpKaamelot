using Android.App;
using Android.Media;
using Tp1.Droid.Implements;
using Tp1.Implements;


[assembly: Xamarin.Forms.Dependency(typeof(AndroidMediaPlayer))]
namespace Tp1.Droid.Implements
{
    public class AndroidMediaPlayer : IMediaPlayer
    {
        protected MediaPlayer player;

        public void Play(string file)
        {

            if (player == null)
            {
                player = new MediaPlayer();
            }
            else
            {
                player.Reset();
            }

            var fd = Application.Context.Assets.OpenFd(file);//global::Android.App.Application.Context
            /*
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.Completion += (s, e) =>
            {
                player.Release();
            };*/
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
            player.Start();
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}