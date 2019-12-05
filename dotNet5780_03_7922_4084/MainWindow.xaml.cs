using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace dotNet5780_03_7922_4084
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Host currentHost;
        List<Host> hostsList = new List<Host>
        {
            new Host()
            {
                _hostName="נופי גולן",
                _units= new List<HostingUnit>()
                {
                    new HostingUnit
                    {
                        _unitName="נרקיס",
                        _isSwimmimgPool=true,
                        _rooms=2,
                        _allOrders=new List<DateTime>(),
                        _uris=new List<string>
                        {
                            "https://www.zimmer.co.il/2504520/Pics/yardensuite%20(3).jpg",
                            "https://www.zimmer.co.il/2504520/Pics/yardensuite%20(2).jpg",
                            "https://www.zimmer.co.il/2504520/Pics/yardensuite%20(1).JPG"
                        }
                    },
                    new HostingUnit
                    {
                        _unitName="יסמין",
                        _isSwimmimgPool=true,
                        _rooms=2,
                        _allOrders=new List<DateTime>(),
                        _uris=new List<string>
                        {
                            "https://www.zimmer.co.il/8226489/Pics/DSC_5787ps_resize.jpg",
                            "https://www.zimmer.co.il/8226489/Home%20Zimmer-01-140210-2-XL.jpg",
                            "https://www.zimmer.co.il/8226489/Home%20Zimmer-27-140210-XL.jpg"
                        }
                    }
                }
            },
             new Host()
            {
                _hostName="אצולה בגולן",
                _units= new List<HostingUnit>()
                {
                    new HostingUnit
                    {
                        _unitName="סוויטת האצילים",
                        _isSwimmimgPool=true,
                        _rooms=3,
                        _allOrders=new List<DateTime>(),
                        _uris=new List<string>
                        {
                            "https://www.zimmer.co.il/14844/soltan%20(1).jpg",
                            "https://www.zimmer.co.il/14844/soltan%20(7).jpg"
                        }
                    },
                    new HostingUnit
                    {
                        _unitName="סוויטת המלכים",
                        _isSwimmimgPool=true,
                        _rooms=3,
                        _allOrders=new List<DateTime>(),
                        _uris=new List<string>
                        {
                            "https://www.zimmer.co.il/14844/nes%20(2).jpg",
                            "https://www.zimmer.co.il/14844/nes%20(6).jpg"
                        }
                    }
                }
            },
             new Host()
            {
                _hostName="בקתות גן עדן",
                _units= new List<HostingUnit>()
                {
                    new HostingUnit
                    {
                        _unitName="בקתת עדי",
                        _isSwimmimgPool=false,
                        _rooms=2,
                        _allOrders=new List<DateTime>(),
                        _uris=new List<string>
                        {
                            "https://www.zimmer.co.il/zhadnes/Pics/adi-sasha%20(5).JPG",
                            "https://www.zimmer.co.il/zhadnes/Pics/IMG_8127.jpg"
                        }
                    },
                    new HostingUnit
                    {
                        _unitName="בקתת שני",
                        _isSwimmimgPool=false,
                        _rooms=3,
                        _allOrders=new List<DateTime>(),
                        _uris=new List<string>
                        {
                            "https://www.zimmer.co.il/zhadnes/Pics/shan-sasha%20(10).JPG",
                            "https://www.zimmer.co.il/zhadnes/image00006.jpg",
                            "https://www.zimmer.co.il/zhadnes/Pics/IMG_8161.jpg"
                        }
                    }
                }
            }
        };
        public MainWindow()
        {
            InitializeComponent();
            cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "_hostName";
            cbHostList.SelectedIndex = 0;
        }

        private void CbHostList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }
        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            currentHost = hostsList[index];
            UpGrid.DataContext = currentHost;
            for (int i = 0; i < currentHost._units.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost._units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }
    }
}

