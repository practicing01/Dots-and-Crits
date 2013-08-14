function Lightsaber2::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Lightsaber2:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Lightsaber2:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Lightsaber2:image_bariconcdactive";
%barslot.guihandle.setAnimation("Lightsaber2:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Lightsaber2:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Lightsaber2:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Lightsaber2:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Lightsaber2:anim_bariconcdinactive");
}
}
}
