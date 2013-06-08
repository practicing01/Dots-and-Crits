//this function unloads level assets

function catacombs::sudodestroy(%this)
{
if (isObject(gui_catacombsscore))
{
gui_catacombsscore.delete();
}
}
