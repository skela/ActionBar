using ActionBarDemo.Widget.ActionBar;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace ActionBarDemo
{
	public class ActionBarResources : IActionBarResources,IActionBarLayouts,IActionBarIds,IActionBarStyleables
	{
		#region IActionBarResources

		public IActionBarLayouts Layout { get { return this; } }		
		public IActionBarIds Id { get { return this; } }
		public IActionBarStyleables Styleable { get { return this; } }

		#endregion

		#region IActionBarIds

		public int actionbar_home_logo
		{
			get
			{
				return Resource.Id.actionbar_home_logo;
			}
		}

		public int actionbar_home_btn
		{
			get
			{
				return Resource.Id.actionbar_home_btn;
			}
		}

		public int actionbar_home_is_back
		{
			get
			{
				return Resource.Id.actionbar_home_is_back;
			}
		}

		public int actionbar_home_bg
		{
			get
			{
				return Resource.Id.actionbar_home_bg;
			}
		}

		public int actionbar_title
		{
			get
			{
				return Resource.Id.actionbar_title;
			}
		}

		public int actionbar_actions
		{
			get
			{
				return Resource.Id.actionbar_actions;
			}
		}

		public int actionbar_left_actions
		{
			get
			{
				return Resource.Id.actionbar_left_actions;
			}
		}

		public int actionbar_progress
		{
			get
			{
				return Resource.Id.actionbar_progress;
			}
		}

		#endregion

		#region IActionBarLayouts

		public int actionbar
		{
			get
			{
				return Resource.Layout.actionbar;
			}
		}

		public int actionbar_item
		{
			get
			{
				return Resource.Layout.actionbar_item;
			}
		}

		#endregion

		#region IActionBarStyleables

		public int[] styleable_actionbar
		{
			get
			{
				return Resource.Styleable.ActionBar;
			}
		}

		public int styleable_actionbar_title
		{
			get
			{
				return Resource.Styleable.ActionBar_title;
			}
		}

		#endregion
	}

    [Activity(Label = "ActionBar", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : ActionBarActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			ActionBar.R = new ActionBarResources ();

            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);
            InitializeActionBar();
            var mailIntent = new Intent(Intent.ActionSend);
            mailIntent.PutExtra(Intent.ExtraEmail, "test@mail.com");
            mailIntent.PutExtra(Intent.ExtraSubject, "Subject");
            mailIntent.PutExtra(Intent.ExtraText, "Body");
            mailIntent.SetType("text/plain");
            var intent = Intent.CreateChooser(mailIntent, "Send mail");
            ActionBar.AddAction(new IntentAction(this, intent, Resource.Drawable.ic_action_message)).AddStubAction()
				.AddAction(new DelegateAction(OpenCameraClick, Android.Resource.Drawable.IcMenuCamera))
				.AddLeftAction(new DelegateAction(Finish, Resource.Drawable.ic_action_back))
                .SetTitle("ActionBarTest");
        }

        private void OpenCameraClick()
        {
            Toast.MakeText(this, "Camera button clicked", ToastLength.Short).Show();
        }
    }
}

