using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using git_demo_viewer.Graph;
using LibGit2Sharp;

namespace git_demo_viewer
{
    public class GitViewModel : INotifyPropertyChanged
    {
        private GitGraph graph;
        private Repository repository;

        public GitGraph Graph
        {
            get { return graph; }
            set
            {
                this.graph = value;
                NotifyPropertyChanged("Graph");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public GitViewModel(Repository repo)
        {
            this.repository = repo;

            this.Reload();
        }

        public void Reload()
        {
            var g = new GitGraph();
            this.Refresh(g);
            this.Graph = g;
        }

        public void Refresh()
        {
            this.Refresh(this.graph);
        }

        public void Refresh(GitGraph graph)
        {
            foreach (var branch in this.repository.Branches)
            {
                if (!branch.CanonicalName.EndsWith("/HEAD"))
                {
                    if (AddBranch(graph, branch) == null)
                        return;
                }
            }

        }

        private BranchVertex AddBranch(GitGraph graph, Branch branch)
        {
            BranchVertex bv;
            BranchEdge be;
            CommitVertex cv;

            if (graph.TryGetBranchVertex(branch.Name, out bv))
            {
                if (bv.Branch.Tip.Sha == branch.Tip.Sha)
                    return bv;

                // Found the branch but it's pointing to another commit. Let's remove it
                // and re-add it

                if (graph.TryGetCommitVertex(bv.Branch.Tip.Sha, out cv))
                {
                    GitEdge e;

                    if (this.graph.TryGetEdge(bv, cv, out e))
                        this.graph.RemoveEdge(e);
                }

                this.graph.RemoveVertex(bv);
            }

            cv = AddCommit(graph, branch.Tip);

            if (cv == null)
                return null;

            if (bv == null)
                bv = new BranchVertex(branch);
            
            be = new BranchEdge(bv, cv);

            graph.AddVertex(bv);
            graph.AddEdge(be);

            return bv;
        }

        private CommitVertex AddCommit(GitGraph graph, Commit commit, int depth = 0)
        {
            if (depth > 25)
                return null;

            CommitVertex existing;

            if (graph.TryGetCommitVertex(commit.Sha, out existing))
                return existing;

            var vertex = new CommitVertex(commit);
            graph.AddCommitVertex(vertex);

            foreach (var parent in commit.Parents)
            {
                var parentVertex = AddCommit(graph, parent, depth + 1);

                if (parentVertex != null)
                    graph.AddEdge(new CommitEdge(vertex, parentVertex));
            }

            return vertex;
        }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}
