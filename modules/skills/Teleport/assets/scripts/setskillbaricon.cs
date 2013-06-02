function Teleport::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Teleport:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Teleport:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Teleport:image_bariconcdactive";
%barslot.guihandle.setAnimation("Teleport:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Teleport:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Teleport:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Teleport:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Teleport:anim_bariconcdinactive");
}
}
}
