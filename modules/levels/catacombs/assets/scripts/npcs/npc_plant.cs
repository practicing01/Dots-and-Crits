function class_plant::onCollision(%this,%object,%collisionDetails)
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
if (%anim!$="catacombs:anim_npc_plant_attackup")
{
%this.playAnimation("catacombs:anim_npc_plant_attackup");
}
}
else if (%this.curdir==1)
{
if (%anim!$="catacombs:anim_npc_plant_attackdown")
{
%this.playAnimation("catacombs:anim_npc_plant_attackdown");
}
}
else if (%this.curdir==2)
{
if (%anim!$="catacombs:anim_npc_plant_attackleft")
{
%this.playAnimation("catacombs:anim_npc_plant_attackleft");
}
}
else if (%this.curdir==3)
{
if (%anim!$="catacombs:anim_npc_plant_attackright")
{
%this.playAnimation("catacombs:anim_npc_plant_attackright");
}
}

}

}

function class_plant::updatehealth(%this)//updatehealth function required by all npc's
{
if (%this.health<=0)
{
%this.setCollisionCallback(false);
cancel(%this.aischedule);
//%this.safeDelete();
if (%this.getAnimation()!$="catacombs:anim_npc_plant_dead")
{
%this.playAnimation("catacombs:anim_npc_plant_dead");
}
}
}

function class_plant::plantai(%this)
{//temporary ai
if (!isObject(%this)){return;}

if (%this.target==-1)//no target, acquire
{
for (%x=0;%x<$numofplayers;%x++)
{
%player=$players.getObject(%x);
if (!isObject(%player.sprite)){continue;}
if (Vector2Distance(%this.Position,%player.sprite.Position)<=Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{
%this.target=%player.sprite;
break;
}
}
}

if (!isObject(%this.target))
{
%this.target=-1;

%anim=%this.getAnimation();
if (%this.curdir==0)
{
if (%anim!$="catacombs:anim_npc_plant_standup")
{
%this.playAnimation("catacombs:anim_npc_plant_standup");
}
}
else if (%this.curdir==1)
{
if (%anim!$="catacombs:anim_npc_plant_standdown")
{
%this.playAnimation("catacombs:anim_npc_plant_standdown");
}
}
else if (%this.curdir==2)
{
if (%anim!$="catacombs:anim_npc_plant_standleft")
{
%this.playAnimation("catacombs:anim_npc_plant_standleft");
}
}
else if (%this.curdir==3)
{
if (%anim!$="catacombs:anim_npc_plant_standright")
{
%this.playAnimation("catacombs:anim_npc_plant_standright");
}
}

}
else
{
if (Vector2Distance(%this.Position,%this.target.Position)>Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{%this.target=-1;}
else
{
if (%this.speed!=0)
{
%this.moveTo(%this.target.Position,%this.speed,true,false);
}

%xdist=mAbs(%this.Position.X-%this.target.Position.X);
%ydist=mAbs(%this.Position.Y-%this.target.Position.Y);
if (%xdist>=%ydist)
{
if (%this.Position.X<=%this.target.Position.X)
{
%this.curdir=3;
if (%this.getAnimation()!$="catacombs:anim_npc_plant_runright")
{
%this.playAnimation("catacombs:anim_npc_plant_runright");
}
}
else
{
%this.curdir=2;
if (%this.getAnimation()!$="catacombs:anim_npc_plant_runleft")
{
%this.playAnimation("catacombs:anim_npc_plant_runleft");
}
}
}
else
{
if (%this.Position.Y<=%this.target.Position.Y)
{
%this.curdir=0;
if (%this.getAnimation()!$="catacombs:anim_npc_plant_runup")
{
%this.playAnimation("catacombs:anim_npc_plant_runup");
}
}
else
{
%this.curdir=1;
if (%this.getAnimation()!$="catacombs:anim_npc_plant_rundown")
{
%this.playAnimation("catacombs:anim_npc_plant_rundown");
}
}
}

}
}

%this.aischedule=schedule(1000,0,"class_plant::plantai",%this);
}

//every npc class has an initialize function
//that gets called onlevelload
function class_plant::initialize(%this)
{
%this.health=100;
%this.target=-1;
%this.curdir=0;//0=up,1=down,2=left,3=right
%this.normalspeed=5;
%this.speed=5;
%this.aischedule=schedule(1000,0,"class_plant::plantai",%this);
}
