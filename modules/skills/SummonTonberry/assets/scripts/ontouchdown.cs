function class_tonberry::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{

//echo(%this@" tonberry touchdown");

%this.curmousepos=%worldPosition;

movebutt(%this,1);
followbutt(%this,1);
snarebutt(%this,1);
shankbutt(%this,1);

}

///////////////////////////////////////////////////////////////

function class_tonberry::joycallback(%this,%state,%cursorpos)
{
return;
}

///////////////////////////////////////////////////////////////

//joystick click
function class_tonberry::stickclick(%this,%state,%cursorpos)
{
if (%state)
{

//echo(%this@" tonberry stickclick");

%this.curmousepos=%cursorpos;

movebutt(%this,1);
followbutt(%this,1);
snarebutt(%this,1);
shankbutt(%this,1);

}

}
