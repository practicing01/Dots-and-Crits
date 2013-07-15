function bitweb::spawninfected(%this,%position)
{
%player1=$players.getObject(0);
%player2=$players.getObject(1);

%infected=new Sprite()
{
Position=%position;
Size=ScaleAssSizeVectorToCam(%this.infectedass);
Image="bitweb:image_infected";
SceneLayer=16;
GravityScale=0;
SceneGroup=25;//npc
class="class_infected";
parentbitweb=%this;
curdir=1;//0=up,1=down,2=left,3=right
schedule_moveto=0;
FixedAngle=true;
ismoving=false;
CollisionCallback=true;
};

%infected.playAnimation("bitweb:anim_infected_stand_down");

%colshapeindex=%infected.createPolygonBoxCollisionShape(%infected.Size);
%infected.setCollisionGroups(0,1,28,29);//0/1 players, 28/29 projectiles
%infected.setCollisionShapeIsSensor(%colshapeindex,true);

DotsandCritsscene.add(%infected);

%this.simset_infected.add(%infected);

}
