using System;
 using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Treeview_DragAndDrop.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Treeview_DragAndDrop.Controls
{

    public class TreeviewControl : ScrollView
    {
        private readonly StackLayout _StackLayout = new StackLayout { Orientation = StackOrientation.Vertical,VerticalOptions=LayoutOptions.FillAndExpand };

        public ObservableCollection<TreeNodeModel> TreeSource
        {
            get { return (ObservableCollection<TreeNodeModel>)GetValue(TreeSourceProperty); }
            set { SetValue(TreeSourceProperty, value); }
        }


        public static readonly BindableProperty TreeSourceProperty = BindableProperty.Create(propertyName: nameof(TreeSource),
                                                                                      returnType: typeof(IEnumerable),
                                                                                      declaringType: typeof(TreeviewControl),
                                                                                      defaultValue: null,
                                                                                      defaultBindingMode: BindingMode.TwoWay,
                                                                                      propertyChanged: OnTreeSourceChanged);

        private static void OnTreeSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Debug.WriteLine("------------------------------------------------------");
            var control = (TreeviewControl)bindable;
            control.TreeSource = (ObservableCollection<TreeNodeModel>)newValue;

            if (control.TreeSource != null)
            {
                Debug.WriteLine(control.TreeSource.Count);
                foreach (var rootNode in control.TreeSource)
                {
                    control._StackLayout.Children.Add(new TreeViewNode(rootNode).CreateNodeView());
                }
            }
        }


        public TreeviewControl()
        {
            Content = _StackLayout;
        }
    }
}
