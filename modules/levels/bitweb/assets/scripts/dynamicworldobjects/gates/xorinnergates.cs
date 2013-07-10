function bitweb::xorinnergates(%this,%mousetile,%playertile)
{

////////////////////////////
%oldstate=%playertile.upgate.state;
%playertile.upgate.state^=%mousetile.upgate.state;
if (%playertile.upgate.state!=%oldstate)
{
if (%playertile.upgate.state)//open
{
%playertile.upgate.setCollisionSuppress(true);
%playertile.upgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playertile.upgate.setCollisionSuppress(false);
%playertile.upgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////
%oldstate=%playertile.downgate.state;
%playertile.downgate.state^=%mousetile.downgate.state;
if (%playertile.downgate.state!=%oldstate)
{
if (%playertile.downgate.state)//open
{
%playertile.downgate.setCollisionSuppress(true);
%playertile.downgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playertile.downgate.setCollisionSuppress(false);
%playertile.downgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////
%oldstate=%playertile.leftgate.state;
%playertile.leftgate.state^=%mousetile.leftgate.state;
if (%playertile.leftgate.state!=%oldstate)
{
if (%playertile.leftgate.state)//open
{
%playertile.leftgate.setCollisionSuppress(true);
%playertile.leftgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playertile.leftgate.setCollisionSuppress(false);
%playertile.leftgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////
%oldstate=%playertile.rightgate.state;
%playertile.rightgate.state^=%mousetile.rightgate.state;
if (%playertile.rightgate.state!=%oldstate)
{
if (%playertile.rightgate.state)//open
{
%playertile.rightgate.setCollisionSuppress(true);
%playertile.rightgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playertile.rightgate.setCollisionSuppress(false);
%playertile.rightgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////

%oldstate=%mousetile.upgate.state;
%mousetile.upgate.state^=%playertile.upgate.state;
if (%mousetile.upgate.state!=%oldstate)
{
if (%mousetile.upgate.state)//open
{
%mousetile.upgate.setCollisionSuppress(true);
%mousetile.upgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousetile.upgate.setCollisionSuppress(false);
%mousetile.upgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////
%oldstate=%mousetile.downgate.state;
%mousetile.downgate.state^=%playertile.downgate.state;
if (%mousetile.downgate.state!=%oldstate)
{
if (%mousetile.downgate.state)//open
{
%mousetile.downgate.setCollisionSuppress(true);
%mousetile.downgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousetile.downgate.setCollisionSuppress(false);
%mousetile.downgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////
%oldstate=%mousetile.leftgate.state;
%mousetile.leftgate.state^=%playertile.leftgate.state;
if (%mousetile.leftgate.state!=%oldstate)
{
if (%mousetile.leftgate.state)//open
{
%mousetile.leftgate.setCollisionSuppress(true);
%mousetile.leftgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousetile.leftgate.setCollisionSuppress(false);
%mousetile.leftgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////
%oldstate=%mousetile.rightgate.state;
%mousetile.rightgate.state^=%playertile.rightgate.state;
if (%mousetile.rightgate.state!=%oldstate)
{
if (%mousetile.rightgate.state)//open
{
%mousetile.rightgate.setCollisionSuppress(true);
%mousetile.rightgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousetile.rightgate.setCollisionSuppress(false);
%mousetile.rightgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////

Audiere_Reset(%this.sound_gatemovement);
Audiere_Play(%this.sound_gatemovement,0,1.0);

}
