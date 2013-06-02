function Melee::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Melee:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Melee:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Melee:image_bariconcdactive";
%barslot.guihandle.setAnimation("Melee:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Melee:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Melee:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Melee:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Melee:anim_bariconcdinactive");
}
}
}
