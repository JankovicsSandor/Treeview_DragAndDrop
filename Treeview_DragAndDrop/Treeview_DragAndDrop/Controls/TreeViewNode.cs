using System;
using System.Collections.Generic;
using System.Diagnostics;
using Treeview_DragAndDrop.Models;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Treeview_DragAndDrop.Controls
{
    public class TreeViewNode : Expander
    {
        TreeNodeModel nodeData;
        int Depth;
        public TreeViewNode(TreeNodeModel rootNode, int depth = 0)
        {
            nodeData = rootNode;
            Depth = depth;
            Content = CreateNodeView();
        }

        public View CreateNodeView()
        {
            if (!nodeData.IsLeaf)
            {                          
                Expander rootView = new Expander() { };
                rootView.BindingContext = nodeData;
                rootView.Header = CreateHeaderText(Depth);
                rootView.SetBinding(Expander.IsExpandedProperty, nameof(nodeData.IsExpanded));
                rootView.Content = this.GetSubNodeList(nodeData, Depth + 1);

                rootView.Header.GestureRecognizers.Add(CreateDragGesture());
                rootView.Content.GestureRecognizers.Add(CreateDragGesture());
                rootView.Header.GestureRecognizers.Add(CreateDropGesture());
                rootView.Content.GestureRecognizers.Add(CreateDropGesture());
                return rootView;
            }
            else
            {
                return this.CreateHeaderText(Depth + 1);
            }
        }

        private View GetSubNodeList(TreeNodeModel rootNode, int depth)
        {
            StackLayout baseLayout = new StackLayout() { Orientation = StackOrientation.Vertical };
            foreach (var child in rootNode.Children)
            {
                if (!child.IsLeaf)
                {
                    baseLayout.Children.Add(new TreeViewNode(child, depth + 1).CreateNodeView());
                }
                else
                {
                    View leafView = new TreeViewNode(child, depth + 1).CreateNodeView();
                    leafView.BindingContext = child;
                    baseLayout.Children.Add(leafView);
                }
            };
            return baseLayout;
        }
        private View CreateHeaderText(int depth)
        {
            BoxView _SpacerBoxView = new BoxView();
            StackLayout headerStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                //VerticalOptions = LayoutOptions.FillAndExpand
            };
            _SpacerBoxView.WidthRequest = depth * 15;

            headerStack.Children.Add(_SpacerBoxView);
            if (!nodeData.IsLeaf)
            {
                headerStack.Children.Add(CreateImageWithPropertyBinding(nameof(nodeData.ExpandIconUrl)));
                headerStack.Children.Add(CreateImageWithPropertyBinding(nameof(nodeData.IconUrl)));
            }
            else
            {
                _SpacerBoxView.WidthRequest = depth * 15;
            }
            Label textLabel = new Label() { VerticalTextAlignment = TextAlignment.Center };
            textLabel.SetBinding(Label.TextProperty, nameof(nodeData.Text));
            headerStack.Children.Add(textLabel);

            return headerStack;
        }

        private Image CreateImageWithPropertyBinding(string nameProperty)
        {
            Image expandedStatusImage = new Image();

            FileImageSource fileImageSource = new FileImageSource();
            fileImageSource.SetBinding(FileImageSource.FileProperty, nameProperty);

            expandedStatusImage.Source = fileImageSource;

            return expandedStatusImage;
        }

        private DragGestureRecognizer CreateDragGesture()
        {
            DragGestureRecognizer dragGesture = new DragGestureRecognizer() { CanDrag = true };
            dragGesture.DragStarting += DragGesture_DragStarting;

            return dragGesture;
        }

        private void DragGesture_DragStarting(object sender, DragStartingEventArgs e)
        {
            e.Data.Properties.Add("Data", nodeData);
        }

        private DropGestureRecognizer CreateDropGesture()
        {
            DropGestureRecognizer dropGesture = new DropGestureRecognizer() { AllowDrop = true };
            dropGesture.DragOver += DropGesture_DragOver;
            dropGesture.DragLeave += DropGesture_DragLeave;
            dropGesture.Drop += DropGesture_Drop;

            return dropGesture;
        }

        private void DropGesture_DragOver(object sender, DragEventArgs e)
        {
            var control = sender as DropGestureRecognizer;

            if (control != null)
            {
                StackLayout parentStack = control.Parent as StackLayout;
                parentStack.BackgroundColor = Color.Red;
                Debug.WriteLine("Drag over");
            }

        }

        private void DropGesture_Drop(object sender, DropEventArgs e)
        {
            var control = sender as DropGestureRecognizer;

            if (control != null)
            {
                StackLayout parentStack = control.Parent as StackLayout;
                parentStack.BackgroundColor = Color.Default;
                TreeNodeModel dataPackage = (TreeNodeModel)e.Data.Properties["Data"];
                Debug.WriteLine("Drag drop");
                Debug.WriteLine(dataPackage);
            }
        }

        private void DropGesture_DragLeave(object sender, DragEventArgs e)
        {
            var control = sender as DropGestureRecognizer;

            if (control != null)
            {
                StackLayout parentStack = control.Parent as StackLayout;
                parentStack.BackgroundColor = Color.Default;
                Debug.WriteLine("Drag end");
            }
        }

    }
}
