function gui_mainmenu::newgame(%this)
{
$cantogglepausemenu=1;
cancelallschedules();
Canvas.popDialog(gui_mainmenu);

$levelmoduleid=0;
if (gui_list_level.getSelectedItem()!=-1)
{
$levelmoduleid=simset_list_levels.getObject(gui_list_level.getSelectedItem());
$levelmoduleid.ScopeSet.loadlevel();
}
else
{
$levelmoduleid=simset_list_levels.getObject(getRandom(0,gui_list_level.getItemCount()-1));
$levelmoduleid.ScopeSet.loadlevel();
}

//alxStop($menumusic);

//DotsandCritsscene.setDebugOn("joints");
//DotsandCritsscene.setDebugOn("metrics");
//DotsandCritsscene.setDebugOn("fps");
//DotsandCritsscene.setDebugOn("wireframe");
//DotsandCritsscene.setDebugOn("aabb");
//DotsandCritsscene.setDebugOn("oobb");
//DotsandCritsscene.setDebugOn("sleep");
//DotsandCritsscene.setDebugOn("collision");
//DotsandCritsscene.setDebugOn("position");
//DotsandCritsscene.setDebugOn("sort");
//DotsandCritsscene.setDebugOn("controllers");

}
