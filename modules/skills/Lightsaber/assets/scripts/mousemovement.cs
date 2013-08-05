function class_Lightsaber::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}
%this.parentScriptObject.mouseprevpos=%worldPosition;
}

function class_Lightsaber::onTouchUp(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}
DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,false);
DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.elbowrevolutejoint,false);
}

function class_Lightsaber::onTouchDragged(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}

if (%this.parentScriptObject.dragiteration<3){%this.parentScriptObject.dragiteration++;return;}
else{%this.parentScriptObject.dragiteration=0;}

%xdist=mAbs(%this.parentScriptObject.mouseprevpos.X-%worldPosition.X);
%ydist=mAbs(%this.parentScriptObject.mouseprevpos.Y-%worldPosition.Y);

if (%xdist>%ydist)
{
DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.elbowrevolutejoint,false);

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
DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,false);

if (%worldPosition.Y<%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.elbowrevolutejoint,true,-1000,10000);

}
else if (%worldPosition.Y>%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.elbowrevolutejoint,true,1000,10000);

}

}

%this.parentScriptObject.mouseprevpos=%worldPosition;
}
