function class_goal::onCollision(%this,%object,%collisionDetails)
{

if (%this.parentbitweb.score>%this.parentbitweb.topscore)
{
%topscorefile=new FileObject();
%topscorefile.OpenForWrite("./../../../../topscore.txt");
%topscorefile.writeline(%this.parentbitweb.score);
%topscorefile.close();
%topscorefile.delete();
}

schedule(0,0,"gui_pausemenu::returntomainmenu");

}
