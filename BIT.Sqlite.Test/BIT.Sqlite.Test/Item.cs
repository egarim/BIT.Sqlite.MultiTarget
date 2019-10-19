using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

using System;
using System.Linq;
using Xamarin.Forms;

namespace BIT.Sqlite.Test
{
    public class Item : XPObject
    {

        string text;
        [Size(256)]
        public string Text
        {
            get { return text; }
            set { SetPropertyValue(nameof(Text), ref text, value); }
        }
        string description;

        public Item()
        {

        }

        public Item(Session session) : base(session)
        {

        }

        public Item(Session session, XPClassInfo classInfo) : base(session, classInfo)
        {

        }

        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get { return description; }
            set { SetPropertyValue(nameof(Description), ref description, value); }
        }
    }
}