function bitweb::sudodestroy(%this)
{

%this.unloadgates();

%this.unloadaudioass();

%this.unloadgoal();

%this.unloadspider();

%this.unloadinfected();

%this.unloadimmunity();

%this.unloadsurvivor();

%this.unloadaudioass();

%this.unloadprojectile();

deleteVariables("$bitwebhandle");

if (isObject(gui_bitwebscore))
{
gui_bitwebscore.delete();
}
}
