using System;
using System.Collections.Generic;
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

        public Expander CreateNodeView()
        {
            Expander rootExpander = new Expander()
            {
                Header = CreateHeaderText(Depth)
            };
            rootExpander.BindingContext = nodeData;
            rootExpander.SetBinding(Expander.IsExpandedProperty, nameof(nodeData.IsExpanded));

            rootExpander.Content = this.GetSubNodeList(nodeData, Depth + 1);
            return rootExpander;
        }

        private View GetSubNodeList(TreeNodeModel rootNode, int depth)
        {
            Expander subExpander = new Expander();
            foreach (var child in rootNode.Children)
            {
                subExpander.Header = CreateHeaderText(depth);
                subExpander.Content = new TreeViewNode(child, depth + 1).CreateNodeView();
            };
            return subExpander;
        }


        private StackLayout CreateHeaderText(int depth)
        {
            BoxView _SpacerBoxView = new BoxView();
            StackLayout headerStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };


            _SpacerBoxView.WidthRequest = depth * 20;

            headerStack.Children.Add(_SpacerBoxView);
            headerStack.Children.Add(CreateImageWithPropertyBinding(nameof(nodeData.ExpandIconUrl)));
            headerStack.Children.Add(CreateImageWithPropertyBinding(nameof(nodeData.IconUrl)));

            Label textLabel = new Label();
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
    }
}
