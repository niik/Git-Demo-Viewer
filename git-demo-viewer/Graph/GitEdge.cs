using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp;
using QuickGraph;

namespace git_demo_viewer.Graph
{
    public abstract class GitEdge : Edge<GitVertex>
    {
        public abstract string Title { get; }

        public GitEdge(GitVertex source, GitVertex target) : base(source, target) { }
    }
}
