function class_DeusExTelum_Radar::rotate_radar(%this)
{

if (!isObject(%this)){return;}

%player=$players.getObject(0);

%xdist=mAbs(%this.parentmodule.handle_goal.Position.X-%player.sprite.Position.X);
%ydist=mAbs(%this.parentmodule.handle_goal.Position.Y-%player.sprite.Position.Y);

if (%xdist>%ydist)
{

if (%this.parentmodule.handle_goal.Position.X<%player.sprite.Position.X)
{

//%this.setImageFrame(1);//bugged!

%this.Frame=1;

}
else
{

//%this.setImageFrame(0);

%this.Frame=0;

}

}
else
{

if (%this.parentmodule.handle_goal.Position.Y<%player.sprite.Position.Y)
{

//%this.setImageFrame(3);

%this.Frame=2;

}
else
{

//%this.setImageFrame(2);

%this.Frame=3;

}

}

schedule(5000,0,"class_DeusExTelum_Radar::rotate_radar",%this);

}
