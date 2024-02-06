using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Timerbaev_41
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();

            var currentProducts = Timerbaev_41razmerEntities.GetContext().Product.ToList();
            ProductListView.ItemsSource = currentProducts;

            ComboType.SelectedIndex = 0;
            UpdateProducts();
        }
        private void UpdateProducts()
        {
            var currentProducts = Timerbaev_41razmerEntities.GetContext().Product.ToList();

            if (ComboType.SelectedIndex == 0)
            {
                currentProducts = currentProducts.Where(p => (p.ProductDiscountAmount >= 0 && p.ProductDiscountAmount <= 100)).ToList();
            }
            if (ComboType.SelectedIndex == 1)
            {
                currentProducts = currentProducts.Where(p => (p.ProductDiscountAmount >= 0 && p.ProductDiscountAmount < 9.99)).ToList();
            }
            if (ComboType.SelectedIndex == 2)
            {
                currentProducts = currentProducts.Where(p => (p.ProductDiscountAmount >= 10 && p.ProductDiscountAmount < 14.99)).ToList();
            }
            if (ComboType.SelectedIndex == 3)
            {
                currentProducts = currentProducts.Where(p => (p.ProductDiscountAmount >= 15 && p.ProductDiscountAmount <= 100)).ToList();
            }
            currentProducts = currentProducts.Where(p => p.ProductName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            if (RButtonDown.IsChecked.Value)
            {
                currentProducts = currentProducts.OrderByDescending(p => p.ProductCost).ToList();
            }
            if (RButtonUp.IsChecked.Value)
            {
                currentProducts = currentProducts.OrderBy(p => p.ProductCost).ToList();
            }
            ProductListView.ItemsSource = currentProducts;
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void RButtonUp_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void RButtonDown_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void TBoxSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
