function Lightsaber2::skill_Lightsaber2(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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

%customfieldobj=Lightsaber2.customplayerfields.getObject(%user);

if (%customfieldobj.Lightsaber2on)
{
%customfieldobj.Lightsaber2on=false;

%customfieldobj.Lightsaber2sprite.Visible=false;
%customfieldobj.Lightsaber2sprite.Active=false;
%customfieldobj.shoulderobj.Active=false;
%customfieldobj.shoulderobj.Visible=false;
%customfieldobj.mountobj.dismount();
%customfieldobj.mountobj.Active=false;
%customfieldobj.mountobj.Visible=false;
%customfieldobj.dummyobj.Active=false;
%customfieldobj.dummyobj.Visible=false;

DotsandCritsscene.deleteJoint(%customfieldobj.shoulderrevolutejoint);
DotsandCritsscene.deleteJoint(%customfieldobj.saberjoint);
DotsandCritsscene.deleteJoint(%customfieldobj.dummyjoint);

}
else
{

%customfieldobj.Lightsaber2on=true;

%customfieldobj.Lightsaber2sprite.Visible=true;
%customfieldobj.Lightsaber2sprite.Active=true;
%customfieldobj.shoulderobj.Active=true;
%customfieldobj.shoulderobj.Visible=true;
%customfieldobj.mountobj.Active=true;
%customfieldobj.mountobj.Visible=true;
%customfieldobj.dummyobj.Active=true;
%customfieldobj.dummyobj.Visible=true;

%customfieldobj.Lightsaber2sprite.parentScriptObject.mouseprevpos=DotsandCritswindow.getMousePosition();

%spritesize=%player.sprite.getSpriteSize();

%sabersize=ScaleAssSizeVectorToCam(Lightsaber2.Lightsaber2ass);

%customfieldobj.mountobj.Position=%player.sprite.Position;

%customfieldobj.dummyobj.Position=%player.sprite.Position;

%customfieldobj.shoulderobj.Position=%player.sprite.Position;

%customfieldobj.Lightsaber2sprite.Position=%customfieldobj.shoulderobj.Position;
%customfieldobj.Lightsaber2sprite.Position.Y+=%spritesize.Y/2;
%customfieldobj.Lightsaber2sprite.Position.Y+=%sabersize.Y/2;

//attach joints
%customfieldobj.mountobj.mount(%player.sprite,"0 0",0,true,0);

%customfieldobj.dummyjoint=DotsandCritsscene.createWeldJoint(%customfieldobj.mountobj,%customfieldobj.dummyobj,
"0 0","0 0",0,1,false);

%customfieldobj.shoulderrevolutejoint=DotsandCritsscene.createRevoluteJoint(%customfieldobj.dummyobj,%customfieldobj.shoulderobj,
"0 0","0 0",false);

%customfieldobj.saberjoint=DotsandCritsscene.createWeldJoint(%customfieldobj.shoulderobj,%customfieldobj.Lightsaber2sprite,
%customfieldobj.shoulderobj.getLocalPoint(%customfieldobj.Lightsaber2sprite.Position),"0 0",0,1,false);

}

//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
