using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using System.Collections.Generic;
using Android.Graphics;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity, View.IOnClickListener, ViewPager.IOnPageChangeListener
    {
        private static List<string> toolsList;
        private static TextView[] toolsTextViews;
        private View[] views;
        private LayoutInflater inflater;
        private ScrollView scrollView;
        private int scrllViewWidth = 0, scrollViewMiddle = 0;
        private ViewPager shop_pager;
        private int currentItem = 0;
        private ShopAdapter shopAdapter;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            scrollView = (ScrollView)FindViewById<ScrollView>(Resource.Id.tools_scrlllview);
            shopAdapter = new ShopAdapter(SupportFragmentManager);
            inflater = LayoutInflater.From(this);
            ShowToolsView();
            InitPager();
        }
        public void Add()
        {
            toolsList = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                toolsList.Add("大类" + i);
            }
        }
        /// <summary>
        /// 动态生成显示items中的textview
        /// </summary>
        private void ShowToolsView()
        {
            Add();
            LinearLayout toolsLayout = FindViewById<LinearLayout>(Resource.Id.tools);
            toolsTextViews = new TextView[toolsList.Count];
            views = new View[toolsList.Count];
            for (int i = 0; i < toolsList.Count; i++)
            {
                View view = inflater.Inflate(Resource.Layout.Left, null);
                view.Id = i;
                view.SetOnClickListener(this);
                TextView textView = (TextView)view.FindViewById<TextView>(Resource.Id.text);
                textView.Text = toolsList[i];
                toolsLayout.AddView(view);
                toolsTextViews[i] = textView;
                views[i] = view;
            }
            ChangeTextColor(0);
        }
        /// <summary>
        /// 初始化ViewPager控件相关内容
        /// </summary>
        private void InitPager()
        {
            shop_pager = FindViewById<ViewPager>(Resource.Id.goods_pager);
            shop_pager.Adapter = shopAdapter;
            shop_pager.SetOnPageChangeListener(this);
        }
        public void OnClick(View v)
        {
            shop_pager.CurrentItem = v.Id;
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {

        }

        public void OnPageScrollStateChanged(int state)
        {

        }

        public void OnPageSelected(int position)
        {
            if (shop_pager.CurrentItem != position) shop_pager.CurrentItem = position;
            if (currentItem != position)
            {
                ChangeTextColor(position);
                ChangeTextLocation(position);
            }
            currentItem = position;
        }
        /// <summary>
        /// ViewPager 加载选项卡
        /// </summary>
        private class ShopAdapter : FragmentPagerAdapter
        {
            public ShopAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
            {

            }
            public override int Count
            {
                get
                {
                    return toolsList.Count;
                }
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                Android.Support.V4.App.Fragment fragment = new ClassificationFragment();
                Bundle bundle = new Bundle();
                String str = toolsList[position];
                bundle.PutString("typename", str);
                fragment.Arguments = bundle;
                return fragment;
            }

        }
        /// <summary>
        /// 改变textView的颜色
        /// </summary>
        /// <param name="id"></param>
        private void ChangeTextColor(int id)
        {
            for (int i = 0; i < toolsTextViews.Length; i++)
            {
                if (i != id)
                {
                    toolsTextViews[i].SetBackgroundResource(Android.Resource.Color.Transparent);
                    toolsTextViews[i].SetTextColor(Setcolor(0xff000000));
                }
            }
            toolsTextViews[id].SetBackgroundResource(Android.Resource.Color.White);
            toolsTextViews[id].SetTextColor(Setcolor(0xffff5d5e));
        }
        /// <summary>
        /// uint转color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Color Setcolor(uint color)
        {
            byte R, G, B;
            R = (byte)(color >> 10);
            G = (byte)(color >> 5 & 0x1f);
            B = (byte)(color & 0x1f);
            Color c = Color.Argb(100, R, G, B);
            return c;
        }
        /// <summary>
        /// 改变栏目位置
        /// </summary>
        /// <param name="clickPosition"></param>
        private void ChangeTextLocation(int clickPosition)
        {
            int x = (views[clickPosition].Top - GetScrollViewMiddle() + (GetViewheight(views[clickPosition]) / 2));
            scrollView.SmoothScrollTo(0, x);
        }
        private int GetScrollViewMiddle()
        {
            if (scrollViewMiddle == 0)
                scrollViewMiddle = GetScrollViewheight() / 2;
            return scrollViewMiddle;
        }
        private int GetScrollViewheight()
        {
            if (scrllViewWidth == 0)
                scrllViewWidth = scrollView.Bottom - scrollView.Top;
            return scrllViewWidth;
        }
        private int GetViewheight(View view)
        {
            return view.Bottom - view.Top;
        }


    }
}

