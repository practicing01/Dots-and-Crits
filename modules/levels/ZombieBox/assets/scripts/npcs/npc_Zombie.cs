function class_Zombie::onCollision(%this,%object,%collisionDetails){
if (%this.health<=0){return;}

%byte=false;

if (%object.class$="class_player")
{
%player=$players.getObject(%object.playerindex);
%player.health-=100;
$levelmoduleid.ScopeSet.healthdisplay(%object.playerindex,%player.health);
%byte=true;
}
else if (%object.SceneGroup==25||%object.SceneGroup==26)//npc's, dynamic world objects
{
if (%object.class!$="class_Zombie")
{
if (%object.health>0)
{
%object.health-=100;
%object.updatehealth();
%byte=true;
}
}
}

if (%byte)
{
//check if not already animated
//animate
%anim=%this.getAnimation();
if (%this.curdir==0)
{
if (%anim!$="ZombieBox:anim_zombie_attackup")
{
%this.playAnimation("ZombieBox:anim_zombie_attackup");
}
}
else if (%this.curdir==1)
{
if (%anim!$="ZombieBox:anim_zombie_attackdown")
{
%this.playAnimation("ZombieBox:anim_zombie_attackdown");
}
}
else if (%this.curdir==2)
{
if (%anim!$="ZombieBox:anim_zombie_attackleft")
{
%this.playAnimation("ZombieBox:anim_zombie_attackleft");
}
}
else if (%this.curdir==3)
{
if (%anim!$="ZombieBox:anim_zombie_attackright")
{
%this.playAnimation("ZombieBox:anim_zombie_attackright");
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

%this.parentzombiebox.livezombiecount--;

if (isObject(gui_text_livezombiecount))
{
gui_text_livezombiecount.setText(%this.parentzombiebox.livezombiecount);
}

if (%this.curdir==0)
{
if (%this.getAnimation()!$="ZombieBox:anim_zombie_dieup")
{
%this.playAnimation("ZombieBox:anim_zombie_dieup");
}
}
else if (%this.curdir==1)
{
if (%this.getAnimation()!$="ZombieBox:anim_zombie_diedown")
{
%this.playAnimation("ZombieBox:anim_zombie_diedown");
}
}
else if (%this.curdir==2)
{
if (%this.getAnimation()!$="ZombieBox:anim_zombie_dieleft")
{
%this.playAnimation("ZombieBox:anim_zombie_dieleft");
}
}
else if (%this.curdir==3)
{
if (%this.getAnimation()!$="ZombieBox:anim_zombie_dieright")
{
%this.playAnimation("ZombieBox:anim_zombie_dieright");
}
}
}
}

function class_Zombie::Zombieai(%this)
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
if (%anim!$="ZombieBox:anim_zombie_standup")
{
%this.playAnimation("ZombieBox:anim_zombie_standup");
}
}
else if (%this.curdir==1)
{
if (%anim!$="ZombieBox:anim_zombie_standdown")
{
%this.playAnimation("ZombieBox:anim_zombie_standdown");
}
}
else if (%this.curdir==2)
{
if (%anim!$="ZombieBox:anim_zombie_standleft")
{
%this.playAnimation("ZombieBox:anim_zombie_standleft");
}
}
else if (%this.curdir==3)
{
if (%anim!$="ZombieBox:anim_zombie_standright")
{
%this.playAnimation("ZombieBox:anim_zombie_standright");
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
if (%this.getAnimation()!$="ZombieBox:anim_zombie_runright")
{
%this.playAnimation("ZombieBox:anim_zombie_runright");
}
}
else
{
%this.curdir=2;
if (%this.getAnimation()!$="ZombieBox:anim_zombie_runleft")
{
%this.playAnimation("ZombieBox:anim_zombie_runleft");
}
}
}
else
{
if (%this.Position.Y<=%this.target.Position.Y)
{
%this.curdir=0;
if (%this.getAnimation()!$="ZombieBox:anim_zombie_runup")
{
%this.playAnimation("ZombieBox:anim_zombie_runup");
}
}
else
{
%this.curdir=1;
if (%this.getAnimation()!$="ZombieBox:anim_zombie_rundown")
{
%this.playAnimation("ZombieBox:anim_zombie_rundown");
}
}
}

}
}

%this.aischedule=schedule(1000,0,"class_Zombie::Zombieai",%this);
}

//every npc class has an initialize function
//that gets called onlevelload
function class_Zombie::initialize(%this)
{
%this.health=100;
%this.target=-1;
%this.curdir=0;//0=up,1=down,2=left,3=right
%this.normalspeed=50;
%this.speed=50;
%this.aischedule=schedule(1000,0,"class_Zombie::Zombieai",%this);
}
