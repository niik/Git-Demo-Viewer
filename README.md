# Git Demo Viewer #

Code dump of one of my hacks. A git tree vizualiser. Never finished, severely lacking in features. Built using libgitsharp, QuickGraph and Graphsharp.

Phil Haack created a very similar but much less hacky visualizer ([blog post](http://haacked.com/archive/2012/03/15/visualize-git-with-seegit.aspx), [github](https://github.com/Haacked/SeeGit)) and you'd do best to check that out instead.

![](https://s3-eu-west-1.amazonaws.com/freakcode/git-demo-viewer.png)

## Usage
Start it up, point it to a git repo and press F5 to have it refresh the changes in the git repo. Refreshing doesn't remove dangling commits (useful for showing what happens in a rebase scenerio for example). Ctrl+F5 reloads the entire graph.

## TODO

* Branch-refs (origin/HEAD -> origin/master instead of pointing at commit if in sync)
* Auto-refresh (filesystemmonitor?)
* Horizontal graphs
* Optimize AddCommit, it recurses on each commit now, it's really not neccesary.
* Custom graph layout? We can assume quite a lot due to the git conventions so we should be
  able to make a nice graph quite easily.
    * Would allow us to position branches better to more clearly illustrate that they point to 
	  a commit
* Limits/ranges (ie, show only commits based on x) -- for reducing clutter when demoing
* Color coding based on hash? Could make it easier to see when dealing with few commits.
  * We could just do assignment for each new sha we see so that it isn't random. Keep a palette of
    good contrasting colors and assign them on the fly.
* Options
	* Show full/abbrevated hash
	* Include author
	* Hide message
	* Include relative date?
	* Keep dangling commits
		* Good for teaching, illustrate that just because you
		  remove a commit it's not gone, it's still there.
	* Always-on-top
	* Show reflog?
* Presentation mode?
	* Always on top
	* Hide window borders, make it compact
	* Auto zoom to "the action" ?
* Hover highligting, notes and edges
* Hover detailed info
	* In popover?
* (teaching mode)?
	follow the concepts of pro-git (see http://progit.org/book/ch3-2.html)
	and name the nodes c0, c1, c2 and so on (based on date?) for more compact
	viewing when demoing