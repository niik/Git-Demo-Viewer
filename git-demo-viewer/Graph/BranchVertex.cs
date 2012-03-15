using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace git_demo_viewer.Graph
{
    public class BranchVertex: GitVertex
    {
        public Branch Branch { get; set; }
        public override string Title
        {
            get { return Branch.Name; }
        }

        public BranchVertex(Branch b)
        {
            this.Branch = b;
        }
    }
}
