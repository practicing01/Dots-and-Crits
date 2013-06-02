function Projectile::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Projectile:image_bariconreadyactive";
%slot.guihandle.setAnimation("Projectile:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="Projectile:image_bariconcdactive";
%slot.guihandle.setAnimation("Projectile:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Projectile:image_bariconreadyinactive";
%slot.guihandle.setAnimation("Projectile:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="Projectile:image_bariconcdinactive";
%slot.guihandle.setAnimation("Projectile:anim_bariconcdinactive");
}
}
}
