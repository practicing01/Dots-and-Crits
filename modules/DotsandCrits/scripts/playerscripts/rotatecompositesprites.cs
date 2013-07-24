function rotatecompositesprites(%playerindex)
{
%player=$players.getObject(%playerindex);

%angle=0;

if (%player.curdir==0)
{
%angle=0;
}
else if (%player.curdir==1)
{
%angle=180;
}
else if (%player.curdir==2)
{
%angle=90;
}
else if (%player.curdir==3)
{
%angle=270;
}

for (%x=0;%x<%player.mountedspriteids.getCount();%x++)
{
%idobj=%player.mountedspriteids.getObject(%x);

if (%idobj.spriteid!=%player.spriteid&&%idobj.rotates)
{
%player.sprite.selectSpriteId(%idobj.spriteid);

%localposition="0 0";

%player.sprite.setSpriteFlipX(false);

if (%player.curdir==0)
{
%localposition.Y+=%idobj.centeroffset;
}
else if (%player.curdir==1)
{
%localposition.Y-=%idobj.centeroffset;
}
else if (%player.curdir==2)
{
%player.sprite.setSpriteFlipX(true);
%localposition.X-=%idobj.centeroffset;
}
else if (%player.curdir==3)
{
%localposition.X+=%idobj.centeroffset;
}

%player.sprite.setSpriteAngle(%angle);
%player.sprite.setSpriteLocalPosition(%localposition);
}

}

%player.sprite.selectSpriteId(%player.spriteid);
}
