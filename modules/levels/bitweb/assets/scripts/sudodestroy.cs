function bitweb::sudodestroy(%this)
{

%this.unloadgates();

%this.unloadaudioass();

if (isObject(gui_bitwebscore))
{
gui_bitwebscore.delete();
}
}
