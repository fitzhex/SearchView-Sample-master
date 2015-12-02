using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;


namespace SearchViewSample
{
	public class WebServices
	{
		public static string getSearchResult(string keyword)
		{

			string requestStr = string.Format ("http://myshop.pi1m.my/api/product/search/"+keyword);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestStr);
			Console.WriteLine ("[WebServices] SetMySkoolPetiMasuk string: {0}",requestStr);
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			//httpWebRequest.ContentLength = data.Length;
			//Stream myStream = httpWebRequest.GetRequestStream();
			//myStream.Write(data,0,data.Length);
			//myStream.Close();

			string Json_Value1 = "";

			try
			{
				using (var response = httpWebRequest.GetResponse ()) {

					using (var reader = new StreamReader (response.GetResponseStream ())) {

						Json_Value1 = reader.ReadToEnd ();
						Console.WriteLine ("[WebServices] Response Init: "+Json_Value1);

					}
				}

			}
			catch(System.Exception e) {

				Console.WriteLine ("[WebServices] Response Init: {0}",e);
			}

			return Json_Value1;
		}

		public class Photo
		{
			public string id { get; set; }
			public string product_id { get; set; }
			public string name { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string deleted_at { get; set; }
		}

		public class Datum
		{
			public string id { get; set; }
			public string sub_category_id { get; set; }
			public string status { get; set; }
			public string user_id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string rating_cache { get; set; }
			public string rating_count { get; set; }
			public string viewer_count { get; set; }
			public string viewer_count_by_week { get; set; }
			public string search_count_by_week { get; set; }
			public string week_viewer { get; set; }
			public string week_search { get; set; }
			public string comment_count { get; set; }
			public string price { get; set; }
			public object sku { get; set; }
			public string date { get; set; }
			public string term { get; set; }
			public string updated_at { get; set; }
			public string created_at { get; set; }
			public string deleted_at { get; set; }
			public string main_photo { get; set; }
			public string url_photo_thumb { get; set; }
			public string url_photo_large { get; set; }
			public List<Photo> photos { get; set; }
		}

		public class RootObject
		{
			public int total { get; set; }
			public int per_page { get; set; }
			public int current_page { get; set; }
			public int last_page { get; set; }
			public int from { get; set; }
			public int to { get; set; }
			public List<Datum> data { get; set; }
		}


	}

}