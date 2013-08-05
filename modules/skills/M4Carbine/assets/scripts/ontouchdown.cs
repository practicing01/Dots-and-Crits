function class_M4Carbine::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}

%player=$players.getObject(0);
%customfieldobj=M4Carbine.customplayerfields.getObject(0);//we know it's user 0 cus they use mouse

if (%player.ammo>0){%player.ammo--;}else{return;}

setskillanimation(%player,2);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote

cancel(%player.schedule_keycleanup);
%player.schedule_keycleanup=schedule(1000,0,"keycleanup",0);

Audiere_Stop(%customfieldobj.sound_m4_fire);
Audiere_Reset(%customfieldobj.sound_m4_fire);
Audiere_Play(%customfieldobj.sound_m4_fire,0,1.0);

%objlist=DotsandCritsscene.pickRayCollision(%player.sprite.Position,%worldPosition,
bit(1)|bit(25)|bit(26)|bit(30),"");//26=world objects, 25=npc's, 30=walls

if (getWordCount(%objlist))
{

//get first objects position
%closestid=getWord(%objlist,0);
%closestpos=getWord(%objlist,1) SPC getWord(%objlist,2);

//string is divided into 7-string chunks, since we got the first (0-6 pieces) we start at the second chunk (7-13)
for (%x=7;%x<getWordCount(%objlist);%x+=7)
{

%pos=getWord(%objlist,%x+1) SPC getWord(%objlist,%x+2);//0 piece is id, 1 and 2 are x,y collision point

if (Vector2Distance(%player.sprite.Position,%pos)
<
Vector2Distance(%player.sprite.Position,%closestpos))
{

%closestid=getWord(%objlist,%x);
%closestpos=%pos;

}

}

if (%closestid.class$="class_player")
{
%playerhit=$players.getObject(%closestid.playerindex);
if (getRandom(0,9)==2)
{
%playerhit.health-=100;
}
else
{
%playerhit.health-=34;
}
$levelmoduleid.ScopeSet.healthdisplay(%closestid.playerindex,%playerhit.health);
}
else
{
if (%closestid.health>0)
{
if (getRandom(0,9)==2)
{
%closestid.health-=100;
}
else
{
%closestid.health-=34;
}
%closestid.updatehealth();
}
}

}

}

///////////////////////////////////////////////////////////////

function class_M4Carbine::joycallback(%this,%state,%cursorpos)
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

if (%player.ammo>0){%player.ammo--;}else{return;}

setskillanimation(%player,2);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote

cancel(%player.schedule_keycleanup);
%player.schedule_keycleanup=schedule(1000,0,"keycleanup",1);

Audiere_Stop(%customfieldobj.sound_m4_fire);
Audiere_Reset(%customfieldobj.sound_m4_fire);
Audiere_Play(%customfieldobj.sound_m4_fire,0,1.0);

if (DotsandCritswindow.Visible)
{
%objlist=DotsandCritsscene.pickRayCollision(%player.sprite.Position,DotsandCritswindow.getWorldPoint(%cursorpos),
bit(0)|bit(25)|bit(26)|bit(30),"");//26=world objects, 25=npc's, 30=walls
}
else
{
if (!$splitplane)
{
%cursorpos.X-=$resolution.X/2;
}
else
{
%cursorpos.Y-=$resolution.Y/2;
}echo(%cursorpos);
%objlist=DotsandCritsscene.pickRayCollision(%player.sprite.Position,scenewindow_player2.getWorldPoint(%cursorpos),
bit(0)|bit(25)|bit(26)|bit(30),"");//26=world objects, 25=npc's, 30=walls
}

if (getWordCount(%objlist))
{

//get first objects position
%closestid=getWord(%objlist,0);
%closestpos=getWord(%objlist,1) SPC getWord(%objlist,2);

//string is divided into 7-string chunks, since we got the first (0-6 pieces) we start at the second chunk (7-13)
for (%x=7;%x<getWordCount(%objlist);%x+=7)
{

%pos=getWord(%objlist,%x+1) SPC getWord(%objlist,%x+2);//0 piece is id, 1 and 2 are x,y collision point

if (Vector2Distance(%player.sprite.Position,%pos)
<
Vector2Distance(%player.sprite.Position,%closestpos))
{

%closestid=getWord(%objlist,%x);
%closestpos=%pos;

}

}

if (%closestid.class$="class_player")
{
%playerhit=$players.getObject(%closestid.playerindex);
if (getRandom(0,9)==2)
{
%playerhit.health-=100;
}
else
{
%playerhit.health-=34;
}
$levelmoduleid.ScopeSet.healthdisplay(%closestid.playerindex,%playerhit.health);
}
else
{
if (%closestid.health>0)
{
if (getRandom(0,9)==2)
{
%closestid.health-=100;
}
else
{
%closestid.health-=34;
}
%closestid.updatehealth();
}
}

}

}
}
