function class_portalprojectile::portalprojectiledecay(%this)
{
%customfieldobj=Portalgun.customplayerfields.getObject(%this.parentplayer);
%vecobj=0;

//create portals
if (!%this.portaltype)
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
Position=%this.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
GravityScale="0";
BodyType="static";
topos=%this.Position;
SceneGroup=27;//portals
class="class_portalgunportal";
parentplayer=%this.parentplayer;
CollisionCallback="true";
};

if (%this.curdir==0)
{
%customfieldobj.portalinobj.curdir=1;
}
else if (%this.curdir==1)
{
%customfieldobj.portalinobj.curdir=0;
}
else if (%this.curdir==2)
{
%customfieldobj.portalinobj.curdir=3;
}
else if (%this.curdir==3)
{
%customfieldobj.portalinobj.curdir=2;
}

%customfieldobj.portalinobj.setCollisionGroups(0,1,25,26,28,29);

DotsandCritsscene.add(%customfieldobj.portalinobj);

%customfieldobj.portalinobj.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));

%customfieldobj.portalinobj.playAnimation(%anim);

%customfieldobj.portalinobj.setAngle((%this.Angle+180)%360);

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
Position=%this.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
GravityScale="0";
BodyType="static";
topos=%this.Position;
SceneGroup=27;//portals
class="class_portalgunportal";
parentplayer=%this.parentplayer;
CollisionCallback="true";
};

if (%this.curdir==0)
{
%customfieldobj.portaloutobj.curdir=1;
}
else if (%this.curdir==1)
{
%customfieldobj.portaloutobj.curdir=0;
}
else if (%this.curdir==2)
{
%customfieldobj.portaloutobj.curdir=3;
}
else if (%this.curdir==3)
{
%customfieldobj.portaloutobj.curdir=2;
}

%customfieldobj.portaloutobj.setCollisionGroups(0,1,25,26,28,29);

DotsandCritsscene.add(%customfieldobj.portaloutobj);

%customfieldobj.portaloutobj.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));

%customfieldobj.portaloutobj.playAnimation(%anim);

%customfieldobj.portaloutobj.setAngle((%this.Angle+180)%360);

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

if (isObject(%this))
{
%this.cancelMoveTo();
%this.parenthandle.wavevectors.deleteObjects();
%this.parenthandle.wavevectors.delete();
cancel(%this.parenthandle.schedule_decay);
%parenthandle=%this.parenthandle;
%this.safeDelete();
%parenthandle.delete();
}
}
