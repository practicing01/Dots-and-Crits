function class_Lightsaber::joycallback(%this,%state,%cursorpos)
{
if (!%this.Active){return;}

if (%state.X==0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,false);

}

if (%state.Y==0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.elbowrevolutejoint,false);

}

if (%state.X!=0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.elbowrevolutejoint,false);

if (%cursorpos.X<%this.parentScriptObject.mouseprevpos.X)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,10000,100000);

}
else if (%cursorpos.X>%this.parentScriptObject.mouseprevpos.X)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,-10000,100000);

}

}

if (%state.Y!=0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,false);

if (%cursorpos.Y<%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.elbowrevolutejoint,true,-1000,10000);

}
else if (%cursorpos.Y>%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.elbowrevolutejoint,true,1000,10000);

}

}

%this.parentScriptObject.mouseprevpos=%cursorpos;

}
