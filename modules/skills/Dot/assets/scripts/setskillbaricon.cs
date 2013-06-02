function Dot::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Dot:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Dot:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Dot:image_bariconcdactive";
%barslot.guihandle.setAnimation("Dot:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Dot:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Dot:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Dot:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Dot:anim_bariconcdinactive");
}
}
}
