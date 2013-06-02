function Grab::skill_Grab(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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

%customfieldobj=Grab.customplayerfields.getObject(%user);

if (isObject(%customfieldobj.grabbedobject))//let go
{
cancel(%customfieldobj.schedulehandle);
%customfieldobj.grabbedobject=0;
}
else
{

%objlist=DotsandCritsscene.pickArea(
%player.sprite.Position.X-(%player.sprite.getWidth()),
%player.sprite.Position.Y+(%player.sprite.getHeight()),
%player.sprite.Position.X+(%player.sprite.getWidth()),
%player.sprite.Position.Y-(%player.sprite.getHeight()),
bit(26),"","oobb");//26=world objects

for (%x=0;%x<getWordCount(%objlist);%x++)
{
%obj=getWord(%objlist,%x);
%customfieldobj.grabbedobject=%obj;

%customfieldobj.grabbedobject.Position=%player.sprite.Position;

%playerspritesize=%player.sprite.getSpriteSize();
%spritesize=%customfieldobj.grabbedobject.getSize();

if (%player.curdir==0)//up
{
%customfieldobj.grabbedobject.Position.Y+=(%spritesize.Y/2)+(%playerspritesize.Y/2);
}
else if (%player.curdir==1)//down
{
%customfieldobj.grabbedobject.Position.Y-=(%spritesize.Y/2)+(%playerspritesize.Y/2);
}
else if (%player.curdir==2)//left
{
%customfieldobj.grabbedobject.Position.X-=(%spritesize.X/2)+(%playerspritesize.X/2);
}
else if (%player.curdir==3)//right
{
%customfieldobj.grabbedobject.Position.X+=(%spritesize.X/2)+(%playerspritesize.X/2);
}

%customfieldobj.schedulehandle=schedule(1,0,"movemountedobject",%user);

break;
}

}

//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
