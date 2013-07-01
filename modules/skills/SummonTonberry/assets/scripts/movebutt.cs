function movebutt(%tonberry,%phase)
{
//echo(%tonberry SPC "moved butt");

if (%phase==0)//set listener phase
{

if (!%tonberry.listen4move)
{
%tonberry.listen4move=true;
}
else
{
%tonberry.listen4move=false;
}

}
else if (%phase==1)//process click phase
{

if (%tonberry.listen4move)
{

//going right or left
if (mAbs(%tonberry.curmousepos.X-%tonberry.prevmousepos.X)
>=
mAbs(%tonberry.curmousepos.Y-%tonberry.prevmousepos.Y))
{

if (%tonberry.curmousepos.X>%tonberry.prevmousepos.X)
{
%tonberry.playAnimation("SummonTonberry:anim_runright");
%tonberry.curdir=3;
}
else
{
%tonberry.playAnimation("SummonTonberry:anim_runleft");
%tonberry.curdir=2;
}

}
else//going up or down
{

if (%tonberry.curmousepos.Y>%tonberry.prevmousepos.Y)
{
%tonberry.playAnimation("SummonTonberry:anim_runup");
%tonberry.curdir=0;
}
else
{
%tonberry.playAnimation("SummonTonberry:anim_rundown");
%tonberry.curdir=1;
}

}

cancel(%tonberry.schedule_follow);
%tonberry.obj2follow=0;

%tonberry.moveTo(%tonberry.curmousepos,10,1,0);

%tonberry.listen4move=false;
%tonberry.prevmousepos=%tonberry.curmousepos;

}
}

}
