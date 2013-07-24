function class_M4Carbine::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}

%player=$players.getObject(0);
%customfieldobj=M4Carbine.customplayerfields.getObject(0);//we know it's user 0 cus they use mouse

Audiere_Stop(%customfieldobj.sound_m4_fire);
Audiere_Reset(%customfieldobj.sound_m4_fire);
Audiere_Play(%customfieldobj.sound_m4_fire,0,1.0);

}

///////////////////////////////////////////////////////////////

function class_M4Carbine::joycallback(%state,%cursorpos)
{
return;
}

///////////////////////////////////////////////////////////////

//joystick click
function class_M4Carbine::stickclick(%this,%state,%cursorpos)
{
if (%state)//touch down
{

if (!%this.Active){return;}

%player=$players.getObject(1);
%customfieldobj=M4Carbine.customplayerfields.getObject(1);//we know it's user 0 cus they use mouse



}
}
