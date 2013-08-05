exec("./guisplitupdate.cs");

if (isObject(scenewindow_player1))
{
scenewindow_player1.delete();
}

new SceneWindow(scenewindow_player1)
{
Profile=DotsandCritswindowprofile;
};

if (isObject(scenewindow_player2))
{
scenewindow_player2.delete();
}

new SceneWindow(scenewindow_player2)
{
Profile=DotsandCritswindowprofile;
};

if (!$splitplane)//vertical
{
scenewindow_player1.setPosition(0,0);
scenewindow_player1.setExtent($resolution.X/2,$resolution.Y);
scenewindow_player1.setCameraArea("-50 -31.25 0 31.25");

scenewindow_player2.setPosition($resolution.X/2,0);
scenewindow_player2.setExtent($resolution.X/2,$resolution.Y);
scenewindow_player2.setCameraArea("0 -31.25 50 31.25");
}
else//horizontal
{
scenewindow_player1.setPosition(0,0);
scenewindow_player1.setExtent($resolution.X,$resolution.Y/2);
scenewindow_player1.setCameraArea("-50 -31.25 50 0");

scenewindow_player2.setPosition(0,$resolution.Y/2);
scenewindow_player2.setExtent($resolution.X,$resolution.Y/2);
scenewindow_player2.setCameraArea("-50 0 50 31.25");
}

scenewindow_player1.setScene(DotsandCritsscene);
scenewindow_player2.setScene(DotsandCritsscene);
DotsandCritswindow.add(scenewindow_player1);
DotsandCrits.add(scenewindow_player1);
DotsandCritswindow.add(scenewindow_player2);
DotsandCrits.add(scenewindow_player2);
scenewindow_player1.setUseBackgroundColor(true);
scenewindow_player2.setUseBackgroundColor(true);
scenewindow_player1.setBackgroundColor(Black);
scenewindow_player2.setBackgroundColor(Black);
scenewindow_player1.setVisible(false);
scenewindow_player2.setVisible(false);
scenewindow_player1.setObjectInputEventGroupFilter($allBits);
scenewindow_player1.setObjectInputEventLayerFilter($allBits);
scenewindow_player2.setObjectInputEventGroupFilter($allBits);
scenewindow_player2.setObjectInputEventLayerFilter($allBits);
scenewindow_player1.setLockMouse(true);
scenewindow_player2.setLockMouse(true);

if (isObject($schedule_checkforsplit))
{
cancel($schedule_checkforsplit.schedulehandle);
$schedule_checkforsplit.delete();
}

$schedule_checkforsplit=new ScriptObject()
{
schedulehandle="0";
};

if (isObject($schedule_centralizecamera))
{
cancel($schedule_centralizecamera.schedulehandle);
$schedule_centralizecamera.delete();
}

$schedule_centralizecamera=new ScriptObject()
{
schedulehandle="0";
};

function centralizecamera()
{
%player1=$players.getObject(0);
%player2=$players.getObject(1);
if (!isObject(%player1)||!isObject(%player2))
{
$schedule_centralizecamera.schedulehandle=schedule(1,0,"centralizecamera");
return;
}

%campos=VectorAdd(%player1.sprite.Position,%player2.sprite.Position);
%campos.X=%campos.X/2;%campos.Y=%campos.Y/2;
DotsandCritswindow.setCameraPosition(%campos.X,%campos.Y);
$schedule_centralizecamera.schedulehandle=schedule(1,0,"centralizecamera");
}

function splitcamera()
{
%player1=$players.getObject(0);
%player2=$players.getObject(1);
if (!isObject(%player1)||!isObject(%player2))
{
$schedule_checkforsplit.schedulehandle=schedule(1000,0,"splitcamera");
return;
}

%player1pos=%player1.sprite.Position;
%player2pos=%player2.sprite.Position;

if ($playerssplit)
{
if (mAbs(%player1pos.X-%player2pos.X)<$camsize.X&&mAbs(%player1pos.Y-%player2pos.Y)<$camsize.Y)
{
$playerssplit=false;
repositionskillbar();

scenewindow_player1.setVisible(false);
scenewindow_player2.setVisible(false);
DotsandCritswindow.setVisible(true);
DotsandCritswindow.dismount();

guisplitupdate(0);

$schedule_centralizecamera.schedulehandle=schedule(1,0,"centralizecamera");
}
}
else
{
if (mAbs(%player1pos.X-%player2pos.X)>$camsize.X||mAbs(%player1pos.Y-%player2pos.Y)>$camsize.Y)
{
cancel($schedule_centralizecamera.schedulehandle);

$playerssplit=true;
repositionskillbar();

scenewindow_player1.setVisible(true);
scenewindow_player2.setVisible(true);
DotsandCritswindow.setVisible(false);

guisplitupdate(1);

scenewindow_player1.mount(%player1.sprite,"0 0",0,true,false);
scenewindow_player2.mount(%player2.sprite,"0 0",0,true,false);

}
}

$schedule_checkforsplit.schedulehandle=schedule(1000,0,"splitcamera");
}

$schedule_centralizecamera.schedulehandle=schedule(0,0,"centralizecamera");
$schedule_checkforsplit.schedulehandle=schedule(1,0,"splitcamera");

$cancellableschedules.add($schedule_checkforsplit);
$cancellableschedules.add($schedule_centralizecamera);
