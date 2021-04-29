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
        public string IconUrl { get; set; }
        public string Text { get; set; }
        public bool IsExpanded { get; set; } = true;
        public IList<TreeNodeModel> Children { get; set; }

        public TreeNodeModel()
        {
            Children = new List<TreeNodeModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
