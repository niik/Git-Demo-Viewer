using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp;
using QuickGraph;

namespace git_demo_viewer.Graph
{
    public class CommitEdge : GitEdge
    {
        public CommitEdge(CommitVertex source, CommitVertex target)
            : base(source, target)
        {
            this.SourceCommitVertex = source;
            this.TargetCommitVertex = target;
        }


        public override string Title
        {
            get { return SourceCommitVertex.Title + " is child of " + TargetCommitVertex.Title; }
        }

        public CommitVertex SourceCommitVertex { get; set; }

        public CommitVertex TargetCommitVertex { get; set; }
    }
}
