using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Content;

namespace IntentDemo_Xamarin_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnMap;
        Button btnCall;
        Button btnEmail;

        EditText txtPhone;
        EditText txtLat;
        EditText txtLong;
        EditText txtEmailTo;
        EditText txtEmailSubject;
        EditText txtEmailMessage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get our button from the layout resource,
            // and attach an event to it
            btnMap = FindViewById<Button>(Resource.Id.btnMap);
            btnCall = FindViewById<Button>(Resource.Id.btnCall);
            btnEmail = FindViewById<Button>(Resource.Id.btnMail);

            txtPhone = FindViewById<EditText>(Resource.Id.txtPhone);
            txtLat = FindViewById<EditText>(Resource.Id.txtLat);
            txtLong = FindViewById<EditText>(Resource.Id.txtLong);
            txtEmailTo = FindViewById<EditText>(Resource.Id.txtEmailTo);
            txtEmailSubject = FindViewById<EditText>(Resource.Id.txtSubject);
            txtEmailMessage = FindViewById<EditText>(Resource.Id.txtMessage);

            btnCall.Click += BtnCall_Click;
            btnMap.Click += BtnMap_Click;
            btnEmail.Click += BtnEmail_Click;
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            var email = new Intent(Android.Content.Intent.ActionSend);

            email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { txtEmailTo.Text });

            //You can add a CC as well
            //email.PutExtra(Android.Content.Intent.ExtraCc,txtEmailTo.Text);

            email.PutExtra(Android.Content.Intent.ExtraSubject, txtEmailSubject.Text);

            email.PutExtra(Android.Content.Intent.ExtraText, txtEmailMessage.Text);

            email.SetType("message/rfc822");

            StartActivity(email);
        }

        private void BtnMap_Click(object sender, EventArgs e)
        {
            var geoUri = Android.Net.Uri.Parse("geo:" + txtLat.Text + "," + txtLong.Text);
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }
        private void BtnCall_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("tel:" + txtPhone.Text);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}