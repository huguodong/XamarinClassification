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

namespace XamarinClassification
{
    public class Types : Java.Lang.Object
    {
        private int Id;
        private String Typename;
        private String Typeiconurl;
        public Types(int id, String typename, String typeiconurl) : base()
        {

            this.Id = id;
            this.Typename = typename;
            this.Typeiconurl = typeiconurl;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetId(int id)
        {
            this.Id = id;
        }
        public String GetTypename()
        {
            return Typename;
        }
        public void SetTypename(String typename)
        {
            this.Typename = typename;
        }
        public String GetTypeiconurl()
        {
            return Typeiconurl;
        }
        public void SetTypeiconurl(String typeiconurl)
        {
            this.Typeiconurl = typeiconurl;
        }
    }
}