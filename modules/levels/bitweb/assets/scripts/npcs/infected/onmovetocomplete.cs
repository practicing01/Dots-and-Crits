function class_infected::onMoveToComplete(%this)
{
if (!isObject(%this))
{
return;
}

%this.ismoving=false;

if (%this.curdir==0)
{
%this.playAnimation("bitweb:anim_infected_stand_up");
}
else if (%this.curdir==1)
{
%this.playAnimation("bitweb:anim_infected_stand_down");
}
else if (%this.curdir==2)
{
%this.playAnimation("bitweb:anim_infected_stand_left");
}
else if (%this.curdir==3)
{
%this.playAnimation("bitweb:anim_infected_stand_right");
}

}
