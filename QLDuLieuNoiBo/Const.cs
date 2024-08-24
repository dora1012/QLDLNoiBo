using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDuLieuNoiBo
{
    public class Const
    {
        public static Const instance;
        public static Const Instance
        {
            get { if (instance == null) instance = new Const(); return instance; }
            private set { Const.instance = value; }
        }
        private Const() { }
        public string hk = "HK2";
        public string nam = "2024";
    }
}
