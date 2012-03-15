using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;
using GraphSharp.Controls;
using GraphSharp.Algorithms.Layout.Simple.Tree;
using GraphSharp.Algorithms.Layout.Simple.Hierarchical;
using GraphSharp.Algorithms.Layout;

namespace git_demo_viewer.Graph
{
    public class GitGraphLayout : GraphLayout<GitVertex, GitEdge, GitGraph>
    {
        public GitGraphLayout()
        {
            LayoutAlgorithmType = "EfficientSugiyama";
            //LayoutParameters = new SimpleTreeLayoutParameters
            //{
            //    Direction = LayoutDirection.RightToLeft,
            //    OptimizeWidthAndHeight = true,

            //};
        }
    }
}
