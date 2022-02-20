using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;

namespace SteamOracale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Graph graph = new Graph();

        public MainWindow()
        {
            InitializeComponent();

            _ = graph.AddProfile("76561198131635745", 0);

            ConnectProfile("76561198022322056", "76561198131635745");
        }

        private void BuildGraph()
        {

            for (int i = graph.profiles.Count - 1; i >= 0; i--)
            {
                if (!graph.profiles[i].searched)
                {
                    graph.profiles[i].SearchProfile(graph);
                } else
                {
                    break;
                }
            }
        }

        private void ConnectProfile(string toConnect, string start)
        {
            bool found = false;
            while (!found)
            {
                BuildGraph();
                for (int i = graph.profiles.Count - 1; i >= 0; i--)
                {
                    if (graph.profiles[i].steamID == toConnect)
                    {
                        found = true;
                        break;
                    }
                }
            }

            _ = Tree.Items.Add(new TextBlock()
            {
                Text = $"{start} | 0"
            });

            foreach (Profile profile in graph.profiles.Where(s => s.weight == 1))
            {
                if (profile.connections.ContainsKey(toConnect))
                {
                    _ = Tree.Items.Add(new TextBlock()
                    {
                        Text = $"{profile.steamID} | {profile.weight}"
                    });

                    _ = Tree.Items.Add(new TextBlock()
                    {
                        Text = $"{toConnect} | 2"
                    });
                    return;
                }
            }

        }
    }
}
