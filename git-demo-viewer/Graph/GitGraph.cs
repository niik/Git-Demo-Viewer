using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;
using LibGit2Sharp;

namespace git_demo_viewer.Graph
{
    public class GitGraph : BidirectionalGraph<GitVertex, GitEdge>
    {
        private Dictionary<string, CommitVertex> commitMap = new Dictionary<string, CommitVertex>();
        private Dictionary<string, BranchVertex> branchMap = new Dictionary<string, BranchVertex>();

        public GitGraph()
            : base(allowParallelEdges: false)
        {
        }

        public override bool AddVertex(GitVertex v)
        {
            var cv = v as CommitVertex;

            if (cv != null)
                return AddCommitVertex(cv);

            var bv = v as BranchVertex;

            if (bv != null)
                return AddBranchVertex(bv);

            return base.AddVertex(v);
        }

        public bool AddCommitVertex(CommitVertex v)
        {
            commitMap.Add(v.Commit.Sha, v);
            return base.AddVertex(v);
        }

        public bool AddBranchVertex(BranchVertex v)
        {
            branchMap.Add(v.Branch.Name, v);
            return base.AddVertex(v);
        }

        public override bool RemoveVertex(GitVertex v)
        {
            if (base.RemoveVertex(v))
            {
                var cv = v as CommitVertex;

                if (cv != null)
                {
                    this.commitMap.Remove(cv.Commit.Sha);
                    return true;
                }

                var bv = v as BranchVertex;

                if (bv != null)
                {
                    this.branchMap.Remove(bv.Branch.Name);
                    return true;
                }

                return true;
            }

            return false;
        }

        public bool ContainsCommit(string sha)
        {
            return this.commitMap.ContainsKey(sha);
        }

        public bool TryGetCommitVertex(string sha, out CommitVertex vertex)
        {
            return commitMap.TryGetValue(sha, out vertex);
        }

        public bool TryGetBranchVertex(string name, out BranchVertex vertex)
        {
            return branchMap.TryGetValue(name, out vertex);
        }
    }
}
