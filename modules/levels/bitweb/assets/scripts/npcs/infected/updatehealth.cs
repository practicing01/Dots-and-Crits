function class_infected::updatehealth(%this)
{

/*Audiere_Reset(%this.parentbitweb.sound_infecteddeath);
Audiere_Play(%this.parentbitweb.sound_infecteddeath,0,1.0);
*/

alxStop(%this.parentbitweb.sound_infecteddeath);
%this.parentbitweb.sound_infecteddeath=alxPlay("bitweb:audio_infecteddeath");

%this.parentbitweb.score++;
gui_text_player2score.setText("Score: "@%this.parentbitweb.score);

%this.parentbitweb.simset_infected.remove(%this);
%this.safeDelete();

}
