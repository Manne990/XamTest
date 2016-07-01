using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace XamTest.Pages
{
    public partial class HiabTableViewPage : ContentPage
    {
        public HiabTableViewPage()
        {
            InitializeComponent();

            this.BindingContext = new HiabTableViewModel();
        }
    }

    public class HiabTableViewModel : ViewModelBase
    {
        public HiabTableViewModel()
        {
            this.FormattedTableData = ParseTableData("HIAB X-HIPRO 1058||HIAB X-HIPRO 1058 E-10||HIAB X-HIPRO 1058 E-6||HIAB X-HIPRO 1058 E-6+JIB 175X-4||HIAB X-HIPRO 1058 E-6+JIB 175X-5||HIAB X-HIPRO 1058 E-7||HIAB X-HIPRO 1058 E-7+JIB 150X-4||HIAB X-HIPRO 1058 E-7+JIB 150X-6||HIAB X-HIPRO 1058 E-7+JIB 175X-4||HIAB X-HIPRO 1058 E-7+JIB 175X-5||HIAB X-HIPRO 1058 E-8||HIAB X-HIPRO 1058 E-8+JIB 150X-4||HIAB X-HIPRO 1058 E-8+JIB 150X-6||HIAB X-HIPRO 1058 E-8+JIB 175X-4 JDC||HIAB X-HIPRO 1058 E-8+JIB 175X-5 JDC||HIAB X-HIPRO 1058 E-9||HIAB X-HIPRO 1058 EP-4||HIAB X-HIPRO 1058 EP-5||HIAB X-HIPRO 1058 EP-6==Control System||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro||HiPro==Weight (kg)||8279||7382||8731||8816||7652||8880||9018||8986||9071||7895||9115||9253||9227||9312||8128||6616||6997||7180==Lifting Capacity (kNm)||794||819||819||819||812||812||812||812||812||803||803||803||803||803||798||840||831||825==Hydraulic Extension Outreach (m)||24||15.4||15.4||15.4||17.6||17.6||17.6||17.6||17.6||19.7||19.7||19.7||19.7||19.7||21.9||11.8||14.2||16.4==Outreach With Jib (m)||||||23.6||25.2||||25.9||29.7||25.7||27.2||||28||31.8||27.7||29.3||||||||==Outreach / lifting capacity, standard||4.4 - 18000,6.3 - 12300,8 - 9300,9.7 - 7300,11.6 - 5800,13.6 - 4750,15.5 - 4050,17.6 - 3450,19.6 - 3050,21.8 - 2720,23.8 - 2480||4.4 - 18000,5.9 - 13900,7.6 - 10500,9.3 - 8400,11.2 - 6800,13.2 - 5700,15.1 - 5000||4.4 - 18000,5.9 - 13900,7.6 - 10500,9.3 - 8400,11.2 - 6800,13.2 - 5700,15.1 - 5000||4.4 - 18000,5.9 - 13900,7.6 - 10500,9.3 - 8400,11.2 - 6800,13.2 - 5700,15.1 - 5000||4.5 - 18000,6.1 - 13200,7.7 - 10100,9.5 - 8000,11.4 - 6500,13.4 - 5400,15.3 - 4700,17.3 - 4100||4.5 - 18000,6.1 - 13200,7.7 - 10100,9.5 - 8000,11.4 - 6500,13.4 - 5400,15.3 - 4700,17.3 - 4100||4.5 - 18000,6.1 - 13200,7.7 - 10100,9.5 - 8000,11.4 - 6500,13.4 - 5400,15.3 - 4700,17.3 - 4100||4.5 - 18000,6.1 - 13200,7.7 - 10100,9.5 - 8000,11.4 - 6500,13.4 - 5400,15.3 - 4700,17.3 - 4100||4.5 - 18000,6.1 - 13200,7.7 - 10100,9.5 - 8000,11.4 - 6500,13.4 - 5400,15.3 - 4700,17.3 - 4100||4.4 - 18000,6.1 - 13000,7.8 - 9800,9.5 - 7800,11.4 - 6200,13.4 - 5200,15.3 - 4450,17.4 - 3850,19.4 - 3450||4.4 - 18000,6.1 - 13000,7.8 - 9800,9.5 - 7800,11.4 - 6200,13.4 - 5200,15.3 - 4450,17.4 - 3850,19.4 - 3450||4.4 - 18000,6.1 - 13000,7.8 - 9800,9.5 - 7800,11.4 - 6200,13.4 - 5200,15.3 - 4450,17.4 - 3850,19.4 - 3450||4.4 - 18000,6.1 - 13000,7.8 - 9800,9.5 - 7800,11.4 - 6200,13.4 - 5200,15.3 - 4450,17.4 - 3850,19.4 - 3450||4.4 - 18000,6.1 - 13000,7.8 - 9800,9.5 - 7800,11.4 - 6200,13.4 - 5200,15.3 - 4450,17.4 - 3850,19.4 - 3450||4.4 - 18000,6.2 - 12600,7.9 - 9500,9.6 - 7500,11.5 - 6000,13.5 - 4950,15.4 - 4200,17.5 - 3600,19.5 - 3200,21.6 - 2880||4.7 - 18000,6 - 14200,7.7 - 11000,9.6 - 8700,11.6 - 7200||4.7 - 18000,6.2 - 13500,8 - 10300,9.9 - 8200,11.9 - 6700,14.1 - 5600||4.7 - 18000,6.2 - 13300,8 - 10100,9.9 - 8000,11.9 - 6600,14.1 - 5500,16.3 - 4700==Outreach / lifting capacity, manual||||||25 - 1580||26.5 - 1280||||27.7 - 1180||30.9 - 800||27 - 1580||28.5 - 1260||||29.8 - 1180||33 - 800||29.1 - 1300||30.6 - 1020||||||||==Outreach / lifting capacity, with JIB||||||18.4 - 3000,19.4 - 2820,20.6 - 2640,21.9 - 2400,23.3 - 1920||18.4 - 2920,19.4 - 2740,20.7 - 2540,21.9 - 2320,23.4 - 1840,24.9 - 1520||||20.3 - 2540,21.6 - 2360,22.9 - 2220,24.3 - 1920,25.8 - 1560||20.6 - 2340,21.9 - 2180,23.2 - 2020,24.6 - 1680,26.1 - 1340,27.8 - 1080,29.5 - 920||20.5 - 2380,21.5 - 2240,22.7 - 2100,24 - 1980,25.4 - 1860||20.5 - 2300,21.5 - 2160,22.7 - 2020,24 - 1900,25.4 - 1780,27 - 1520||||22.3 - 2020,23.6 - 1880,24.9 - 1780,26.3 - 1680,27.8 - 1560||22.7 - 1820,24 - 1700,25.3 - 1580,26.7 - 1480,28.2 - 1340,29.9 - 1080,31.6 - 920||22.5 - 1860,23.5 - 1760,24.7 - 1660,26 - 1560,27.4 - 1480||22.5 - 1780,23.5 - 1680,24.8 - 1560,26 - 1480,27.5 - 1380,29 - 1240||||||||");
        }

        private ObservableCollection<ObservableCollection<string>> _formattedTableData;
        public ObservableCollection<ObservableCollection<string>> FormattedTableData
        {
            get
            {
                return _formattedTableData;
            }
            set
            {
                if (value != _formattedTableData)
                {
                    _formattedTableData = value;
                    RaisePropertyChanged(() => FormattedTableData);
                }
            }
        }

        private ObservableCollection<ObservableCollection<string>> ParseTableData(string tableData)
        {
            var results = new ObservableCollection<ObservableCollection<string>>();
            var rows = new ObservableCollection<string>(tableData.Split(new string[] { "==" }, StringSplitOptions.None));

            foreach (var row in rows)
            {
                results.Add(new ObservableCollection<string>(row.Split(new string[] { "||" }, StringSplitOptions.None)));
            }

            return results;
        }
    }
}