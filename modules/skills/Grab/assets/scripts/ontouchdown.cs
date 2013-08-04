function class_grabmousecaptureobj::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}

%player=$players.getObject(0);
%customfieldobj=Grab.customplayerfields.getObject(0);//we know it's user 0 cus they use mouse

////////////////////////////////////////////////////////////////////////////

if (!isObject(%customfieldobj.grabbedobject)){return;}

cancel(%customfieldobj.schedulehandle);

if (%player.curdir==0)//up
{
%customfieldobj.grabbedobject.setLinearVelocity(0,100);
}
else if (%player.curdir==1)//down
{
%customfieldobj.grabbedobject.setLinearVelocity(0,-100);
}
else if (%player.curdir==2)//left
{
%customfieldobj.grabbedobject.setLinearVelocity(-100,0);
}
else if (%player.curdir==3)//right
{
%customfieldobj.grabbedobject.setLinearVelocity(100,0);
}

%customfieldobj.grabbedobject=0;

}

///////////////////////////////////////////////////////////////

function class_grabmousecaptureobj::joycallback(%this,%state,%cursorpos)
{
return;
}

///////////////////////////////////////////////////////////////

//joystick click
function class_grabmousecaptureobj::stickclick(%this,%state,%cursorpos)
{
if (%state)//touch down
{

if (!%this.Active){return;}

%player=$players.getObject(1);
%customfieldobj=Grab.customplayerfields.getObject(1);//we know it's user 0 cus they use mouse

if (!isObject(%customfieldobj.grabbedobject)){return;}

cancel(%customfieldobj.schedulehandle);

if (%player.curdir==0)//up
{
%customfieldobj.grabbedobject.setLinearVelocity(0,100);
}
else if (%player.curdir==1)//down
{
%customfieldobj.grabbedobject.setLinearVelocity(0,-100);
}
else if (%player.curdir==2)//left
{
%customfieldobj.grabbedobject.setLinearVelocity(-100,0);
}
else if (%player.curdir==3)//right
{
%customfieldobj.grabbedobject.setLinearVelocity(100,0);
}

%customfieldobj.grabbedobject=0;

}
}
