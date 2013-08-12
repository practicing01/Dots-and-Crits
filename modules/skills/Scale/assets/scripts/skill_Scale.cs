function Scale::skill_Scale(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
//////////////////

if (!%user)
{

%mousepos="0 0";

if (DotsandCritswindow.Visible)
{
%mousepos=DotsandCritswindow.getMousePosition();
}
else if (scenewindow_player1.Visible)
{
%mousepos=scenewindow_player1.getMousePosition();
}

%newsize="0 0";

%newsize.X=mAbs(%player.sprite.Position.X-%mousepos.X);
%newsize.Y=mAbs(%player.sprite.Position.Y-%mousepos.Y);

%player.sprite.setSpriteSize(%newsize);
%player.sprite.clearCollisionShapes();
%player.sprite.createPolygonBoxCollisionShape(%newsize);

}
else
{

%mousepos="0 0";

if (DotsandCritswindow.Visible)
{
%mousepos=DotsandCritswindow.getMousePosition();
}
else if (scenewindow_player2.Visible)
{
%mousepos=scenewindow_player2.getMousePosition();
}

%newsize="0 0";

%newsize.X=mAbs(%player.sprite.Position.X-$joyobject.cursorgui.Position.X);
%newsize.Y=mAbs(%player.sprite.Position.Y-$joyobject.cursorgui.Position.Y);

%player.sprite.setSpriteSize(%newsize);
%player.sprite.clearCollisionShapes();
%player.sprite.createPolygonBoxCollisionShape(%newsize);


}

//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
