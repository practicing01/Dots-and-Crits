function class_portalgunportal::onCollision(%this,%object,%collisionDetails)
{
%object.Position=%this.topos;

%customfieldobj=Portalgun.customplayerfields.getObject(%this.parentplayer);

%toportal=0;

if (%this==%customfieldobj.portalinobj)
{
%toportal=%customfieldobj.portaloutobj;
}
else
{
%toportal=%customfieldobj.portalinobj;
}

if (%toportal.curdir==0)
{
%object.Position.Y+=(%object.Size.Y)+(%toportal.Size.Y);
}
else if (%toportal.curdir==1)
{
%object.Position.Y-=(%object.Size.Y)+(%toportal.Size.Y);
}
else if (%toportal.curdir==2)
{
%object.Position.X-=(%object.Size.X)+(%toportal.Size.X);
}
else if (%toportal.curdir==3)
{
%object.Position.X+=(%object.Size.X)+(%toportal.Size.X);
}

}
