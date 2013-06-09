function class_Bombermine::onAnimationEnd(%this)
{

%objlist=DotsandCritsscene.pickArea(
%this.Position.X-(%this.getWidth()),
%this.Position.Y+(%this.getHeight()),
%this.Position.X+(%this.getWidth()),
%this.Position.Y-(%this.getHeight()),
bit(0)|bit(1)|bit(25)|bit(26),"","oobb");

for (%x=0;%x<getWordCount(%objlist);%x++)
{
%obj=getWord(%objlist,%x);

if (%obj.class$="class_player")
{
%player=$players.getObject(%obj.playerindex);
%player.health-=10;
$levelmoduleid.ScopeSet.healthdisplay(%obj.playerindex,%player.health);
}
else if (%obj.SceneGroup==25||%obj.SceneGroup==26)//npc's, dynamic world objects
{
%obj.health-=10;
%obj.updatehealth();
}

}

%this.safeDelete();

}
