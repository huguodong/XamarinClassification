using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Sample
{
    public class MyAdapter : BaseAdapter
    {
        // ∂®“ÂContext
        private LayoutInflater mInflater;
        private List<string> list;
        private Context context;
        public MyAdapter(Context context, List<string> list)
        {
            mInflater = LayoutInflater.From(context);
            this.list = list;
            this.context = context;
        }
        public override int Count
        {
            get
            {
                return list.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return list[position];
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            MyView view;
            if (convertView == null)
            {
                view = new MyView();
                convertView = mInflater.Inflate(Resource.Layout.Item, null);
                view.name = (TextView)convertView.FindViewById(Resource.Id.typename);
                view.name.Text = list[position];
                convertView.Tag = view;
            }
            else {
                view = (MyView)convertView.Tag;
            }
            return convertView;
        }
        private class MyView : Java.Lang.Object
        {
            public TextView name;
        }
    }
}