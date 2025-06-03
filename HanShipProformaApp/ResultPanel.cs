using Microsoft.IdentityModel.Protocols;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using NPOI.WP.UserModel;
using NPOI.XWPF.UserModel;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HanShipProformaApp
{
    public partial class ResultPanel : Form
    {
        private string ship_name = "deneme";
        private string customer = "emir";
        private string flag;
        private string flagname;
        private double nt;
        private double gt;
        private double loa;
        private double beam;
        private double draft;
        private string port;
        private string portcity;
        private string inbound;
        private string outbound;
        private double dollar_tl;
        private double euro_dollar;
        private double imo;
        private double dmt;
        private string operation;
        private int anchorage_day;
        private string cargo_type;
        private string cargo_type2;
        private double cargo_weight;

        private double notary_public_fee = 0;
        private double sundries = 0;
        private double agency_staff_car_expenses = 0;
        private double launchboat_services = 0;
        private double communication_expenses = 0;

        private double postage = 0;
        private double Fiscalstamps = 0;
        private double SanitaryDues = 0;
        private double mauneldolar = 0;
        private double maunelEuro = 0;

        private double lcb;
        private ProformaPanel _proformaPanel; // ProformaPanel referansını sakla
        public ResultPanel(string ship_name, string customer, string flag, string flagname, double nt, double gt, double loa, double beam, double draft, string port, string portcity, string inbound, string outbound, double dollar_tl, double euro_dollar, double imo, double dmt, string operation, string v, int anchorage_day, string cargo_type, string tboxOtherCargoType, double cargo_weight, double notary_public_fee = 0, double sundries = 0, double agency_staff_car_expenses = 0, double launchboat_services = 0, double communication_expenses = 0, double postage = 0, double fiscalstamps = 0, double sanitaryDues = 0, double mauneldolar = 0, double maunelEuro = 0, ProformaPanel proformaPanel = null)
        {
            this.ship_name = ship_name;
            this.customer = customer;
            this.flag = flag;
            this.flagname = flagname;
            this.nt = nt;
            this.gt = gt;
            this.loa = loa;
            this.beam = beam;
            this.draft = draft;
            this.port = port;
            this.portcity = portcity;
            this.inbound = inbound;
            this.outbound = outbound;
            this.dollar_tl = dollar_tl;
            this.euro_dollar = euro_dollar;
            this.imo = imo;
            this.dmt = dmt;
            this.operation = operation;
            this.anchorage_day = anchorage_day;
            this.cargo_type = cargo_type;
            this.cargo_type2 = tboxOtherCargoType;
            this.cargo_weight = cargo_weight;
            this.notary_public_fee = notary_public_fee;
            this.sundries = sundries;
            this.agency_staff_car_expenses = agency_staff_car_expenses;
            this.launchboat_services = launchboat_services;
            this.communication_expenses = communication_expenses;
            this.postage = postage;
            this.Fiscalstamps = fiscalstamps;
            this.SanitaryDues = sanitaryDues;
            this.mauneldolar = mauneldolar;
            this.maunelEuro = maunelEuro;
            this._proformaPanel = proformaPanel; // Referansı sakla
            InitializeComponent();
        }
        static double Yuvarla1000Ustune(double sayi)
        {
            double islem_sayisi = sayi;
            while (islem_sayisi % 1000 != 0)
            {
                islem_sayisi++;
            }
            return islem_sayisi;
        }

        public double CalculateSanitaryDues()
        {
            if (dollar_tl == 0)
            {
                return Math.Round((nt * 17.27) / mauneldolar);
            }
            return Math.Round((nt * 17.27) / dollar_tl);
        }

        public double CalculateLightDues()
        {
            if (nt <= 800)
            {
                return (800 * 0.2112) * 2;
            }
            else
            {
                double total = 0;
                total += 800 * 0.2112;
                total += (nt - 800) * 0.1056;
                return Math.Round(total * 2);
            }
        }

        public double CalculateVts()
        {

            if (nt >= 300 && nt <= 2000)
            {
                return 88 * 2;
            }
            else if (nt >= 2001 && nt <= 5000)
            {
                return 176 * 2;
            }
            else if (nt >= 5001 && nt <= 10000)
            {
                return 330 * 2;
            }
            else if (nt >= 10001 && nt <= 20000)
            {
                return 495 * 2;
            }
            else if (nt >= 20001 && nt <= 50000)
            {
                return 660 * 2;
            }
            else if (nt > 50000)
            {
                return 990 * 2;
            }
            else
            {
                return -1;
            }
        }
        //türkiye için etap bulduk
        public double EtapBul()
        {
            double[] kabotaj = {
             1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
             11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
             21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
             31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
             41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
             51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
             61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
             71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
             81000, 82000, 83000, 84000, 85000
               };

            // etap dizisi
            double[] etap = {
             98.8, 146.25, 193.7, 241.15, 288.6, 336.05, 383.5, 430.95, 478.4, 525.85,
             573.3, 620.75, 668.2, 715.65, 763.1, 810.55, 858, 905.45, 952.9, 1000.35,
             1047.8, 1095.25, 1142.7, 1190.15, 1237.6, 1285.05, 1332.5, 1379.95, 1427.4, 1474.85,
             1522.3, 1569.75, 1617.2, 1664.65, 1712.1, 1759.55, 1807, 1854.45, 1901.9, 1949.35,
             1996.8, 2044.25, 2091.7, 2139.15, 2186.6, 2234.05, 2281.5, 2328.95, 2376.4, 2423.85,
             2471.3, 2518.75, 2566.2, 2613.65, 2661.1, 2708.55, 2756, 2803.45, 2850.9, 2898.35,
             2945.8, 2993.25, 3040.7, 3088.15, 3135.6, 3183.05, 3230.5, 3277.95, 3325.4, 3372.85,
             3420.3, 3467.75, 3515.2, 3562.65, 3610.1, 3657.55, 3705, 3752.45, 3799.9, 3847.35,
             3894.8, 3942.25, 3989.7, 4037.15, 4084.6
               };
            double result = etap[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)
            for (int i = 0; i < kabotaj.Length; i++)
            {
                if (gt <= kabotaj[i])
                {
                    result = etap[i];
                    break;
                }
            }
            return result * 2;
        }
        //türkiye için pilotaj bulduk
        public double pılotajbul()
        {
            double[] limits = {
               1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
               11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
               21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
               31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
               41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
               51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
               61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
               71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
               81000, 82000, 83000, 84000, 85000
            };
            double[] pilotaj = {
                91, 123.5, 156, 188.5, 221, 253.5, 286, 318.5, 351, 383.5,
                416, 448.5, 481, 513.5, 546, 578.5, 611, 643.5, 676, 708.5,
                741, 773.5, 806, 838.5, 871, 903.5, 936, 968.5, 1001, 1033.5,
                1066, 1098.5, 1131, 1163.5, 1196, 1228.5, 1261, 1293.5, 1326, 1358.5,
                1391, 1423.5, 1456, 1488.5, 1521, 1553.5, 1586, 1618.5, 1651, 1683.5,
                1716, 1748.5, 1781, 1813.5, 1846, 1878.5, 1911, 1943.5, 1976, 2008.5,
                2041, 2073.5, 2106, 2138.5, 2171, 2203.5, 2236, 2268.5, 2301, 2333.5,
                2366, 2398.5, 2431, 2463.5, 2496, 2528.5, 2561, 2593.5, 2626, 2658.5,
                2691, 2723.5, 2756, 2788.5, 2821
            };
            double result = pilotaj[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)
            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = pilotaj[i];
                    break;
                }
            }
            return result * 2;
        }
        //türkiye için demir bulduk
        public double demirbul()
        {
            double[] limits = {
               1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
               11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
               21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
               31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
               41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
               51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
               61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
               71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
               81000, 82000, 83000, 84000, 85000
            };
            double[] anchorage = {
               19.76, 29.25, 38.74, 48.23, 57.72, 67.21, 76.7, 86.19, 95.68, 105.17,
               114.66, 124.15, 133.64, 143.13, 152.62, 162.11, 171.6, 181.09, 190.58, 200.07,
               209.56, 219.05, 228.54, 238.03, 247.52, 257.01, 266.5, 275.99, 285.48, 294.97,
               304.46, 313.95, 323.44, 332.93, 342.42, 351.91, 361.4, 370.89, 380.38, 389.87,
               399.36, 408.85, 418.34, 427.83, 437.32, 446.81, 456.3, 465.79, 475.28, 484.77,
               494.26, 503.75, 513.24, 522.73, 532.22, 541.71, 551.2, 560.69, 570.18, 579.67,
               589.16, 598.65, 608.14, 617.63, 627.12, 636.61, 646.1, 655.59, 665.08, 674.57,
               684.06, 693.55, 703.04, 712.53, 722.02, 731.51, 741, 750.49, 759.98, 769.47,
               778.96, 788.45, 797.94, 807.43, 816.92
            };
            double result = anchorage[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)
            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = anchorage[i];
                    break;
                }
            }
            return result * 2;
        }
        //türkiye için tagbot bulduk
        public double tagbotbul()
        {
            double[] limits = {
             1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
             11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
             21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
             31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
             41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
             51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
             61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
             71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
             81000, 82000, 83000, 84000, 85000
             };
            double[] tugBoatButugBoat = {
             154.7, 187.2, 219.7, 252.2, 284.7, 317.2, 349.7, 382.2, 414.7, 447.2,
             479.7, 512.2, 544.7, 577.2, 609.7, 642.2, 674.7, 707.2, 739.7, 772.2,
             804.7, 837.2, 869.7, 902.2, 934.7, 967.2, 999.7, 1032.2, 1064.7, 1097.2,
             1129.7, 1162.2, 1194.7, 1227.2, 1259.7, 1292.2, 1324.7, 1357.2, 1389.7, 1422.2,
             1454.7, 1487.2, 1519.7, 1552.2, 1584.7, 1617.2, 1649.7, 1682.2, 1714.7, 1747.2,
             1779.7, 1812.2, 1844.7, 1877.2, 1909.7, 1942.2, 1974.7, 2007.2, 2039.7, 2072.2,
             2104.7, 2137.2, 2169.7, 2202.2, 2234.7, 2267.2, 2299.7, 2332.2, 2364.7, 2397.2,
             2429.7, 2462.2, 2494.7, 2527.2, 2559.7, 2592.2, 2624.7, 2657.2, 2689.7, 2722.2,
             2754.7, 2787.2, 2819.7, 2852.2, 2884.7
             };
            double result = tugBoatButugBoat[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)
            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = tugBoatButugBoat[i];
                    break;
                }
            }
            return result * 4;
        }
        //türkiye için morning bulduk
        public double morningbul()
        {
            double[] limits = {
             1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
             11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
             21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
             31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
             41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
             51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
             61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
             71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
             81000, 82000, 83000, 84000, 85000
             };
            double[] mooring = {
            14.3, 22.1, 29.9, 37.7, 45.5, 53.3, 61.1, 68.9, 76.7, 84.5,
            92.3, 100.1, 107.9, 115.7, 123.5, 131.3, 139.1, 146.9, 154.7, 162.5,
            170.3, 178.1, 185.9, 193.7, 201.5, 209.3, 217.1, 224.9, 232.7, 240.5,
            248.3, 256.1, 263.9, 271.7, 279.5, 287.3, 295.1, 302.9, 310.7, 318.5,
            326.3, 334.1, 341.9, 349.7, 357.5, 365.3, 373.1, 380.9, 388.7, 396.5,
            404.3, 412.1, 419.9, 427.7, 435.5, 443.3, 451.1, 458.9, 466.7, 474.5,
            482.3, 490.1, 497.9, 505.7, 513.5, 521.3, 529.1, 536.9, 544.7, 552.5,
            560.3, 568.1, 575.9, 583.7, 591.5, 599.3, 607.1, 614.9, 622.7, 630.5,
            638.3, 646.1, 653.9, 661.7, 669.5
            };
            double result = mooring[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)
            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = mooring[i];
                    break;
                }
            }
            return result * 2;
        }
        public double EtapPortInOutBul()
        {
            double[] limits = {
             1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
             11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
             21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
             31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
             41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
             51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
             61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
             71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
             81000, 82000, 83000, 84000, 85000, 86000, 87000, 88000, 89000, 90000,
             91000, 92000, 93000, 94000, 95000, 96000, 97000, 98000, 99000, 100000,
             101000, 102000, 103000, 104000, 105000, 106000, 107000, 108000, 109000, 110000,
             111000, 112000, 113000, 114000, 115000, 116000, 117000, 118000, 119000, 120000,
             121000, 122000, 123000, 124000, 125000, 126000, 127000, 128000, 129000, 130000,
             131000, 132000, 133000
            };


            // B hücresine karşılık gelen değerler
            double[] bValues = {
              198, 293, 387, 482, 577, 672, 767, 862, 957, 1052,
              1147, 1242, 1336, 1431, 1526, 1621, 1716, 1811, 1906, 2001,
              2096, 2191, 2285, 2380, 2475, 2570, 2665, 2760, 2855, 2950,
              3045, 3140, 3234, 3329, 3424, 3519, 3614, 3709, 3804, 3899,
              3994, 4089, 4183, 4278, 4373, 4468, 4563, 4658, 4753, 4848,
              4943, 5038, 5132, 5227, 5322, 5417, 5512, 5607, 5702, 5797,
              5892, 5987, 6081, 6176, 6271, 6366, 6461, 6556, 6651, 6746,
              6841, 6936, 7030, 7125, 7220, 7315, 7410, 7505, 7600, 7695,
              7790, 7885, 7979, 8074, 8169, 8264, 8359, 8454, 8549, 8644,
              8739, 8834, 8928, 9023, 9118, 9213, 9308, 9403, 9498, 9593,
              9688, 9783, 9877, 9972, 10067, 10162, 10257, 10352, 10447, 10542,
              10637, 10732, 10826, 10921, 11016, 11111, 11206, 11301, 11396, 11491,
              11586, 11681, 11775, 11870, 11965, 12060, 12155, 12250, 12345, 12440,
              12535, 12630, 12724
             };
            double result = bValues[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)

            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }
            return result * 2;
        }
        public double CalculatePilotageBerthUnberth()
        {
            double[] limits = {
             1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
             11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
             21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
             31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
             41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
             51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
             61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
             71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
             81000, 82000, 83000, 84000, 85000, 86000, 87000, 88000, 89000, 90000,
             91000, 92000, 93000, 94000, 95000, 96000, 97000, 98000, 99000, 100000,
             101000, 102000, 103000, 104000, 105000, 106000, 107000, 108000, 109000, 110000,
             111000, 112000, 113000, 114000, 115000, 116000, 117000, 118000, 119000, 120000,
             121000, 122000, 123000, 124000, 125000, 126000, 127000, 128000, 129000, 130000,
             131000, 132000, 133000
            };


            int[] bValues = {
             256, 361, 467, 572, 677, 783, 888, 993, 1099, 1204,
             1309, 1414, 1520, 1625, 1730, 1836, 1941, 2046, 2152, 2257,
             2362, 2467, 2573, 2678, 2783, 2889, 2994, 3099, 3205, 3310,
             3415, 3520, 3626, 3731, 3836, 3942, 4047, 4152, 4258, 4363,
             4468, 4573, 4679, 4784, 4889, 4995, 5100, 5205, 5311, 5416,
             5521, 5626, 5732, 5837, 5942, 6048, 6153, 6258, 6364, 6469,
             6574, 6679, 6785, 6890, 6995, 7101, 7206, 7311, 7417, 7522,
             7627, 7732, 7838, 7943, 8048, 8154, 8259, 8364, 8470, 8575,
             8680, 8785, 8891, 8996, 9101, 9207, 9312, 9417, 9523, 9628,
             9733, 9838, 9944, 10049, 10154, 10260, 10365, 10470, 10576, 10681,
             10786, 10891, 10997, 11102, 11207, 11313, 11418, 11523, 11629, 11734,
             11839, 11944, 12050, 12155, 12260, 12366, 12471, 12576, 12682, 12787,
             12892, 12997, 13103, 13208, 13313, 13419, 13524, 13629, 13735, 13840,
             13945, 14050, 14156
            };


            double result = bValues[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)

            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }

            return result * 2;
        }
        public double CalculateAnchor()
        {
            double[] limits = {
             1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
             11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
             21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
             31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
             41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
             51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
             61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
             71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
             81000, 82000, 83000, 84000, 85000, 86000, 87000, 88000, 89000, 90000,
             91000, 92000, 93000, 94000, 95000, 96000, 97000, 98000, 99000, 100000,
             101000, 102000, 103000, 104000, 105000, 106000, 107000, 108000, 109000, 110000,
             111000, 112000, 113000, 114000, 115000, 116000, 117000, 118000, 119000, 120000,
             121000, 122000, 123000, 124000, 125000, 126000, 127000, 128000, 129000, 130000,
             131000, 132000, 133000
            };

            int[] bValues = {
             40, 59, 77, 96, 115, 134, 153, 172, 191, 210,
             229, 248, 267, 286, 305, 324, 343, 362, 381, 400,
             419, 438, 457, 476, 495, 514, 533, 552, 571, 590,
             609, 628, 647, 666, 685, 704, 723, 742, 761, 780,
             799, 818, 837, 856, 875, 894, 913, 932, 951, 970,
             989, 1008, 1026, 1045, 1064, 1083, 1102, 1121, 1140, 1159,
             1178, 1197, 1216, 1235, 1254, 1273, 1292, 1311, 1330, 1349,
             1368, 1387, 1406, 1425, 1444, 1463, 1482, 1501, 1520, 1539,
             1558, 1577, 1596, 1615, 1634, 1653, 1672, 1691, 1710, 1729,
             1748, 1767, 1786, 1805, 1824, 1843, 1862, 1881, 1900, 1919,
             1938, 1957, 1975, 1994, 2013, 2032, 2051, 2070, 2089, 2108,
             2127, 2146, 2165, 2184, 2203, 2222, 2241, 2260, 2279, 2298,
             2317, 2336, 2355, 2374, 2393, 2412, 2431, 2450, 2469, 2488,
             2507, 2526, 2545
            };


            double result = bValues[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)

            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }

            return result * 2;
        }

        public double CalculateTugBoat()
        {
            double[] limits = {
             1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
             11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
             21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
             31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
             41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
             51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
             61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
             71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
             81000, 82000, 83000, 84000, 85000, 86000, 87000, 88000, 89000, 90000,
             91000, 92000, 93000, 94000, 95000, 96000, 97000, 98000, 99000, 100000,
             101000, 102000, 103000, 104000, 105000, 106000, 107000, 108000, 109000, 110000,
             111000, 112000, 113000, 114000, 115000, 116000, 117000, 118000, 119000, 120000,
             121000, 122000, 123000, 124000, 125000, 126000, 127000, 128000, 129000, 130000,
             131000, 132000, 133000
             };

            int[] bValues = {
             485, 576, 667, 758, 849, 940, 1031, 1122, 1213, 1304,
             1395, 1486, 1577, 1668, 1759, 1850, 1941, 2032, 2123, 2214,
             2305, 2396, 2487, 2578, 2669, 2760, 2851, 2942, 3033, 3124,
             3215, 3306, 3397, 3488, 3579, 3670, 3761, 3852, 3943, 4034,
             4125, 4216, 4307, 4398, 4489, 4580, 4671, 4762, 4853, 4944,
             5035, 5126, 5217, 5308, 5399, 5490, 5581, 5672, 5763, 5854,
             5945, 6036, 6127, 6218, 6309, 6400, 6491, 6582, 6673, 6764,
             6855, 6946, 7037, 7128, 7219, 7310, 7401, 7492, 7583, 7674,
             7765, 7856, 7947, 8038, 8129, 8220, 8311, 8402, 8493, 8584,
             8675, 8766, 8857, 8948, 9039, 9130, 9221, 9312, 9403, 9494,
             9585, 9676, 9767, 9858, 9949, 10040, 10131, 10222, 10313, 10404,
             10495, 10586, 10677, 10768, 10859, 10950, 11041, 11132, 11223, 11314,
             11405, 11496, 11587, 11678, 11769, 11860, 11951, 12042, 12133, 12224,
             12315, 12406, 12497
            };
            double result = bValues[^1]; // Varsayılan olarak en son değeri ata
            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }
            if (gt < 5000)
            {
                return result * 2;
            }
            else
            {
                return (gt > 45000) ? result * 7 : result * 4;
            }

        }

        public double CalculateMooring()
        {
            double[] limits = {
             1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000,
             11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
             21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
             31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000, 40000,
             41000, 42000, 43000, 44000, 45000, 46000, 47000, 48000, 49000, 50000,
             51000, 52000, 53000, 54000, 55000, 56000, 57000, 58000, 59000, 60000,
             61000, 62000, 63000, 64000, 65000, 66000, 67000, 68000, 69000, 70000,
             71000, 72000, 73000, 74000, 75000, 76000, 77000, 78000, 79000, 80000,
             81000, 82000, 83000, 84000, 85000, 86000, 87000, 88000, 89000, 90000,
             91000, 92000, 93000, 94000, 95000, 96000, 97000, 98000, 99000, 100000,
             101000, 102000, 103000, 104000, 105000, 106000, 107000, 108000, 109000, 110000,
             111000, 112000, 113000, 114000, 115000, 116000, 117000, 118000, 119000, 120000,
             121000, 122000, 123000, 124000, 125000, 126000, 127000, 128000, 129000, 130000,
             131000, 132000, 133000
            };
            double[] bValues = {
             28.6, 42.9, 57.2, 71.5, 85.8, 100.1, 114.4, 128.7, 143, 157.3,
             171.6, 185.9, 200.2, 214.5, 228.8, 243.1, 257.4, 271.7, 286, 300.3,
             314.6, 328.9, 343.2, 357.5, 371.8, 386.1, 400.4, 414.7, 429, 443.3,
             457.6, 471.9, 486.2, 500.5, 514.8, 529.1, 543.4, 557.7, 572, 586.3,
             600.6, 614.9, 629.2, 643.5, 657.8, 672.1, 686.4, 700.7, 715, 729.3,
             743.6, 757.9, 772.2, 786.5, 800.8, 815.1, 829.4, 843.7, 858, 872.3,
             886.6, 900.9, 915.2, 929.5, 943.8, 958.1, 972.4, 986.7, 1001, 1015.3,
             1029.6, 1043.9, 1058.2, 1072.5, 1086.8, 1101.1, 1115.4, 1129.7, 1144,
             1158.3, 1172.6, 1186.9, 1201.2, 1215.5, 1229.8, 1244.1, 1258.4, 1272.7,
             1287, 1301.3, 1315.6, 1329.9, 1344.2, 1358.5, 1372.8, 1387.1, 1401.4,
             1415.7, 1430, 1444.3, 1458.6, 1472.9, 1487.2, 1501.5, 1515.8, 1530.1,
             1544.4, 1558.7, 1573, 1587.3, 1601.6, 1615.9, 1630.2, 1644.5, 1658.8,
             1673.1, 1687.4, 1701.7, 1716, 1730.3, 1744.6, 1758.9, 1773.2, 1787.5,
             1801.8, 1816.1, 1830.4, 1844.7, 1859, 1873.3, 1887.6, 1901.9, 1916.2
             };
            double result = bValues[^1]; // Varsayılan olarak en son değeri ata (eğer hiçbir koşula uymazsa)

            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }

            return result * 2;
        }
        public double CalculateGarbageFee()
        {
            int[] limits = { 1000, 5000, 10000, 15000, 20000, 25000, 35000, 60000, int.MaxValue };

            // B hücresine karşılık gelen yeni değerler
            int[] bValues = { 80, 140, 210, 250, 300, 350, 400, 540, 720 };

            int result = bValues[^1]; // Varsayılan olarak en büyük değeri ata

            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }
            if (euro_dollar == 0)
            {
                return Math.Ceiling(result * maunelEuro);
            }
            else
            {
                return Math.Ceiling(result * euro_dollar);
            }

        }
        public double Poashizmet()
        {
            if (gt <= 3000)
                return gt * 0.80;
            else if (gt <= 5000)
                return gt * 0.50;
            else if (gt <= 7000)
                return gt * 0.45;
            else if (gt <= 9000)
                return gt * 0.40;
            else if (gt <= 11000)
                return gt * 0.35;
            else if (gt <= 15000)
                return gt * 0.30;
            else if (gt <= 23000)
                return gt * 0.25;
            else
                return gt * 0.20;
        }
        public double CalculatePortDuty()
        {
            if (port.Contains("Likit"))
            {
                double result = 0.1 * gt;
                if (euro_dollar == 0)
                {
                    return result * maunelEuro;
                }

                return result * euro_dollar;
            }
            else if (portcity.Contains("Marmara") || port.Contains("POAS"))
            {
                double edited_gt = Math.Ceiling(gt / 1000.0) * 1000;
                return ((edited_gt / 1000) * 30) * anchorage_day;
            }
            else
            {
                double edited_gt = Math.Ceiling(gt / 1000.0) * 1000;
                return ((edited_gt / 1000) * 30);
            }

        }
        public double CalculateMooringSafetyServices()
        {

            if (port.Contains("Likit") && flag == "Turkey")
            {
                double edited_gt = Math.Floor(gt / 1000.0) * 1000;

                return (((edited_gt / 1000) * 30) + 150) / 2;
            }

            else if (port.Contains("Likit") && flag == "Foreign")
            {
                double edited_gt = Math.Floor(gt / 1000.0) * 1000;
                if (euro_dollar == 0)
                {
                    return (((edited_gt / 1000) * 75) + 350) * maunelEuro;
                }
                return (((edited_gt / 1000) * 75) + 350) * euro_dollar;
            }
            else
            {
                double edited_gt = Math.Floor(gt / 1000.0) * 1000;

                return ((edited_gt / 1000) * 30) + 150;
            }
        }
        public double LoadingMasterFee()
        {
            if (port.Contains("Likit"))
            {

                if (cargo_type == "Crude oil and petroleum products")
                {
                    if (euro_dollar == 0)
                    {
                        return (cargo_weight * 0.35) * maunelEuro;
                    }
                    return (cargo_weight * 0.35) * euro_dollar;
                }

            }
            else
            {
                return (cargo_weight * 1.11 * 0.045);
            }
            return 0;
        }
        public double CalculateWharfage()
        {
            if (portcity.Contains("Marmara"))
            {
                return Math.Ceiling(port_duty + mooring_safety_services + loading_master_fee);
            }
            else if (portcity.Contains("İzmit"))
            {
                if (port.Contains("Poliport"))
                {
                    if (port_duty < 400)
                    {
                        return 400;
                    }
                    else
                    {
                        return Math.Ceiling(port_duty);
                    }
                }
                else if (port == "POAS Terminal")
                {
                    return Math.Ceiling(port_duty + 1000 + poashizmet);
                }
                else
                {
                    return Math.Ceiling(port_duty + mooring_safety_services);
                }
            }
            else
            {
                return Math.Ceiling(port_duty + mooring_safety_services + loading_master_fee);
            }

        }
        public double HarbourMasterDues()
        {
            int[] limits = { 500, 2000, 4000, 8000, 10000, 30000, 50000, int.MaxValue };
            double[] bValues = { 1079, 2879, 5757, 8636, 14393, 28786, 43179, 71965 };
            double result = bValues[^1];
            for (int i = 0; i < limits.Length; i++)
            {
                if (nt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }
            if (dollar_tl == 0)
            {
                return result / mauneldolar;
            }
            return result / dollar_tl;


            //int[] limitsgt = { 500, 1000, 1500, 2000, 2500, 5000, 10000, 25000, 35000, 50000, int.MaxValue };
            //double[] tlValues = { 1400, 2800, 2800, 4200, 4200, 4900, 5600, 6300, 7000, 7500, 8000 };
            //double resultgt = tlValues[^1];
            //for (int i = 0; i < limits.Length; i++)
            //{
            //    if (gt <= limits[i])
            //    {
            //        result = tlValues[i];
            //        break;
            //    }
            //}

            //double y = result / dollar_tl;



            //int[] cargoLimits = { 20000, 40000, 60000, 100000, int.MaxValue };
            //double[] cargoValues = { 650, 1000, 1300, 1600, 2000 };

            //double cargoResult = cargoValues[^1]; // Varsayılan olarak en büyük değer

            //for (int i = 0; i < cargoLimits.Length; i++)
            //{
            //    if (cargo_weight <= cargoLimits[i])
            //    {
            //        cargoResult = cargoValues[i];
            //        break;
            //    }
            //}
            //return x+y+ cargoResult;


        }
        public double PortServiceFees()
        {
            int[] limits = { 500, 1000, 1500, 2000, 2500, 5000, 10000, 25000, 35000, 50000, int.MaxValue };
            double[] bValues = { 1400, 2800, 2800, 4200, 4200, 4900, 5600, 6300, 7000, 7500, 8000 };

            double result = bValues[^1]; // Varsayılan olarak en büyük değeri ata

            for (int i = 0; i < limits.Length; i++)
            {
                if (gt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }
            if (dollar_tl == 0)
            {
                return result / mauneldolar;
            }
            return result / dollar_tl;
        }
        public double ChamberShipFee()
        {
            int[] limits = { 20000, 40000, 60000, 100000, int.MaxValue };
            double[] bValues = { 650, 1000, 1300, 1600, 2000 };

            double result = bValues[^1]; // Varsayılan olarak en büyük değeri ata


            for (int i = 0; i < limits.Length; i++)
            {
                if (cargo_weight * 1.11 <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }
            return result;
        }
        public double CalculateLCB()
        {
            int[] limits = { 500, 2000, 4000, 8000, 10000, 30000, 500000, int.MaxValue };
            int[] bValues = { 200, 500, 1200, 1800, 2400, 4800, 7200, 8000 };

            int result = bValues[^1]; // Varsayılan olarak en büyük değeri ata

            for (int i = 0; i < limits.Length; i++)
            {
                if (nt <= limits[i])
                {
                    result = bValues[i];
                    break;
                }
            }
            if (dollar_tl == 0)
            {
                return ((result * 2) / mauneldolar);
            }
            return ((result * 2) / dollar_tl);

        }
        public double CalculateAgencyService()
        {
            if (nt >= 0 && nt <= 500)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round(600 * maunelEuro);
                }
                else
                {
                    return Math.Round(600 * euro_dollar);
                }
            }
            else if (nt >= 501 && nt <= 1000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round(1000 * maunelEuro);
                }
                return Math.Round(1000 * euro_dollar);
            }
            else if (nt >= 1001 && nt <= 2000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round(1500 * maunelEuro);
                }
                return Math.Round(1500 * euro_dollar);
            }
            else if (nt >= 2001 && nt <= 3000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round(1850 * maunelEuro);
                }
                return Math.Round(1850 * euro_dollar);
            }
            else if (nt >= 3001 && nt <= 4000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round(2300 * maunelEuro);
                }
                return Math.Round(2300 * euro_dollar);
            }
            else if (nt >= 4001 && nt <= 5000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round(2750 * maunelEuro);
                }
                return Math.Round(2750 * euro_dollar);

            }
            else if (nt >= 5001 && nt <= 7500)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round(3200 * maunelEuro);
                }
                return Math.Round(3200 * euro_dollar);

            }
            else if (nt >= 7501 && nt <= 10000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round(4000 * maunelEuro);
                }
                return Math.Round(4000 * euro_dollar);
            }
            else if (nt >= 10000 && nt <= 20000)
            {
                double remain = (Yuvarla1000Ustune(nt - 10000)) / 1000;
                if (euro_dollar == 0)
                {
                    return Math.Round((4000 + remain * 125) * maunelEuro);
                }
                return Math.Round((4000 + remain * 125) * euro_dollar);
            }
            else if (nt >= 20001 && nt <= 30000)
            {
                double remain1 = 1250;
                double remain2 = (Yuvarla1000Ustune(nt - 20000)) / 1000;
                if (euro_dollar == 0)
                {
                    return Math.Round((4000 + remain1 + remain2 * 100) * maunelEuro);
                }
                return Math.Round((4000 + remain1 + remain2 * 100) * euro_dollar);
            }
            else
            {
                double remain1 = 1250;
                double remain2 = 1000;
                double remain3 = (Yuvarla1000Ustune(nt - 30000)) / 1000;
                if (euro_dollar == 0)
                {
                    return Math.Round((4000 + remain1 + remain2 + remain3 * 75) * maunelEuro);
                }
                return Math.Round((4000 + remain1 + remain2 + remain3 * 75) * euro_dollar);
            }
        }
        //public double CalculateSuperVisionService()
        //{
        //    //if (nt >= 0 && nt <= 500)
        //    //{
        //    //    return Math.Round(600 * euro_dollar);
        //    //}
        //    //else if (nt >= 501 && nt <= 1000)
        //    //{
        //    //    return Math.Round(1000 * euro_dollar);
        //    //}
        //    //else if (nt >= 1001 && nt <= 2000)
        //    //{
        //    //    return Math.Round(1500 * euro_dollar);
        //    //}
        //    //else if (nt >= 2001 && nt <= 3000)
        //    //{
        //    //    return Math.Round(1850 * euro_dollar);
        //    //}
        //    //else if (nt >= 3001 && nt <= 4000)
        //    //{
        //    //    return Math.Round(2300 * euro_dollar);
        //    //}
        //    //else if (nt >= 4001 && nt <= 5000)
        //    //{
        //    //    return Math.Round(2750 * euro_dollar);

        //    //}
        //    //else if (nt >= 5001 && nt <= 7500)
        //    //{
        //    //    return Math.Round(3200 * euro_dollar);

        //    //}
        //    //else if (nt >= 7501 && nt <= 10000)
        //    //{
        //    //    return Math.Round(4000 * euro_dollar);
        //    //}
        //    //else if (nt >= 10000 && nt <= 20000)
        //    //{
        //    //    double remain = (Yuvarla1000Ustune(nt - 10000)) / 1000;
        //    //    return Math.Round((4000 + remain * 125) * euro_dollar);
        //    //}
        //    //else if (nt >= 20001 && nt <= 30000)
        //    //{
        //    //    double remain1 = 1250;
        //    //    double remain2 = (Yuvarla1000Ustune(nt - 20000)) / 1000;
        //    //    return Math.Round((4000 + remain1 + remain2 * 100) * euro_dollar);
        //    //}
        //    //else
        //    //{
        //    //    double remain1 = 1250;
        //    //    double remain2 = 1000;
        //    //    double remain3 = (Yuvarla1000Ustune(nt - 30000)) / 1000; ;
        //    //    return Math.Round((4000 + remain1 + remain2 + remain3 * 75) * euro_dollar);

        //    if (cargo_type.Contains("Dry"))
        //    {
        //        return CalculateDryCargo();
        //    }
        //    else if (cargo_type.Contains("Crude"))
        //    {
        //        return CalculateCrudeOil();
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}
        public double CalculateDryCargo()
        {
            if (cargo_weight >= 0 && cargo_weight <= 10000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round((cargo_weight * 0.15) * maunelEuro);
                }
                if (cargo_weight * 0.15 < 300)
                {
                    return Math.Round(300 * euro_dollar);
                }
                else
                {
                    return Math.Round((cargo_weight * 0.15) * euro_dollar);
                }

            }
            else if (cargo_weight >= 10001 && cargo_weight <= 20000)
            {
                double remain1 = 1500;
                double remain2 = (cargo_weight - 10000) * 0.10;
                if (euro_dollar == 0)
                {
                    return Math.Round((remain1 + remain2) * maunelEuro);
                }
                return Math.Round((remain1 + remain2) * euro_dollar);
            }
            else
            {
                double remain1 = 1500;
                double remain2 = 1000;
                double remain3 = (cargo_weight - 20000) * 0.05;
                if (euro_dollar == 0)
                {
                    return Math.Round((remain1 + remain2 + remain3) * maunelEuro);
                }
                return Math.Round((remain1 + remain2 + remain3) * euro_dollar);
            }
        }


        public double CalculateCrudeOil()
        {
            if (cargo_weight >= 0 && cargo_weight <= 15000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round((cargo_weight * 0.040) * maunelEuro);
                }
                if (cargo_weight * 0.040 < 300)
                {
                    return Math.Round(300 * euro_dollar);
                }
                else
                {
                    return Math.Round((cargo_weight * 0.040) * euro_dollar);
                }
            }
            else if (cargo_weight >= 15001 && cargo_weight <= 35000)
            {
                double remain1 = 600;
                double remain2 = (cargo_weight - 15000) * 0.030;
                if (euro_dollar == 0)
                {
                    return Math.Round((remain1 + remain2) * maunelEuro);
                }
                return Math.Round((remain1 + remain2) * euro_dollar);
            }
            else
            {
                double remain1 = 600;
                double remain2 = 600;
                double remain3 = (cargo_weight - 35000) * 0.015;
                if (euro_dollar == 0)
                {
                    return Math.Round((remain1 + remain2 + remain3) * maunelEuro);
                }
                return Math.Round((remain1 + remain2 + remain3) * euro_dollar);
            }
        }
        public double CalculateLPG()
        {
            if (cargo_weight >= 0 && cargo_weight <= 15000)
            {
                if (euro_dollar == 0)
                {
                    return Math.Round((cargo_weight * 0.15) * maunelEuro);
                }
                if (cargo_weight * 0.15 < 300)
                {
                    return Math.Round(300 * euro_dollar);
                }
                else
                {
                    return Math.Round((cargo_weight * 0.15) * euro_dollar);
                }
            }
            else
            {
                double remain1 = 2250;
                double remain2 = (cargo_weight - 15000) * 0.05;
                if (euro_dollar == 0)
                {
                    return Math.Round((remain1 + remain2) * maunelEuro);
                }
                return Math.Round((remain1 + remain2) * euro_dollar);
            }
        }
        public double CalculateChemical()
        {
            if (euro_dollar == 0)
            {
                return Math.Round((cargo_weight * 0.15) * maunelEuro);
            }
            if (cargo_weight * 0.15 < 300)
            {
                return Math.Round(300 * euro_dollar);
            }
            else
            {
                return Math.Round((cargo_weight * 0.15) * euro_dollar);
            }
        }
        public double Calculatepilotage()
        {
            if (portcity.Contains("Marmara"))
            {
                return BerthUnberth;
            }
            else if (portcity.Contains("İzmit"))
            {
                return BerthUnberth + anchor + EtapPortInOut;
            }
            else if (portcity.Contains("Mersin"))
            {
                return BerthUnberth * 1.15;
            }
            else
            {
                return 0;
            }
        }


        double sanitary_dues = 0;
        double light_dues = 0;
        double VTS = 0;
        double EtapPortInOut = 0;
        double BerthUnberth = 0;
        double anchor = 0;
        double pilotageFees = 0;
        double tugboat = 0;
        double mooring = 0;
        double garbage_fee = 0;
        double port_duty = 0;
        double mooring_safety_services = 0;
        double loading_master_fee = 0;
        double wharfage_fee = 0;
        double harbour_master_co_shipping = 0;
        double harbour_master_dues = 0;
        double port_service_fees = 0;
        double chamber_ship_fee = 0;
        double overtime_dues = 0;
        double agency_service = 0;
        double supervision_services = 0;
        double newberth;
        double poashizmet = 0;
        private void ResultPanel_Load(object sender, EventArgs e)
        {
            if (flag == "Turkey")
            {
                sanitary_dues = CalculateSanitaryDues();
                labelSanitaryDues.Text = "Sanitary Dues : " + sanitary_dues.ToString() + "$";

                sanitary_dues = CalculateSanitaryDues();
                labelSanitaryDues.Text = "Sanitary Dues : " + sanitary_dues.ToString() + "$";

                VTS = CalculateVts();
                labelVTS.Text = "VTS : " + VTS.ToString() + "$";
                if (portcity == "Marmara Ereğlisi & Tekirdağ")
                {
                    VTS = 0;
                }
                light_dues = CalculateLightDues();
                labelLightDues.Text = "Light Dues : " + light_dues.ToString() + "$";

                EtapPortInOut = EtapBul();
                BerthUnberth = pılotajbul();
                anchor = demirbul();
                pilotageFees = EtapPortInOut + BerthUnberth + anchor;
                labelPilotageFees.Text = "Pilotage Fees : " + BerthUnberth.ToString() + "$";

                tugboat = tagbotbul();
                labelTugboat.Text = "Tugboat : " + tugboat.ToString() + "$";

                mooring = morningbul();
                labelMooring.Text = "Mooring : " + mooring.ToString() + "$";

                garbage_fee = CalculateGarbageFee();
                labelGarbageFee.Text = "Garbage Fee : " + garbage_fee.ToString() + "$";

                port_duty = CalculatePortDuty();
                mooring_safety_services = CalculateMooringSafetyServices();
                loading_master_fee = LoadingMasterFee();
                wharfage_fee = 0;
                harbour_master_co_shipping = 0;
                wharfage_fee = Math.Ceiling(port_duty + mooring_safety_services + loading_master_fee);
                harbour_master_dues = HarbourMasterDues();
                port_service_fees = PortServiceFees();
                chamber_ship_fee = ChamberShipFee();
                harbour_master_co_shipping = Math.Ceiling(harbour_master_dues + port_service_fees + chamber_ship_fee);

                labelHarbourMasterCoShipping.Text = "Harbour Master Co Shipping : " + harbour_master_dues.ToString() + "$";
                labelWharfageFee.Text = "Wharfage Fee : " + wharfage_fee.ToString() + "$";

                lcb = CalculateLCB();
                overtime_dues = 0;
                if (portcity == "Marmara Ereğlisi & Tekirdağ")
                {
                    overtime_dues = Math.Ceiling(lcb + 134);
                    labelOvertimeDues.Text = "Overtime Dues : " + overtime_dues.ToString() + "$";
                }
                else if (portcity == "İzmit")
                {
                    overtime_dues = (lcb + (8600 / dollar_tl));
                    labelOvertimeDues.Text = "Overtime Dues : " + overtime_dues.ToString() + "$";
                }

                agency_service = CalculateAgencyService();
                labelAgencyService.Text = "Agency Services : " + agency_service.ToString() + "$";

                supervision_services = 0;

                if (cargo_type.Contains("Dry"))
                {
                    supervision_services = CalculateDryCargo();
                    labelSupervisionServices.Text = "Supervision Services : " + supervision_services.ToString() + "$";
                }
                else if (cargo_type.Contains("Crude"))
                {
                    supervision_services = CalculateCrudeOil();
                    labelSupervisionServices.Text = "Supervision Services : " + supervision_services.ToString() + "$";
                }
                else if (cargo_type.Contains("LPG"))
                {
                    supervision_services = CalculateLPG();
                    labelSupervisionServices.Text = "Supervision Services : " + supervision_services.ToString() + "$";
                }
                else if (cargo_type.Contains("Chemical"))
                {
                    supervision_services = CalculateChemical();
                    labelSupervisionServices.Text = "Supervision Services : " + supervision_services.ToString() + "$";
                }

            }



















            else
            {
                sanitary_dues = CalculateSanitaryDues();
                labelSanitaryDues.Text = "Sanitary Dues : " + sanitary_dues.ToString() + "$";

                sanitary_dues = CalculateSanitaryDues();
                labelSanitaryDues.Text = "Sanitary Dues : " + sanitary_dues.ToString() + "$";

                light_dues = CalculateLightDues();
                labelLightDues.Text = "Light Dues : " + light_dues.ToString() + "$";

                VTS = CalculateVts();
                if (portcity == "Marmara Ereğlisi & Tekirdağ")
                {
                    VTS = 0;
                }
                labelVTS.Text = "VTS : " + VTS.ToString() + "$";

                EtapPortInOut = EtapPortInOutBul();
                BerthUnberth = CalculatePilotageBerthUnberth();
                anchor = CalculateAnchor();

                pilotageFees = Calculatepilotage();
                labelPilotageFees.Text = "Pilotage Fees : " + pilotageFees.ToString() + "$";

                tugboat = CalculateTugBoat();
                labelTugboat.Text = "Tugboat : " + tugboat.ToString() + "$";

                mooring = Math.Floor(CalculateMooring());
                labelMooring.Text = "Mooring : " + mooring.ToString() + "$";

                garbage_fee = Math.Floor(CalculateGarbageFee());
                labelGarbageFee.Text = "Garbage Fee : " + garbage_fee.ToString() + "$";

                port_duty = CalculatePortDuty();
                mooring_safety_services = CalculateMooringSafetyServices();
                loading_master_fee = LoadingMasterFee();
                harbour_master_co_shipping = 0;
                poashizmet = Math.Floor(Poashizmet());
                wharfage_fee = CalculateWharfage();
                harbour_master_dues = HarbourMasterDues();
                port_service_fees = PortServiceFees();
                chamber_ship_fee = ChamberShipFee();
                harbour_master_co_shipping = Math.Ceiling(harbour_master_dues + port_service_fees + chamber_ship_fee);

                labelHarbourMasterCoShipping.Text = "Harbour Master Co Shipping : " + harbour_master_co_shipping.ToString() + "$";
                labelWharfageFee.Text = "Wharfage Fee : " + wharfage_fee.ToString() + "$";
                lcb = Math.Floor(CalculateLCB());
                overtime_dues = 0;
                if (portcity == "Marmara Ereğlisi & Tekirdağ")
                {
                    overtime_dues = Math.Ceiling(lcb + 134);
                    labelOvertimeDues.Text = "Overtime Dues : " + overtime_dues.ToString() + "$";
                }
                else if (portcity == "İzmit")
                {
                    overtime_dues = Math.Ceiling(lcb + (8600 / dollar_tl));
                    labelOvertimeDues.Text = "Overtime Dues : " + overtime_dues.ToString() + "$";
                }
                agency_service = CalculateAgencyService();
                labelAgencyService.Text = "Agency Services : " + agency_service.ToString() + "$";
                supervision_services = 0;
                if (cargo_type.Contains("Dry"))
                {
                    supervision_services = CalculateDryCargo();
                    labelSupervisionServices.Text = "Supervision Services : " + supervision_services.ToString() + "$";
                }
                else if (cargo_type.Contains("Crude"))
                {
                    supervision_services = CalculateCrudeOil();
                    labelSupervisionServices.Text = "Supervision Services : " + supervision_services.ToString() + "$";
                }
                else if (cargo_type.Contains("LPG"))
                {
                    supervision_services = CalculateLPG();
                    labelSupervisionServices.Text = "Supervision Services : " + supervision_services.ToString() + "$";
                }
                else if (cargo_type.Contains("Chemical"))
                {
                    supervision_services = CalculateChemical();
                    labelSupervisionServices.Text = "Supervision Services : " + supervision_services.ToString() + "$";
                }
                LBLNotary.Text = notary_public_fee.ToString();
                LBLNotary.Text = "Notary Public Fee : " + notary_public_fee.ToString() + "$";
                LBLSundries.Text = sundries.ToString();
                LBLSundries.Text = "Sundries : " + sundries.ToString() + "$";
                LBLPostage.Text = postage.ToString();
                LBLPostage.Text = "Postage : " + postage.ToString() + "$";
                LBLCOEX.Text = communication_expenses.ToString();
                LBLCOEX.Text = "Communication Expenses : " + communication_expenses.ToString() + "$";
                LBLLaunch.Text = launchboat_services.ToString();
                LBLLaunch.Text = "Launchboat Services : " + launchboat_services.ToString() + "$";
                LBLAgency.Text = agency_staff_car_expenses.ToString();
                LBLAgency.Text = "Agency staff car expenses : " + agency_staff_car_expenses.ToString() + "$";
                LBLFiscal.Text = Fiscalstamps.ToString();
                LBLFiscal.Text = "Fiscal Stamps : " + Fiscalstamps.ToString() + "$";
            }
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //    // Calculate the total
            //    double total = sanitary_dues + light_dues + VTS + EtapPortInOut + BerthUnberth +
            //                   anchor + pilotageFees + tugboat + mooring + garbage_fee + port_duty +
            //                   mooring_safety_services + loading_master_fee + wharfage_fee +
            //                   harbour_master_co_shipping + harbour_master_dues + port_service_fees +
            //                   chamber_ship_fee + overtime_dues + agency_service + supervision_services;
            //    // Create a Word document
            //    XWPFDocument document = new XWPFDocument();

            //    // Tarih ve Şehir (Sağa Hizalı)
            //    XWPFParagraph dateParagraph = document.CreateParagraph();
            //    dateParagraph.Alignment = ParagraphAlignment.RIGHT;
            //    XWPFRun dateRun = dateParagraph.CreateRun();
            //    dateRun.SetText("Istanbul; " + DateTime.Now.ToString("dd.MM.yyyy"));
            //    dateRun.FontSize = 12;
            //    dateRun.FontFamily = "Comic Sans MS";
            //    dateRun.IsBold = true;

            //    // Firma Bilgileri (Kalın & İtalik)
            //    XWPFParagraph customerParagraph = document.CreateParagraph();
            //    XWPFRun customerRun = customerParagraph.CreateRun();
            //    customerRun.SetText("Messrs.:");
            //    customerRun.IsBold = true;
            //    customerRun.IsItalic = true;
            //    customerRun.FontSize = 12;
            //    customerRun.FontFamily = "Comic Sans MS";

            //    XWPFRun companyRun = customerParagraph.CreateRun();
            //    companyRun.SetText($"\n"{customer}"");
            //    companyRun.IsBold = true;
            //    companyRun.FontSize = 12;
            //    companyRun.FontFamily = "Comic Sans MS";

            //    // Konu Başlığı
            //    XWPFParagraph subjectParagraph = document.CreateParagraph();
            //    XWPFRun subjectRun = subjectParagraph.CreateRun();
            //    subjectRun.SetText($"Re: M/T "{ship_name}" – {port} Call Proforma DA");
            //    subjectRun.IsBold = true;
            //    subjectRun.FontSize = 12;
            //    subjectRun.FontFamily = "Comic Sans MS";

            //    // Giriş Metni
            //    XWPFParagraph introParagraph = document.CreateParagraph();
            //    XWPFRun introRun = introParagraph.CreateRun();
            //    introRun.SetText("Good Day,");
            //    introRun.IsBold = true;
            //    introRun.IsItalic = true;
            //    introRun.FontSize = 12;
            //    introRun.FontFamily = "Comic Sans MS";

            //    XWPFRun introBodyRun = introParagraph.CreateRun();
            //    introBodyRun.SetText("\nPleased to quote our estimated breakdown for caption vessel's call at our waters.");
            //    introBodyRun.FontSize = 12;
            //    introBodyRun.FontFamily = "Comic Sans MS";

            //    // Gemi Bilgileri
            //    XWPFParagraph shipInfoParagraph = document.CreateParagraph();
            //    XWPFRun shipInfoRun = shipInfoParagraph.CreateRun();
            //    shipInfoRun.SetText($"M/T "{ship_name}" (IMO: {imo})");
            //    shipInfoRun.IsBold = true;
            //    shipInfoRun.FontSize = 12;
            //    shipInfoRun.FontFamily = "Comic Sans MS";


            //    // Create Borderless Table with 3 Columns
            //    XWPFTable table = document.CreateTable(6, 3);

            //    table.SetBottomBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            //    table.SetLeftBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            //    table.SetRightBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            //    table.SetTopBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            //    table.SetInsideHBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            //    table.SetInsideVBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");

            //    // Fill the Table
            //    table.GetRow(0).GetCell(0).SetText("FLAG:");
            //    if (flag == "Turkey")
            //    {
            //        table.GetRow(0).GetCell(1).SetText(flag);
            //    }
            //    if (flagname == "")
            //    {
            //    }
            //    else
            //    {
            //        table.GetRow(0).GetCell(1).SetText(flagname);
            //    }
            //    table.GetRow(0).GetCell(2).SetText($"NT: {nt}");
            //    table.GetRow(1).GetCell(0).SetText("GT:");
            //    table.GetRow(1).GetCell(1).SetText(gt.ToString());
            //    table.GetRow(1).GetCell(2).SetText($"LOA: {loa} m");

            //    table.GetRow(2).GetCell(0).SetText("BEAM:");
            //    table.GetRow(2).GetCell(1).SetText($"{beam} m");
            //    table.GetRow(2).GetCell(2).SetText($"Draft: {draft} m");

            //    table.GetRow(3).GetCell(0).SetText("Port of Call:");
            //    table.GetRow(3).GetCell(1).SetText(port);
            //    table.GetRow(3).GetCell(2).SetText("");

            //    table.GetRow(4).GetCell(0).SetText("Inbound:");
            //    table.GetRow(4).GetCell(1).SetText(inbound);
            //    table.GetRow(4).GetCell(2).SetText($"Outbound: {outbound}");

            //    table.GetRow(5).GetCell(0).SetText("operation:");
            //    table.GetRow(5).GetCell(1).SetText($"{operation}");
            //    table.GetRow(5).GetCell(2).SetText("");
            //    foreach (var row in table.Rows)
            //    {
            //        row.Height = 200;  // Satır yüksekliğini ayarlayın
            //    }
            //    // Hücrelerin içine yazdığınız metinlere göre genişlikleri dinamik olarak ayarlamak
            //    foreach (var row in table.Rows)
            //    {
            //        foreach (var cell in row.GetTableCells())
            //        {
            //            // Hücre içeriğine göre boyutları ayarlayın (örneğin, padding ekleyin)
            //            cell.SetText(cell.GetText().Trim());  // Metin içeriğini düzenleme
            //        }
            //    }
            //    // Add Exchange Rate Below the Table
            //    XWPFParagraph exchangeParagraph = document.CreateParagraph();
            //    XWPFRun exchangeRun = exchangeParagraph.CreateRun();
            //    exchangeRun.SetText($"Exchange Rate: US$1.00={dollar_tl}TRY / Euro1.00={euro_dollar}US$");
            //    exchangeRun.FontSize = 12;
            //    exchangeRun.FontFamily = "Comic Sans MS";


            //    // Add Table Header
            //    XWPFParagraph tableTitleParagraph = document.CreateParagraph();
            //    XWPFRun tableTitleRun = tableTitleParagraph.CreateRun();
            //    tableTitleRun.SetText("\nFees/Dues/Expenses Table:");
            //    tableTitleRun.IsBold = true;
            //    tableTitleRun.FontSize = 12;
            //    string a = "Port in/out";
            //    if (portcity == "Marmara Ereğlisi & Tekirdağ")
            //    {
            //        a = "Port in/out Marmara Ereğlisi & Tekirdağ";
            //    }

            //    // Fee Table Data
            //    string[,] feeTable = {
            //    { "Sanitary dues", sanitary_dues.ToString("N2"), "Port in/out" },
            //    { "Light dues", light_dues.ToString("N2"), "Port in/out" },
            //    { "VTS Dues", VTS.ToString("N2"), $"{a}" },
            //    { "Pilotage fees", pilotageFees.ToString("N2"), "Berth/Unberth with 30% Tanker surcharge" },
            //    { "Towage Fee", tugboat.ToString("N2"), "2 in/ 2 out - with 30% tanker surcharge" },
            //    { "Mooring/Unmooring Fee", mooring.ToString("N2"), "Berth/Unberth with 30% Tanker surcharge" },
            //    { "Wharfage Fee", wharfage_fee.ToString("N2"), $"{port} terminal (for {anchorage_day} day)" },
            //    { "Anchorage fee", "0.00", $"pls see 2nd page" },
            //    { "Garbage Fee", garbage_fee.ToString("N2"), "Fixed    EUR" },
            //    { "H. Master & C.O. Shipping", harbour_master_co_shipping.ToString("N2"), "With 0.5% contribution to COS" },
            //    { "Notary Public fee", notary_public_fee.ToString("N2"), "If any at cost" },
            //    { "Launchboat Services", launchboat_services.ToString("N2"), "$850 to be charged for launchboat + permission exp.in case inward clearance requested at anchorage" },
            //    { "Overtime dues", overtime_dues.ToString("N2"), "For inward/outward Custom & H. Master clearance" },
            //    {"Fiscal Stamps/Stationary Ex",Fiscalstamps.ToString("N2"),"If any at cost" },
            //    { "Agency Service", agency_service.ToString("N2"), "As per tariff – Min. fee" },
            //    { "Sundries", sundries.ToString("N2"), "Routine port/cargo operations" },
            //    { "Agency staff car expenses", agency_staff_car_expenses.ToString("N2"), "Routine port/cargo operations" },
            //    { "Communication expenses", communication_expenses.ToString("N2"), "Routine port/cargo operations" },
            //    { "Supervision Services", supervision_services.ToString("N2"), "As per tariff – Min. fee" },
            //    {"Postage", postage.ToString("N2"),"FDA dispacth" },
            //    //{"Previous Balance",sanitary_dues.ToString("N2"),"As per SOA" },
            //    { "Total", total.ToString("N2"), "USD" }
            //};
            //    // Create Table
            //    XWPFTable table1 = document.CreateTable(feeTable.GetLength(0) + 1, 3);
            //    // Fill Table Data
            //    for (int i = 0; i < feeTable.GetLength(0); i++)
            //    {
            //        XWPFTableRow row = table1.GetRow(i + 1);
            //        row.GetCell(0).SetText(feeTable[i, 0]);
            //        row.GetCell(1).SetText(feeTable[i, 1]);
            //        row.GetCell(2).SetText(feeTable[i, 2]);
            //    }
            //    // Add 2nd Page Content
            //    XWPFParagraph notesParagraph = document.CreateParagraph();
            //    XWPFRun notesRun = notesParagraph.CreateRun();
            //    notesRun.IsBold = true;
            //    notesRun.SetText("Managers should note that:");
            //    notesRun.FontSize = 12;
            //    // Calculate anchorage fees
            //    double coefficient = 0.004;
            //    double anchorage_fee_per_day = gt * coefficient; // 96.26 USD per day
            //    double total_anchorage_fee = anchorage_fee_per_day * anchorage_day;
            //    XWPFParagraph detailsParagraph = document.CreateParagraph();
            //    XWPFRun detailsRun2 = detailsParagraph.CreateRun();
            //    detailsRun2.SetText(
            //        "- As per tariff, above given fees are minimum fees.\n" +
            //        "- As per tariff applied at all Turkish ports; Pilotage, tugboat assistance, and mooring service fees are subject to a 50% surcharge on official holidays.\n" +
            //        "- Customs claim huge fines against discrepancy in discharged quantity exceeding a respective percentage of the BL figure. Owners are responsible for these fines and must pay them to discharge port customs to avoid vessel arrest. Owners should instruct load port agents to issue a letter for Turkish customs immediately after discrepancy occurs at load port. (A sample letter can be provided upon request.) By accepting this proforma, you agree to all its terms and conditions.\n" +
            //        "- As per tariff applied at all Turkish ports; Anchorage fee:\n" +
            //        "  * First 72 hours: Free\n" +
            //        $"  * After 72 hours: {gt} x {coefficient} = {anchorage_fee_per_day:F2} USD per day\n" +
            //        $"    * Daily payment (up to 7 days): {anchorage_fee_per_day:F2} USD x {anchorage_day} days\n" +
            //        $"    * Monthly basis (1 month exemption): {anchorage_fee_per_day:F2} USD x 25 days = {anchorage_fee_per_day * 25:F2} USD\n" +
            //        $"    * Annual basis (1 year exemption): {anchorage_fee_per_day:F2} USD x 150 days = {anchorage_fee_per_day * 150:F2} USD\n");
            //    detailsRun2.FontSize = 12;

            //    // Add Banking Information
            //    XWPFParagraph bankInfoParagraph = document.CreateParagraph();
            //    XWPFRun bankInfoRun = bankInfoParagraph.CreateRun();
            //    bankInfoRun.IsBold = true;
            //    bankInfoRun.SetText("\nBank Details:");
            //    bankInfoRun.FontSize = 12;


            //    XWPFParagraph bankDetailsParagraph = document.CreateParagraph();
            //    XWPFRun bankDetailsRun = bankDetailsParagraph.CreateRun();
            //    bankDetailsRun.SetText(
            //        "USD\n" +
            //        "Banker: T. Garanti Bankası\n" +
            //        "Branch: Sahrayicedid / Istanbul (Branch Code: 277)\n" +
            //        "Swift: TGBATRISXXX\n" +
            //        "IBAN: TR90 0006 2000 2770 0009 0987 41\n" +
            //        "Account no.: 9098741\n" +
            //        "In favour of: Han Shipping Co. Ltd.\n" +
            //        $"Ref: M/T "{ship_name}" – OPET, Marmara Ereglisi call D/A\n");
            //    bankDetailsRun.FontSize = 12;

            //    // Closing Remarks
            //    XWPFParagraph closingParagraph = document.CreateParagraph();
            //    XWPFRun closingRun = closingParagraph.CreateRun();
            //    closingRun.SetText("\nPlease do not hesitate to contact us for further information or assistance.\nWe look forward to hearing from you soon.\n\nRespectfully yours,");
            //    closingRun.FontSize = 12;



            // Calculate the total
            double total = sanitary_dues + light_dues + VTS +
                    pilotageFees + tugboat + mooring + garbage_fee +
                    wharfage_fee +
                   harbour_master_co_shipping +
                    overtime_dues + agency_service + supervision_services + sundries + agency_staff_car_expenses + communication_expenses + postage + launchboat_services + Fiscalstamps;
            // Create a Word document
            XWPFDocument document = new XWPFDocument();

            // Resmin yolu
            string imagePath = @"C:\Users\RUSH\Desktop\OCTOAPPUS\HanShipProformaAppeng-ncel-master\HanShipProformaApp\bin\Debug\net8.0-windows\hanlogo.png";

            if (!File.Exists(imagePath))
            {
                MessageBox.Show("Resim dosyası bulunamadı.");
                return;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    fs.CopyTo(ms);
                }

                ms.Position = 0; // <-- Bu satır çok önemli!

                XWPFHeader header = document.CreateHeader(HeaderFooterType.DEFAULT);
                XWPFParagraph pictureParagraph = header.CreateParagraph();
                pictureParagraph.Alignment = ParagraphAlignment.RIGHT;

                XWPFRun pictureRun = pictureParagraph.CreateRun();

                try
                {
                    int widthInPixels = 125;  // %389 genişlik
                    int heightInPixels = 58; // %241 yükseklik

                    int widthEMU = Units.ToEMU(widthInPixels);
                    int heightEMU = Units.ToEMU(heightInPixels);

                    pictureRun.AddPicture(ms, (int)PictureType.PNG, imagePath, widthEMU, heightEMU);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim eklenirken hata oluştu: " + ex.Message);
                    return;
                }
            }






            // Tarih ve Şehir (Sağa Hizalı)
            XWPFParagraph dateParagraph = document.CreateParagraph();
            dateParagraph.Alignment = ParagraphAlignment.RIGHT;
            XWPFRun dateRun = dateParagraph.CreateRun();
            dateRun.SetText("Istanbul; " + DateTime.Now.ToString("dd.MM.yyyy"));
            dateRun.FontSize = 10;
            dateRun.FontFamily = "Comic Sans MS";

            // Firma Bilgileri (Kalın & İtalik)
            XWPFParagraph customerParagraph = document.CreateParagraph();
            XWPFRun customerRun = customerParagraph.CreateRun();
            customerRun.SetText("Messrs.:");
            customerRun.FontSize = 10;
            customerRun.FontFamily = "Comic Sans MS";

            XWPFRun companyRun = customerParagraph.CreateRun();
            companyRun.SetText($"\n\"{customer}\"");
            companyRun.IsBold = true;
            companyRun.FontSize = 10;
            companyRun.FontFamily = "Comic Sans MS";

            // Konu Başlığı
            XWPFParagraph subjectParagraph = document.CreateParagraph();
            XWPFRun subjectRun = subjectParagraph.CreateRun();
            subjectRun.SetText($"Re: M/T \"{ship_name}\" – {port} Call Proforma DA");
            subjectRun.FontSize = 10;
            subjectRun.FontFamily = "Comic Sans MS";
            subjectRun.Underline = UnderlinePatterns.Single;

            // Giriş Metni
            XWPFParagraph introParagraph = document.CreateParagraph();
            XWPFRun introRun = introParagraph.CreateRun();
            introRun.SetText("Good Day,");
            introRun.FontSize = 10;
            introRun.FontFamily = "Comic Sans MS";

            XWPFRun introBodyRun = introParagraph.CreateRun();
            introBodyRun.SetText("\nPleased to quote our estimated breakdown for caption vessel's call at our waters.");
            introBodyRun.FontSize = 10;
            introBodyRun.FontFamily = "Comic Sans MS";

            // Gemi Bilgileri
            XWPFParagraph shipInfoParagraph = document.CreateParagraph();
            XWPFRun shipInfoRun = shipInfoParagraph.CreateRun();
            shipInfoRun.SetText($"M/T \"{ship_name}\" (IMO: {imo})");
            shipInfoRun.IsBold = true;
            shipInfoRun.FontSize = 10;
            shipInfoRun.FontFamily = "Comic Sans MS";
            shipInfoRun.Underline = UnderlinePatterns.Single;
            // İlk tabloyu oluştur
            // === TABLE 1 (3x3) ===
            // Belge ve tablo oluştur

            // 1. TABLO (Üst Bilgiler)
            // 1. Tabloyu Oluştur
            // İlk Tabloyu Oluştur
            // 1. Tabloyu Oluştur
            // 1. Tabloyu Oluştur
            // 1. Tabloyu Oluştur
            XWPFTable table = document.CreateTable(4, 3);

            // Kenarlıkları gizle
            table.SetBottomBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            table.SetLeftBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            table.SetRightBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            table.SetTopBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            table.SetInsideHBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");
            table.SetInsideVBorder(XWPFTable.XWPFBorderType.NIL, 0, 0, "");

            // Hücrelerdeki metni ayarlayacak fonksiyon
            void SetCellText(XWPFTableCell cell, string text)
            {
                cell.RemoveParagraph(0);
                XWPFParagraph para = cell.AddParagraph();
                para.Alignment = ParagraphAlignment.LEFT;
                para.SpacingBetween = 1; para.SpacingBefore = 0; para.SpacingAfter = 0; // Satır aralığı ayarları
                para.IsWordWrapped = true;

                XWPFRun run = para.CreateRun();
                run.FontSize = 10;
                run.FontFamily = "Comic Sans MS";
                run.SetText(text);

                cell.SetVerticalAlignment(XWPFTableCell.XWPFVertAlign.CENTER);
            }


            // Tablonun her hücresini yazalım
            SetCellText(table.GetRow(0).GetCell(0), $"FLAG: {flag}");
            SetCellText(table.GetRow(0).GetCell(1), $"NT: {nt}");
            SetCellText(table.GetRow(0).GetCell(2), $"GT: {gt}");

            SetCellText(table.GetRow(1).GetCell(0), $"LOA: {loa} m");
            SetCellText(table.GetRow(1).GetCell(1), $"BEAM: {beam} m");
            SetCellText(table.GetRow(1).GetCell(2), $"Draft: {draft} m");

            SetCellText(table.GetRow(2).GetCell(0), $"Port of Call: {port}");
            SetCellText(table.GetRow(2).GetCell(1), $"Inbound: {inbound}");
            SetCellText(table.GetRow(2).GetCell(2), $"Outbound: {outbound}");


            SetCellText(table.GetRow(3).GetCell(0), $"Operation: {operation}");
            SetCellText(table.GetRow(3).GetCell(1), $"Exch. Rate: US$1.00={dollar_tl}TR / Euro1.00={euro_dollar}US$");
            SetCellText(table.GetRow(3).GetCell(2), $"");

            // Tablo genişliklerini ayarlamak için tblGrid kullanıyoruz
            var tbl = table.GetCTTbl();
            var tblGrid = tbl.tblGrid; // Grid (ızgara) yapısını alıyoruz

            // Eğer tblGrid null ise, yeni bir tblGrid oluşturuyoruz
            if (tblGrid == null)
            {
                tblGrid = tbl.AddNewTblGrid();
            }

            // 1. sütunun genişliği
            var col1 = tblGrid.AddNewGridCol();
            col1.w = 2000; // Genişlik ayarı (EMU cinsinden)

            // 2. sütunun genişliği
            var col2 = tblGrid.AddNewGridCol();
            col2.w = 3000; // Genişlik ayarı (EMU cinsinden)

            // 3. sütunun genişliği
            var col3 = tblGrid.AddNewGridCol();
            col3.w = 4000; // Genişlik ayarı (EMU cinsinden)

            // Tablo genişliğini de ayarlayalım
            tbl.tblPr.tblW.type = ST_TblWidth.dxa;
            tbl.tblPr.tblW.w = 10000.ToString(); // Tablonun toplam genişliği (EMU cinsinden)




            // Fee Table Data
            // Ücret verileri
            // Ücret verileri
            string a = "Port in/out";
            if (portcity == "Marmara Ereğlisi & Tekirdağ")
            {
                a = "Port in/out Marmara Ereğlisi & Tekirdağ";
            }

            string[,] feeTable = {
            { "Sanitary dues", sanitary_dues.ToString("N2"), "Port in/out" },
            { "Light dues", light_dues.ToString("N2"), "Port in/out" },
            { "VTS Dues", VTS.ToString("N2"), $"{a}" },
            { "Pilotage fees", pilotageFees.ToString("N2"), "Berth/Unberth with 30% Tanker surcharge" },
            { "Towage Fee", tugboat.ToString("N2"), "2 in/ 2 out - with 30% tanker surcharge" },
            { "Mooring/Unmooring Fee", mooring.ToString("N2"), "Berth/Unberth with 30% Tanker surcharge" },
            { "Wharfage Fee", wharfage_fee.ToString("N2"), $"{port} terminal (for {anchorage_day} day)" },
            { "Anchorage fee", "0.00", $"pls see 2nd page" },
            { "Garbage Fee", garbage_fee.ToString("N2"), "Fixed    EUR" },
            { "H. Master & C.O. Shipping", harbour_master_co_shipping.ToString("N2"), "With 0.5% contribution to COS" },
            { "Notary Public fee", notary_public_fee.ToString("N2"), "If any at cost" },
            { "Launchboat Services", launchboat_services.ToString("N2"), "$850 to be charged for launchboat + permission exp.in case inward clearance requested at anchorage" },
            { "Overtime dues", overtime_dues.ToString("N2"), "For inward/outward Custom & H. Master clearance" },
            {"Fiscal Stamps/Stationary Ex",Fiscalstamps.ToString("N2"),"If any at cost" },
            { "Agency Service", agency_service.ToString("N2"), "As per tariff – Min. fee" },
            { "Sundries", sundries.ToString("N2"), "Routine port/cargo operations" },
            { "Agency staff car expenses", agency_staff_car_expenses.ToString("N2"), "Routine port/cargo operations" },
            { "Communication expenses", communication_expenses.ToString("N2"), "Routine port/cargo operations" },
            { "Supervision Services", supervision_services.ToString("N2"), "As per tariff – Min. fee" },
            {"Postage", postage.ToString("N2"),"FDA dispacth" },
            //{"Previous Balance",sanitary_dues.ToString("N2"),"As per SOA" },
            { "Total", total.ToString("N2"), "USD" }
        };

            // Tabloyu oluştur (14 veri satırı + 1 başlık)
            XWPFTable table1 = document.CreateTable(feeTable.GetLength(0) + 1, feeTable.GetLength(1));

            // Hücre genişliklerini ayarlayın
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                XWPFTableRow row = table1.GetRow(i);

                for (int j = 0; j < row.GetTableCells().Count; j++)
                {
                    XWPFTableCell cell = row.GetCell(j);
                    CT_TcPr tcPr = cell.GetCTTc().AddNewTcPr();
                    CT_TblWidth tblWidth = tcPr.AddNewTcW();

                    // Sütun 1, 3 için normal genişlik
                    if (j == 0)
                    {
                        tblWidth.w = "3500";  // Diğer sütunlar için normal genişlik
                    }

                    // "Amount (USD)" sütunu için daha dar bir genişlik
                    else if (j == 1)
                    {
                        tblWidth.w = "500";  // "Amount (USD)" sütununu daha dar yapıyoruz
                    }
                    else if (j == 2)
                    {
                        tblWidth.w = "4500";  // "Amount (USD)" sütununu daha dar yapıyoruz
                    }

                    tblWidth.type = ST_TblWidth.dxa;
                }
            }

            // Kalın kenarlıklar (çizgiler)
            table1.SetInsideHBorder(XWPFTable.XWPFBorderType.SINGLE, 8, 0, "000000");
            table1.SetInsideVBorder(XWPFTable.XWPFBorderType.SINGLE, 8, 0, "000000");
            table1.SetBottomBorder(XWPFTable.XWPFBorderType.SINGLE, 8, 0, "000000");
            table1.SetTopBorder(XWPFTable.XWPFBorderType.SINGLE, 8, 0, "000000");
            table1.SetLeftBorder(XWPFTable.XWPFBorderType.SINGLE, 8, 0, "000000");
            table1.SetRightBorder(XWPFTable.XWPFBorderType.SINGLE, 8, 0, "000000");

            // Başlık satırını elle ayarlayın
            XWPFTableRow headerRow = table1.GetRow(0);

            // Başlık hücrelerini manuel olarak ayarlayın
            headerRow.GetCell(0).SetText("Fees/dues/expenses");
            headerRow.GetCell(1).SetText("Amount (USD)");
            headerRow.GetCell(2).SetText("Remarks");

            // Başlık stilini uygulayın
            // Başlık stilini uygulayın
            for (int j = 0; j < 3; j++)
            {
                XWPFTableCell headerCell = headerRow.GetCell(j);
                headerCell.RemoveParagraph(0);

                XWPFParagraph para = headerCell.AddParagraph();
                para.SpacingBetween = 1;
                para.SpacingBefore = 0;
                para.SpacingAfter = 0;

                XWPFRun run = para.CreateRun();
                run.FontFamily = "Comic Sans MS";
                run.FontSize = 10;
                run.IsBold = true;

                if (j == 0)
                    run.SetText("Fees/dues/expenses");
                else if (j == 1)
                    run.SetText("Amount (USD)");
                else if (j == 2)
                    run.SetText("Remarks");
            }


            // Diğer hücrelerin stilini ayarlayın
            for (int i = 1; i < table1.Rows.Count; i++)
            {
                XWPFTableRow row = table1.GetRow(i);
                for (int j = 0; j < row.GetTableCells().Count; j++)
                {
                    XWPFTableCell cell = row.GetCell(j);
                    cell.RemoveParagraph(0);

                    XWPFParagraph para = cell.AddParagraph();
                    para.SpacingBetween = 1;
                    para.SpacingBefore = 0;
                    para.SpacingAfter = 0;
                    para.IsWordWrapped = true;

                    XWPFRun run = para.CreateRun();
                    run.FontFamily = "Comic Sans MS";
                    run.FontSize = 10;

                    string cellText = feeTable[i - 1, j];
                    run.SetText(cellText);

                    if (j == 1)
                    {
                        para.Alignment = ParagraphAlignment.RIGHT;
                    }
                }
            }
            // Belgenin footer'ını oluştur
            // Footer'ı oluşturuyoruz
            // Footer'ı oluşturuyoruz
            // Footer'ı oluşturuyoruz
            // Footer'ı oluşturuyoruz
            // Footer'ı oluşturuyoruz
            XWPFFooter footer = document.CreateFooter(HeaderFooterType.DEFAULT);

            // Alt bilgiye paragraf ekliyoruz
            XWPFParagraph footerParagraph = footer.CreateParagraph();

            footerParagraph.Alignment = ParagraphAlignment.RIGHT;  // Metni ortalayalım,
            footerParagraph.IndentationRight = 0; // Sağ girintiyi sıfırlıyoruz

            footerParagraph.SpacingBefore = 0;  // Önceki boşluğu sıfırlıyoruz
            footerParagraph.SpacingAfter = 0;   // Sonraki boşluğu sıfırlıyoruz

            // "Han Shipping Co. Ltd." başlık kısmı - Kalın, 10pt, mavi renk
            XWPFRun footerRun = footerParagraph.CreateRun();
            footerRun.SetText("Han Shipping Co. Ltd.\n");
            footerRun.FontFamily = "Tahoma"; // Font: Tahoma
            footerRun.FontSize = 10;         // Font Boyutu: 10pt
            footerRun.IsBold = true;         // Kalın yazı
            footerRun.SetColor("0000FF");    // Renk: Mavi (Hex: #0000FF)

            // Diğer metin kısmı - Mavi renk, 8pt
            footerRun = footerParagraph.CreateRun();
            footerRun.SetText("A: Barbaros Mh. Mor Sumbul Sk. No.5/A,\n" +
                              "Deluxia Palace D.86 - 34746 Atasehir, Istanbul \n" +
                              "T: +90 216 456 5773-75\n");
            footerRun.FontFamily = "Tahoma"; // Font: Tahoma
            footerRun.FontSize = 8;          // Font Boyutu: 8pt
            footerRun.SetColor("0000FF");    // Renk: Mavi (Hex: #0000FF)

            // E-posta adresini altı çizili yapıyoruz ve 8pt
            footerRun = footerParagraph.CreateRun();
            footerRun.SetText("E-mail: agency@hanship.com");
            footerRun.FontFamily = "Tahoma"; // Font: Tahoma
            footerRun.FontSize = 8;          // Font Boyutu: 8pt
            footerRun.Underline = UnderlinePatterns.Single;    // Altı çizili yapıyoruz
            footerRun.SetColor("0000FF");    // Renk: Mavi (Hex: #0000FF)











            // Calculate anchorage fees
            double coefficient = 0.004;
            double anchorage_fee_per_day = gt * coefficient; // 96.26 USD per day
            double total_anchorage_fee = anchorage_fee_per_day * anchorage_day;


            // SAYFA SONU EKLE - 2. sayfadan başlat
            XWPFParagraph detailsParagraph = document.CreateParagraph();
            XWPFRun detailsRun2 = detailsParagraph.CreateRun();
            detailsRun2.AddBreak(BreakType.PAGE); // <<< BU SATIRI EKLEDİK

            detailsRun2.SetText(
                "- As per tariff, above given fees are minimum fees.\n" +
                "- As per tariff applied at all Turkish ports; Pilotage, tugboat assistance, and mooring service fees are subject to a 50% surcharge on official holidays.\n" +
                "- Customs claim huge fines against discrepancy in discharged quantity exceeding a respective percentage of the BL figure. Owners are responsible for these fines and must pay them to discharge port customs to avoid vessel arrest. Owners should instruct load port agents to issue a letter for Turkish customs immediately after discrepancy occurs at load port. (A sample letter can be provided upon request.) By accepting this proforma, you agree to all its terms and conditions.\n" +
                "- As per tariff applied at all Turkish ports; Anchorage fee:\n" +
                "  * First 72 hours: Free\n" +
                $"  * After 72 hours: {gt} x {coefficient} = {anchorage_fee_per_day:F2} USD per day\n" +
                $"    * Daily payment (up to 7 days): {anchorage_fee_per_day:F2} USD x {anchorage_day} days\n" +
                $"    * Monthly basis (1 month exemption): {anchorage_fee_per_day:F2} USD x 25 days = {anchorage_fee_per_day * 25:F2} USD\n" +
                $"    * Annual basis (1 year exemption): {anchorage_fee_per_day:F2} USD x 150 days = {anchorage_fee_per_day * 150:F2} USD\n");
            detailsRun2.FontSize = 9;
            detailsRun2.FontFamily = "Comic Sans MS";



            XWPFParagraph bankDetailsParagraph = document.CreateParagraph();
            XWPFRun bankDetailsRun = bankDetailsParagraph.CreateRun();
            bankDetailsRun.SetText(
                "USD\n" +
                "Banker: T. Garanti Bankası\n" +
                "Branch: Sahrayicedid / Istanbul (Branch Code: 277)\n" +
                "Swift: TGBATRISXXX\n" +
                "IBAN: TR90 0006 2000 2770 0009 0987 41\n" +
                "Account no.: 9098741\n" +
                "In favour of: Han Shipping Co. Ltd.\n" +
                $"Ref: M/T \"{ship_name}\" - OPET, Marmara Ereglisi call D/A\n");
            bankDetailsRun.FontSize = 9;
            bankDetailsRun.FontFamily = "Comic Sans MS";

            // Closing Remarks
            XWPFParagraph closingParagraph = document.CreateParagraph();
            XWPFRun closingRun = closingParagraph.CreateRun();
            closingRun.SetText("\nPlease do not hesitate to contact us for further information or assistance.\nWe look forward to hearing from you soon.\n\nRespectfully yours,");
            closingRun.FontSize = 9;
            closingRun.FontFamily = "Comic Sans MS";


            string directoryPath = @"C:\Users\RUSH\Desktop\words";
            string filePath = Path.Combine(directoryPath, "Ship_Expenses_Report.docx");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            // Dosyayı oluştur ve yaz
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                document.Write(stream);
            }
            MessageBox.Show("Word file created successfully: " + filePath);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_proformaPanel != null)
            {
                // Eğer referans varsa, onu kullan
                this.Hide();
                _proformaPanel.Show();
            }
            else
            {
                // Geriye uyumluluk için eski davranışı koru
                ProformaPanel pp = new ProformaPanel();
                this.Hide();
                pp.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LBLSundries_Click(object sender, EventArgs e)
        {

        }

        private void LBLFiscal_Click(object sender, EventArgs e)
        {

        }
    }
}