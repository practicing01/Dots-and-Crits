function ThrowKnife::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="ThrowKnife:image_bariconreadyactive";
%slot.guihandle.setAnimation("ThrowKnife:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="ThrowKnife:image_bariconcdactive";
%slot.guihandle.setAnimation("ThrowKnife:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="ThrowKnife:image_bariconreadyinactive";
%slot.guihandle.setAnimation("ThrowKnife:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="ThrowKnife:image_bariconcdinactive";
%slot.guihandle.setAnimation("ThrowKnife:anim_bariconcdinactive");
}
}
}
