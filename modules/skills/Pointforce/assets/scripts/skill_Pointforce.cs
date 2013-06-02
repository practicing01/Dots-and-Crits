function Pointforce::skill_Pointforce(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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

%customfieldobj=Pointforce.customplayerfields.getObject(%user);

if (%customfieldobj.controllerhandle)
{
%customfieldobj.controllerhandle.delete();
%customfieldobj.controllerhandle=0;
}
else
{

%customfieldobj.controllerhandle=new PointForceController();
%customfieldobj.controllerhandle.setControlGroups(26);
%customfieldobj.controllerhandle.setControlLayers("0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30");
%customfieldobj.controllerhandle.Radius=30;
%customfieldobj.controllerhandle.Force=10000;
%customfieldobj.controllerhandle.NonLinear=false;
%customfieldobj.controllerhandle.LinearDrag=1;
%customfieldobj.controllerhandle.AngularDrag=1;
DotsandCritsscene.Controllers.add(%customfieldobj.controllerhandle);
%customfieldobj.controllerhandle.setTrackedObject(%player.sprite);
%customfieldobj.controllerhandle.Position="30 0";

}

//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
