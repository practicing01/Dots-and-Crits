function class_microwaveparticle::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player")
{
%this.hitplayer=true;

if (%this.curdir.X==1)
{
%this.setLinearVelocityX(-5);
%this.curdir.X=-1;
}
else if (%this.curdir.X==-1)
{
%this.setLinearVelocityX(5);
%this.curdir.X=1;
}

if (%this.curdir.Y==1)
{
%this.setLinearVelocityY(-5);
%this.curdir.Y=-1;
}
else if (%this.curdir.Y==-1)
{
%this.setLinearVelocityY(5);
%this.curdir.Y=1;
}

}
else if (%object.SceneGroup==25||%object.SceneGroup==26)//npc's, dynamic world objects
{
if (%object.health>0&&%object.class$="class_mech")
{
if (/*%this.handle_emitter==%object&&*/%this.hitplayer==true)
{
echo("spotted by radar");
schedule(0,0,"gui_pausemenu::returntomainmenu");
}
}
}

}
