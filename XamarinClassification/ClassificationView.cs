using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
namespace XamarinClassification
{
    public class ClassificationView : Android.Support.V4.App.Fragment
    {
        private List<Types> list;
        private ImageView hint_img;
        private GridView listView;
        private MyAdapter adapter;
        private Types type;
        private ProgressBar progressBar;
        private String typename;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment_pro_type, null);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBar);
            hint_img = view.FindViewById<ImageView>(Resource.Id.hint_img);
            listView = view.FindViewById<GridView>(Resource.Id.listView);
            typename = Arguments.GetString("typename");
            view.FindViewById<TextView>(Resource.Id.toptype).Text = typename;
            GetTypeList();
            adapter = new MyAdapter(Activity, list);
            listView.Adapter = adapter;
            listView.ItemClick += ListView_ItemClick;
            return view;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
          
        }

        private void GetTypeList()
        {
            list = new List<Types>();
            for (int i = 1; i < 35; i++)
            {
                type = new Types(i, typename + i, "");
                list.Add(type);
            }
            progressBar.Visibility = ViewStates.Gone;
        }

    }
}