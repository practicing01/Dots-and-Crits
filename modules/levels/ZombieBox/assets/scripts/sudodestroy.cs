//this function unloads level assets

function ZombieBox::sudodestroy(%this)
{

alxStopAll();

if (isObject(gui_ZombieBoxscore))
{
gui_ZombieBoxscore.delete();
}

%this.unloadass();

%this.p1moduleid.ScopeSet.unloadass();
%this.p2moduleid.ScopeSet.unloadass();
}
