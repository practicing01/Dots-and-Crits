function bitweb::movespiders(%this)
{
%player1=$players.getObject(0);

%objlist=DotsandCritsscene.pickPoint(
%player1.sprite.Position,
bit(4),"","oobb");

%playertile=0;

if (getWordCount(%objlist))
{
%playertile=getWord(%objlist,0);
}
else {return;}

%offset=ScaleVectorToCam("50 50");

for (%x=0;%x<%this.simset_spiders.getCount();%x++)
{

%spider=%this.simset_spiders.getObject(%x);

%xdist=mAbs(%spider.Position.X-%playertile.Position.X);
%ydist=mAbs(%spider.Position.Y-%playertile.Position.Y);

%objlist=DotsandCritsscene.pickPoint(
%spider.Position,
bit(4),"","oobb");

%spidertile=0;

if (getWordCount(%objlist))
{
%spidertile=getWord(%objlist,0);
}
else {return;}

////////////////////////////////////////////////

if (%xdist>%ydist)//move left/right
{

if (%spider.Position.X<%playertile.Position.X)
{

if (%spidertile.rightgate.state)//open, check if right gate is open
{

%objlist=DotsandCritsscene.pickPoint(
%spider.Position.X+%offset.X SPC %spider.Position.Y,
bit(4),"","oobb");

%spiderrighttile=0;

if (getWordCount(%objlist))
{
%spiderrighttile=getWord(%objlist,0);
}else{return;}

if (%spiderrighttile.leftgate.state)//open, walk to the right
{

%spider.spidermoveto(%spiderrighttile.Position);

}
else//closed, check if can open, if so walk to the right
{

for (%y=1;%y<%this.simset_gates.getCount();%y++)//start at one cus first tile doesn't have a tile to the left of it
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.leftgate.state)
{

%this.xoroutergates(%this.simset_gates.getObject(%y-1).Position,%spidertile.Position);

//walk
%spider.spidermoveto(%spiderrighttile.Position);

break;
}

}

}

}
else//closed, open it
{

for (%y=0;%y<%this.simset_gates.getCount();%y++)
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.rightgate.state)
{

%this.xorinnergates(%potentialgate,%spidertile);

break;
}

}

}

}
else if (%spider.Position.X>%playertile.Position.X)
{

if (%spidertile.leftgate.state)//open, check if left gate is open
{

%objlist=DotsandCritsscene.pickPoint(
%spider.Position.X-%offset.X SPC %spider.Position.Y,
bit(4),"","oobb");

%spiderlefttile=0;

if (getWordCount(%objlist))
{
%spiderlefttile=getWord(%objlist,0);
}else{return;}

if (%spiderlefttile.rightgate.state)//open, walk to the left
{

%spider.spidermoveto(%spiderlefttile.Position);

}
else//closed, check if can open, if so walk to the left
{

for (%y=0;%y<%this.simset_gates.getCount()-1;%y++)//-1 cus last tile doesn't have a tile to the right of it
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.rightgate.state)
{

%this.xoroutergates(%this.simset_gates.getObject(%y+1).Position,%spidertile.Position);

//walk
%spider.spidermoveto(%spiderlefttile.Position);

break;
}

}

}

}
else//closed, open it
{

for (%y=0;%y<%this.simset_gates.getCount();%y++)
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.leftgate.state)
{

%this.xorinnergates(%potentialgate,%spidertile);

break;
}

}

}

}

}
else//move up/down
{

if (%spider.Position.Y<%playertile.Position.Y)
{

if (%spidertile.upgate.state)//open, check if up gate is open
{

%objlist=DotsandCritsscene.pickPoint(
%spider.Position.X SPC %spider.Position.Y+%offset.Y,
bit(4),"","oobb");

%spideruptile=0;

if (getWordCount(%objlist))
{
%spideruptile=getWord(%objlist,0);
}else{return;}

if (%spideruptile.downgate.state)//open, walk up
{

%spider.spidermoveto(%spideruptile.Position);

}
else//closed, check if can open, if so walk up
{

for (%y=0;%y<%this.simset_gates.getCount()-25;%y++)//-25 cus last row doesn't have tiles on bottom of it
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.downgate.state)
{

%this.xoroutergates(%this.simset_gates.getObject(%y+25).Position,%spidertile.Position);

//walk
%spider.spidermoveto(%spideruptile.Position);

break;
}

}

}

}
else//closed, open it
{

for (%y=0;%y<%this.simset_gates.getCount();%y++)
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.upgate.state)
{

%this.xorinnergates(%potentialgate,%spidertile);

break;
}

}

}

}
else if (%spider.Position.Y>%playertile.Position.Y)
{

if (%spidertile.downgate.state)//open, check if down gate is open
{

%objlist=DotsandCritsscene.pickPoint(
%spider.Position.X SPC %spider.Position.Y-%offset.Y,
bit(4),"","oobb");

%spiderdowntile=0;

if (getWordCount(%objlist))
{
%spiderdowntile=getWord(%objlist,0);
}else{return;}

if (%spiderdowntile.upgate.state)//open, walk down
{

%spider.spidermoveto(%spiderdowntile.Position);

}
else//closed, check if can open, if so walk to the right
{

for (%y=25;%y<%this.simset_gates.getCount();%y++)//start at 25 cus the first row doesn't have tiles on top of it
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.upgate.state)
{

%this.xoroutergates(%this.simset_gates.getObject(%y-25).Position,%spidertile.Position);

//walk
%spider.spidermoveto(%spiderdowntile.Position);

break;
}

}

}

}
else//closed, open it
{

for (%y=0;%y<%this.simset_gates.getCount();%y++)
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.downgate.state)
{

%this.xorinnergates(%potentialgate,%spidertile);

break;
}

}

}

}

}

}

Audiere_Reset(%this.sound_bitspiderfootsteps);
Audiere_Play(%this.sound_bitspiderfootsteps,0,1.0);

%this.schedule_movespiders.schedulehandle=schedule(5000,0,"bitweb::movespiders",%this);
}
