function Snare::skill_Snare(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

%customfieldobj=Snare.customplayerfields.getObject(%user);

if (%iteration==0)
{
setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
//////////////////
//should add nice fancy spell effect anim

//pickray
//store handle

%dest=%player.sprite.Position;

if (%player.curdir==0)//up
{
%dest.Y+=ScaleVectorToCam("0" SPC $resolution.Y).Y;
}
else if (%player.curdir==1)//down
{
%dest.Y-=ScaleVectorToCam("0" SPC $resolution.Y).Y;
}
else if (%player.curdir==2)//left
{
%dest.X-=ScaleVectorToCam($resolution.X SPC "0").X;
}
else if (%player.curdir==3)//right
{
%dest.X+=ScaleVectorToCam($resolution.X SPC "0").X;
}

%objlist=DotsandCritsscene.pickRayCollision(%player.sprite.Position,%dest,
bit(!%user)|bit(25)|bit(26),"");//26=world objects

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

%customfieldobj.targethandle=%closestid;

}
else if (%iteration==1)//give it at least 1 second of casting animation
{
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
}

if (%iteration<10)
{
if (isObject(%customfieldobj.targethandle))
{

if (%customfieldobj.targethandle.Class$="class_player")
{

%targplayer=$players.getObject(%customfieldobj.targethandle.playerindex);

if (%targplayer.speed>0){%targplayer.speed-=$normalplayerspeed;}
if (%targplayer.speed<0){%targplayer.speed=0;}

restartmove(%targplayer);

}
else if (%customfieldobj.targethandle.SceneGroup==25)//npcs
{

if (%customfieldobj.targethandle.speed>0){%customfieldobj.targethandle.speed-=%customfieldobj.targethandle.normalspeed;}
if (%customfieldobj.targethandle.speed<0){%customfieldobj.targethandle.speed=0;}
%customfieldobj.targethandle.cancelMoveTo();

}

}
}
else if (%iteration>=10)
{
if (isObject(%customfieldobj.targethandle))
{

if (%customfieldobj.targethandle.Class$="class_player")
{

%targplayer=$players.getObject(%customfieldobj.targethandle.playerindex);

%targplayer.speed+=$normalplayerspeed;

restartmove(%targplayer);

}
else if (%customfieldobj.targethandle.SceneGroup==25)//npcs
{
%customfieldobj.targethandle.speed+=%customfieldobj.targethandle.normalspeed;
}

}

$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}
%iteration++;
%scheduleobject.schedulehandle=schedule(1000,0,"Snare::skill_Snare",%this,%scheduleobject,%user,%iteration);
}
