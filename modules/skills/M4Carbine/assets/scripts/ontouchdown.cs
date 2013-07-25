function class_M4Carbine::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}

%player=$players.getObject(0);
%customfieldobj=M4Carbine.customplayerfields.getObject(0);//we know it's user 0 cus they use mouse

Audiere_Stop(%customfieldobj.sound_m4_fire);
Audiere_Reset(%customfieldobj.sound_m4_fire);
Audiere_Play(%customfieldobj.sound_m4_fire,0,1.0);

%objlist=DotsandCritsscene.pickRayCollision(%player.sprite.Position,%worldPosition,
bit(1)|bit(25)|bit(26),"");//26=world objects

if (getWordCount(%objlist))
{

%obj=getWord(%objlist,0);

if (%obj.class$="class_player")
{
%playerhit=$players.getObject(%obj.playerindex);
%playerhit.health-=100;
$levelmoduleid.ScopeSet.healthdisplay(%obj.playerindex,%playerhit.health);
}
else
{
%obj.health-=100;
%obj.updatehealth();
}

}

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

Audiere_Stop(%customfieldobj.sound_m4_fire);
Audiere_Reset(%customfieldobj.sound_m4_fire);
Audiere_Play(%customfieldobj.sound_m4_fire,0,1.0);

if (DotsandCritswindow.Visible)
{
%objlist=DotsandCritsscene.pickRayCollision(%player.sprite.Position,DotsandCritswindow.getWorldPoint(%cursorpos),
bit(0)|bit(25)|bit(26),"");//26=world objects
}
else
{
%objlist=DotsandCritsscene.pickRayCollision(%player.sprite.Position,scenewindow_player2.getWorldPoint(%cursorpos),
bit(0)|bit(25)|bit(26),"");//26=world objects
}

if (getWordCount(%objlist))
{

%obj=getWord(%objlist,0);

if (%obj.class$="class_player")
{
%playerhit=$players.getObject(%obj.playerindex);
%playerhit.health-=100;
$levelmoduleid.ScopeSet.healthdisplay(%obj.playerindex,%playerhit.health);
}
else
{
%obj.health-=100;
%obj.updatehealth();
}

}

}
}
