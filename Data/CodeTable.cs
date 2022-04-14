using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZimHelpDesk.Data
{
    public class CodeTable
    {
        public static class DemandStatus
        {
            public static string[] DemandStatusArr = { "Oluşturuldu", "Değerlendiriliyor", "Reddedildi", "Atandı", "Kapatıldı" };
            public static int CREATED = 0;
            public static int EVALUATING = 1;
            public static int REJECTED = 2;
            public static int ATTENDED = 3;
            public static int CLOSED = 4;
        }

        public static class Department
        {
            public static string[] DepartmentArr = { "Üretim", "Kalite Kontrol", "Dış Ticaret", "Satınalma", "İnsan Kaynakları", "Nihai Proses", "Bilgi Teknolojileri","Finans"};
            public static int MANUFACTURE = 1;
            public static int QUALITY = 2;
            public static int FOREIGNTRADE = 3;
            public static int PURCHASE = 4;
            public static int HUMAN = 5;
            public static int LASTPROCESS=6;
            public static int INFORMATION= 7;
            public static int FINANCE=8;
        }

        public static class DemandType
        {
            public static string[] TypeArr ={ "ERP","SİSTEM" };
            public static int ERP = 0;
            public static int SISTEM = 1;

        }
    }
}
