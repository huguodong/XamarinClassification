using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android.Support.V4.View;
using Android.Graphics;

namespace XamarinClassification
{
    [Activity(Label = "XamarinClassification", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity, View.IOnClickListener, ViewPager.IOnPageChangeListener
    {
        private static List<string> toolsList;
        private TextView[] toolsTextViews;
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
             SetContentView(Resource.Layout.activity_b);
            scrollView = (ScrollView)FindViewById<ScrollView>(Resource.Id.tools_scrlllview);
            shopAdapter = new ShopAdapter(SupportFragmentManager);
            inflater = LayoutInflater.From(this);
            ShowToolsView();
            InitPager();
        }
        public void Add()
        {
            toolsList = new List<string>();
            toolsList.Add("常用分类");
            toolsList.Add("潮流女装"); toolsList.Add("品牌男装"); toolsList.Add("内衣配饰"); toolsList.Add("家用电器"); toolsList.Add("手机数码"); toolsList.Add("电脑办公");
            toolsList.Add("个护化妆"); toolsList.Add("母婴频道"); toolsList.Add("食物生鲜");
            toolsList.Add("酒水饮料"); toolsList.Add("家居家纺"); toolsList.Add("整车车品"); toolsList.Add("鞋靴箱包"); toolsList.Add("运动户外"); toolsList.Add("图书");
            toolsList.Add("玩具乐器"); toolsList.Add("钟表"); toolsList.Add("居家生活"); toolsList.Add("珠宝饰品"); toolsList.Add("音像制品"); toolsList.Add("家具建材");
            toolsList.Add("计生情趣"); toolsList.Add("营养保健"); toolsList.Add("奢侈礼品"); toolsList.Add("生活服务"); toolsList.Add("旅游出行");
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
                View view = inflater.Inflate(Resource.Layout.item_b_top_nav_layout, null);
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

        public void OnPageScrollStateChanged(int state)
        {

        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
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
                Android.Support.V4.App.Fragment fragment = new ClassificationView();
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

