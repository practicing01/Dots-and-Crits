function bitweb::loadlevel(%this)
{
///////////////////////////////////////////////////////////////////////////

$bitwebhandle=%this;

cancelallschedules();
DotsandCritsscene.clear();

///////////////////////////////////////////////////////////////////////////

%this.loadedscene=TamlRead("./../../scenes/bitweb.scene.taml");

if (!isObject(%this.loadedscene))
{
echo("couldn't read taml");
}

%this.loadedscene.setName("");
setCustomScene(%this.loadedscene);

///////////////////////////////////////////////////////////////////////////

DotsandCritsscene.setGravity(0,0);

///////////////////////////////////////////////////////////////////////////

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

%player1=$players.getObject(0);
%player2=$players.getObject(1);

//game-specific resizing of player sprites so custom sprites can be used
%size=((24*$resolution.X)/1280) SPC ((24*$resolution.Y)/800);
%size.X=(%size.X*$camsize.X)/$resolution.X;
%size.Y=(%size.Y*$camsize.Y)/$resolution.Y;

%player1.sprite.setSpriteSize(%size);
%player1.sprite.clearCollisionShapes();
%player1.sprite.createPolygonBoxCollisionShape(%size);

%player2.sprite.setSpriteSize(%size);
%player2.sprite.clearCollisionShapes();
%player2.sprite.createPolygonBoxCollisionShape(%size);

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

if (isObject(%player2))
{
%player2.sprite.safeDelete();
}

$joyobject.cursorgui.Visible=false;
}

DotsandCritswindow.dismount();
DotsandCritswindow.setCameraPosition(0,0);

///////////////////////////////////////////////////////////////////////////

Canvas.popDialog(gui_skillbar);

///////////////////////////////////////////////////////////////////////////

if (isObject(gui_bitwebscore))
{
gui_bitwebscore.delete();
}
DotsandCrits.add(TamlRead("./../gui/score.gui.taml"));
Canvas.pushDialog(gui_bitwebscore);

///////////////////////////////////////////////////////////////////////////

%this.schedule_shuffle=new ScriptObject()
{
schedulehandle=0;
};
$cancellableschedules.add(%this.schedule_shuffle);
%this.loadgates();

///////////////////////////////////////////////////////////////////////////

%this.loadgoal();

///////////////////////////////////////////////////////////////////////////

%this.loadaudioass();

/*
Audiere_Stop(%this.sound_levelmusic);
Audiere_Reset(%this.sound_levelmusic);
Audiere_Play(%this.sound_levelmusic,1,1.0);
*/

alxStop(%this.sound_levelmusic);
%this.sound_levelmusic=alxPlay("bitweb:audio_levelmusic");

///////////////////////////////////////////////////////////////////////////

%this.initmouseinput();

///////////////////////////////////////////////////////////////////////////

%topscorefile=new FileObject();
%topscorefile.OpenForRead("./../../topscore.txt");
%this.topscore=%topscorefile.readline();
%topscorefile.close();
%topscorefile.delete();
gui_text_player1score.setText("Topscore: "@%this.topscore);
%this.score=0;
gui_text_player2score.setText("Score: "@%this.score);

///////////////////////////////////////////////////////////////////////////

%this.loadspider();

//spawn spiders
for (%x=0;%x<5;%x++)
{
%this.spawnspider();
}

%this.schedule_movespiders=new ScriptObject()
{
schedulehandle=0;
};
$cancellableschedules.add(%this.schedule_movespiders);

%this.schedule_movespiders.schedulehandle=schedule(5000,0,"bitweb::movespiders",%this);

%this.schedule_respawnspiders=new ScriptObject()
{
schedulehandle=0;
};
$cancellableschedules.add(%this.schedule_respawnspiders);

%this.schedule_respawnspiders.schedulehandle=schedule(20000,0,"bitweb::respawnspiders",%this);

///////////////////////////////////////////////////////////////////////////

%player=$players.getObject(0);
%player.sprite.isimmune=false;
%player.sprite.immunityfadeschedule=0;

%this.loadimmunity();

%this.schedule_respawnimmunity=new ScriptObject()
{
schedulehandle=0;
};
$cancellableschedules.add(%this.schedule_respawnimmunity);

%this.schedule_respawnimmunity.schedulehandle=schedule(20000,0,"class_immunity::respawn",%this.immunity);

///////////////////////////////////////////////////////////////////////////

%this.loadsurvivor();

%this.schedule_respawnsurvivor=new ScriptObject()
{
schedulehandle=0;
};
$cancellableschedules.add(%this.schedule_respawnsurvivor);

%this.schedule_respawnsurvivor.schedulehandle=schedule(20000,0,"class_survivor::respawn",%this.survivor);

///////////////////////////////////////////////////////////////////////////

%this.loadinfected();

%this.schedule_moveinfected=new ScriptObject()
{
schedulehandle=0;
};
$cancellableschedules.add(%this.schedule_moveinfected);

%this.schedule_moveinfected.schedulehandle=schedule(5000,0,"bitweb::moveinfected",%this);

///////////////////////////////////////////////////////////////////////////

%player=$players.getObject(0);
%player.sprite.ammo=0;

%this.loadprojectile();

%this.schedule_respawnprojectile=new ScriptObject()
{
schedulehandle=0;
};
$cancellableschedules.add(%this.schedule_respawnprojectile);

%this.schedule_respawnprojectile.schedulehandle=schedule(20000,0,"class_bitwebprojectile::respawn",%this.projectile);

///////////////////////////////////////////////////////////////////////////

%this.schedule_shuffle.schedulehandle=schedule(20000,0,"bitweb::shufflegates",%this);
}
