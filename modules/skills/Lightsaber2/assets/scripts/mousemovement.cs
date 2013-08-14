function class_Lightsaber2::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}
%this.parentScriptObject.mouseprevpos=%worldPosition;
}

function class_Lightsaber2::onTouchUp(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}
DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,false);
}

function class_Lightsaber2::onTouchDragged(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}

if (%this.parentScriptObject.dragiteration<3){%this.parentScriptObject.dragiteration++;return;}
else{%this.parentScriptObject.dragiteration=0;}


%xdist=mAbs(%this.parentScriptObject.mouseprevpos.X-%worldPosition.X);
%ydist=mAbs(%this.parentScriptObject.mouseprevpos.Y-%worldPosition.Y);

if (%xdist>%ydist)
{

if (%worldPosition.X<%this.parentScriptObject.mouseprevpos.X)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,10000,100000);

}
else if (%worldPosition.X>%this.parentScriptObject.mouseprevpos.X)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,-10000,100000);

}

}
else
{

if (%worldPosition.Y>%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,10000,100000);

}
else if (%worldPosition.Y<%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,-10000,100000);

}

}

%this.parentScriptObject.mouseprevpos=%worldPosition;
}
