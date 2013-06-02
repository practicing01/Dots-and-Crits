function Cloak::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Cloak:image_bariconreadyactive";
%slot.guihandle.setAnimation("Cloak:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="Cloak:image_bariconcdactive";
%slot.guihandle.setAnimation("Cloak:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Cloak:image_bariconreadyinactive";
%slot.guihandle.setAnimation("Cloak:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="Cloak:image_bariconcdinactive";
%slot.guihandle.setAnimation("Cloak:anim_bariconcdinactive");
}
}
}
