function class_Portalgun::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}

%player=$players.getObject(0);
%customfieldobj=Portalgun.customplayerfields.getObject(0);//we know it's user 0 cus they use mouse

%ass=0;
%img=0;
%anim=0;

if (!%customfieldobj.portaltoshoot)
{
%ass=Portalgun.projectileinass;
%img="Portalgun:image_projectilein";
%anim="Portalgun:anim_projectilein";
}
else
{
%ass=Portalgun.projectileoutass;
%img="Portalgun:image_projectileout";
%anim="Portalgun:anim_projectileout";
}

////////////////////////////////////////////////////////////////////////////
//set this projectile's sprite
%projectilesprite=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
class="class_portalprojectile";
parenthandle=0;
CollisionCallback="true";
SceneLayer=16;
GravityScale="0";
Bullet="true";
parentplayer=0;
portaltype=%customfieldobj.portaltoshoot;
curdir=%player.curdir;
};

if (!%player.sprite.SceneGroup)//player 0 casted
{
%projectilesprite.SceneGroup=28;//player 0 projectiles
%projectilesprite.setCollisionGroups(1,25,26,29,30);//1=player 2, 29=player 2 projectiles, 30=walls, 26=world objects
}
else//player 1 casted
{
%projectilesprite.SceneGroup=29;//player 1 projectiles
%projectilesprite.setCollisionGroups(0,25,26,28,30);//0=player 1, 28=player 1 projectiles, 30=walls, 26=world objects
}

DotsandCritsscene.add(%projectilesprite);
%projectilesprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));

%projectilesprite.playAnimation(%anim);
//////////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//create vector list for this projectiles path
%wavevectors=new SimSet();

%dest="0 0";

%spritesize=%player.sprite.getSpriteSize();

if (%player.curdir==0)//up
{
////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(0);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X;
%dest.Y=%pos.Y+$resolution.Y;
}
else if (%player.curdir==1)//down
{
%projectilesprite.setAngle(180);

////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(1);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X;
%dest.Y=%pos.Y-$resolution.Y;
}
else if (%player.curdir==2)//left
{
%projectilesprite.setAngle(90);

////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(2);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X-$resolution.X;
%dest.Y=%pos.Y;
}
else if (%player.curdir==3)//right
{
%projectilesprite.setAngle(270);

////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(3);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X+$resolution.X;
%dest.Y=%pos.Y;
}

///////////////////////////////

%dest=ScaleVectorToCam(%dest);
%vector=new SimObject()
{
x=%dest.X;
y=%dest.Y;
};
%wavevectors.add(%vector);

/////////////////////////////////////////////////////////////////////////////

//create projectile object that holds all the info and add it to the projectile list
%projectile=new SimObject()
{
//sprite (holds animation, position, collision shape, class)
sprite=%projectilesprite;
//list of points to move to
wavevectors=%wavevectors;
//index to above list
current_destination_vector=0;
//caster handle for collision detection
parenthandle=%player.sprite;
schedule_decay=0;
};
%projectile.sprite.parenthandle=%projectile;//needed cus onMoveToComplete() is for the sprite

//////////////////////////////////////////////
//start first moveTo()
%dest="0 0";
%dest.X=%projectile.wavevectors.getObject(%projectile.current_destination_vector).x;
%dest.Y=%projectile.wavevectors.getObject(%projectile.current_destination_vector).y;
%projectile.sprite.moveTo(%dest,10,0,0);

%speed=10;
%time=((Vector2Distance(%projectile.sprite.Position,%dest)/%speed)*1000)+1000;
%projectile.schedule_decay=schedule(%time,0,"class_portalprojectile::portalprojectiledecay",%projectile.sprite);

//////////////////////////////////////////////////////////////
%customfieldobj.portaltoshoot=!%customfieldobj.portaltoshoot;
}

///////////////////////////////////////////////////////////////

function class_Portalgun::joycallback(%this,%state,%cursorpos)
{
return;
}

///////////////////////////////////////////////////////////////

//joystick click
function class_Portalgun::stickclick(%this,%state,%cursorpos)
{
if (%state)//touch down
{
//DotsandCritswindow.getWorldPoint(%cursorpos)

if (!%this.Active){return;}

%player=$players.getObject(1);
%customfieldobj=Portalgun.customplayerfields.getObject(1);//we know it's user 0 cus they use mouse

%ass=0;
%img=0;
%anim=0;

if (!%customfieldobj.portaltoshoot)
{
%ass=Portalgun.projectileinass;
%img="Portalgun:image_projectilein";
%anim="Portalgun:anim_projectilein";
}
else
{
%ass=Portalgun.projectileoutass;
%img="Portalgun:image_projectileout";
%anim="Portalgun:anim_projectileout";
}

////////////////////////////////////////////////////////////////////////////
//set this projectile's sprite
%projectilesprite=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
class="class_portalprojectile";
parenthandle=0;
CollisionCallback="true";
SceneLayer=16;
GravityScale="0";
Bullet="true";
parentplayer=0;
portaltype=%customfieldobj.portaltoshoot;
curdir=%player.curdir;
};

if (!%player.sprite.SceneGroup)//player 0 casted
{
%projectilesprite.SceneGroup=28;//player 0 projectiles
%projectilesprite.setCollisionGroups(1,25,26,29,30);//1=player 2, 29=player 2 projectiles, 30=walls, 26=world objects
}
else//player 1 casted
{
%projectilesprite.SceneGroup=29;//player 1 projectiles
%projectilesprite.setCollisionGroups(0,25,26,28,30);//0=player 1, 28=player 1 projectiles, 30=walls, 26=world objects
}

DotsandCritsscene.add(%projectilesprite);
%projectilesprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));

%projectilesprite.playAnimation(%anim);
//////////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////
//create vector list for this projectiles path
%wavevectors=new SimSet();

%dest="0 0";

%spritesize=%player.sprite.getSpriteSize();

if (%player.curdir==0)//up
{
////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(0);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X;
%dest.Y=%pos.Y+$resolution.Y;
}
else if (%player.curdir==1)//down
{
%projectilesprite.setAngle(180);

////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(1);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X;
%dest.Y=%pos.Y-$resolution.Y;
}
else if (%player.curdir==2)//left
{
%projectilesprite.setAngle(90);

////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(2);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X-$resolution.X;
%dest.Y=%pos.Y;
}
else if (%player.curdir==3)//right
{
%projectilesprite.setAngle(270);

////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(3);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X+$resolution.X;
%dest.Y=%pos.Y;
}

///////////////////////////////

%dest=ScaleVectorToCam(%dest);
%vector=new SimObject()
{
x=%dest.X;
y=%dest.Y;
};
%wavevectors.add(%vector);

/////////////////////////////////////////////////////////////////////////////

//create projectile object that holds all the info and add it to the projectile list
%projectile=new SimObject()
{
//sprite (holds animation, position, collision shape, class)
sprite=%projectilesprite;
//list of points to move to
wavevectors=%wavevectors;
//index to above list
current_destination_vector=0;
//caster handle for collision detection
parenthandle=%player.sprite;
schedule_decay=0;
};
%projectile.sprite.parenthandle=%projectile;//needed cus onMoveToComplete() is for the sprite

//////////////////////////////////////////////
//start first moveTo()
%dest="0 0";
%dest.X=%projectile.wavevectors.getObject(%projectile.current_destination_vector).x;
%dest.Y=%projectile.wavevectors.getObject(%projectile.current_destination_vector).y;
%projectile.sprite.moveTo(%dest,10,0,0);

%speed=10;
%time=((Vector2Distance(%projectile.sprite.Position,%dest)/%speed)*1000)+1000;
%projectile.schedule_decay=schedule(%time,0,"class_portalprojectile::portalprojectiledecay",%projectile.sprite);

//////////////////////////////////////////////////////////////
%customfieldobj.portaltoshoot=!%customfieldobj.portaltoshoot;

}
}
