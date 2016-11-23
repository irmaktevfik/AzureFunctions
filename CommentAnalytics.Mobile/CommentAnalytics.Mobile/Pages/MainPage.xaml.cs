using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CommentAnalytics.Mobile.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly Repository.Comment repository = new Repository.Comment();
        public MainPage()
        {
            InitializeComponent();
            btnSubmit.Clicked += BtnSubmit_Clicked;
        }

        private async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            ActivityIndicator.IsEnabled = true;
            if (!String.IsNullOrEmpty(txtComments.Text))
            {
                await repository.SaveComment(new Repository.CommentModel() { value = txtComments.Text });
            }
            txtComments.Text = string.Empty;
            ActivityIndicator.IsEnabled = false;
        }
    }
}
