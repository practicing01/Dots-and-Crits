function bitweb::xoroutergates(%this,%mousepos,%playerpos)
{

%mouseuptile=0;
%mousedowntile=0;
%mouselefttile=0;
%mouserighttile=0;

%offset=ScaleVectorToCam("50 50");
/////////////////////////////

%objlist=DotsandCritsscene.pickPoint(
%mousepos.X SPC %mousepos.Y+%offset.Y,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%mouseuptile=getWord(%objlist,0);
}

/////////////////////////////

%objlist=DotsandCritsscene.pickPoint(
%mousepos.X SPC %mousepos.Y-%offset.Y,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%mousedowntile=getWord(%objlist,0);
}

/////////////////////////////

%objlist=DotsandCritsscene.pickPoint(
%mousepos.X-%offset.X SPC %mousepos.Y,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%mouselefttile=getWord(%objlist,0);
}

//////////////////////////////

%objlist=DotsandCritsscene.pickPoint(
%mousepos.X+%offset.X SPC %mousepos.Y,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%mouserighttile=getWord(%objlist,0);
}

//////////////////////////////

%playeruptile=0;
%playerdowntile=0;
%playerlefttile=0;
%playerrighttile=0;

%objlist=DotsandCritsscene.pickPoint(
%playerpos.X SPC %playerpos.Y+%offset.Y,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%playeruptile=getWord(%objlist,0);
}

/////////////////////////////

%objlist=DotsandCritsscene.pickPoint(
%playerpos.X SPC %playerpos.Y-%offset.Y,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%playerdowntile=getWord(%objlist,0);
}

/////////////////////////////

%objlist=DotsandCritsscene.pickPoint(
%playerpos.X-%offset.X SPC %playerpos.Y,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%playerlefttile=getWord(%objlist,0);
}

//////////////////////////////

%objlist=DotsandCritsscene.pickPoint(
%playerpos.X+%offset.X SPC %playerpos.Y,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%playerrighttile=getWord(%objlist,0);
}

//////////////////////////////

if (%mouseuptile&&%playeruptile)
{

%oldstate=%playeruptile.downgate.state;
%playeruptile.downgate.state^=%mouseuptile.downgate.state;
if (%playeruptile.downgate.state!=%oldstate)
{
if (%playeruptile.downgate.state)//open
{
%playeruptile.downgate.setCollisionSuppress(true);
%playeruptile.downgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playeruptile.downgate.setCollisionSuppress(false);
%playeruptile.downgate.playAnimation("bitweb:anim_beam_close");
}
}

%oldstate=%mouseuptile.downgate.state;
%mouseuptile.downgate.state^=%playeruptile.downgate.state;
if (%mouseuptile.downgate.state!=%oldstate)
{
if (%mouseuptile.downgate.state)//open
{
%mouseuptile.downgate.setCollisionSuppress(true);
%mouseuptile.downgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mouseuptile.downgate.setCollisionSuppress(false);
%mouseuptile.downgate.playAnimation("bitweb:anim_beam_close");
}
}

}

//////////////////////////////

if (%mousedowntile&&%playerdowntile)
{

%oldstate=%playerdowntile.upgate.state;
%playerdowntile.upgate.state^=%mousedowntile.upgate.state;
if (%playerdowntile.upgate.state!=%oldstate)
{
if (%playerdowntile.upgate.state)//open
{
%playerdowntile.upgate.setCollisionSuppress(true);
%playerdowntile.upgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playerdowntile.upgate.setCollisionSuppress(false);
%playerdowntile.upgate.playAnimation("bitweb:anim_beam_close");
}
}

%oldstate=%mousedowntile.upgate.state;
%mousedowntile.upgate.state^=%playerdowntile.upgate.state;
if (%mousedowntile.upgate.state!=%oldstate)
{
if (%mousedowntile.upgate.state)//open
{
%mousedowntile.upgate.setCollisionSuppress(true);
%mousedowntile.upgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mousedowntile.upgate.setCollisionSuppress(false);
%mousedowntile.upgate.playAnimation("bitweb:anim_beam_close");
}
}

}

//////////////////////////////

if (%mouselefttile&&%playerlefttile)
{

%oldstate=%playerlefttile.rightgate.state;
%playerlefttile.rightgate.state^=%mouselefttile.rightgate.state;
if (%playerlefttile.rightgate.state!=%oldstate)
{
if (%playerlefttile.rightgate.state)//open
{
%playerlefttile.rightgate.setCollisionSuppress(true);
%playerlefttile.rightgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playerlefttile.rightgate.setCollisionSuppress(false);
%playerlefttile.rightgate.playAnimation("bitweb:anim_beam_close");
}
}

%oldstate=%mouselefttile.rightgate.state;
%mouselefttile.rightgate.state^=%playerlefttile.rightgate.state;
if (%mouselefttile.rightgate.state!=%oldstate)
{
if (%mouselefttile.rightgate.state)//open
{
%mouselefttile.rightgate.setCollisionSuppress(true);
%mouselefttile.rightgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mouselefttile.rightgate.setCollisionSuppress(false);
%mouselefttile.rightgate.playAnimation("bitweb:anim_beam_close");
}
}

}

//////////////////////////////

if (%mouserighttile&&%playerrighttile)
{

%oldstate=%playerrighttile.leftgate.state;
%playerrighttile.leftgate.state^=%mouserighttile.leftgate.state;
if (%playerrighttile.leftgate.state!=%oldstate)
{
if (%playerrighttile.leftgate.state)//open
{
%playerrighttile.leftgate.setCollisionSuppress(true);
%playerrighttile.leftgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%playerrighttile.leftgate.setCollisionSuppress(false);
%playerrighttile.leftgate.playAnimation("bitweb:anim_beam_close");
}
}

%oldstate=%mouserighttile.leftgate.state;
%mouserighttile.leftgate.state^=%playerrighttile.leftgate.state;
if (%mouserighttile.leftgate.state!=%oldstate)
{
if (%mouserighttile.leftgate.state)//open
{
%mouserighttile.leftgate.setCollisionSuppress(true);
%mouserighttile.leftgate.playAnimation("bitweb:anim_beam_open");
}
else
{
%mouserighttile.leftgate.setCollisionSuppress(false);
%mouserighttile.leftgate.playAnimation("bitweb:anim_beam_close");
}
}

}

//////////////////////////////

Audiere_Reset(%this.sound_gatemovement);
Audiere_Play(%this.sound_gatemovement,0,1.0);

}
