function portalprojectiledecay(%projectile)
{
%customfieldobj=Portalgun.customplayerfields.getObject(%projectile.parentplayer);
%vecobj=0;

//create portals
if (!%projectile.portaltype)
{

if (isObject(%customfieldobj.portalinobj))
{
%customfieldobj.portalinobj.safeDelete();
}

%ass=Portalgun.portalinass;
%img="Portalgun:image_portalin";
%anim="Portalgun:anim_portalin";

%customfieldobj.portalinobj=new Sprite()
{
Position=%projectile.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
GravityScale="0";
BodyType="static";
topos=%projectile.Position;
SceneGroup=27;//portals
class="class_portalgunportal";
parentplayer=%projectile.parentplayer;
CollisionCallback="true";
};

if (%projectile.curdir==0)
{
%customfieldobj.portalinobj.curdir=1;
}
else if (%projectile.curdir==1)
{
%customfieldobj.portalinobj.curdir=0;
}
else if (%projectile.curdir==2)
{
%customfieldobj.portalinobj.curdir=3;
}
else if (%projectile.curdir==3)
{
%customfieldobj.portalinobj.curdir=2;
}

%customfieldobj.portalinobj.setCollisionGroups(0,1,25,26,28,29);

DotsandCritsscene.add(%customfieldobj.portalinobj);

%customfieldobj.portalinobj.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));

%customfieldobj.portalinobj.playAnimation(%anim);

%customfieldobj.portalinobj.setAngle((%projectile.Angle+180)%360);

/*%vecobj=Portalgun.vectortable.getObject(%customfieldobj.portalinobj.Angle);

%customfieldobj.portalinobj.topos+=(%vecobj.x SPC %vecobj.y);*/

}
else
{

if (isObject(%customfieldobj.portaloutobj))
{
%customfieldobj.portaloutobj.safeDelete();
}

%ass=Portalgun.portaloutass;
%img="Portalgun:image_portalout";
%anim="Portalgun:anim_portalout";

%customfieldobj.portaloutobj=new Sprite()
{
Position=%projectile.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
GravityScale="0";
BodyType="static";
topos=%projectile.Position;
SceneGroup=27;//portals
class="class_portalgunportal";
parentplayer=%projectile.parentplayer;
CollisionCallback="true";
};

if (%projectile.curdir==0)
{
%customfieldobj.portaloutobj.curdir=1;
}
else if (%projectile.curdir==1)
{
%customfieldobj.portaloutobj.curdir=0;
}
else if (%projectile.curdir==2)
{
%customfieldobj.portaloutobj.curdir=3;
}
else if (%projectile.curdir==3)
{
%customfieldobj.portaloutobj.curdir=2;
}

%customfieldobj.portaloutobj.setCollisionGroups(0,1,25,26,28,29);

DotsandCritsscene.add(%customfieldobj.portaloutobj);

%customfieldobj.portaloutobj.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));

%customfieldobj.portaloutobj.playAnimation(%anim);

%customfieldobj.portaloutobj.setAngle((%projectile.Angle+180)%360);

/*%vecobj=Portalgun.vectortable.getObject(%customfieldobj.portaloutobj.Angle);

%customfieldobj.portaloutobj.topos+=(%vecobj.x SPC %vecobj.y);*/

}

if (isObject(%customfieldobj.portalinobj)&&isObject(%customfieldobj.portaloutobj))
{
%customfieldobj.portalinobj.topos=%customfieldobj.portaloutobj.Position;
%customfieldobj.portaloutobj.topos=%customfieldobj.portalinobj.Position;
/*
%vecobj=Portalgun.vectortable.getObject(%customfieldobj.portaloutobj.Angle);
%customfieldobj.portalinobj.topos.X+=%vecobj.x;
%customfieldobj.portalinobj.topos.Y+=%vecobj.y;

%vecobj=Portalgun.vectortable.getObject(%customfieldobj.portalinobj.Angle);
%customfieldobj.portaloutobj.topos.X+=%vecobj.x;
%customfieldobj.portaloutobj.topos.Y+=%vecobj.y;*/
}

if (isObject(%projectile))
{
%projectile.cancelMoveTo();
%projectile.parenthandle.wavevectors.deleteObjects();
%projectile.parenthandle.wavevectors.delete();
cancel(%projectile.parenthandle.schedule_decay);
%parenthandle=%projectile.parenthandle;
%projectile.safeDelete();
%parenthandle.delete();
}
}
