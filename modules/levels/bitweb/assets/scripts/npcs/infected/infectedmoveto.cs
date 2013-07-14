function class_infected::infectedmoveto(%this,%position)
{

%xdist=mAbs(%this.Position.X-%position.X);
%ydist=mAbs(%this.Position.Y-%position.Y);

if (%xdist>%ydist)//move right or left
{

if (%this.Position.X<%position.X)//move right
{

if (%this.curdir!=3||%this.ismoving==false)
{
%this.ismoving=true;
%this.curdir=3;
%this.playAnimation("bitweb:anim_infected_run_right");
}

%this.moveTo(%position,5,true,false);

}
else if (%this.Position.X>%position.X)//move left
{

if (%this.curdir!=2||%this.ismoving==false)
{
%this.ismoving=true;
%this.curdir=2;
%this.playAnimation("bitweb:anim_infected_run_left");
}

%this.moveTo(%position,5,true,false);

}

}
else//move up or down
{

if (%this.Position.Y<%position.Y)//move up
{

if (%this.curdir!=0||%this.ismoving==false)
{
%this.ismoving=true;
%this.curdir=0;
%this.playAnimation("bitweb:anim_infected_run_up");
}

%this.moveTo(%position,5,true,false);

}
else if (%this.Position.Y>%position.Y)//move down
{

if (%this.curdir!=1||%this.ismoving==false)
{
%this.ismoving=true;
%this.curdir=1;
%this.playAnimation("bitweb:anim_infected_run_down");
}

%this.moveTo(%position,5,true,false);

}

}

}
