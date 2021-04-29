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
                Header = CreateHeaderText(nodeData, Depth)

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
                subExpander.Header = CreateHeaderText(rootNode, depth);
                subExpander.Content = GetSubNodeList(child, depth + 1);
            }
            subExpander.BindingContext = nodeData;
            subExpander.SetBinding(Expander.IsExpandedProperty, nameof(nodeData.IsExpanded));

            return subExpander;
        }

        private StackLayout CreateHeaderText(TreeNodeModel node, int depth)
        {
            BoxView _SpacerBoxView = new BoxView();
            StackLayout headerStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };


            _SpacerBoxView.WidthRequest = depth * 20;

            headerStack.Children.Add(_SpacerBoxView);

            Label textLabel = new Label();
            textLabel.SetBinding(Label.TextProperty, nameof(node.Text));

            headerStack.Children.Add(textLabel);

            return headerStack;
        }
    }
}
