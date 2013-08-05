function Projectile::skill_Projectile(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
//////////////////
//create sprite for casting animation, it schedules a self-deletion
//the sprite doesn't have to attach to the character, it can be a regular sprite that stays at the casting spot
%spriteid=%player.sprite.addSprite();

%idobj=new ScriptObject()
{
spriteid=%spriteid;
rotates=true;
name="Projectile";
centeroffset=0;
};
%player.mountedspriteids.add(%idobj);

%ass=0;
if ($view==0)
{
%ass=Projectile.top_explosionass;
%player.sprite.setSpriteAnimation("Projectile:anim_topdown_explosion");
}
else
{
%ass=Projectile.side_explosionass;
%player.sprite.setSpriteAnimation("Projectile:anim_sideview_explosion");
}

%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%player.sprite.SetSpriteDepth(0);//in front of character
%player.sprite.setSpriteBlendAlpha(0.1);
%player.sprite.selectSpriteId(%player.spriteid);//important so anim-setting functions can work
schedule(1000,0,"removespritefromcomposite",%player,%spriteid);
rotatecompositesprites(%user);
//////////////////
%img=0;
if ($view==0)
{
%ass=Projectile.top_projectileass;
%img="Projectile:image_topdown_projectile";
}
else
{
%ass=Projectile.side_projectileass;
%img="Projectile:image_sideview_projectile";
}

for (%x=0;%x<1;%x++)
{
////////////////////////////////////////////////////////////////////////////
//set this projectile's sprite
%projectilesprite=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
class="class_projectile";
parenthandle=0;
CollisionCallback="true";
SceneLayer=16;
GravityScale="0";
Bullet="true";
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

//%projectilesprite.Position.Y+=%spritesize.Y/2;
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

//%projectilesprite.Position.Y-=%spritesize.Y/2;
%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X;
%dest.Y=%pos.Y-$resolution.Y;
}
else if (%player.curdir==2)//left
{
%projectilesprite.setAngle(270);

////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(2);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

//%projectilesprite.Position.X-=%spritesize.X/2;
%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X-$resolution.X;
%dest.Y=%pos.Y;
}
else if (%player.curdir==3)//right
{
%projectilesprite.setAngle(90);

////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(3);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%projectilesprite.Position.X+=%origin.x;
%projectilesprite.Position.Y+=%origin.y;
///////////

//%projectilesprite.Position.X+=%spritesize.X/2;
%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%dest.X=%pos.X+$resolution.X;
%dest.Y=%pos.Y;
}

///////////////////////////////

%dest=ScaleVectorToCam(%dest);
%vector=new ScriptObject()
{
x=%dest.X;
y=%dest.Y;
};
%wavevectors.add(%vector);

/////////////////////////////////////////////////////////////////////////////
//create projectile object that holds all the info and add it to the projectile list
%projectile=new ScriptObject()
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
%projectile.schedule_decay=schedule(%time,0,"class_projectile::projectiledecay",%projectile.sprite);

/////////////////////////////////////////////////
}//end for
//////////////////
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);

$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
//////////////////
}
