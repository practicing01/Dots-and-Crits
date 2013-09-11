function class_bitweb_goal::onCollision(%this,%object,%collisionDetails)
{

if (%this.parentbitweb.score>%this.parentbitweb.topscore)
{
%topscorefile=new FileObject();
%topscorefile.OpenForWrite("./../../../../topscore.txt");
%topscorefile.writeline(%this.parentbitweb.score);
%topscorefile.close();
%topscorefile.delete();
}

//Audiere_Reset(%this.sound_reachgoal);
//Audiere_Play(%this.sound_reachgoal,0,1.0);

alxStop(%this.sound_reachgoal);
%this.sound_reachgoal=alxPlay("bitweb:audio_reachgoal");

schedule(1000,0,"gui_pausemenu::returntomainmenu");

}
