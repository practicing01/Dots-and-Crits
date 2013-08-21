function class_mech::onCollision(%this,%object,%collisionDetails)
{
if (%this.health<=0){return;}

%xdist=mAbs(%this.Position.X-%object.Position.X);
%ydist=mAbs(%this.Position.Y-%object.Position.Y);

if (%xdist>%ydist)
{

if (%this.curdir.Y==1)
{
%this.curdir.Y=-1;
%this.setLinearVelocityY(%this.curdir.Y*%this.speed);
%this.playAnimation("DeusExTelum:anim_mech_rundown");
}
else
{
%this.curdir.Y=1;
%this.setLinearVelocityY(%this.curdir.Y*%this.speed);
%this.playAnimation("DeusExTelum:anim_mech_runup");
}

}
else
{

if (%this.curdir.X==1)
{
%this.curdir.X=-1;
%this.setLinearVelocityX(%this.curdir.X*%this.speed);
%this.playAnimation("DeusExTelum:anim_mech_runleft");
}
else
{
%this.curdir.X=1;
%this.setLinearVelocityX(%this.curdir.X*%this.speed);
%this.playAnimation("DeusExTelum:anim_mech_runright");
}

}

}

function class_mech::updatehealth(%this)//updatehealth function required by all npc's
{
if (%this.health<=0)
{
%this.setCollisionCallback(false);
cancel(%this.aischedule);

%this.parentDeusExTelum.livemechcount--;

if (isObject(gui_text_livemechcount))
{
gui_text_livemechcount.setText(%this.parentDeusExTelum.livemechcount);
}

%this.safeDelete();

}
}

function class_mech::mechai(%this)
{
if (!isObject(%this)){return;}



%this.aischedule=schedule(1000,0,"class_mech::mechai",%this);
}

//every npc class has an initialize function
//that gets called onlevelload
function class_mech::initialize(%this)
{
%this.health=100;
%this.target=-1;
%this.normalspeed=5;
%this.speed=5;

%this.curdir="0 0";

if (getRandom(0,1))
{
%this.curdir.X=1;
}else {%this.curdir.X=-1;}

if (getRandom(0,1))
{
%this.curdir.Y=1;
}else {%this.curdir.Y=-1;}

if (getRandom(0,1))
{
if (%this.curdir.X==1)
{
%this.playAnimation("DeusExTelum:anim_mech_runright");
}
else
{
%this.playAnimation("DeusExTelum:anim_mech_runleft");
}
}
else
{
if (%this.curdir.Y==1)
{
%this.playAnimation("DeusExTelum:anim_mech_runup");
}
else
{
%this.playAnimation("DeusExTelum:anim_mech_rundown");
}
}

%this.setLinearVelocity(%this.curdir.X*%this.speed,%this.curdir.Y*%this.speed);

%this.aischedule=schedule(1000,0,"class_mech::mechai",%this);
}
