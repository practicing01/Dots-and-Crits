function catacombs::sudodestroy(%this)
{
if (isObject(gui_catacombsscore))
{
gui_catacombsscore.delete();
}
}
