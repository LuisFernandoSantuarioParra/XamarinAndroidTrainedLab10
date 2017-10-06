using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int Counter = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            var ContentHeader = FindViewById<TextView>(Resource.Id.ContentHeader);
            ContentHeader.Text = GetText(Resource.String.ContentHeader);

            var ClickMe = FindViewById<Button>(Resource.Id.ClickMe);
            var ClickCounter = FindViewById<TextView>(Resource.Id.ClickCounter);

            ClickMe.Click += (s,e) => {
                Counter++;
                ClickCounter.Text = Resources.GetQuantityString(Resource.Plurals.numberOfClicks,Counter,Counter);
                var Player = Android.Media.MediaPlayer.Create(this,Resource.Raw.sound);
                Player.Start();
            };

            Android.Content.Res.AssetManager Manager = this.Assets;
            using (var Reader=new System.IO.StreamReader(Manager.Open("Contenido.txt"))) {
                ContentHeader.Text += $"\n\n{Reader.ReadToEnd()}";
            }
        }


    }
}

