function deathballvalley::sudodestroy(%this)
{
if (isObject(gui_deathballvalleyscore))
{
gui_deathballvalleyscore.delete();
}
}
