function shankbutt(%tonberry,%phase)
{
//echo(%tonberry SPC "shanked butt");

if (%phase==0)//set listener phase
{

if (!%tonberry.listen4shank)
{
%tonberry.listen4shank=true;
}
else
{
%tonberry.listen4shank=false;
}

}
else if (%phase==1)//process click phase
{

if (%tonberry.listen4shank)
{

%objlist=DotsandCritsscene.pickPoint(
%tonberry.curmousepos,
bit(0)|bit(1)|bit(25)|bit(26),"","oobb");//25=npc, 26=dynamic world object

if (getWordCount(%objlist)==0){return;}//make sure something got clicked on

%obj=getWord(%objlist,0);//get first object

if (%obj!=%tonberry.obj2shank)//new target
{
cancel(%tonberry.schedule_shank);
%tonberry.schedule_shank=0;
}

%tonberry.obj2shank=%obj;

%dest=%obj.Position;

%objsize=%obj.getSize();
%tonberrysize=%tonberry.getSize();

//going right or left
if (mAbs(%tonberry.Position.X-%obj.Position.X)
>=
mAbs(%tonberry.Position.Y-%obj.Position.Y))
{

if (%tonberry.Position.X>%obj.Position.X)
{
%tonberry.playAnimation("SummonTonberry:anim_runleft");
%dest.X+=(%objsize.X/2)+(%tonberrysize.X/2);
%tonberry.curdir=2;
}
else
{
%tonberry.playAnimation("SummonTonberry:anim_runright");
%dest.X-=(%objsize.X/2)+(%tonberrysize.X/2);
%tonberry.curdir=3;
}

}
else//going up or down
{

if (%tonberry.Position.Y>%obj.Position.Y)
{
%tonberry.playAnimation("SummonTonberry:anim_rundown");
%dest.Y+=(%objsize.Y/2)+(%tonberrysize.Y/2);
%tonberry.curdir=1;
}
else
{
%tonberry.playAnimation("SummonTonberry:anim_runup");
%dest.Y-=(%objsize.Y/2)+(%tonberrysize.Y/2);
%tonberry.curdir=0;
}

}

cancel(%tonberry.schedule_follow);
%tonberry.obj2follow=0;

%tonberry.moveTo(%dest,10,1,0);

%tonberry.listen4shank=false;
%tonberry.prevmousepos=%tonberry.curmousepos;

%tonberry.schedule_shank=schedule(1000,0,"shankbutt",%tonberry,2);//phase 2=update moveTo

}
}
else if (%phase==2)//update moveTo
{

if (!isObject(%tonberry.obj2shank))
{
%tonberry.obj2shank=0;
cancel(%tonberry.schedule_shank);
return;
}

%dest=%tonberry.obj2shank.Position;

%objsize=%tonberry.obj2shank.getSize();
%tonberrysize=%tonberry.getSize();

//going right or left
if (mAbs(%tonberry.Position.X-%tonberry.obj2shank.Position.X)
>=
mAbs(%tonberry.Position.Y-%tonberry.obj2shank.Position.Y))
{

if (%tonberry.Position.X>%tonberry.obj2shank.Position.X)
{
%tonberry.playAnimation("SummonTonberry:anim_runleft");
%dest.X+=(%objsize.X/2)+(%tonberrysize.X/2);
%tonberry.curdir=2;
}
else
{
%tonberry.playAnimation("SummonTonberry:anim_runright");
%dest.X-=(%objsize.X/2)+(%tonberrysize.X/2);
%tonberry.curdir=3;
}

}
else//going up or down
{

if (%tonberry.Position.Y>%tonberry.obj2shank.Position.Y)
{
%tonberry.playAnimation("SummonTonberry:anim_rundown");
%dest.Y+=(%objsize.Y/2)+(%tonberrysize.Y/2);
%tonberry.curdir=1;
}
else
{
%tonberry.playAnimation("SummonTonberry:anim_runup");
%dest.Y-=(%objsize.Y/2)+(%tonberrysize.Y/2);
%tonberry.curdir=0;
}

}

%tonberry.moveTo(%dest,10,1,0);

%tonberry.schedule_shank=schedule(1000,0,"shankbutt",%tonberry,2);//phase 2=update moveTo

}

}
