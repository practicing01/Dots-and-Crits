function Speedboof::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Speedboof:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Speedboof:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Speedboof:image_bariconcdactive";
%barslot.guihandle.setAnimation("Speedboof:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Speedboof:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Speedboof:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Speedboof:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Speedboof:anim_bariconcdinactive");
}
}
}
