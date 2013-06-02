function Snare::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Snare:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Snare:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Snare:image_bariconcdactive";
%barslot.guihandle.setAnimation("Snare:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Snare:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Snare:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Snare:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Snare:anim_bariconcdinactive");
}
}
}
