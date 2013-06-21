function class_Lightsaber::joycallback(%this,%state,%cursorpos)
{
if (!%this.Active){return;}

if (%state.X==0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.shoulderrevolutejoint,false);

}

if (%state.Y==0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.elbowrevolutejoint,false);

}

if (%state.X!=0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.elbowrevolutejoint,false);

if (%cursorpos.X<%this.parentsimobject.mouseprevpos.X)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.shoulderrevolutejoint,true,10000,100000);

}
else if (%cursorpos.X>%this.parentsimobject.mouseprevpos.X)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.shoulderrevolutejoint,true,-10000,100000);

}

}

if (%state.Y!=0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.shoulderrevolutejoint,false);

if (%cursorpos.Y<%this.parentsimobject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.elbowrevolutejoint,true,-1000,10000);

}
else if (%cursorpos.Y>%this.parentsimobject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentsimobject.elbowrevolutejoint,true,1000,10000);

}

}

%this.parentsimobject.mouseprevpos=%cursorpos;

}
