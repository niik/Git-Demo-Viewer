using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp;
using QuickGraph;

namespace git_demo_viewer.Graph
{
    public class BranchEdge : GitEdge
    {
        public BranchEdge(BranchVertex source, CommitVertex target) :
            base(source, target)
        {
            this.BranchVertex = source;
            this.CommitVertex = target;
        }

        public override string Title
        {
            get { return this.BranchVertex.Branch.Name + " is at " + this.CommitVertex.Title; }
        }

        public BranchVertex BranchVertex { get; set; }

        public CommitVertex CommitVertex { get; set; }
    }
}
