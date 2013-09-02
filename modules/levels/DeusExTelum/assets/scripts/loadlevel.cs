function DeusExTelum::loadlevel(%this)//change DeusExTelum to your module name
{
cancelallschedules();
DotsandCritsscene.clear();

%this.livemechcount=1;

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

if (isObject(gui_DeusExTelumscore))
{
gui_DeusExTelumscore.delete();
}
DotsandCrits.add(TamlRead("./../gui/score.gui.taml"));
Canvas.pushDialog(gui_DeusExTelumscore);

if ($view==0)
{
DotsandCritsscene.setGravity(0,0);
}
else
{
$levelgravity=-20;//can set to a custom number
DotsandCritsscene.setGravity(0,$levelgravity);
}

%this.loadass();

//feeble attempt at optimization

%this.mapsizescale=5;

%this.worldlimits=($camsize.X*%this.mapsizescale)/2 SPC ($camsize.Y*%this.mapsizescale)/2;

%this.worldlimitsreduced=%this.worldlimits;

%this.worldlimitsreduced.X*=20;
%this.worldlimitsreduced.X/=100;

%this.worldlimitsreduced.Y*=20;
%this.worldlimitsreduced.Y/=100;

%microwaveemittersize=ScaleAssSizeVectorToCam(%this.ass_mech);
%this.halfmicrowaveemittersize=%microwaveemittersize.X/2 SPC %microwaveemittersize.Y/2;

%microwaveparticlesize=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
%this.halfmicrowaveparticlesize=%microwaveparticlesize.X/2 SPC %microwaveparticlesize.Y/2;

//procedural generation

%this.generateworldlimits();
%this.generatespawnportals();

//

//simsets for tile types
//types: ground, wall, decal, dwo, npc
//sprites are decorative objects such as lights
//ground tiles cover the entire map area and must be the same size
//walls will cover 25% of the map
//decals will cover 50% of the map
//dwo's will cover 25% of the map
//npc's will cover 25% of the map

%this.generatefloortiles();

//

%this.generatewalltiles();

//

%this.generatedecaltiles();

//

//%this.generatedwotiles();

//

%this.generatenpcs();

//

%this.spawngoal();

//

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

//init npc's
for (%x=0;%x<DotsandCritsscene.getCount();%x++)
{
%obj=DotsandCritsscene.getObject(%x);
if (%obj.SceneGroup==25)//npc
{
%obj.initialize();
}
}

%schedulehandle_playeremitvisible=new ScriptObject()
{
schedulehandle="0";
};

%schedulehandle_playeremitvisible.schedulehandle=schedule(1000,0,"DeusExTelum::playeremitvisible",%this,%schedulehandle_playeremitvisible);

$cancellableschedules.add(%schedulehandle_playeremitvisible);

%this.load_radar();

}
