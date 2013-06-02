function removespritefromcomposite(%player,%sprite)
{
if (isObject(%player.sprite))
{
if (%player.sprite.selectSpriteId(%sprite))
{
%player.sprite.removeSprite();
%player.sprite.selectSpriteId(%player.spriteid);//reselect character sprite
}

for (%x=0;%x<%player.mountedspriteids.getCount();%x++)
{
%idobj=%player.mountedspriteids.getObject(%x);
if (%idobj.spriteid==%sprite)
{
%player.mountedspriteids.remove(%idobj);
break;
}
}
}
}
