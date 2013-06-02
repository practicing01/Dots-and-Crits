function Deathball::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Deathball:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Deathball:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Deathball:image_bariconcdactive";
%barslot.guihandle.setAnimation("Deathball:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Deathball:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Deathball:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Deathball:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Deathball:anim_bariconcdinactive");
}
}
}
