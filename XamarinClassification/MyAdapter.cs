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
        // ����Context
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
                if (type.GetTypename().Contains("���԰칫"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.diannao);
                }
                else if (type.GetTypename().Contains("������ױ"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.huazhuang);
                }
                else if (type.GetTypename().Contains("Ьѥ���"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.nvxie);
                }
                else if (type.GetTypename().Contains("����Ůװ"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.nvzhuang);
                }
                else if (type.GetTypename().Contains("ͼ��"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.shuji);
                }
                else if (type.GetTypename().Contains("�������"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.wanju);
                }
                else if (type.GetTypename().Contains("������Ʒ"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.yingshi);
                }
                else if (type.GetTypename().Contains("���÷���"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.yiyong);
                }
                else if (type.GetTypename().Contains("Ʒ����װ"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.nanzhuang);
                }
                else if (type.GetTypename().Contains("��������"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.neiyi);
                }
                else if (type.GetTypename().Contains("���õ���"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.dianqi);
                }
                else if (type.GetTypename().Contains("�ֻ�����"))
                {
                    view.icon.SetBackgroundResource(Resource.Drawable.shouji);
                }
                else {
                    view.icon.SetBackgroundResource(Resource.Drawable.nvzhuang);
                }
            }
            #endregion//ͼ��
            return convertView;
        }
        private class MyView : Java.Lang.Object
        {
            public ImageView icon;
            public TextView name;
        }

    }
}