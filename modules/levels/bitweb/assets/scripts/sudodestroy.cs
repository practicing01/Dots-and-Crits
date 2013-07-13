function bitweb::sudodestroy(%this)
{

%this.unloadgates();

%this.unloadaudioass();

%this.unloadgoal();

%this.unloadspider();

if (isObject(gui_bitwebscore))
{
gui_bitwebscore.delete();
}
}
