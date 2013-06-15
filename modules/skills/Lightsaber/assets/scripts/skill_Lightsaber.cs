function Lightsaber::skill_Lightsaber(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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

%customfieldobj=Lightsaber.customplayerfields.getObject(%user);

if (%customfieldobj.Lightsaberon)
{
%customfieldobj.Lightsaberon=false;

%customfieldobj.Lightsabersprite.Visible=false;
%customfieldobj.Lightsabersprite.Active=false;
%customfieldobj.shoulderobj.Active=false;
%customfieldobj.shoulderobj.Visible=false;
%customfieldobj.elbowobj.Active=false;
%customfieldobj.elbowobj.Visible=false;
%customfieldobj.mountobj.dismount();
%customfieldobj.mountobj.Active=false;
%customfieldobj.mountobj.Visible=false;
%customfieldobj.dummyobj.Active=false;
%customfieldobj.dummyobj.Visible=false;

DotsandCritsscene.deleteJoint(%customfieldobj.shoulderrevolutejoint);
DotsandCritsscene.deleteJoint(%customfieldobj.elbowrevolutejoint);
DotsandCritsscene.deleteJoint(%customfieldobj.saberjoint);
DotsandCritsscene.deleteJoint(%customfieldobj.dummyjoint);

}
else
{

%customfieldobj.Lightsaberon=true;

%customfieldobj.Lightsabersprite.Visible=true;
%customfieldobj.Lightsabersprite.Active=true;
%customfieldobj.shoulderobj.Active=true;
%customfieldobj.shoulderobj.Visible=true;
%customfieldobj.elbowobj.Active=true;
%customfieldobj.elbowobj.Visible=true;
%customfieldobj.mountobj.Active=true;
%customfieldobj.mountobj.Visible=true;
%customfieldobj.dummyobj.Active=true;
%customfieldobj.dummyobj.Visible=true;

%customfieldobj.Lightsabersprite.parentsimobject.mouseprevpos=DotsandCritswindow.getMousePosition();

%spritesize=%player.sprite.getSpriteSize();

%sabersize=ScaleAssSizeVectorToCam(Lightsaber.Lightsaberass);

%customfieldobj.mountobj.Position=%player.sprite.Position;

%customfieldobj.dummyobj.Position=%player.sprite.Position;

%customfieldobj.shoulderobj.Position=%player.sprite.Position;

%customfieldobj.elbowobj.Position=%player.sprite.Position;

%customfieldobj.elbowobj.Position.Y+=%spritesize.Y/2;

%customfieldobj.Lightsabersprite.Position=%customfieldobj.elbowobj.Position;

%customfieldobj.Lightsabersprite.Position.Y+=%sabersize.Y/2;

//attach joints
%customfieldobj.mountobj.mount(%player.sprite,"0 0",0,true,0);

%customfieldobj.dummyjoint=DotsandCritsscene.createWeldJoint(%customfieldobj.mountobj,%customfieldobj.dummyobj,
"0 0","0 0",0,1,false);

%customfieldobj.shoulderrevolutejoint=DotsandCritsscene.createRevoluteJoint(%customfieldobj.dummyobj,%customfieldobj.shoulderobj,
"0 0","0 0",false);

%customfieldobj.elbowrevolutejoint=DotsandCritsscene.createRevoluteJoint(%customfieldobj.shoulderobj,%customfieldobj.elbowobj,
%customfieldobj.shoulderobj.getLocalPoint(%customfieldobj.elbowobj.Position),"0 0",false);

%customfieldobj.saberjoint=DotsandCritsscene.createWeldJoint(%customfieldobj.elbowobj,%customfieldobj.Lightsabersprite,
%customfieldobj.elbowobj.getLocalPoint(%customfieldobj.Lightsabersprite.Position),"0 0",0,1,false);

}

//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
