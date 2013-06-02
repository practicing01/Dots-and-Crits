function Grab::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Grab:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Grab:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Grab:image_bariconcdactive";
%barslot.guihandle.setAnimation("Grab:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Grab:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Grab:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Grab:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Grab:anim_bariconcdinactive");
}
}
}
