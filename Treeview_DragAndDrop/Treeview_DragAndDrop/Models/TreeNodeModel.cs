using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Treeview_DragAndDrop.Models
{
    public class TreeNodeModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string imgUrl;

        public string IconUrl
        {
            get { return imgUrl; }
            set
            {
                imgUrl = value;
                OnPropertyChanged();
            }
        }

        public string Text { get; set; }
        private bool isExpanded;

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                OnPropertyChanged();
                if (value)
                {
                    IconUrl = "Assets/FolderOpen.png";
                    ExpandIconUrl = "Assets/OpenGlyph.png";
                }
                else
                {
                    IconUrl = "Assets/FolderClosed.png";
                    ExpandIconUrl = "Assets/CollapsedGlyph.png";
                }
            }
        }

        private string expandIconUrl;

        public string ExpandIconUrl
        {
            get { return expandIconUrl; }
            set
            {
                expandIconUrl = value;
                OnPropertyChanged();
            }
        }

        public bool IsLeaf { get => Children.Count == 0; }


        public IList<TreeNodeModel> Children { get; set; }

        public TreeNodeModel()
        {
            Children = new List<TreeNodeModel>();
            IconUrl = "Assets/FolderClosed.png";
            ExpandIconUrl = "Assets/CollapsedGlyph.png";
            IsExpanded = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id:{Id}, Text: {Text},Expanded: {IsExpanded}, Children:{Children}");
            return sb.ToString();
        }
    }
}
