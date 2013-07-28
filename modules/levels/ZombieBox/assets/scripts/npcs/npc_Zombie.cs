function class_Zombie::onCollision(%this,%object,%collisionDetails)
{
if (%this.health<=0){return;}

%byte=false;

if (%object.class$="class_player")
{
%player=$players.getObject(%object.playerindex);
%player.health-=10;
$levelmoduleid.ScopeSet.healthdisplay(%object.playerindex,%player.health);
%byte=true;
}
else if (%object.SceneGroup==25||%object.SceneGroup==26)//npc's, dynamic world objects
{
%object.health-=10;
%object.updatehealth();
%byte=true;
}

if (%byte)
{
//check if not already animated
//animate
%anim=%this.getAnimation();
if (%this.curdir==0)
{
if (%anim!$="ZombieBox:anim_npc_Zombie_attackup")
{
%this.playAnimation("ZombieBox:anim_npc_Zombie_attackup");
}
}
else if (%this.curdir==1)
{
if (%anim!$="ZombieBox:anim_npc_Zombie_attackdown")
{
%this.playAnimation("ZombieBox:anim_npc_Zombie_attackdown");
}
}
else if (%this.curdir==2)
{
if (%anim!$="ZombieBox:anim_npc_Zombie_attackleft")
{
%this.playAnimation("ZombieBox:anim_npc_Zombie_attackleft");
}
}
else if (%this.curdir==3)
{
if (%anim!$="ZombieBox:anim_npc_Zombie_attackright")
{
%this.playAnimation("ZombieBox:anim_npc_Zombie_attackright");
}
}

}

}

function class_Zombie::updatehealth(%this)//updatehealth function required by all npc's
{
if (%this.health<=0)
{
%this.setCollisionCallback(false);
cancel(%this.aischedule);
//%this.safeDelete();
if (%this.getAnimation()!$="ZombieBox:anim_npc_Zombie_dead")
{
%this.playAnimation("ZombieBox:anim_npc_Zombie_dead");
}
}
}

function Zombieai(%Zombie)
{//temporary ai
if (!isObject(%Zombie)){return;}

if (%Zombie.target==-1)//no target, acquire
{
for (%x=0;%x<$numofplayers;%x++)
{
%player=$players.getObject(%x);
if (!isObject(%player.sprite)){continue;}
if (Vector2Distance(%Zombie.Position,%player.sprite.Position)<=Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{
%Zombie.target=%player.sprite;
break;
}
}
}

if (!isObject(%Zombie.target))
{
%Zombie.target=-1;

%anim=%Zombie.getAnimation();
if (%Zombie.curdir==0)
{
if (%anim!$="ZombieBox:anim_npc_Zombie_standup")
{
%Zombie.playAnimation("ZombieBox:anim_npc_Zombie_standup");
}
}
else if (%Zombie.curdir==1)
{
if (%anim!$="ZombieBox:anim_npc_Zombie_standdown")
{
%Zombie.playAnimation("ZombieBox:anim_npc_Zombie_standdown");
}
}
else if (%Zombie.curdir==2)
{
if (%anim!$="ZombieBox:anim_npc_Zombie_standleft")
{
%Zombie.playAnimation("ZombieBox:anim_npc_Zombie_standleft");
}
}
else if (%Zombie.curdir==3)
{
if (%anim!$="ZombieBox:anim_npc_Zombie_standright")
{
%Zombie.playAnimation("ZombieBox:anim_npc_Zombie_standright");
}
}

}
else
{
if (Vector2Distance(%Zombie.Position,%Zombie.target.Position)>Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{%Zombie.target=-1;}
else
{
if (%Zombie.speed!=0)
{
%Zombie.moveTo(%Zombie.target.Position,%Zombie.speed,true,false);
}

%xdist=mAbs(%Zombie.Position.X-%Zombie.target.Position.X);
%ydist=mAbs(%Zombie.Position.Y-%Zombie.target.Position.Y);
if (%xdist>=%ydist)
{
if (%Zombie.Position.X<=%Zombie.target.Position.X)
{
%Zombie.curdir=3;
if (%Zombie.getAnimation()!$="ZombieBox:anim_npc_Zombie_runright")
{
%Zombie.playAnimation("ZombieBox:anim_npc_Zombie_runright");
}
}
else
{
%Zombie.curdir=2;
if (%Zombie.getAnimation()!$="ZombieBox:anim_npc_Zombie_runleft")
{
%Zombie.playAnimation("ZombieBox:anim_npc_Zombie_runleft");
}
}
}
else
{
if (%Zombie.Position.Y<=%Zombie.target.Position.Y)
{
%Zombie.curdir=0;
if (%Zombie.getAnimation()!$="ZombieBox:anim_npc_Zombie_runup")
{
%Zombie.playAnimation("ZombieBox:anim_npc_Zombie_runup");
}
}
else
{
%Zombie.curdir=1;
if (%Zombie.getAnimation()!$="ZombieBox:anim_npc_Zombie_rundown")
{
%Zombie.playAnimation("ZombieBox:anim_npc_Zombie_rundown");
}
}
}

}
}

%Zombie.aischedule=schedule(1000,0,"Zombieai",%Zombie);
}

//every npc class has an initialize function
//that gets called onlevelload
function class_Zombie::initialize(%this)
{
%this.health=100;
%this.target=-1;
%this.curdir=0;//0=up,1=down,2=left,3=right
%this.normalspeed=5;
%this.speed=5;
%this.aischedule=schedule(1000,0,"Zombieai",%this);
}
