function Portalgun::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Portalgun:image_bariconreadyactive";
%slot.guihandle.setAnimation("Portalgun:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="Portalgun:image_bariconcdactive";
%slot.guihandle.setAnimation("Portalgun:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Portalgun:image_bariconreadyinactive";
%slot.guihandle.setAnimation("Portalgun:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="Portalgun:image_bariconcdinactive";
%slot.guihandle.setAnimation("Portalgun:anim_bariconcdinactive");
}
}
}
