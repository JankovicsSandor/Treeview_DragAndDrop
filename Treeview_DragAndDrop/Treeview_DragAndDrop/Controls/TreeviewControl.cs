using System;
using System.Collections.Generic;
using System.Text;
using Treeview_DragAndDrop.Models;
using Xamarin.Forms;

namespace Treeview_DragAndDrop.Controls
{
    public class TreeviewControl : ScrollView
    {
        private readonly StackLayout _StackLayout = new StackLayout { Orientation = StackOrientation.Vertical };

        public IList<TreeNodeModel> ItemsSource
        {
            get { return (IList<TreeNodeModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }


        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(propertyName: nameof(ItemsSource), returnType: typeof(IList<TreeNodeModel>),
                                                                                      declaringType: typeof(TreeviewControl), defaultValue: new List<TreeNodeModel>(),
                                                                                      defaultBindingMode: BindingMode.TwoWay, propertyChanged: ItemsSourceChanged);
        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (TreeviewControl)bindable;
            control.ItemsSource = (IList<TreeNodeModel>)newValue;

            foreach (var rootNode in control.ItemsSource)
            {
                control._StackLayout.Children.Add(new TreeViewNode(rootNode).CreateNodeView());
            }

        }

        public TreeviewControl()
        {
            Content = _StackLayout;
        }
    }
}
