function bitweb::moveinfected(%this)
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

for (%x=0;%x<%this.simset_infected.getCount();%x++)
{

%infected=%this.simset_infected.getObject(%x);

%xdist=mAbs(%infected.Position.X-%playertile.Position.X);
%ydist=mAbs(%infected.Position.Y-%playertile.Position.Y);

%objlist=DotsandCritsscene.pickPoint(
%infected.Position,
bit(4),"","oobb");

%infectedtile=0;

if (getWordCount(%objlist))
{
%infectedtile=getWord(%objlist,0);
}
else {return;}

////////////////////////////////////////////////

if (%xdist>%ydist)//move left/right
{

if (%infected.Position.X<%playertile.Position.X)
{

if (%infectedtile.rightgate.state)//open, check if right gate is open
{

%objlist=DotsandCritsscene.pickPoint(
%infected.Position.X+%offset.X SPC %infected.Position.Y,
bit(4),"","oobb");

%infectedrighttile=0;

if (getWordCount(%objlist))
{
%infectedrighttile=getWord(%objlist,0);
}else{return;}

if (%infectedrighttile.leftgate.state)//open, walk to the right
{

%infected.infectedmoveto(%infectedrighttile.Position);

}
else//closed, check if can open, if so walk to the right
{

for (%y=1;%y<%this.simset_gates.getCount();%y++)//start at one cus first tile doesn't have a tile to the left of it
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.leftgate.state)
{

%this.xoroutergates(%this.simset_gates.getObject(%y-1).Position,%infectedtile.Position);

//walk
%infected.infectedmoveto(%infectedrighttile.Position);

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

%this.xorinnergates(%potentialgate,%infectedtile);

break;
}

}

}

}
else if (%infected.Position.X>%playertile.Position.X)
{

if (%infectedtile.leftgate.state)//open, check if left gate is open
{

%objlist=DotsandCritsscene.pickPoint(
%infected.Position.X-%offset.X SPC %infected.Position.Y,
bit(4),"","oobb");

%infectedlefttile=0;

if (getWordCount(%objlist))
{
%infectedlefttile=getWord(%objlist,0);
}else{return;}

if (%infectedlefttile.rightgate.state)//open, walk to the left
{

%infected.infectedmoveto(%infectedlefttile.Position);

}
else//closed, check if can open, if so walk to the left
{

for (%y=0;%y<%this.simset_gates.getCount()-1;%y++)//-1 cus last tile doesn't have a tile to the right of it
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.rightgate.state)
{

%this.xoroutergates(%this.simset_gates.getObject(%y+1).Position,%infectedtile.Position);

//walk
%infected.infectedmoveto(%infectedlefttile.Position);

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

%this.xorinnergates(%potentialgate,%infectedtile);

break;
}

}

}

}

}
else//move up/down
{

if (%infected.Position.Y<%playertile.Position.Y)
{

if (%infectedtile.upgate.state)//open, check if up gate is open
{

%objlist=DotsandCritsscene.pickPoint(
%infected.Position.X SPC %infected.Position.Y+%offset.Y,
bit(4),"","oobb");

%infecteduptile=0;

if (getWordCount(%objlist))
{
%infecteduptile=getWord(%objlist,0);
}else{return;}

if (%infecteduptile.downgate.state)//open, walk up
{

%infected.infectedmoveto(%infecteduptile.Position);

}
else//closed, check if can open, if so walk up
{

for (%y=0;%y<%this.simset_gates.getCount()-25;%y++)//-25 cus last row doesn't have tiles on bottom of it
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.downgate.state)
{

%this.xoroutergates(%this.simset_gates.getObject(%y+25).Position,%infectedtile.Position);

//walk
%infected.infectedmoveto(%infecteduptile.Position);

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

%this.xorinnergates(%potentialgate,%infectedtile);

break;
}

}

}

}
else if (%infected.Position.Y>%playertile.Position.Y)
{

if (%infectedtile.downgate.state)//open, check if down gate is open
{

%objlist=DotsandCritsscene.pickPoint(
%infected.Position.X SPC %infected.Position.Y-%offset.Y,
bit(4),"","oobb");

%infecteddowntile=0;

if (getWordCount(%objlist))
{
%infecteddowntile=getWord(%objlist,0);
}else{return;}

if (%infecteddowntile.upgate.state)//open, walk down
{

%infected.infectedmoveto(%infecteddowntile.Position);

}
else//closed, check if can open, if so walk to the right
{

for (%y=25;%y<%this.simset_gates.getCount();%y++)//start at 25 cus the first row doesn't have tiles on top of it
{

%potentialgate=%this.simset_gates.getObject(%y);

if (%potentialgate.upgate.state)
{

%this.xoroutergates(%this.simset_gates.getObject(%y-25).Position,%infectedtile.Position);

//walk
%infected.infectedmoveto(%infecteddowntile.Position);

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

%this.xorinnergates(%potentialgate,%infectedtile);

break;
}

}

}

}

}

}

Audiere_Reset(%this.sound_infectedfootsteps);
Audiere_Play(%this.sound_infectedfootsteps,0,1.0);

%this.schedule_moveinfected.schedulehandle=schedule(5000,0,"bitweb::moveinfected",%this);
}
