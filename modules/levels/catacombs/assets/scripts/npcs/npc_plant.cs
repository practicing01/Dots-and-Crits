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

function class_plant::updatehealth(%this)
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

function plantai(%plant)
{//temporary ai
if (!isObject(%plant)){return;}

if (%plant.target==-1)//no target, acquire
{
for (%x=0;%x<$numofplayers;%x++)
{
%player=$players.getObject(%x);
if (!isObject(%player.sprite)){continue;}
if (Vector2Distance(%plant.Position,%player.sprite.Position)<=Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{
%plant.target=%player.sprite;
break;
}
}
}

if (!isObject(%plant.target))
{
%plant.target=-1;

%anim=%plant.getAnimation();
if (%plant.curdir==0)
{
if (%anim!$="catacombs:anim_npc_plant_standup")
{
%plant.playAnimation("catacombs:anim_npc_plant_standup");
}
}
else if (%plant.curdir==1)
{
if (%anim!$="catacombs:anim_npc_plant_standdown")
{
%plant.playAnimation("catacombs:anim_npc_plant_standdown");
}
}
else if (%plant.curdir==2)
{
if (%anim!$="catacombs:anim_npc_plant_standleft")
{
%plant.playAnimation("catacombs:anim_npc_plant_standleft");
}
}
else if (%plant.curdir==3)
{
if (%anim!$="catacombs:anim_npc_plant_standright")
{
%plant.playAnimation("catacombs:anim_npc_plant_standright");
}
}

}
else
{
if (Vector2Distance(%plant.Position,%plant.target.Position)>Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{%plant.target=-1;}
else
{
%plant.moveTo(%plant.target.Position,5,true,false);

%xdist=mAbs(%plant.Position.X-%plant.target.Position.X);
%ydist=mAbs(%plant.Position.Y-%plant.target.Position.Y);
if (%xdist>=%ydist)
{
if (%plant.Position.X<=%plant.target.Position.X)
{
%plant.curdir=3;
if (%plant.getAnimation()!$="catacombs:anim_npc_plant_runright")
{
%plant.playAnimation("catacombs:anim_npc_plant_runright");
}
}
else
{
%plant.curdir=2;
if (%plant.getAnimation()!$="catacombs:anim_npc_plant_runleft")
{
%plant.playAnimation("catacombs:anim_npc_plant_runleft");
}
}
}
else
{
if (%plant.Position.Y<=%plant.target.Position.Y)
{
%plant.curdir=0;
if (%plant.getAnimation()!$="catacombs:anim_npc_plant_runup")
{
%plant.playAnimation("catacombs:anim_npc_plant_runup");
}
}
else
{
%plant.curdir=1;
if (%plant.getAnimation()!$="catacombs:anim_npc_plant_rundown")
{
%plant.playAnimation("catacombs:anim_npc_plant_rundown");
}
}
}

}
}

%plant.aischedule=schedule(1000,0,"plantai",%plant);
}

//every npc class has an initialize function
//that gets called onlevelload
function class_plant::initialize(%this)
{
%this.health=100;
%this.target=-1;
%this.curdir=0;//0=up,1=down,2=left,3=right
%this.aischedule=schedule(1000,0,"plantai",%this);
}
