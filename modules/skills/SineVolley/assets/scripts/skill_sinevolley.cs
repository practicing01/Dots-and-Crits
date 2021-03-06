function SineVolley::skill_SineVolley(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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
name="SineVolley";
centeroffset=0;
};
%player.mountedspriteids.add(%idobj);

%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(SineVolley.explosionass));
%player.sprite.setSpriteAnimation("SineVolley:anim_explosion");
%player.sprite.SetSpriteDepth(0);//in front of character
%player.sprite.setSpriteBlendAlpha(0.1);
%player.sprite.selectSpriteId(%player.spriteid);//important so anim-setting functions can work
schedule(1000,0,"removespritefromcomposite",%player,%spriteid);
rotatecompositesprites(%user);
//////////////////
for (%x=0;%x<7;%x++)
{
////////////////////////////////////////////////////////////////////////////
//set this projectile's sprite
%projectilesprite=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(SineVolley.projectileass);
Image="SineVolley:image_projectile";
class="class_sinevolleyprojectile";
parenthandle=0;
SceneLayer=16;
CollisionCallback="true";
GravityScale="0";
Bullet="true";
};

if (!%player.sprite.SceneGroup)//player 0 casted
{
%projectilesprite.SceneGroup=28;//player 0 projectiles
%projectilesprite.setCollisionGroups(1,25,26,29,30);//1=player 2, 29=player 2 projectiles, 30=walls, 26=world objects
}
else//player 2 casted
{
%projectilesprite.SceneGroup=29;//player 1 projectiles
%projectilesprite.setCollisionGroups(0,25,26,28,30);//0=player 1, 28=player 1 projectiles, 30=walls, 26=world objects
}

DotsandCritsscene.add(%projectilesprite);
%projectilesprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(SineVolley.projectileass));
//////////////////////////////////////////////////////////////////////////////
//create vector list for this projectiles path
%wavevectors=new SimSet();

//code thanks to: Mario Klingemann: http://www.quasimondo.com/
//http://www.processing.org/discourse/alpha/board_Contributions_Beyond_action_display_num_1112719128.html

/*%freq=8;
%amp=30;
%phase=0;*/

///////////////////////////////
//code for rotating a vector around another vector thanks to:
//Richard Marks: http://ccpssolutions.com/nogdusforums/index.php?topic=666.0

//%degree=0;
%dest="0 0";
%vecsetobj=0;

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
//%degree=(270+(%x*30))%360;

%vecsetobj=SineVolley.vectortable.getObject((270+(%x*30))%360);
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
//%degree=90+(%x*30);

%vecsetobj=SineVolley.vectortable.getObject(90+(%x*30));
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
//%degree=0+(%x*30);

%vecsetobj=SineVolley.vectortable.getObject(0+(%x*30));
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
//%degree=180+(%x*30);

%vecsetobj=SineVolley.vectortable.getObject(180+(%x*30));
}

/*%pos=ScaleCamVectorToRes(%projectilesprite.Position);
%cx=%pos.X;
%cy=%pos.Y;

%c=mCos(mDegToRad(%degree));
%s=mSin(mDegToRad(%degree));

%dest="0 0";
%dest.X=%pos.X;
%dest.Y=%pos.Y+$resolution.Y;

%dest.X-=%pos.X;
%dest.Y-=%pos.Y;
%xval=%dest.X*%c-%dest.Y*%s;
%yval=%dest.X*%s+%dest.Y*%c;
%dest.X=%xval+%pos.X;
%dest.Y=%yval+%pos.Y;


///////////////////////////////
%dx=%dest.X-%cx;
%dy=%dest.Y-%cy;
%l=mSqrt(%dx*%dx+%dy*%dy);

%nx=%amp*%dy/%l;
%ny=%amp*-%dx/%l;

%tstep=1.0/(%l/35);//dividing by a lower number makes smoother sinoids, higher faster

for (%t=0;%t<=1.0;%t+=%tstep)
{
%a=mSin(%phase+(2*$pie)*%t*%freq);
%xval=%cx+%t*%dx+%nx*%a;
%yval=%cy+%t*%dy+%ny*%a;
%tmpvec="0 0";%tmpvec.X=%xval;%tmpvec.Y=%yval;
%tmpvec=ScaleVectorToCam(%tmpvec);
%vector=new ScriptObject()
{
x=%tmpvec.X;
y=%tmpvec.Y;
};
%wavevectors.add(%vector);
}*/

for (%y=0;%y<%vecsetobj.getCount();%y++)
{

%vecobj=%vecsetobj.getObject(%y);

%dest.X=%vecobj.x;
%dest.Y=%vecobj.y;

%dest.X+=%projectilesprite.Position.X;
%dest.Y+=%projectilesprite.Position.Y;

%vector=new ScriptObject()
{
x=%dest.X;
y=%dest.Y;
};
%wavevectors.add(%vector);

}
/////////////////////////////////////////////////////////////////////////////
//create projectile object that holds all the info and add it to the projectile list
%projectile=new ScriptObject()
{
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
%projectile.sprite.moveTo(%dest,10,1,1);

%speed=10;
%time=((Vector2Distance(%projectile.sprite.Position,%dest)/%speed)*1000)+1000;
%projectile.schedule_decay=schedule(%time,0,"class_sinevolleyprojectile::sinevolleydecay",%projectile.sprite);

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
