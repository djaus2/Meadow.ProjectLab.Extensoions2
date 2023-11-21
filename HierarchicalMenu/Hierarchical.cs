using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HierarchicalMenu
{
    public class Recursive
    {
        public string Item { get; set; }
        public List<Recursive>? Sub { get; set; } = null;
    }

    public  static class Hierarchical
    {
        public static string MainTitle { get; set; } = "Main Hierarchical Menu";
        public static void InitMenu()
        {
            MenuSelections = new int[NumMenuLevels];
        }

        public static int[] MenuSelections;

        public static string GetSelections()
        {
            List<string> selections = new List<string>();
            string selection = "";
            for (int i = 0; i < NumMenuLevels; i++)
            {
                selection = $"{MenuSelections[i]}:{GetMenu(i+1).Title}";              
                selections.Add(selection);
            }
            string csvSelections = string.Join(",", selections.Select(s => s.ToString()).ToArray());

            return csvSelections;
        }

        public static int NumMenuLevels
        {
            get
            {
                int i = 1;
                List<Recursive> rek = Rec;
                while (rek[0].Sub != null)
                {
                    i++;
                    rek = rek[0].Sub;
                }
                return i;
            }
        }
        public static MenuData GetMenu(int numLevels)
        {
            List<int> items = MenuSelections.Take(numLevels).ToList();

            MenuData md = new MenuData();
            string Title = "";
            List<string> menuItems = new List<string>();
            List<Recursive> rek = Rec;
            if ((items != null) && (items.Count() > 0))
            {
                for (int i=0;i<items.Count();i++)
                {
                    if ((items[i] < 0 ) || (!(rek.Count() > items[i])))
                    {
                        break;
                    }
                    if(items.Count() == i+1)
                    {
                        Title = rek[items[i]].Item;
                        if (rek[items[i]].Sub != null)
                        {
                            menuItems = (from n in rek[items[i]].Sub select n.Item).ToList();
                        }
                    }
                    else
                    {
                        rek = rek[items[i]].Sub;
                    }
                }
            }
            else
            {
                Title = MainTitle;
                menuItems = (from n in rek select n.Item).ToList();
            }

            md.Items = string.Join(",", menuItems.Select(s => s.ToString()).ToArray());
            md.Title = Title;
            return md;
        }

        public static readonly List<Recursive> Rec = new List<Recursive>
        {
            new Recursive {
                Item = "Item1",
                Sub = new List<Recursive>
                {
                    new Recursive {
                        Item = "Item1.1",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item1.1.1"
                            },
                            new Recursive {
                                Item = "Item1.1.2"
                            },
                            new Recursive {
                                Item = "Item1.1.3"
                            },
                            new Recursive {
                                Item = "Item1.1.4"
                            }
                        }
                    },
                    new Recursive {
                        Item = "Item1.2",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item1.2.1"
                            },
                            new Recursive {
                                Item = "Item1.2.2"
                            },
                            new Recursive {
                                Item = "Item1.2.3"
                            },
                            new Recursive {
                                Item = "Item1.2.4"
                            }
                        }
                    },
                    new Recursive {
                        Item = "Item1.3",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item1.3.1"
                            },
                            new Recursive {
                                Item = "Item1.3.2"
                            },
                            new Recursive {
                                Item = "Item1.3.3"
                            },
                            new Recursive {
                                Item = "Item1.3.4"
                            }
                        }
                    },
                }
            },
            new Recursive {
                Item = "Item2",
                Sub = new List<Recursive>
                {
                    new Recursive {
                        Item = "Item2.1",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item2.1.1"
                            },
                            new Recursive {
                                Item = "Item2.1.2"
                            },
                            new Recursive {
                                Item = "Item2.1.3"
                            },
                            new Recursive {
                                Item = "Item2.1.4"
                            },
                        }
                    },
                    new Recursive {
                        Item = "Item2.2",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item2.2.1"
                            },
                            new Recursive {
                                Item = "Item2.2.2"
                            },
                            new Recursive {
                                Item = "Item2.2.3"
                            },
                            new Recursive {
                                Item = "Item2.2.4"
                            }
                        }
                    },
                                            new Recursive {
                        Item = "Item2.3",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item2.3.1"
                            },
                            new Recursive {
                                Item = "Item2.3.2"
                            },
                            new Recursive {
                                Item = "Item2.3.3"
                            },
                            new Recursive {
                                Item = "Item2.3.4"
                            }
                        }
                    },
                }
            },
            new Recursive {
                Item = "Item3",
                Sub = new List<Recursive>
                {
                    new Recursive {
                        Item = "Item3.1",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item3.1.1"
                            },
                            new Recursive {
                                Item = "Item3.1.2"
                            },
                            new Recursive {
                                Item = "Item3.1.3"
                            },
                            new Recursive {
                                Item = "Item3.1.4"
                            },
                            new Recursive {
                                Item = "Item3.1.5"
                            },
                            new Recursive {
                                Item = "Item3.1.6"
                            }
                        }
                    },
                    new Recursive {
                        Item = "Item3.2",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item3.2.1"
                            },
                            new Recursive {
                                Item = "Item3.2.2"
                            },
                            new Recursive {
                                Item = "Item3.2.3"
                            },
                            new Recursive {
                                Item = "Item3.2.4"
                            },
                            new Recursive {
                                Item = "Item3.2.5"
                            },
                            new Recursive {
                                Item = "Item3.2.6"
                            }
                        }
                    },
                    new Recursive {
                        Item = "Item3.3",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item3.3.1"
                            },
                            new Recursive {
                                Item = "Item3.3.2"
                            },
                            new Recursive {
                                Item = "Item3.3.3"
                            },
                            new Recursive {
                                Item = "Item3.3.4"
                            },
                            new Recursive {
                                Item = "Item3.3.5"
                            },
                            new Recursive {
                                Item = "Item3.3.6"
                            }
                        }
                    }
                }
            },
            new Recursive {
                Item = "Item4",
                Sub = new List<Recursive>
                {
                    new Recursive { Item = "Item4.1",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item4.1.1"
                            },
                            new Recursive {
                                Item = "Item4.1.2"
                            },
                            new Recursive {
                                Item = "Item4.1.3"
                            },
                            new Recursive {
                                Item = "Item4.1.4"
                            },
                            new Recursive {
                                Item = "Item4.1.5"
                            },
                            new Recursive {
                                Item = "Item4.1.6"
                            }
                        }
                    },
                    new Recursive {
                        Item = "Item4.2",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item4.2.1"
                            },
                            new Recursive {
                                Item = "Item4.2.2"
                            },
                            new Recursive {
                                Item = "Item4.2.3"
                            },
                            new Recursive {
                                Item = "Item4.2.4"
                            },
                            new Recursive {
                                Item = "Item4.2.5"
                            },
                            new Recursive {
                                Item = "Item4.2.6"
                            }
                        }
                    },
                    new Recursive {
                        Item = "Item4.3",
                        Sub = new List<Recursive> {
                            new Recursive {
                                Item = "Item4.3.1"
                            },
                            new Recursive {
                                Item = "Item4.3.2"
                            },
                            new Recursive {
                                Item = "Item4.3.3"
                            },
                            new Recursive {
                                Item = "Item4.3.4"
                            },
                            new Recursive {
                                Item = "Item4.3.5"
                            },
                            new Recursive {
                                Item = "Item4.3.6"
                            }
                        }
                    },
                }
            }
        };
    }
}