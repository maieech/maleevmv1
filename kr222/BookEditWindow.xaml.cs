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
using System.Windows.Shapes;

namespace kr222
{

    public partial class BookEditWindow : Window
    {
        public Book Book { get; private set; }

        public BookEditWindow()
        {
            InitializeComponent();
            Book = new Book
            {
                ReleaseDate = DateTime.Now.Date,
                Status = BookStatus.Available
            };
            dpReleaseDate.SelectedDate = DateTime.Now.Date;
        }

        public BookEditWindow(Book book) : this()
        {
            Book = book;
            txtArticle.Text = book.Article;
            txtTitle.Text = book.Title;
            txtGenre.Text = book.Genre;
            dpReleaseDate.SelectedDate = book.ReleaseDate;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArticle.Text) || string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Заполните обязательные поля (Артикул и Название)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Book.Article = txtArticle.Text;
            Book.Title = txtTitle.Text;
            Book.Genre = txtGenre.Text;
            Book.ReleaseDate = dpReleaseDate.SelectedDate ?? DateTime.Now.Date;

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

