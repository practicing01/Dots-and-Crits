function class_tonberry::onMoveToComplete(%this)
{
if (!isObject(%this))
{
return;
}

if (!isObject(%this.obj2shank))
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
%this.playAnimation("SummonTonberry:anim_shankup");
}
else if (%this.curdir==1)
{
%this.playAnimation("SummonTonberry:anim_shankdown");
}
else if (%this.curdir==2)
{
%this.playAnimation("SummonTonberry:anim_shankleft");
}
else if (%this.curdir==3)
{
%this.playAnimation("SummonTonberry:anim_shankright");
}

%objlist=DotsandCritsscene.pickArea(
%this.Position.X-(%this.getWidth()),
%this.Position.Y+(%this.getHeight()),
%this.Position.X+(%this.getWidth()),
%this.Position.Y-(%this.getHeight()),
bit(0)|bit(1)|bit(25)|bit(26),"","oobb");

for (%x=0;%x<getWordCount(%objlist);%x++)
{
%obj=getWord(%objlist,%x);

if (%obj==%this.obj2shank)
{

if (%obj.class$="class_player")
{
%player=$players.getObject(%obj.playerindex);
%player.health-=100;
$levelmoduleid.ScopeSet.healthdisplay(%obj.playerindex,%player.health);
}
else if (%obj.SceneGroup==25||%obj.SceneGroup==26)//npc's, dynamic world objects
{
%obj.health-=100;
%obj.updatehealth();
}

%this.obj2shank=0;
cancel(%this.schedule_shank);
%this.schedule_shank=0;
return;

}

}

//cancel cus object dodged
%this.obj2shank=0;
cancel(%this.schedule_shank);
%this.schedule_shank=0;

}

}

