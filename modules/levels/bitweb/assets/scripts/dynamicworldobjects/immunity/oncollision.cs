function class_immunity::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player")
{
cancel(%object.immunityfadeschedule);

%object.isimmune=true;
%this.Visible=false;

%object.immunityfadeschedule=schedule(20000,0,"class_immunity::fadeimmunity",%this,%object);

Audiere_Reset(%this.parentbitweb.sound_acquireimmunity);
Audiere_Play(%this.parentbitweb.sound_acquireimmunity,0,1.0);

}

}
