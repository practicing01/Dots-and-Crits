function DeusExTelum::radiatemicrowaves(%this,%emitter)
{
%speed=5;
////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
Image="DeusExTelum:image_microwaveparticle";
class="class_microwaveparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
//Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="0 1";
hitplayer=false;
};

%sprite_particle.Position.Y+=(%emitter.Size.Y/2)+(%sprite_particle.Size.Y/2);//up

%sprite_particle.setCollisionGroups(0,1,25,26);//0=player 1, 1=player 2, 25=npcs, 26=world objects

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocityY(%speed);

%dest=%sprite_particle.Position;

%dest.Y+=%this.worldlimitsreduced.Y;

//%dest.Y-=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000)+1000;
schedule(%time,0,"class_microwaveparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////
/*
%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
Image="DeusExTelum:image_microwaveparticle";
class="class_microwaveparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="1 1";
hitplayer=false;
};

%sprite_particle.Position.X+=(%emitter.Size.X/2)+(%sprite_particle.Size.X/2);//right

%sprite_particle.Position.Y+=(%emitter.Size.Y/2)+(%sprite_particle.Size.Y/2);//up

%sprite_particle.setCollisionGroups(0,1,25,26);//0=player 1, 1=player 2, 25=npcs, 26=world objects

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocity(%speed,%speed);

%dest=%sprite_particle.Position;

%dest.X+=%this.worldlimitsreduced.X;

//%dest.X-=mAbs(%this.worldlimitsreduced.X-%dest.X);

%dest.Y+=%this.worldlimitsreduced.Y;

//%dest.Y-=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000)+1000;
schedule(%time,0,"class_microwaveparticle::decay",%sprite_particle);
*/
////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
Image="DeusExTelum:image_microwaveparticle";
class="class_microwaveparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="1 0";
hitplayer=false;
};

%sprite_particle.Position.X+=(%emitter.Size.X/2)+(%sprite_particle.Size.X/2);//right

%sprite_particle.setCollisionGroups(0,1,25,26);//0=player 1, 1=player 2, 25=npcs, 26=world objects

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocityX(%speed);

%dest=%sprite_particle.Position;

%dest.X+=%this.worldlimitsreduced.X;

//%dest.X-=mAbs(%this.worldlimitsreduced.X-%dest.X);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000)+1000;
schedule(%time,0,"class_microwaveparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////
/*
%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
Image="DeusExTelum:image_microwaveparticle";
class="class_microwaveparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="1 -1";
hitplayer=false;
};

%sprite_particle.Position.X+=(%emitter.Size.X/2)+(%sprite_particle.Size.X/2);//right

%sprite_particle.Position.Y-=(%emitter.Size.Y/2)+(%sprite_particle.Size.Y/2);//down

%sprite_particle.setCollisionGroups(0,1,25,26);//0=player 1, 1=player 2, 25=npcs, 26=world objects

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocity(%speed,-%speed);

%dest=%sprite_particle.Position;

%dest.X+=%this.worldlimitsreduced.X;

//%dest.X-=mAbs(%this.worldlimitsreduced.X-%dest.X);

%dest.Y-=%this.worldlimitsreduced.Y;

//%dest.Y+=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000)+1000;
schedule(%time,0,"class_microwaveparticle::decay",%sprite_particle);
*/
////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
Image="DeusExTelum:image_microwaveparticle";
class="class_microwaveparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="0 -1";
hitplayer=false;
};

%sprite_particle.Position.Y-=(%emitter.Size.Y/2)+(%sprite_particle.Size.Y/2);//down

%sprite_particle.setCollisionGroups(0,1,25,26);//0=player 1, 1=player 2, 25=npcs, 26=world objects

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocityY(-%speed);

%dest=%sprite_particle.Position;

%dest.Y-=%this.worldlimitsreduced.Y;

//%dest.Y+=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000)+1000;
schedule(%time,0,"class_microwaveparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////
/*
%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
Image="DeusExTelum:image_microwaveparticle";
class="class_microwaveparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="-1 -1";
hitplayer=false;
};

%sprite_particle.Position.X-=(%emitter.Size.X/2)+(%sprite_particle.Size.X/2);//left

%sprite_particle.Position.Y-=(%emitter.Size.Y/2)+(%sprite_particle.Size.Y/2);//down

%sprite_particle.setCollisionGroups(0,1,25,26);//0=player 1, 1=player 2, 25=npcs, 26=world objects

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocity(-%speed,-%speed);

%dest=%sprite_particle.Position;

%dest.X-=%this.worldlimitsreduced.X;

//%dest.X+=mAbs(%this.worldlimitsreduced.X-%dest.X);

%dest.Y-=%this.worldlimitsreduced.Y;

//%dest.Y+=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000)+1000;
schedule(%time,0,"class_microwaveparticle::decay",%sprite_particle);
*/
////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
Image="DeusExTelum:image_microwaveparticle";
class="class_microwaveparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="-1 0";
hitplayer=false;
};

%sprite_particle.Position.X-=(%emitter.Size.X/2)+(%sprite_particle.Size.X/2);//left

%sprite_particle.setCollisionGroups(0,1,25,26);//0=player 1, 1=player 2, 25=npcs, 26=world objects

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocityX(-%speed);

%dest=%sprite_particle.Position;

%dest.X-=%this.worldlimitsreduced.X;

//%dest.X+=mAbs(%this.worldlimitsreduced.X-%dest.X);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000)+1000;
schedule(%time,0,"class_microwaveparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////
/*
%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_microwaveparticle);
Image="DeusExTelum:image_microwaveparticle";
class="class_microwaveparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="-1 1";
hitplayer=false;
};

%sprite_particle.Position.X-=(%emitter.Size.X/2)+(%sprite_particle.Size.X/2);//left

%sprite_particle.Position.Y+=(%emitter.Size.Y/2)+(%sprite_particle.Size.Y/2);//up

%sprite_particle.setCollisionGroups(0,1,25,26);//0=player 1, 1=player 2, 25=npcs, 26=world objects

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocity(-%speed,%speed);

%dest=%sprite_particle.Position;

%dest.X-=%this.worldlimitsreduced.X;

//%dest.X+=mAbs(%this.worldlimitsreduced.X-%dest.X);

%dest.Y+=%this.worldlimitsreduced.Y;

//%dest.Y-=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000)+1000;
schedule(%time,0,"class_microwaveparticle::decay",%sprite_particle);
*/
////////////////////////////////////////////////////////////

}
