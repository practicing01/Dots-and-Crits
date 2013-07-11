function class_bitwebmousecaptureobj::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{

%objlist=DotsandCritsscene.pickPoint(
%worldPosition,
bit(3),"","oobb");//3=tiles that hold the gates

%mousetile=0;

if (getWordCount(%objlist))
{
%mousetile=getWord(%objlist,0);
}
else {return;}

%player=$players.getObject(0);

%playertile=0;

%objlist=DotsandCritsscene.pickPoint(
%player.sprite.Position,
bit(3),"","oobb");

if (getWordCount(%objlist))
{
%playertile=getWord(%objlist,0);
}
else {return;}

%this.parentbitweb.xorinnergates(%mousetile,%playertile);

}

function class_bitwebmousecaptureobj::onRightMouseDown(%this,%touchID,%worldPosition,%mouseClicks)
{

%player=$players.getObject(0);

%this.parentbitweb.xoroutergates(%worldPosition,%player.sprite.Position);

}

function class_bitwebmousecaptureobj::onMiddleMouseDown(%this,%touchID,%worldPosition,%mouseClicks)
{

%player=$players.getObject(0);

//%this.parentbitweb.throwknife(%worldPosition,%player.sprite.Position);

}
