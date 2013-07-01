function class_tonberry::onAnimationEnd(%this)
{

if (!isObject(%this))
{
return;
}

if (!isObject(%this.obj2follow))
{

if (%this.curdir==0)
{
%this.playAnimation("SummonTonberry:anim_standup");
}
else if (%this.curdir==1)
{
%this.playAnimation("SummonTonberry:anim_standdown");
}
else if (%this.curdir==2)
{
%this.playAnimation("SummonTonberry:anim_standleft");
}
else if (%this.curdir==3)
{
%this.playAnimation("SummonTonberry:anim_standright");
}

}
else
{

if (%this.curdir==0)
{
%this.playAnimation("SummonTonberry:anim_runup");
}
else if (%this.curdir==1)
{
%this.playAnimation("SummonTonberry:anim_rundown");
}
else if (%this.curdir==2)
{
%this.playAnimation("SummonTonberry:anim_runleft");
}
else if (%this.curdir==3)
{
%this.playAnimation("SummonTonberry:anim_runright");
}

}

}
