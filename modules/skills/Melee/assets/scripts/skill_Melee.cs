function Melee::skill_Melee(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

if (%iteration==0)
{
setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
//////////////////
//should add nice fancy spell effect anim
//////////////////
%objlist=DotsandCritsscene.pickArea(
%player.sprite.Position.X-(%player.sprite.getWidth()),
%player.sprite.Position.Y+(%player.sprite.getHeight()),
%player.sprite.Position.X+(%player.sprite.getWidth()),
%player.sprite.Position.Y-(%player.sprite.getHeight()),
bit(!%this.playerindex)|bit(25)|bit(26),"","oobb");//26=dynamic objects

for (%x=0;%x<getWordCount(%objlist);%x++)
{
%obj=getWord(%objlist,%x);
if (%obj.class$="class_player")
{
%player2=$players.getObject(%obj.playerindex);
%player2.health-=10;
$levelmoduleid.ScopeSet.healthdisplay(%obj.playerindex,%player2.health);
}
else if (%obj.SceneGroup==25||%obj.SceneGroup==26)//npc's, dynamic world objects
{
if (%obj.health>0)
{
%obj.health-=10;
%obj.updatehealth();
}
}
}//end for
///////////////
}
else if (%iteration==1)//give it at least 1/2 second of casting animation
{
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}
//////////////////
%iteration++;
%scheduleobject.schedulehandle=schedule(500,0,"Melee::skill_Melee",%this,%scheduleobject,%user,%iteration);
//////////////////
}
