using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treeview_DragAndDrop.Models;
using Xamarin.Forms;

namespace Treeview_DragAndDrop
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            BindingContext = new HomepageViewModel();
            InitializeComponent();

        }

        private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
        {
            Debug.WriteLine("Drag Start");
        }
    }
}
