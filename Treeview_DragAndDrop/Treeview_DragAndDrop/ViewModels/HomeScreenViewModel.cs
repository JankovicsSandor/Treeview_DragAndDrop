using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Treeview_DragAndDrop.Models;
using Xamarin.Forms;

namespace Treeview_DragAndDrop.ViewModels
{
    public class HomeScreenViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TreeNodeModel> fromTreeList;
        private ObservableCollection<TreeNodeModel> toTreeList;

        public ObservableCollection<TreeNodeModel> FromTreeList
        {
            get => fromTreeList;
            set { fromTreeList = value; OnPropertyChanged(); }
        }
        public ObservableCollection<TreeNodeModel> ToTreeList
        {
            get => toTreeList;
            set { toTreeList = value; OnPropertyChanged(); }
        }

        public ICommand ExpandAllCommand { get; set; }
        public ICommand CollapseAllCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HomeScreenViewModel()
        {
            FromTreeList = new ObservableCollection<TreeNodeModel>();
            ToTreeList = new ObservableCollection<TreeNodeModel>();
            Task.Run(() => CreateTreeListCollections());
            ExpandAllCommand = new Command(ExpandAll);
            CollapseAllCommand = new Command(CloseAll);

        }

        private void ExpandAll(object obj)
        {
            foreach (var fromTree in FromTreeList)
            {
                this.ToggleRecursive(fromTree, true);
            }
            Debug.WriteLine("Done");
        }

        private void CloseAll(object obj)
        {
            foreach (var fromTree in FromTreeList)
            {
                this.ToggleRecursive(fromTree, false);
            }
            Debug.WriteLine("Done");
        }

        private void ToggleRecursive(TreeNodeModel node, bool value)
        {
            node.IsExpanded = value;
            foreach (var nodeChild in node.Children)
            {
                ToggleRecursive(nodeChild, value);
            }

        }

        private void CreateTreeListCollections()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ObservableCollection<TreeNodeModel> treeNodeModels = new ObservableCollection<TreeNodeModel>();
                treeNodeModels.Add(new TreeNodeModel()
                {
                    Id = 1,
                    Text = "Első",
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                        }
                    }
                });

                List<TreeNodeModel> resList = new List<TreeNodeModel>();

                for (int i = 0; i < 100; i++)
                {
                    resList.Add(new TreeNodeModel()
                    {
                        Id = i,
                        Text = $"Node#{i}"
                    });
                }

                treeNodeModels.Add(new TreeNodeModel()
                {
                    Id = 1,
                    Text = "Masodik",
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Masodik.Egy",
                            Children=resList
                        },
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Masodik.Egy",
                            Children=new List<TreeNodeModel>()
                            {
                                new TreeNodeModel(){
                                    Id = 1,
                                    Text = "Masodik.Egy.Egy",
                                    Children = new List<TreeNodeModel>()
                                     {
                                       new TreeNodeModel() {
                                            Id = 2,
                                            Text = "Masodik.Egy.Egy.Egy",
                                       }
                                    }
                                }
                            }
                        },
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Masodik.Egy",
                            Children=new List<TreeNodeModel>()
                            {
                                new TreeNodeModel(){
                                    Id = 1,
                                    Text = "Masodik.Egy.Egy",
                                    Children = new List<TreeNodeModel>()
                                     {
                                       new TreeNodeModel() {
                                            Id = 2,
                                            Text = "Masodik.Egy.Egy.Egy",
                                       }
                                    }
                                }
                            }
                        },new TreeNodeModel() {
                            Id = 2,
                            Text = "Masodik.Egy",
                            Children=new List<TreeNodeModel>()
                            {
                                new TreeNodeModel(){
                                    Id = 1,
                                    Text = "Masodik.Egy.Egy",
                                    Children = new List<TreeNodeModel>()
                                     {
                                       new TreeNodeModel() {
                                            Id = 2,
                                            Text = "Masodik.Egy.Egy.Egy",
                                       }
                                    }
                                }
                            }
                        },new TreeNodeModel() {
                            Id = 2,
                            Text = "Masodik.Egy",
                            Children=new List<TreeNodeModel>()
                            {
                                new TreeNodeModel(){
                                    Id = 1,
                                    Text = "Masodik.Egy.Egy",
                                    Children = new List<TreeNodeModel>()
                                     {
                                       new TreeNodeModel() {
                                            Id = 2,
                                            Text = "Masodik.Egy.Egy.Egy",
                                       }
                                    }
                                }
                            }
                        }
                    }
                });
                treeNodeModels.Add(new TreeNodeModel()
                {
                    Id = 1,
                    Text = "Első",
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                            Children=new List<TreeNodeModel>(){
                               new TreeNodeModel()
                               {
                                    Id=3,
                                    Text="Almafa"
                               }
                            }
                        }
                    }
                });
                treeNodeModels.Add(new TreeNodeModel()
                {
                    Id = 1,
                    Text = "Első",
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                        }
                    }
                });
                FromTreeList = treeNodeModels;
            });

            Device.BeginInvokeOnMainThread(() =>
            {
                ObservableCollection<TreeNodeModel> toTreeNodeModels = new ObservableCollection<TreeNodeModel>();
                toTreeNodeModels.Add(new TreeNodeModel()
                {
                    Id = 1,
                    Text = "Első",
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                        }
                    }
                });
                toTreeNodeModels.Add(new TreeNodeModel()
                {
                    Id = 1,
                    Text = "Első",

                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                        }
                    }
                });
                toTreeNodeModels.Add(new TreeNodeModel()
                {
                    Id = 1,
                    Text = "Első",
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                        }
                    }
                });
                toTreeNodeModels.Add(new TreeNodeModel()
                {
                    Id = 1,
                    Text = "Első",
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                        }
                    }
                });
                ToTreeList = toTreeNodeModels;
            });
        }
    }
}
