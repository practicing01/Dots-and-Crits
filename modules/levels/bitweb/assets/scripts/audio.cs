function bitweb::loadaudioass(%this)
{
/*
%this.sound_levelmusic=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_levelmusic,expandPath("./../audio/levelmusic.ogg"));

%this.sound_acquireammo=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_acquireammo,expandPath("./../audio/acquireammo.ogg"));

%this.sound_acquireimmunity=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_acquireimmunity,expandPath("./../audio/acquireimmunity.ogg"));

%this.sound_bitspiderdeath=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_bitspiderdeath,expandPath("./../audio/bitspiderdeath.ogg"));

%this.sound_bitspiderfootsteps=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_bitspiderfootsteps,expandPath("./../audio/bitspiderfootsteps.ogg"));

%this.sound_gatemovement=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_gatemovement,expandPath("./../audio/gatemovement.ogg"));

%this.sound_gunshot=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_gunshot,expandPath("./../audio/gunshot.ogg"));

%this.sound_infecteddeath=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_infecteddeath,expandPath("./../audio/infecteddeath.ogg"));

%this.sound_infectedfootsteps=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_infectedfootsteps,expandPath("./../audio/infectedfootsteps.ogg"));

%this.sound_playerdeath=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_playerdeath,expandPath("./../audio/playerdeath.ogg"));

%this.sound_playerfootsteps=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_playerfootsteps,expandPath("./../audio/playerfootsteps.ogg"));

%this.sound_reachgoal=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_reachgoal,expandPath("./../audio/reachgoal.ogg"));

%this.sound_rescuesurvivor=new audiere_soundhandle();
Audiere_OpenSound(%this.sound_rescuesurvivor,expandPath("./../audio/rescuesurvivor.ogg"));
*/

%this.sound_levelmusic=0;

%this.sound_acquireammo=0;

%this.sound_acquireimmunity=0;

%this.sound_bitspiderdeath=0;

%this.sound_bitspiderfootsteps=0;

%this.sound_gatemovement=0;

%this.sound_gunshot=0;

%this.sound_infecteddeath=0;

%this.sound_infectedfootsteps=0;

%this.sound_playerdeath=0;

%this.sound_playerfootsteps=0;

%this.sound_reachgoal=0;

%this.sound_rescuesurvivor=0;


}

function bitweb::unloadaudioass(%this)
{
/*
Audiere_Stop(%this.sound_levelmusic);
Audiere_Stop(%this.sound_acquireammo);
Audiere_Stop(%this.sound_acquireimmunity);
Audiere_Stop(%this.sound_bitspiderdeath);
Audiere_Stop(%this.sound_bitspiderfootsteps);
Audiere_Stop(%this.sound_gatemovement);
Audiere_Stop(%this.sound_gunshot);
Audiere_Stop(%this.sound_infecteddeath);
Audiere_Stop(%this.sound_infectedfootsteps);
Audiere_Stop(%this.sound_playerdeath);
Audiere_Stop(%this.sound_playerfootsteps);
Audiere_Stop(%this.sound_reachgoal);
Audiere_Stop(%this.sound_rescuesurvivor);
*/

/*alxStop(%this.sound_levelmusic);
alxStop(%this.sound_acquireammo);
alxStop(%this.sound_acquireimmunity);
alxStop(%this.sound_bitspiderdeath);
alxStop(%this.sound_bitspiderfootsteps);
alxStop(%this.sound_gatemovement);
alxStop(%this.sound_gunshot);
alxStop(%this.sound_infecteddeath);
alxStop(%this.sound_infectedfootsteps);
alxStop(%this.sound_playerdeath);
alxStop(%this.sound_playerfootsteps);
alxStop(%this.sound_reachgoal);
alxStop(%this.sound_rescuesurvivor);
*/
}
