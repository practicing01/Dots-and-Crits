function class_survivor::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player"&&!%this.used)
{

%this.parentbitweb.score++;
gui_text_player2score.setText("Score: "@%this.parentbitweb.score);

%this.Visible=false;
%this.used=true;
//%this.clearCollisionShapes();
//%this.setCollisionSuppress(true);

Audiere_Reset(%this.parentbitweb.sound_rescuesurvivor);
Audiere_Play(%this.parentbitweb.sound_rescuesurvivor,0,1.0);

//schedule(0,0,"class_survivor::clearcolshapes",%this);
}
else if ((%object.class$="class_bitspider"||%object.class$="class_infected")&&!%this.used)
{

Audiere_Reset(%this.parentbitweb.sound_playerdeath);
Audiere_Play(%this.parentbitweb.sound_playerdeath,0,1.0);

%this.Visible=false;
%this.used=true;
//%this.clearCollisionShapes();
//%this.setCollisionSuppress(true);

//schedule(0,0,"class_survivor::clearcolshapes",%this);

%this.parentbitweb.spawninfected(%this.Position);

}

}
