function bitweb::xorinnergates(%this,%mousetile,%playertile)
{

////////////////////////////
%oldstate=%playertile.upgate.state;
%playertile.upgate.state^=%mousetile.upgate.state;
if (%playertile.upgate.state!=%oldstate)
{
if (%playertile.upgate.state)//open
{
%playertile.upgate.clearCollisionShapes();
%playertile.upgate.setCollisionSuppress(true);
%playertile.upgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playertile.upgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%playertile.upgate.localpoint.X,%playertile.upgate.localpoint.Y);
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
%playertile.downgate.clearCollisionShapes();
%playertile.downgate.setCollisionSuppress(true);
%playertile.downgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playertile.downgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%playertile.downgate.localpoint.X,%playertile.downgate.localpoint.Y);
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
%playertile.leftgate.clearCollisionShapes();
%playertile.leftgate.setCollisionSuppress(true);
%playertile.leftgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playertile.leftgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%playertile.leftgate.localpoint.X,%playertile.leftgate.localpoint.Y);
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
%playertile.rightgate.clearCollisionShapes();
%playertile.rightgate.setCollisionSuppress(true);
%playertile.rightgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playertile.rightgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%playertile.rightgate.localpoint.X,%playertile.rightgate.localpoint.Y);
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
%mousetile.upgate.clearCollisionShapes();
%mousetile.upgate.setCollisionSuppress(true);
%mousetile.upgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousetile.upgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%mousetile.upgate.localpoint.X,%mousetile.upgate.localpoint.Y);
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
%mousetile.downgate.clearCollisionShapes();
%mousetile.downgate.setCollisionSuppress(true);
%mousetile.downgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousetile.downgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%mousetile.downgate.localpoint.X,%mousetile.downgate.localpoint.Y);
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
%mousetile.leftgate.clearCollisionShapes();
%mousetile.leftgate.setCollisionSuppress(true);
%mousetile.leftgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousetile.leftgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%mousetile.leftgate.localpoint.X,%mousetile.leftgate.localpoint.Y);
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
%mousetile.rightgate.clearCollisionShapes();
%mousetile.rightgate.setCollisionSuppress(true);
%mousetile.rightgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousetile.rightgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%mousetile.rightgate.localpoint.X,%mousetile.rightgate.localpoint.Y);
%mousetile.rightgate.setCollisionSuppress(false);
%mousetile.rightgate.playAnimation("bitweb:anim_beam_close");
}
}
////////////////////////////

Audiere_Reset(%this.sound_gatemovement);
Audiere_Play(%this.sound_gatemovement,0,1.0);

}
