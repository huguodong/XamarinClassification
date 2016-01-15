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

namespace XamarinClassification
{
    public class MyAdapter : BaseAdapter
    {
        // 定义Context
        private LayoutInflater mInflater;
        private List<Types> list;
        private Context context;
        private Types type;
        public MyAdapter(Context context, List<Types> list)
        {
            mInflater = LayoutInflater.From(context);
            this.list = list;
            this.context = context;
        }
        public override int Count
        {
            get
            {
                if (list != null && list.Count > 0)
                    return list.Count;
                else
                    return 0;
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
                convertView = mInflater.Inflate(Resource.Layout.list_pro_type_item, null);
                view.icon = (ImageView)convertView.FindViewById(Resource.Id.typeicon);
                view.name = (TextView)convertView.FindViewById(Resource.Id.typename);
                convertView.Tag = view;
            }
            else {
                view = (MyView)convertView.Tag;
            }
            #region
            if (list != null && list.Count > 0)
            {
                type = list[position];
                view.name.Text=type.GetTypename();
                if (type.GetTypename().Contains("电脑办公"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.diannao);
                }
                else if (type.GetTypename().Contains("个护化妆"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.huazhuang);
                }
                else if (type.GetTypename().Contains("鞋靴箱包"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.nvxie);
                }
                else if (type.GetTypename().Contains("潮流女装"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.nvzhuang);
                }
                else if (type.GetTypename().Contains("图书"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.shuji);
                }
                else if (type.GetTypename().Contains("玩具乐器"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.wanju);
                }
                else if (type.GetTypename().Contains("音像制品"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.yingshi);
                }
                else if (type.GetTypename().Contains("常用分类"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.yiyong);
                }
                else if (type.GetTypename().Contains("品牌男装"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.nanzhuang);
                }
                else if (type.GetTypename().Contains("内衣配饰"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.neiyi);
                }
                else if (type.GetTypename().Contains("家用电器"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.dianqi);
                }
                else if (type.GetTypename().Contains("手机数码"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.shouji);
                }
                else {
                    view.icon.SetBackgroundResource(Resource.Drawable.nvzhuang);
                }
            }
            #endregion//图标
            return convertView;
        }
        private class MyView : Java.Lang.Object
        {
            public ImageView icon;
            public TextView name;
        }

    }
}