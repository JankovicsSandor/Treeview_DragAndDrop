using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Treeview_DragAndDrop.Models
{
    public class HomepageViewModel: INotifyPropertyChanged
    {
        public IList<TreeNodeModel> treeViewList { get; } = new List<TreeNodeModel>()
        {
            new TreeNodeModel()
            {
                Id=1,
                Text="Elso",
                Children=new List<TreeNodeModel>()
            },
            new TreeNodeModel()
            {
                Id=2,
                Text="Ketto",
                Children=new List<TreeNodeModel>()
            },
            new TreeNodeModel()
            {
                Id=3,
                Text="Harom",
                Children=new List<TreeNodeModel>()
            },
            new TreeNodeModel()
            {
                Id=4,
                Text="Negz",
                Children=new List<TreeNodeModel>()
            }
        };

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
