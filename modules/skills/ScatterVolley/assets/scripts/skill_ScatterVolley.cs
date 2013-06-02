function ScatterVolley::skill_ScatterVolley(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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

%idobj=new SimObject()
{
spriteid=%spriteid;
rotates=true;
name="ScatterVolley";
centeroffset=0;
};
%player.mountedspriteids.add(%idobj);

%ass=0;
if ($view==0)
{
%ass=ScatterVolley.top_explosionass;
%player.sprite.setSpriteAnimation("ScatterVolley:anim_topdown_explosion");
}
else
{
%ass=ScatterVolley.side_explosionass;
%player.sprite.setSpriteAnimation("ScatterVolley:anim_sideview_explosion");
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
%ass=ScatterVolley.top_projectileass;
%img="ScatterVolley:image_topdown_ScatterVolley";
}
else
{
%ass=ScatterVolley.side_projectileass;
%img="ScatterVolley:image_sideview_ScatterVolley";
}

for (%x=0;%x<1;%x++)
{
////////////////////////////////////////////////////////////////////////////
//set this ScatterVolley's sprite
%ScatterVolleysprite=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
class="class_ScatterVolley";
parenthandle=0;
CollisionCallback="true";
SceneLayer=16;
GravityScale="0";
Bullet="true";
};

if (!%player.sprite.SceneGroup)//player 0 casted
{
%ScatterVolleysprite.SceneGroup=28;//player 0 ScatterVolleys
%ScatterVolleysprite.setCollisionGroups(1,25,26,29,30);//1=player 2, 29=player 2 ScatterVolleys, 30=walls, 26=world objects
}
else//player 2 casted
{
%ScatterVolleysprite.SceneGroup=29;//player 1 ScatterVolleys
%ScatterVolleysprite.setCollisionGroups(0,25,26,28,30);//0=player 1, 28=player 1 ScatterVolleys, 30=walls, 26=world objects
}

DotsandCritsscene.add(%ScatterVolleysprite);
%ScatterVolleysprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));
//////////////////////////////////////////////////////////////////////////////
//create vector list for this ScatterVolleys path
%wavevectors=new SimSet();

//%degree=0;
%dest="0 0";
%vecobj=0;

%spritesize=%player.sprite.getSpriteSize();

if (%player.curdir==0)//up
{
////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(0);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%ScatterVolleysprite.Position.X+=%origin.x;
%ScatterVolleysprite.Position.Y+=%origin.y;
///////////

//%ScatterVolleysprite.Position.Y+=%spritesize.Y/2;
//%degree=(270+(getRandom(0,6)*30))%360;

%vecobj=ScatterVolley.vectortable.getObject((270+(getRandom(0,6)*30))%360);
}
else if (%player.curdir==1)//down
{
////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(1);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%ScatterVolleysprite.Position.X+=%origin.x;
%ScatterVolleysprite.Position.Y+=%origin.y;
///////////

//%ScatterVolleysprite.Position.Y-=%spritesize.Y/2;
//%degree=90+(getRandom(0,6)*30);

%vecobj=ScatterVolley.vectortable.getObject(90+(getRandom(0,6)*30));
}
else if (%player.curdir==2)//left
{
////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(2);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%ScatterVolleysprite.Position.X+=%origin.x;
%ScatterVolleysprite.Position.Y+=%origin.y;
///////////

//%ScatterVolleysprite.Position.X-=%spritesize.X/2;
//%degree=0+(getRandom(0,6)*30);

%vecobj=ScatterVolley.vectortable.getObject(0+(getRandom(0,6)*30));
}
else if (%player.curdir==3)//right
{
////////////
//set position based on custom sprite projectile origins
%dirset=%player.projectileorigindirset.getObject(3);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%ScatterVolleysprite.Position.X+=%origin.x;
%ScatterVolleysprite.Position.Y+=%origin.y;
///////////

//%ScatterVolleysprite.Position.X+=%spritesize.X/2;
//%degree=180+(getRandom(0,6)*30);

%vecobj=ScatterVolley.vectortable.getObject(180+(getRandom(0,6)*30));
}
/*
%pos=ScaleCamVectorToRes(%ScatterVolleysprite.Position);
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
*/

%dest.X=%vecobj.x;
%dest.Y=%vecobj.y;

%dest.X+=%ScatterVolleysprite.Position.X;
%dest.Y+=%ScatterVolleysprite.Position.Y;
///////////////////////////////

//%dest=ScaleVectorToCam(%dest);
%vector=new SimObject()
{
x=%dest.X;
y=%dest.Y;
};
%wavevectors.add(%vector);

/////////////////////////////////////////////////////////////////////////////
//create ScatterVolley object that holds all the info and add it to the ScatterVolley list
%ScatterVolley=new SimObject()
{
//sprite (holds animation, position, collision shape, class)
sprite=%ScatterVolleysprite;
//list of points to move to
wavevectors=%wavevectors;
//index to above list
current_destination_vector=0;
//caster handle for collision detection
parenthandle=%player.sprite;
schedule_decay=0;
};
%ScatterVolley.sprite.parenthandle=%ScatterVolley;//needed cus onMoveToComplete() is for the sprite

//////////////////////////////////////////////
//start first moveTo()
%dest="0 0";
%dest.X=%ScatterVolley.wavevectors.getObject(%ScatterVolley.current_destination_vector).x;
%dest.Y=%ScatterVolley.wavevectors.getObject(%ScatterVolley.current_destination_vector).y;
%ScatterVolley.sprite.moveTo(%dest,10,0,0);

//////////////////////////////////////////////
//set projectile angle
%ScatterVolley.sprite.setAngle(Vector2AngleToPoint(%ScatterVolley.sprite.Position,%dest));
//////////////////////////////////////////////

%speed=10;
%time=((Vector2Distance(%ScatterVolley.sprite.Position,%dest)/%speed)*1000)+1000;
%ScatterVolley.schedule_decay=schedule(%time,0,"ScatterVolleydecay",%ScatterVolley.sprite);

/////////////////////////////////////////////////
}//end for
//////////////////
if (%iteration==0)
{
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
}
else if (%iteration>=8)
{
keycleanup(%user);
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

%iteration++;
%scheduleobject.schedulehandle=schedule(250,0,"ScatterVolley::skill_ScatterVolley",%this,%scheduleobject,%user,%iteration);
//////////////////
}
