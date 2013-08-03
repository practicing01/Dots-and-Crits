function space::loadlevel(%this)
{
cancelallschedules();
DotsandCritsscene.clear();

if ($view==0)
{
%this.loadedscene=TamlRead("./../../scenes/topdown.scene.taml");
}
else
{
%this.loadedscene=TamlRead("./../../scenes/sideview.scene.taml");
}

if (!isObject(%this.loadedscene))
{
echo("couldn't read taml");
}

%this.loadedscene.setName("");
setCustomScene(%this.loadedscene);

if ($view==0)
{
DotsandCritsscene.setGravity(0,0);
}
else
{
$levelgravity=-20;
DotsandCritsscene.setGravity(0,$levelgravity);
}

$player_to_load=0;
if (gui_list_player1.getSelectedItem()!=-1)
{
%this.p1moduleid=simset_list_playersprites.getObject(gui_list_player1.getSelectedItem());
%this.p1moduleid.ScopeSet.loadsprite();
}
else
{
%this.p1moduleid=simset_list_playersprites.getObject(getRandom(0,gui_list_player1.getItemCount()-1));
%this.p1moduleid.ScopeSet.loadsprite();
}

$player_to_load=1;
if (gui_list_player2.getSelectedItem()!=-1)
{
%this.p2moduleid=simset_list_playersprites.getObject(gui_list_player2.getSelectedItem());
%this.p2moduleid.ScopeSet.loadsprite();
}
else
{
%this.p2moduleid=simset_list_playersprites.getObject(getRandom(0,gui_list_player2.getItemCount()-1));
%this.p2moduleid.ScopeSet.loadsprite();
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
if (isObject(scenewindow_player1))
{
scenewindow_player1.setVisible(false);
}
if (isObject(scenewindow_player2))
{
scenewindow_player2.setVisible(false);
}
DotsandCritswindow.setVisible(true);
DotsandCritswindow.mount(%player1.sprite,"0 0",0,true,false);

%player2=$players.getObject(1);
if (isObject(%player2.sprite))
{
%player2.sprite.safeDelete();
}

$joyobject.cursorgui.Visible=false;
}

if (isObject(gui_spacescore))
{
gui_spacescore.delete();
}
DotsandCrits.add(TamlRead("./../gui/score.gui.taml"));
Canvas.pushDialog(gui_spacescore);

//init npc's
for (%x=0;%x<DotsandCritsscene.getCount();%x++)
{
%obj=DotsandCritsscene.getObject(%x);
if (%obj.SceneGroup==25)//npc
{
%obj.initialize();
}
}

}
