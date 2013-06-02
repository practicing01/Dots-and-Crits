function gui_mainmenu::newgame()
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

$player_to_load=0;
if (gui_list_player1.getSelectedItem()!=-1)
{
%moduleid=simset_list_playersprites.getObject(gui_list_player1.getSelectedItem());
%moduleid.ScopeSet.loadsprite();
}
else
{
%moduleid=simset_list_playersprites.getObject(getRandom(0,gui_list_player1.getItemCount()-1));
%moduleid.ScopeSet.loadsprite();
}

$player_to_load=1;
if (gui_list_player2.getSelectedItem()!=-1)
{
%moduleid=simset_list_playersprites.getObject(gui_list_player2.getSelectedItem());
%moduleid.ScopeSet.loadsprite();
}
else
{
%moduleid=simset_list_playersprites.getObject(getRandom(0,gui_list_player2.getItemCount()-1));
%moduleid.ScopeSet.loadsprite();
}

$levelmoduleid.ScopeSet.loadplayerclass();

if (!$singleplayer)
{
if ($aiopponent)
{
//start ai function
$levelmoduleid.ScopeSet.ai();
}
}
else
{

cancel($schedule_centralizecamera.schedulehandle);
cancel($schedule_checkforsplit.schedulehandle);

%player1=$players.getObject(0);

$playerssplit=false;
repositionskillbar();
scenewindow_player1.setVisible(false);
scenewindow_player2.setVisible(false);
DotsandCritswindow.setVisible(true);
DotsandCritswindow.mount(%player1.sprite,"0 0",0,true,false);

%player2=$players.getObject(1);
%player2.sprite.safeDelete();
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
