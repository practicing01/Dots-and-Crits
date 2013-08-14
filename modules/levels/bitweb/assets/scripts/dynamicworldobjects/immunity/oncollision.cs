function class_immunity::onCollision(%this,%object,%collisionDetails)
{

if (%object.class$="class_player"&&!%this.used)
{
cancel(%object.immunityfadeschedule);

%object.isimmune=true;
%this.Visible=false;
%this.used=true;
//%this.clearCollisionShapes();//all horribly fucking bugged, went for the "used" variable instead
//%this.setCollisionSuppress(true);

%object.immunityfadeschedule=schedule(20000,0,"class_immunity::fadeimmunity",%this,%object);

/*
Audiere_Reset(%this.parentbitweb.sound_acquireimmunity);
Audiere_Play(%this.parentbitweb.sound_acquireimmunity,0,1.0);
*/

alxStop(%this.parentbitweb.sound_acquireimmunity);
%this.parentbitweb.sound_acquireimmunity=alxPlay("bitweb:audio_acquireimmunity");

//schedule(0,0,"class_immunity::clearcolshapes",%this);
}

}
