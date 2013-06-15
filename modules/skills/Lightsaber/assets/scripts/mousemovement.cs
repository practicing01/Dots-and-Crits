function class_Lightsaber::onTouchDown(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}
%this.parentsimobject.mouseprevpos=%worldPosition;
}

function class_Lightsaber::onTouchUp(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}
DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.shoulderrevolutejoint,false);
DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.elbowrevolutejoint,false);
}

function class_Lightsaber::onTouchDragged(%this,%touchID,%worldPosition,%mouseClicks)
{
if (!%this.Active){return;}

if (%this.parentsimobject.dragiteration<3){%this.parentsimobject.dragiteration++;return;}
else{%this.parentsimobject.dragiteration=0;}

%xdist=mAbs(%this.parentsimobject.mouseprevpos.X-%worldPosition.X);
%ydist=mAbs(%this.parentsimobject.mouseprevpos.Y-%worldPosition.Y);

if (%xdist>%ydist)
{
DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.elbowrevolutejoint,false);

if (%worldPosition.X<%this.parentsimobject.mouseprevpos.X)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.shoulderrevolutejoint,true,10000,100000);

}
else if (%worldPosition.X>%this.parentsimobject.mouseprevpos.X)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.shoulderrevolutejoint,true,-10000,100000);

}

}
else
{
DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.shoulderrevolutejoint,false);

if (%worldPosition.Y<%this.parentsimobject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.elbowrevolutejoint,true,-1000,10000);

}
else if (%worldPosition.Y>%this.parentsimobject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.elbowrevolutejoint,true,1000,10000);

}

}

%this.parentsimobject.mouseprevpos=%worldPosition;
}
