function DeusExTelum::radiatevisiblewaves(%this,%emitter)
{
%speed=10;
////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_visibleparticle);
Image="DeusExTelum:image_visibleparticle";
class="class_visibleparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
//Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="0 1";
};

if (!%emitter.playerindex)
{
%sprite_particle.setCollisionGroups(1,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}
else
{
%sprite_particle.setCollisionGroups(0,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocityY(%speed);

%dest=%sprite_particle.Position;

%dest.Y+=%this.worldlimitsreduced.Y;

//%dest.Y-=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000);
schedule(%time,0,"class_visibleparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_visibleparticle);
Image="DeusExTelum:image_visibleparticle";
class="class_visibleparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="1 1";
};

if (!%emitter.playerindex)
{
%sprite_particle.setCollisionGroups(1,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}
else
{
%sprite_particle.setCollisionGroups(0,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocity(%speed,%speed);

%dest=%sprite_particle.Position;

%dest.X+=%this.worldlimitsreduced.X;

//%dest.X-=mAbs(%this.worldlimitsreduced.X-%dest.X);

%dest.Y+=%this.worldlimitsreduced.Y;

//%dest.Y-=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000);
schedule(%time,0,"class_visibleparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_visibleparticle);
Image="DeusExTelum:image_visibleparticle";
class="class_visibleparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="1 0";
};

if (!%emitter.playerindex)
{
%sprite_particle.setCollisionGroups(1,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}
else
{
%sprite_particle.setCollisionGroups(0,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocityX(%speed);

%dest=%sprite_particle.Position;

%dest.X+=%this.worldlimitsreduced.X;

//%dest.X-=mAbs(%this.worldlimitsreduced.X-%dest.X);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000);
schedule(%time,0,"class_visibleparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_visibleparticle);
Image="DeusExTelum:image_visibleparticle";
class="class_visibleparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="1 -1";
};

if (!%emitter.playerindex)
{
%sprite_particle.setCollisionGroups(1,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}
else
{
%sprite_particle.setCollisionGroups(0,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocity(%speed,-%speed);

%dest=%sprite_particle.Position;

%dest.X+=%this.worldlimitsreduced.X;

//%dest.X-=mAbs(%this.worldlimitsreduced.X-%dest.X);

%dest.Y-=%this.worldlimitsreduced.Y;

//%dest.Y+=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000);
schedule(%time,0,"class_visibleparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_visibleparticle);
Image="DeusExTelum:image_visibleparticle";
class="class_visibleparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="0 -1";
};

if (!%emitter.playerindex)
{
%sprite_particle.setCollisionGroups(1,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}
else
{
%sprite_particle.setCollisionGroups(0,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocityY(-%speed);

%dest=%sprite_particle.Position;

%dest.Y-=%this.worldlimitsreduced.Y;

//%dest.Y+=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000);
schedule(%time,0,"class_visibleparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_visibleparticle);
Image="DeusExTelum:image_visibleparticle";
class="class_visibleparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="-1 -1";
};

if (!%emitter.playerindex)
{
%sprite_particle.setCollisionGroups(1,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}
else
{
%sprite_particle.setCollisionGroups(0,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocity(-%speed,-%speed);

%dest=%sprite_particle.Position;

%dest.X-=%this.worldlimitsreduced.X;

//%dest.X+=mAbs(%this.worldlimitsreduced.X-%dest.X);

%dest.Y-=%this.worldlimitsreduced.Y;

//%dest.Y+=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000);
schedule(%time,0,"class_visibleparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_visibleparticle);
Image="DeusExTelum:image_visibleparticle";
class="class_visibleparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="-1 0";
};

if (!%emitter.playerindex)
{
%sprite_particle.setCollisionGroups(1,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}
else
{
%sprite_particle.setCollisionGroups(0,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocityX(-%speed);

%dest=%sprite_particle.Position;

%dest.X-=%this.worldlimitsreduced.X;

//%dest.X+=mAbs(%this.worldlimitsreduced.X-%dest.X);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000);
schedule(%time,0,"class_visibleparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////

%sprite_particle=new Sprite()
{
Position=%emitter.Position;
Size=ScaleAssSizeVectorToCam(%this.ass_visibleparticle);
Image="DeusExTelum:image_visibleparticle";
class="class_visibleparticle";
handle_emitter=%emitter;
CollisionCallback="true";
SceneLayer=14;
GravityScale="0";
Bullet="true";
SceneGroup=3;//sensor, might change this value in the future
curdir="-1 1";
};

if (!%emitter.playerindex)
{
%sprite_particle.setCollisionGroups(1,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}
else
{
%sprite_particle.setCollisionGroups(0,25,26,30);//0=player 1, 1=player 2, 25=npcs, 26=world objects, 30=walls
}

DotsandCritsscene.add(%sprite_particle);

%collisionshapeindex=%sprite_particle.createPolygonBoxCollisionShape(%sprite_particle.Size);

%sprite_particle.setCollisionShapeIsSensor(%collisionshapeindex,true);

%sprite_particle.setLinearVelocity(-%speed,%speed);

%dest=%sprite_particle.Position;

%dest.X-=%this.worldlimitsreduced.X;

//%dest.X+=mAbs(%this.worldlimitsreduced.X-%dest.X);

%dest.Y+=%this.worldlimitsreduced.Y;

//%dest.Y-=mAbs(%this.worldlimitsreduced.Y-%dest.Y);

%time=((Vector2Distance(%sprite_particle.Position,%dest)/%speed)*1000);
schedule(%time,0,"class_visibleparticle::decay",%sprite_particle);

////////////////////////////////////////////////////////////

}

function DeusExTelum::playeremitvisible(%this,%schedulehandle)
{

%player1=$players.getObject(0);
%player2=$players.getObject(1);

if (isObject(%player1.sprite))
{
%this.radiatevisiblewaves(%player1.sprite);
}

if (isObject(%player2.sprite))
{
%this.radiatevisiblewaves(%player2.sprite);
}

%schedulehandle.schedulehandle=schedule(1000,0,"DeusExTelum::playeremitvisible",%this,%schedulehandle);
}
