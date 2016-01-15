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

namespace Sample
{
    public class ClassificationFragment : Android.Support.V4.App.Fragment
    {
        private GridView listView;
        private String typename;
        private List<string> list;
        private MyAdapter adapter;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.FragmentView, null);
            listView = view.FindViewById<GridView>(Resource.Id.listView);
            typename = Arguments.GetString("typename");
            view.FindViewById<TextView>(Resource.Id.toptype).Text = typename;
            GetTypeList();
            adapter = new MyAdapter(Activity, list);
            listView.Adapter = adapter;
            listView.ItemClick += ListView_ItemClick; ;
            return view;

        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
         
        }

        private void GetTypeList()
        {
            list = new List<string>();
            for (int i = 1; i < 20; i++)
            {
                list.Add("Ð¡Àà" + i);
            }
        }
    }
}