function Flashlight::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Flashlight:image_bariconreadyactive";
%slot.guihandle.setAnimation("Flashlight:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="Flashlight:image_bariconcdactive";
%slot.guihandle.setAnimation("Flashlight:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Flashlight:image_bariconreadyinactive";
%slot.guihandle.setAnimation("Flashlight:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="Flashlight:image_bariconcdinactive";
%slot.guihandle.setAnimation("Flashlight:anim_bariconcdinactive");
}
}
}
