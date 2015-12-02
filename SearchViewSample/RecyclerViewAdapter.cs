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
using Android.Support.V7.Widget;
using Android.Views.Animations;
using Newtonsoft.Json;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "RecyclerViewAdapter")]			
	public class MyShop_RecyclerViewAdapter : RecyclerView.Adapter
	{
		//public MySkool_ListDataHolder mData;
		public MyShop_ListDataHolderList mData;
		Activity context;
		//for animation

		//foranimation
		public event EventHandler<int> ItemClick;

		//public MySkool_RecyclerViewAdapter (Activity context, MySkool_ListDataHolder data)
		public MyShop_RecyclerViewAdapter (Activity context, MyShop_ListDataHolderList data)
		{
			this.context = context;
			mData = data;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{

			View itemView = LayoutInflater.From (parent.Context).Inflate (Resource.Layout.MyShop_ViewListItem, parent, false);
			MyShop_ViewHolder vh = new MyShop_ViewHolder (itemView, OnClick);

			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			//int item = mData[position];
			//IWindowManager windowManager = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
			MyShop_ViewHolder vh = holder as MyShop_ViewHolder;

				/*//calculate the phone screen
				DisplayMetrics dm = new DisplayMetrics ();
				windowManager.DefaultDisplay.GetMetrics (dm);
				int width = dm.WidthPixels;
				int height = dm.HeightPixels;
				int dens = (int)dm.DensityDpi;
				double wi = (double)width / (double)dens;
				double hi = (double)height / (double)dens;
				double x = Math.Pow (wi,2);
				double y = Math.Pow (hi,2);
				double screenInches = Math.Sqrt (x + y);*/
			vh.tvTitle.Text = mData[position].title;
			vh.tvContent.Text = mData[position].content;


			//vh.IVLike.SetImageResource (mData[position].like);
		}


		public override int ItemCount{
			get { return mData.DataNum; }
		}

		void OnClick (int position)
		{
			if (ItemClick != null)
				ItemClick (this, position);
		}
		
	}

	public class MyShop_ViewHolder : RecyclerView.ViewHolder
	{

		public TextView tvTitle { get; private set; }
		public TextView tvContent { get; private set;}
		public View mMainView { get; set; }
		public MyShop_ViewHolder (View itemView, Action<int> listener) : base(itemView)
		{
			tvTitle = itemView.FindViewById <TextView> (Resource.Id.tvTitle);
			tvContent = itemView.FindViewById <TextView> (Resource.Id.tvContent);

			itemView.Click += (sender, e) => listener (base.Position);
		}
	}

	public class MyShop_ListData
	{
		public string mTitle;
		public string mContent;

		public string title
		{
			get { return mTitle; }
		}

		public string content
		{
			get { return mContent; }
		}

	}
		
}

