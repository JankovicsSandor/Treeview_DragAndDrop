using System;
using System.Collections.Generic;
using System.Text;
using Treeview_DragAndDrop.Models;

namespace Treeview_DragAndDrop.ViewModels
{
    public class HomeScreenViewModel
    {
        public IList<TreeNodeModel> FromTreeList { get; set; }
        public IList<TreeNodeModel> ToTreeList { get; set; }

        public HomeScreenViewModel()
        {
            CreateTreeListCollections();
        }

        private void CreateTreeListCollections()
        {
            FromTreeList = new List<TreeNodeModel>();

            FromTreeList.Add(new TreeNodeModel()
            {
                Id = 1,
                Text = "Első",
                IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                        }
                    }
            });
            FromTreeList.Add(new TreeNodeModel()
            {
                Id = 1,
                Text = "Masodik",
                IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Masodik.Egy",
                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                            Children=new List<TreeNodeModel>()
                            {
                                new TreeNodeModel(){
                                    Id = 1,
                                    Text = "Masodik.Egy.Egy",
                                    IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                                    Children = new List<TreeNodeModel>()
                                     {
                                       new TreeNodeModel() {
                                            Id = 2,
                                            Text = "Masodik.Egy.Egy.Egy",
                                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                                       }
                                    }
                                }
                            }
                        }
                    }
            });
            FromTreeList.Add(new TreeNodeModel()
            {
                Id = 1,
                Text = "Első",
                IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                        }
                    }
            });
            FromTreeList.Add(new TreeNodeModel()
            {
                Id = 1,
                Text = "Első",
                IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                        }
                    }
            });

            ToTreeList = new List<TreeNodeModel>();

            ToTreeList.Add(new TreeNodeModel()
            {
                Id = 1,
                Text = "Első",
                IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                        }
                    }
            });
            ToTreeList.Add(new TreeNodeModel()
            {
                Id = 1,
                Text = "Első",
                IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                        }
                    }
            });
            ToTreeList.Add(new TreeNodeModel()
            {
                Id = 1,
                Text = "Első",
                IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                        }
                    }
            });
            ToTreeList.Add(new TreeNodeModel()
            {
                Id = 1,
                Text = "Első",
                IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel() {
                            Id = 2,
                            Text = "Első.Egy",
                            IconUrl = "https://assets.coingecko.com/coins/images/1060/large/icon-icx-logo.png?1547035003",
                        }
                    }
            });
        }
    }
}
