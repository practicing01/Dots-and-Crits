function bitweb::sudodestroy(%this)
{

%this.unloadgates(%this);

%this.unloadaudioass(%this);

%this.unloadgoal(%this);

%this.unloadspider(%this);

%this.unloadimmunity(%this);

%this.unloadsurvivor(%this);

if (isObject(gui_bitwebscore))
{
gui_bitwebscore.delete();
}
}
