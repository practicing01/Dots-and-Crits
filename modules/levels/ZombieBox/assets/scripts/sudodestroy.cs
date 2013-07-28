//this function unloads level assets

function ZombieBox::sudodestroy(%this)
{
if (isObject(gui_ZombieBoxscore))
{
gui_ZombieBoxscore.delete();
}

%this.unloadass();

}
