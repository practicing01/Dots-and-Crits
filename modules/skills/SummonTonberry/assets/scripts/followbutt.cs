function followbutt(%tonberry,%phase)
{
//echo(%tonberry SPC "followed butt");

if (%phase==0)//set listener phase
{

if (!%tonberry.listen4follow)
{
%tonberry.listen4follow=true;
}
else
{
%tonberry.listen4follow=false;
}

}
else if (%phase==1)//process click phase
{

if (%tonberry.listen4follow)
{

%objlist=DotsandCritsscene.pickPoint(
%tonberry.curmousepos,
bit(0)|bit(1)|bit(25)|bit(26),"","oobb");//25=npc, 26=dynamic world object

if (getWordCount(%objlist)==0){return;}//make sure something got clicked on

%obj=getWord(%objlist,0);//get first object

%tonberry.obj2follow=%obj;

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
%dest.Y+=(%objsize.Y/*/2*/)+(%tonberrysize.Y/*/2*/);
%tonberry.curdir=1;
}
else
{
%tonberry.playAnimation("SummonTonberry:anim_runup");
%dest.Y-=(%objsize.Y/*/2*/)+(%tonberrysize.Y/*/2*/);
%tonberry.curdir=0;
}

}

%tonberry.moveTo(%dest,10,1,0);

%tonberry.listen4follow=false;
%tonberry.prevmousepos=%tonberry.curmousepos;

%tonberry.schedule_follow=schedule(1000,0,"followbutt",%tonberry,2);//phase 2=update moveTo

}
}
else if (%phase==2)//update moveTo
{

if (!isObject(%tonberry.obj2follow))
{
%tonberry.obj2follow=0;
cancel(%tonberry.schedule_follow);
return;
}

%dest=%tonberry.obj2follow.Position;

%objsize=%tonberry.obj2follow.getSize();
%tonberrysize=%tonberry.getSize();

//going right or left
if (mAbs(%tonberry.Position.X-%tonberry.obj2follow.Position.X)
>=
mAbs(%tonberry.Position.Y-%tonberry.obj2follow.Position.Y))
{

if (%tonberry.Position.X>%tonberry.obj2follow.Position.X)
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

if (%tonberry.Position.Y>%tonberry.obj2follow.Position.Y)
{
%tonberry.playAnimation("SummonTonberry:anim_rundown");
%dest.Y+=(%objsize.Y/*/2*/)+(%tonberrysize.Y/*/2*/);
%tonberry.curdir=1;
}
else
{
%tonberry.playAnimation("SummonTonberry:anim_runup");
%dest.Y-=(%objsize.Y/*/2*/)+(%tonberrysize.Y/*/2*/);
%tonberry.curdir=0;
}

}

%tonberry.moveTo(%dest,10,1,0);

%tonberry.schedule_follow=schedule(1000,0,"followbutt",%tonberry,2);//phase 2=update moveTo

}

}
