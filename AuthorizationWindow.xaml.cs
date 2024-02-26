using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace TRRK
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            update();
            Sort.Items.Add("Название по алфавиту");
            Sort.Items.Add("Название против алфавита");
            Sort.Items.Add("По возрастанию цены");
            Sort.Items.Add("По убыванию цены");
            //Sort.SelectedIndex = 1;

            List<ProductType> types = CoreModel.init().ProductTypes.ToList();
            Filt.ItemsSource = types;
            Filt.SelectedIndex = 0;
            types.Insert(0, new ProductType { Title = "Все типы" });
            //scaffold-dbContext "Port=3306;Database=ISPr23-35_TazetdinovRR_23.01.24;Password=ISPr23-35_TazetdinovRR;UserID=ISPr23-35_TazetdinovRR;Character Set=utf8;Server=cfif31.ru" Pomelo.EntityFrameworkCore.MySql
        }
        //функции поиска, сортировки, фильтрации - начало 
        private void update()
        {
            IEnumerable<Product> products = CoreModel.init().Products.Include(p => p.ProductType).Where(p => p.Title.Contains(Poisk.Text) || p.MinCostForAgent.ToString().Contains(Poisk.Text));
            // Pole MinCostForAgent
            //Pole ArticleNumber
            //
            switch (Sort.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(p => p.Title);
                    MessageBox.Show("Данные выведены в алфавитном порядке");
                    break;

                case 1:
                    products = products.OrderByDescending(p => p.Title);
                    MessageBox.Show("Данные выведены против алфавита");
                    break;
                case 2:
                    products = products.OrderBy(p => p.MinCostForAgent);
                    MessageBox.Show("Данные выведены по возратанию цены");
                    break;

                case 3:
                    products = products.OrderByDescending(p => p.MinCostForAgent);
                    MessageBox.Show("Данные выведены по убыванию цены");
                    break;
            }
            if (Filt.SelectedIndex > 0)
                products = products.Where(p => p.ProductTypeId == (Filt.SelectedItem as ProductType).Id);

            LVProduct.ItemsSource = products.ToList();

        }
        //функции поиска, сортировки, фильтрации - конец 

        //обновление данных после измений - начало
        private void Change(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void SortChange(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void FiltChange(object sender, SelectionChangedEventArgs e)
        {
            update();
        }
        //обновление данных после измений - конец
    }
}
