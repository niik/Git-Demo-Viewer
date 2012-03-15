using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace git_demo_viewer.Graph
{
    public class CommitVertex : GitVertex
    {
        public Commit Commit { get; set; }

        public override string Title
        {
            get { return this.Commit.Sha.Substring(0, 6); }
        }

        public string Subject
        {
            get
            {
                if (this.Commit.MessageShort.Length <= 25)
                    return this.Commit.MessageShort;

                return this.Commit.MessageShort.Substring(0, 25);
            }
        }

        public CommitVertex(Commit commit)
        {
            this.Commit = commit;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
