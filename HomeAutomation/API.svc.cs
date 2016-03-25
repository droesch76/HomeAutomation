using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HomeAutomation
{
    public class API : IAPI
    {
        Broker b;

        public int SetStatus(string n, string a)
        {
            b = new Broker();
            return b.InsertStatus(n, a);
        }

        public string GetStatus(string n)
        {
            b = new Broker();
            return b.QueryStatus(n);
        }

        public int SetEvent(string l, string t, string d)
        {
            b = new Broker();
            return b.InsertEvent(l, t, d);
        }

        public string GetEvent(string l)
        {
            b = new Broker();
            return b.QueryEvent(l);
        }

        public int SetEnvironment(string l, string s, string t, string u, string r)
        {
            b = new Broker();
            return b.InsertEnvironment(l, s, t, u, r);
        }

        public string GetEnvironment(string l)
        {
            b = new Broker();
            return b.QueryEnvironment(l);
        }
    }
}
