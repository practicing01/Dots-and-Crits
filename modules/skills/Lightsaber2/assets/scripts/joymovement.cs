function class_Lightsaber2::joycallback(%this,%state,%cursorpos)
{
if (!%this.Active){return;}

if (%this.parentScriptObject.dragiteration<3){%this.parentScriptObject.dragiteration++;return;}
else{%this.parentScriptObject.dragiteration=0;}

if (%state.X==0&&%state.Y==0)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,false);

}

if (%state.X!=0||%state.Y!=0)
{

%xdist=mAbs(%this.parentScriptObject.mouseprevpos.X-%cursorpos.X);
%ydist=mAbs(%this.parentScriptObject.mouseprevpos.Y-%cursorpos.Y);

//if (%xdist>%ydist)
//{

if ((%cursorpos.X<%this.parentScriptObject.mouseprevpos.X)||%cursorpos.Y<%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,10000,100000);

}
else if ((%cursorpos.X>%this.parentScriptObject.mouseprevpos.X)||%cursorpos.Y>%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,-10000,100000);

}

//}
//else
//{

/*if (%cursorpos.Y<%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,-1000,10000);

}
else if (%cursorpos.Y>%this.parentScriptObject.mouseprevpos.Y)
{

DotsandCritsscene.setRevoluteJointMotor(%this.parentScriptObject.shoulderrevolutejoint,true,1000,10000);

}
*/
//}

}

%this.parentScriptObject.mouseprevpos=%cursorpos;

}
